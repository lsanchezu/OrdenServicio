using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace Minsur.OrdenServicio.ApiServiceController.Base
{
    public class BaseApiServiceController
    {
        protected HttpClient oHttpClient;

        public BaseApiServiceController(IConfiguration configuration)
        {
            ConfigurarHttpClient(configuration["Api:Url"]);
        }

        private void ConfigurarHttpClient(string url)
        {
            oHttpClient = new HttpClient();
            oHttpClient.BaseAddress = new Uri(url);
            oHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ObtenerCredenciales());
        }
        private string ObtenerCredenciales()
        {
            var usuario = "usuairo";
            var password = "test";

            return Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", usuario, password)));
        }
    }
}
