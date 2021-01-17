using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Entities
{
    public partial class Student
    {
        [Key]
        public int S_ID { get; set; }
        public DateTime DOB { get; set; }
        public string Class { get; set; }
        public string location { get; set; }
        [ForeignKey("S_ID")]
        public UserInfo UserInfo { get; set; }
    }
}
