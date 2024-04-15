using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration; 

namespace ControleDeContatos.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration; // Acessa o appsettings.json

        // Construtor para receber a interface IConfiguration
        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Método para enviar email
        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                // Obter configurações de SMTP do arquivo appsettings.json
                string host = _configuration.GetValue<string>("SMTP:Host");
                string nome = _configuration.GetValue<string>("SMTP:Nome");
                string userName = _configuration.GetValue<string>("SMTP:UserName");
                string senha = _configuration.GetValue<string>("SMTP:Senha");
                int porta = _configuration.GetValue<int>("SMTP:Porta");

                // Criar uma nova mensagem de email
                MailMessage mail = new MailMessage();

                // Definir o remetente do email
                mail.From = new MailAddress(userName, nome);

                // Adicionar o destinatário do email
                mail.To.Add(email);

                // Definir o assunto do email
                mail.Subject = assunto;

                // Definir o corpo do email
                mail.Body = mensagem;

                // Indicar que o corpo do email contém HTML
                mail.IsBodyHtml = true;

                // Definir a prioridade do email como alta
                mail.Priority = MailPriority.High;

                // Configurar cliente SMTP
                using (SmtpClient smtp = new SmtpClient(host, porta))
                {
                    // Definir credenciais de autenticação
                    smtp.Credentials = new NetworkCredential(userName, senha);

                    // Habilitar SSL para conexão segura
                    smtp.EnableSsl = true;

                    // Enviar o email
                    smtp.Send(mail);

                    // Retorna true se o email for enviado com sucesso
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                // Lidar com exceções, por exemplo, gravando em log
                // Retorna false se ocorrer algum erro ao enviar o email
                return false;
            }
        }
    }
}
