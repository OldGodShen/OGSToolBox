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
    internal class LessonsViewModel : IQueryAttributable,INotifyPropertyChanged
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


        public string authtoken { get;set; }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            token = "Token为" + query["token"].ToString();
            authtoken = query["token"].ToString();
        }


        public Command GetList { get; set; }
        public LessonsViewModel()
        {
            GetList = new Command(GetLessonsList);
        }

        public class @params
        {
        }

        public class RowsItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string searchValue { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string createBy { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string createTime { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string updateBy { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string updateTime { get; set; }
            public string remark { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public @params @params { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int courseClassId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string classType { get; set; }
            public string yearTermId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string startYear { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string endYear { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string term { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string grade { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string classNum { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string courseId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string courseClassType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string courseClassNum { get; set; }
            public string courseClassName { get; set; }
            public string userId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int courseClassSize { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int classSize { get; set; }
            public string classroomId { get; set; }
            public string building { get; set; }
            public string classroom { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string sex { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string startTime { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string endTime { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string credits { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string attendanceProportion { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string usualProportion { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string examProportion { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string delFlag { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string studentId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string eduYearTermList { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public int total { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<RowsItem> rows { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            public string msg { get; set; }
        }
        private async void GetLessonsList()
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
            body = body.Replace("null","0");
            Root rt = JsonConvert.DeserializeObject<Root>(body);
            string Classname = string.Empty;
            foreach (var item in rt.rows)
            {
                Classname = Classname + "\n" + item.courseClassName;
            }
            return Classname;
        }
        private string _list;
        public string List
        {
            set
            {
                _list = GetLessonsList();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("List"));
            }
        }
    }
}
