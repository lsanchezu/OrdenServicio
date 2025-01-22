using Minsur.OrdenServicio.DTO.Body;
using Minsur.OrdenServicio.DTO.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minsur.OrdenServicio.Mail.Interface
{
    public interface IEmailService
    {
        TransactionResponse SendEmailAsync(EmailParametroDto oEmailReporteDto, Action<EmailParametroDto, bool, string> method);
    }
}
