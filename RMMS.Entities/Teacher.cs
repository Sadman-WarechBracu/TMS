using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Entities
{
    public partial class Teacher
    {
        [Key]
        public int T_ID { get; set; }
        public string Location { get; set; }
        public string ContactNo { get; set; }
        public string Description { get; set; }
        public int IsVarified { get; set; }
        [ForeignKey("T_ID")]
        public UserInfo UserInfo { get; set; }
    }
}
