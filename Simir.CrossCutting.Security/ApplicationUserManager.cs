using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Simir.Domain.Entities;
using Simir.Infra.Data.Context;
using Simir.ServiceAgent.Email;

namespace Simir.CrossCutting.Security
{
    public class ApplicationUserManager : UserManager<AspNetUser>
    {
        public ApplicationUserManager(IUserStore<AspNetUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<AspNetUser>(context.Get<SimirContext>()));

            // Configurando validator para nome de usuario
            manager.UserValidator = new UserValidator<AspNetUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Logica de validação e complexidade de senha
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6
            };
            // Configuração de Lockout
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Registrando os providers para Two Factor.
            /*
            manager.RegisterTwoFactorProvider("Código via SMS", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Seu código de segurança é: {0}"
            });
             */


            //*
            manager.RegisterTwoFactorProvider("Código via E-mail", new EmailTokenProvider<AspNetUser>
            {
                Subject = "Código de Segurança",
                BodyFormat = "Seu código de segurança é: {0}"
            });

            // Definindo a classe de serviço de e-mail
            manager.EmailService = new EmailService();
            //*/

            // Definindo a classe de serviço de SMS
            //manager.SmsService = new SmsService();

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<AspNetUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

        // Metodo para login async que guarda os dados Client conectado
        public async Task<IdentityResult> SignInClientAsync(AspNetUser user, string clientKey)
        {
            if (string.IsNullOrEmpty(clientKey))
            {
                throw new ArgumentNullException("clientKey");
            }

            var client = user.Clients.SingleOrDefault(c => c.ClientKey == clientKey);
            if (client == null)
            {
                /* 
                var funcao = user.Funcoes.FirstOrDefault();
                var funcaoNome = funcao == null ? "" : funcao.Nome;
                client = new AspNetClient() { ClientKey = clientKey, FuncaoSelecionada = funcaoNome };
                /* */
                client = new AspNetClient {ClientKey = clientKey, FuncaoSelecionada = "geral"};
                user.Clients.Add(client);
            }

            var result = await UpdateAsync(user);
            user.CurrentClientId = client.Id.ToString();
            return result;
        }

        // Metodo para login async que remove os dados Client conectado
        public async Task<IdentityResult> SignOutClientAsync(AspNetUser user, string clientKey)
        {
            if (string.IsNullOrEmpty(clientKey))
            {
                throw new ArgumentNullException("clientKey");
            }

            var client = user.Clients.SingleOrDefault(c => c.ClientKey == clientKey);
            if (client != null)
            {
                user.Clients.Remove(client);
            }

            user.CurrentClientId = null;
            return await UpdateAsync(user);
        }

        public async Task AddToRoleByEmail(string p1, string p2)
        {
            var user = await FindByEmailAsync(p1);
            this.AddToRole(user.Id, p2);
        }

        public async Task<IdentityResult> TrocarFuncao(AspNetUser user, string funcao)
        {
            if (user.TrocarFuncao(funcao))
            {
                return await UpdateAsync(user);
            }
            ;
            return new IdentityResult("não trocou");
        }

        public async Task UpdateFuncoesToUsuario(ICollection<AspNetFuncao> simirFuncoes, string userName)
        {
            var user = FindByNameAsync(userName).Result;

            //user.Funcoes = simirFuncoes;

            await UpdateAsync(user);
        }

        public string GeraPassword()
        {
            return GeraPassword(8);
        }

        public string GeraPassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var res = new StringBuilder();
            var rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public object GetEmpresaByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<AspNetUser> FindByUsuarioAsync(int usuarioID)
        {
            return await Users.FirstOrDefaultAsync(x => x.UsuarioID == usuarioID);
        }

        public async Task DesativarAsync(AspNetUser user)
        {
            await UpdateSecurityStampAsync(user.Id);
            user.Clients.Clear();
            await UpdateAsync(user);

            await SetLockoutEnabledAsync(user.Id, true);
            await SetLockoutEndDateAsync(user.Id, DateTime.Today.AddYears(100));
        }
    }
}