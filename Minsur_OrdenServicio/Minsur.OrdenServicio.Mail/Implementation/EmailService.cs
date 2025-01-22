using Microsoft.Extensions.Configuration;
using Minsur.OrdenServicio.DTO.Body;
using Minsur.OrdenServicio.DTO.Email;
using Minsur.OrdenServicio.Mail.Base;
using Minsur.OrdenServicio.Mail.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Mail.Implementation
{
    public class EmailService : EmailManager, IEmailService
    {
        public EmailService(IConfiguration configuration) : base(configuration)
        {
        }

        public TransactionResponse SendEmailAsync(EmailParametroDto oEmailParametroDto, Action<EmailParametroDto, bool, string> method)
        {
            ConfigurarEmail(oEmailParametroDto);
            ConfiguracionClienteSmtp();

            oSmtpClient.SendCompleted += (s, e) =>
            {
                SmtpClient_SendCompleted(s, e, method, oEmailParametroDto);
                base.Disposed();
            };

            return base.SendEmailAsync();
        }

        private void SmtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e, Action<EmailParametroDto, bool, string> method, EmailParametroDto oEmailParametroDto)
        {
            var flagEnvioCorrecto = (!e.Cancelled && e.Error == null);
            string mensaje = string.Empty;
            if (e.Error != null)
            {
                mensaje = e.Error.Message;
            }

            method.Invoke(oEmailParametroDto, flagEnvioCorrecto, mensaje);
        }
    }
}
