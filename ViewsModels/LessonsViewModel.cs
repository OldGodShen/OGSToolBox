using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Authentication.Web.Provider;

namespace OGSToolBox.ViewsModels
{
    internal class LessonsViewModel
    {
        //[QueryProperty("TokenGet", "token")]
        public string Token { get; set; }
	    private async void GetLessonsList()
	    {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://106.15.5.115:8788/prod-api/education/courseClass/list?pageNum=1&pageSize=50&studentId={{studentid}}"),
                Headers =
                    {
                        { "Authorization", token },
                    },
            };
            using var response = await client.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();
            Trace.WriteLine(body);
        }
    }
}
