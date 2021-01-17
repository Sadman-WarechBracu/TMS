using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Entities
{
    public partial class Request
    {
        [Key]
        public int R_ID { get; set; }
        [Required]
        public int P_ID { get; set; }
        [Required]
        public int T_ID { get; set; }
        [ForeignKey("P_ID")]
        public Post Post { get; set; }
        [ForeignKey("T_ID")]
        public UserInfo UserInfo { get; set; }
    }
}
