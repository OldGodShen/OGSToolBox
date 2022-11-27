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

        public class Root
        {
            /// <summary>
            /// 操作成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string img { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string captchaOnOff { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string uuid { get; set; }
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
            Root rt = JsonConvert.DeserializeObject<Root>(body);
            string img = rt.img;
            string uuid = rt.uuid;
            request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://www.jfbym.com/api/YmServer/customApi"),
                Content = new StringContent("{\r\n\t\"image\": \"" + img + "\",\r\n\t\"type\": \"50100\",\r\n\t\"token\": \"R9o3JnxOCpc4pFIB1g5dOAfuRMBsBbwu5Kf3/AMuCD8\"\r\n}")
                {
                    Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
                }
            };
            using var codebk = await client.SendAsync(request);
            body = await codebk.Content.ReadAsStringAsync();
            Console.WriteLine(body);
        }
    }
}
