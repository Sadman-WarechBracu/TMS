using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Entities
{
    public partial class AcademicResult
    {
        [Key]
        public int T_ID { get; set; }
        public string SchoolName { get; set; }
        public double S_Result{ get; set; }
        public string CollageName { get; set; }
        public double C_Result { get; set; }
        public string VarsityName { get; set; }
        public double V_Result { get; set; }
        [ForeignKey("T_ID")]
        public UserInfo UserInfo { get; set; }

    }
}
