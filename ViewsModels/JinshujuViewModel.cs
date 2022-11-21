using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGSToolBox.ViewsModels
{
    class JinshujuViewModel
    {
        public string Id { get; set; }
        public string StudentName { get; set; }
        public string ClassId { get; set; }
        public string StudentNum { get; set; }
        public string TeacherName { get; set; }

        public Command Submit { get; set; }
        public JinshujuViewModel()
        {
            Submit = new Command(DoSubmit);
        }

        private void DoSubmit()
        {
            _ = this.Id;
        }
    }
}
