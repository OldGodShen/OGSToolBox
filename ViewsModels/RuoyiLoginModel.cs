using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OGSToolBox.ViewsModels
{
    internal class RuoyiLoginModel
    {
        public string Username { get; set; } = String.Empty;
        public string Passwd { get; set; } = String.Empty;

        public Command RuoyiLogin { get; set; }
        public RuoyiLoginModel()
        {
            RuoyiLogin = new Command(DoRuoyiLogin);
        }

        private async void DoRuoyiLogin()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get ,
                RequestUri = new Uri("http://106.15.5.115:8788/prod-api/captchaImage"),
            };
            using var response = await client.SendAsync(request);
            string body = await response.Content.ReadAsStringAsync();
            Trace.WriteLine(body);
        }
    }
}
