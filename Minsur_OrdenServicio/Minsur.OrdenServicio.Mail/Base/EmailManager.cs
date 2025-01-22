using Microsoft.Extensions.Configuration;
using Minsur.OrdenServicio.Common.Recursos;
using Minsur.OrdenServicio.DTO;
using Minsur.OrdenServicio.DTO.Body;
using Minsur.OrdenServicio.DTO.Email;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Minsur.OrdenServicio.Mail.Base
{
    public class EmailManager
    {
        private string smtpServer;
        private int smtpPort;
        private string smtpPassword;
        private string fromEmailAddress;
        private string fromEmailAlias;
        private string DocumentPath;
        private bool smtpSsl;
        private bool useDefaulCredentials;
        protected MailMessage oMailMessage;
        protected SmtpClient oSmtpClient;

        public EmailManager(IConfiguration configuration)
        {
            this.smtpServer = configuration["Email:SMTP_Server"];
            this.smtpPort = int.Parse(configuration["Email:SMTP_Port"]);
            this.fromEmailAddress = configuration["Email:SMTP_User"];
            this.fromEmailAlias = configuration["Email:SMTP_Alias"];
            this.smtpPassword = configuration["Email:SMTP_Password"];
            this.smtpSsl = bool.Parse(configuration["Email:SMTP_Ssl"]);
            this.useDefaulCredentials = bool.Parse(configuration["Email:SMTP_DefaultCredential"]);
        }

        public void ConfigurarEmail(EmailParametroDto oEmailReporteDto)
        {
            oMailMessage = new MailMessage();
            oEmailReporteDto.Para.Split('|').ToList().ForEach(x => oMailMessage.To.Add(x));
            oMailMessage.From = new MailAddress(fromEmailAddress, fromEmailAlias);
            oMailMessage.Subject = oEmailReporteDto.Asunto;
            oMailMessage.Body = oEmailReporteDto.MensajeHtml;
            oMailMessage.IsBodyHtml = true;
            oMailMessage.BodyEncoding = Encoding.UTF8;
            oMailMessage.Priority = MailPriority.High;
            AdicionarCopia(oMailMessage, oEmailReporteDto.ConCopia);
        }

        public void AdicionarCopia(MailMessage oMailMessage, string toName)
        {
            if (!String.IsNullOrEmpty(toName))
            {
                if (toName.Contains('|'))
                {
                    foreach (var item in toName.Split('|'))
                    {
                        MailAddress copy = new MailAddress(item);
                        oMailMessage.CC.Add(copy);
                    }
                }
                else
                {
                    MailAddress copy = new MailAddress(toName);
                    oMailMessage.CC.Add(copy);
                }
            }
        }

        public void ConfiguracionClienteSmtp()
        {
            oSmtpClient = new SmtpClient(smtpServer, smtpPort);
            oSmtpClient.UseDefaultCredentials = useDefaulCredentials;

            if (!oSmtpClient.UseDefaultCredentials)
            {
                oSmtpClient.Credentials = new NetworkCredential(fromEmailAddress, smtpPassword);
            }

            if (smtpSsl)
            {
                oSmtpClient.EnableSsl = smtpSsl;
                oSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            }

        }

        public TransactionResponse SendEmailAsync()
        {
            TransactionResponse oTransactionResponse = new TransactionResponse();

            try
            {
                oSmtpClient.SendAsync(oMailMessage, null);
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL00000);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL00000;
            }
            catch (Exception ex)
            {
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL99999);
                oTransactionResponse.Mensaje = ex.Message;
            }

            return oTransactionResponse;
        }

        protected void Disposed()
        {
            oSmtpClient.Dispose();
            oMailMessage.Dispose();
        }
    }
}
