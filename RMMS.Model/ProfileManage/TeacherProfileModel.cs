using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Model.ProfileManage
{
    public class TeacherProfileModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Experties { get; set; }
        public List<string> AcademicResult { get; set; }
    }
}
