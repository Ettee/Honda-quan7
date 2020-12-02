using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HondaWeb.Helper
{
    public class DataAPI
    {
        private static HttpClient client = new HttpClient();
        public HttpClient Initial()
        {
            client.BaseAddress = new Uri("https://localhost:44342/");
            return client;    
        }
    }
}
