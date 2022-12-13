using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGSToolBox.ViewsModels
{
    internal class LessonsViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _token;

        public string token
        {
            get { return _token; }
            set
            {
                _token = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("token"));
            }
        }


        public string authtoken { get; set; }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            token = "Token为" + query["token"].ToString();
            authtoken = query["token"].ToString();
        }


        public Command GetList { get; set; }
        public LessonsViewModel()
        {
            GetList = new Command(GetLessonsList);
            GetLessonsList();
        }

        public class @params
        {
        }

        public class RowsItem
        {
            public string searchValue { get; set; }

            public string createBy { get; set; }

            public string createTime { get; set; }

            public string updateBy { get; set; }

            public string updateTime { get; set; }
            public string remark { get; set; }

            public @params @params { get; set; }

            public int courseClassId { get; set; }

            public string classType { get; set; }
            public string yearTermId { get; set; }

            public string startYear { get; set; }

            public string endYear { get; set; }

            public string term { get; set; }

            public string grade { get; set; }

            public string classNum { get; set; }

            public string courseId { get; set; }

            public string courseClassType { get; set; }

            public string courseClassNum { get; set; }
            public string courseClassName { get; set; }
            public string userId { get; set; }

            public int courseClassSize { get; set; }

            public int classSize { get; set; }
            public string classroomId { get; set; }
            public string building { get; set; }
            public string classroom { get; set; }

            public string sex { get; set; }

            public string startTime { get; set; }

            public string endTime { get; set; }

            public string credits { get; set; }

            public string attendanceProportion { get; set; }

            public string usualProportion { get; set; }

            public string examProportion { get; set; }

            public string status { get; set; }

            public string delFlag { get; set; }

            public string studentId { get; set; }

            public string eduYearTermList { get; set; }
        }

        public class Root
        {
            public int total { get; set; }
            public List<RowsItem> rows { get; set; }
            public int code { get; set; }
            public string msg { get; set; }
        }

        private async void GetLessonsList()
        {
            string Classname = string.Empty;
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("http://106.15.5.115:8788/prod-api/education/courseClass/list?pageNum=1&pageSize=50"),
                    Headers =
                    {
                        { "Authorization", authtoken },
                    },
                };
                using var response = await client.SendAsync(request);
                string body = await response.Content.ReadAsStringAsync();
                body = body.Replace("null", "0");
                Root rt = JsonConvert.DeserializeObject<Root>(body);
                foreach (var item in rt.rows)
                {
                    Classname = Classname + "\n" + item.courseClassName;
                }
            }catch(Exception ex)
            {
                Classname = ex.ToString();
            }
            _list = Classname;
        }
        private string _list;
        public string List
        {
            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("List"));
            }
        }
    }
}
