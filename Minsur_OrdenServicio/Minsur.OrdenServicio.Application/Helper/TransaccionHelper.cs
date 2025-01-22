using Minsur.OrdenServicio.Common.Recursos;
using Minsur.OrdenServicio.DTO.Body;
using Serilog;
using System;


namespace Minsur.OrdenServicio.Application.Helper
{
    public static class TransaccionHelper
    {
        public static TransactionResponse RegistrarTransaccion(Action method)
        {
            TransactionResponse oTransactionResponse = new TransactionResponse();
            try
            {
                method();
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL00000);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL00000;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                oTransactionResponse.Codigo = nameof(DictionaryErrors.SOL99999);
                oTransactionResponse.Mensaje = DictionaryErrors.SOL99999;
            }
            return oTransactionResponse;
        }
    }
}
