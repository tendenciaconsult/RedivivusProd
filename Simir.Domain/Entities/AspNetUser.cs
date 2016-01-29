using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Simir.Domain.Enuns;

namespace Simir.Domain.Entities
{
    public class AspNetUser : IdentityUser
    {
        public AspNetUser()
        {
            //Clients = new Collection<AspNetClient>();
            Perfis = new HashSet<AspNetPerfil>();
        }

        public int? EmpresaID { get; set; }
        public virtual TBEmpresa TBEmpresa { get; set; }
        public virtual ICollection<AspNetClient> Clients { get; set; }
        public int? UsuarioID { get; set; }
        public virtual TBUsuario TBUsuario { get; set; }
        public virtual ICollection<AspNetPerfil> Perfis { get; set; }
        //[NotMapped]
        public string CurrentClientId { get; set; }

        [NotMapped]
        public string FuncaoNome { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AspNetUser> manager,
            ClaimsIdentity ext = null)
        {
            // Observe que o authenticationType precisa ser o mesmo que foi definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(CurrentClientId))
            {
                claims.Add(new Claim("AspNet.Identity.ClientId", CurrentClientId));
            }

            if (UsuarioID != null)
            {
                claims.Add(new Claim("AspNet.Identity.Prefeitura", TBUsuario.PrefeituraID.ToString()));
            }

            //  Adicione novos Claims aqui //


            //var modulos = GetAllModulos();
            /*
            foreach (var item in modulos)
            {
                if (item is AspNetModuloPai)
                    claims.Add(new Claim("Titu.pai" + item.ModuloPaiId + "." + item.Display, "pai" + item.AspNetModuloId));
                if (item is AspNetAction)
                {
                    if (item.bVisivelDisplay)
                        claims.Add(new Claim("Menu.pai" + item.ModuloPaiId + "." + item.Display,
                            (item as AspNetAction).AspNetController.Nome + (item as AspNetAction).Nome));
                    else
                        claims.Add(new Claim("Invi.pai" + item.ModuloPaiId + "." + item.Display,
                            (item as AspNetAction).AspNetController.Nome + (item as AspNetAction).Nome));
                }
            }*/

            var permissoes = Permissoes;

            foreach (var permissao in permissoes)
            {
                var item = permissao.AspNetModulo;
                if (item is AspNetModuloPai)
                    claims.Add(new Claim(string.Format("Titu{0}.pai{1}.{2}", item.Ordem.ToString("0000"), item.ModuloPaiId, item.Display), "pai" + item.AspNetModuloId));
                else if (item is AspNetAction)
                {
                    if (item.bVisivelDisplay)
                        claims.Add(new Claim(string.Format("Menu{0}.pai{1}.{2}", item.ModuloPai.Ordem.ToString("0000"), item.ModuloPaiId, item.Display),
                            (item as AspNetAction).AspNetController.Nome + (item as AspNetAction).Nome));
                    else
                        claims.Add(new Claim("Invi.pai" + item.ModuloPaiId + "." + item.Display,
                            (item as AspNetAction).AspNetController.Nome + (item as AspNetAction).Nome));
                }
            }

            if (TBEmpresa != null && (TBEmpresa.TBLicencaOperacaos == null || !TBEmpresa.TBLicencaOperacaos.Any()))
                claims.Add(new Claim("Avis.avisoLicencaVazia", MensagensErro.avisoLicencaVazia));


            //Nome do sujeito
            if(TBEmpresa != null)
                claims.Add(new Claim("AspNet.Identity.Nome", TBEmpresa.nmFantasia));
            else if (TBUsuario != null)
                claims.Add(new Claim("AspNet.Identity.Nome", TBUsuario.nmUsuario));


            // Adicionando Claims externos capturados no login
            if (ext != null)
            {
                await SetExternalProperties(userIdentity, ext);
            }

            // Gerenciamento de Claims para informaçoes do usuario
            //claims.Add(new Claim("AdmRoles", "True"));


            userIdentity.AddClaims(claims);
            return userIdentity;
        }

        private async Task SetExternalProperties(ClaimsIdentity identity, ClaimsIdentity ext)
        {
            if (ext != null)
            {
                var ignoreClaim = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims";
                // Adicionando Claims Externos no Identity
                foreach (var c in ext.Claims)
                {
                    if (!c.Type.StartsWith(ignoreClaim))
                        if (!identity.HasClaim(c.Type, c.Value))
                            identity.AddClaim(c);
                }
            }
        }
        [NotMapped]
        public List<AspNetPermissao> Permissoes
        {
            get
            {
                if (_permissoes == null || !_permissoes.Any())
                    _permissoes = GetAllPermissoes();
                return _permissoes;
            }
        }

        private List<AspNetPermissao> _permissoes;

        private List<AspNetPermissao> GetAllPermissoes()
        {

            if (Perfis == null) return new List<AspNetPermissao>();
            
            Perfis = Perfis.Where(a => (a.bAtivo != null) && (bool) a.bAtivo).ToList();

            var ddd = Perfis.SelectMany(
                a => a.Permissoes.Where(b => b.AspNetModulo.ModuloPaiId != null))
                .GroupBy(customer => customer.AspNetModulo.ModuloPaiId)
                .Select(group => new AspNetPermissao()
                {
                    AspNetModulo = group.First().AspNetModulo.ModuloPai,
                    AspNetModuloId = group.First().AspNetModulo.ModuloPai.AspNetModuloId,
                    AspNetTipoPermissaoId =
                        group.Select(t => t.AspNetTipoPermissaoId)
                            .Aggregate(group.First().AspNetTipoPermissaoId, (x, y) => x | y)
                });

            var ccc = Perfis.SelectMany(x => x.Permissoes)
                .GroupBy(customer => customer.AspNetModuloId)
                .Select(group => new AspNetPermissao()
                {
                    AspNetModulo = group.First().AspNetModulo, 
                    AspNetModuloId = group.First().AspNetModuloId, 
                    AspNetTipoPermissaoId = group.Select(t => t.AspNetTipoPermissaoId).Aggregate(group.First().AspNetTipoPermissaoId, (x, y) => x | y)
                })
                .ToList();
            ccc.AddRange(ddd);
            return ccc.OrderBy(x=>x.AspNetModulo.Ordem).ToList();

        }
         
        public ICollection<AspNetModulo> GetAllModulos()
        {
            if (Perfis == null) return new List<AspNetModulo>();

            
            var ddd = Perfis.SelectMany(
                a => a.Permissoes.Where(b => b.AspNetModulo.ModuloPaiId != null).Select(c => c.AspNetModulo.ModuloPai))
                .GroupBy(customer => customer.AspNetModuloId)
                .Select(group => group.First());

            var ccc = Perfis.SelectMany(x => x.Permissoes.Select(y => y.AspNetModulo))
                .GroupBy(customer => customer.AspNetModuloId)
                .Select(group => group.First())
                .ToList();
            ccc.AddRange(ddd);

            return ccc;


            //return retorno.GroupBy(customer => customer.AspNetModuloId).Select(group => group.First());
        }

        public bool TrocarFuncao(string funcao)
        {
            if (string.IsNullOrEmpty(CurrentClientId)) return false;

            var clientCurrent = Clients.Where(x => x.Id == int.Parse(CurrentClientId)).FirstOrDefault();
            if (clientCurrent == null) return false; // não ter o cliente... não pode acontecer isso
            // if (Funcoes == null || Funcoes.FirstOrDefault(x => x.Nome == funcao) == null) return false; //ele não tem esse funcao

            clientCurrent.FuncaoSelecionada = funcao;
            return true;
        }

        public bool TemPermissao(string caminho, TipoPermissao tipoPermissao)
        {
            var permissao =
                Permissoes.FirstOrDefault(
                    x => x.AspNetModulo is AspNetAction && ((AspNetAction) x.AspNetModulo).GetUrl() == caminho);
            if (permissao == null) return false;

            return (permissao.AspNetTipoPermissaoId & tipoPermissao) == tipoPermissao;
        }
    }
}