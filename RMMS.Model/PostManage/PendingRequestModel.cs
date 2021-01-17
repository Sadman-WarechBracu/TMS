using RMMS.Model.ProfileManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Model.PostManage
{
    public class PendingRequestModel
    {
        public int P_ID { get; set; }
        public string description { get; set; }
        public List<TeacherProfileModel> TeacherList { get; set; }
    }
}
