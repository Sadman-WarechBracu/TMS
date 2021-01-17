using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Entities
{
    public partial class Subject
    {
        [Key]
        public int ID { get; set; }
        public int T_ID { get; set; }
        public string SubjectName { get; set; }
        [ForeignKey("T_ID")]
        public UserInfo UserInfo { get; set; }
    }
}
