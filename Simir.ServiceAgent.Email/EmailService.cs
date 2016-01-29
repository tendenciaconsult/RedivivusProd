using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Simir.Domain;
using Simir.Domain.Helpers;

namespace Simir.ServiceAgent.Email
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            //return ConfigSendGridasync(message);
            await SendMail(message);
        }

        private async Task SendMail(IdentityMessage message)
        {
            
            var Email = message.Destination;

            var objEmail = new MailMessage
            {
                From = new MailAddress(VariaveisDefault.EmailEnvio)
            };
            // Seta o destinatário final
            objEmail.To.Add(VariaveisDefault.EmailEmpresa); // HOTMAIL | LIVE | MSN
            objEmail.CC.Add(Email);
            objEmail.BodyEncoding = Encoding.UTF8;
            // Seta a prioridade para envio do e-mail
            objEmail.Priority = MailPriority.High;
            // Informa se o corpo do texto pode ter html
            objEmail.IsBodyHtml = true;
            // Assunto da mensagem
            objEmail.Subject = message.Subject;
            // Corpo da mensagem
            objEmail.Body = message.Body;
                //"Mensagem Automatica! \n O banco de dados foi atualizado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            // Cria objeto com os dados do SMTP tambem pode usar a porta 25 com baixa seguranca
            var smtpC = new SmtpClient("mail.redivivus.eco.br", 587) // HOTMAIL | LIVE | MSN
            {
                //EnableSsl = true
                EnableSsl = false
            };
            // Informa as credenciais para acessar o servidor de e-mail
            var credenciais = new NetworkCredential(VariaveisDefault.EmailEmpresa, VariaveisDefault.SenhaEmail);
                // HOTMAIL | LIVE | MSN                   
            // Acessa o servidor de e-mail
            smtpC.Credentials = credenciais;
            //Dispara o e-mail

            await smtpC.SendMailAsync(objEmail);
        }

        // Implementação de e-mail manual
        private Task SendMail2(IdentityMessage message)
        {
            const string credentialUserName = "atendimento@redivivus.eco.br";
            const string sentFrom = "dantonmoura@gmail.com";
            const string pwd = "55";
            const string host = "smtp.gmail.com";

            // Configure the client:
            var client = new SmtpClient(host);

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;

            // Create the credentials:
            var credentials = new NetworkCredential(credentialUserName, pwd);
            client.EnableSsl = true;
            client.Credentials = credentials;

            // Create the message:
            var mail = new MailMessage(sentFrom, message.Destination)
            {
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true
            };
            return client.SendMailAsync(mail);
        }
    }
}