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
            string Result = null;
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
                // 生成HTML
                string tHtml = "<table>\n";
                tHtml += "<tr>\n";
                string[] tbHead = { "学分", "课程", "教师", "最大人数", "当前人数", "选课开始时间", "选课结束时间" };
                foreach (string t in tbHead)
                {
                    tHtml += String.Format("<th>%s</th>\n", t);
                }
                tHtml += "</tr>\n";
                foreach (var item in rt.rows)
                {
                    tHtml += "<tr>\n";
                    tHtml += String.Format("<td>%s</td>\n", item.remark);
                    tHtml += String.Format("<td>%s</td>\n", item.courseClassId);
                    tHtml += String.Format("<td>%s</td>\n", item.userId);
                    tHtml += String.Format("<td>%s</td>\n", item.courseClassNum);
                    tHtml += String.Format("<td>%s</td>\n", item.courseClassSize);
                    tHtml += String.Format("<td>%s</td>\n", item.classSize);
                    tHtml += String.Format("<td>%s</td>\n", item.startTime);
                    tHtml += String.Format("<td>%s</td>\n", item.endTime);
                    tHtml += "</tr>\n";
                }
                tHtml += "</table>";
                tHtml = String.Format("<!DOCTYPE html><html><head></head><body>\n%s\n</body></html>", tHtml);
                Result = tHtml;
                Debug.Print(Result);
                Debug.Print("Process the Result yourself!!");
            }catch(Exception ex)
            {
                Result = String.Format("<!DOCTYPE html><html><head></head><body>\n%s\n%s\n</body></html>", "发生错误：", ex.ToString());
            }
            _list = Result;
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
