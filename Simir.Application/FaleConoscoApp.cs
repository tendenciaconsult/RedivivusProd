using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Simir.Application.Interfaces;
using Simir.Application.ViewModels;
using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Services;
using Simir.Infra.Data.Context;
using System.Net.Mail;
using Simir.Domain;
using System.Net;
using System.Text;


namespace Simir.Application
{
    public class FaleConoscoApp : AppServiceBase<SimirContext>, IFaleConoscoApp
    {
        private readonly IFaleConoscoService _Service;

        public FaleConoscoApp(IFaleConoscoService Service)
        {
            _Service = Service;
        }
        public async Task<IDictionary<string, ModelState>> SalvarEnviar(FaleConoscoVM model)
        {
            var tudoCerto = false;

            await EnviarEmail(model);

            var resultado = new Dictionary<string, ModelState>();

            TBFaleConosco Dados = new TBFaleConosco();

            Dados.PrefeituraID = model.PrefeituraID;
            Dados.AssuntoID = Convert.ToInt32(model.AssuntoID);
            Dados.nmAssunto = model.nmAssunto;
            Dados.EmailContato = model.Email;
            Dados.Mensagem = model.Descricao;            
            Dados.nmSolicitante = model.Nome;
            Dados.TelefoneContato = model.Telefone;
            Dados.UserID = model.IdUsuario;

            BeginTransaction();

            try
            {
 
                tudoCerto = await _Service.Add(Dados);

                if (tudoCerto)
                {
                    await CommitAsync();
                    
                }
            }
            catch (ArgumentException ex)
            {
                if (!resultado.ContainsKey(ex.ParamName)) resultado.Add(ex.ParamName, new ModelState());
                var lines = Regex.Split(ex.Message, "\r\n");
                resultado[ex.ParamName].Errors.Add(lines[0]);
            }
            catch(Exception ex)
            {
                var texto = ex.Message;
            }


            return resultado;
        }
        public async Task EnviarEmail(FaleConoscoVM model)
        {
            var Email = model.Email;

            string sMensagem;
            sMensagem = "<b>Solicitante: </b>" + model.Nome + "<br />" +
                        "<b>Email do Solicitante: </b>" + model.Email + "<br />" +
                        "<b>Telefone para contato: </b>" + model.Telefone + "<br />" +
                        "<b>Prefeitura: </b>" + model.nmPrefeitura + "<br />" +
                        "<b>Assunto: <\b> " + model.nmAssunto + " <br />" +
                        "<b>Mensagem: <\b> <br />" + model.Descricao;

            var objEmail = new MailMessage
            {
                From = new MailAddress(VariaveisDefault.EmailEnvio)
            };
            // Seta o destinatário final
            objEmail.To.Add(VariaveisDefault.EmailFaleConosco); // HOTMAIL | LIVE | MSN
            objEmail.CC.Add(model.Email);
            objEmail.BodyEncoding = Encoding.UTF8;
            // Seta a prioridade para envio do e-mail
            objEmail.Priority = MailPriority.High;
            // Informa se o corpo do texto pode ter html
            objEmail.IsBodyHtml = true;
            // Assunto da mensagem
            objEmail.Subject = model.nmAssunto;
            // Corpo da mensagem
            objEmail.Body = sMensagem;
            //"Mensagem Automatica! \n O banco de dados foi atualizado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            // Cria objeto com os dados do SMTP tambem pode usar a porta 25 com baixa seguranca
            var smtpC = new SmtpClient("mail.redivivus.eco.br", 587) // HOTMAIL | LIVE | MSN
            {
                //EnableSsl = true
                EnableSsl = false
            };
            // Informa as credenciais para acessar o servidor de e-mail
            var credenciais = new NetworkCredential(VariaveisDefault.EmailEnvio, VariaveisDefault.SenhaEmail);
            // HOTMAIL | LIVE | MSN                   
            // Acessa o servidor de e-mail
            smtpC.Credentials = credenciais;
            //Dispara o e-mail
            
            try
            {
                await smtpC.SendMailAsync(objEmail);
            }
            catch (Exception ex)
            {
                //return false;
            }
            finally
            {
                //excluímos o objeto de e-mail da memória
                objEmail.Dispose();
                //anexo.Dispose();
            }

        }
    }
}
