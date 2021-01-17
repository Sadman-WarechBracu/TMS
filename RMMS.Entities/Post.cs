using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Entities
{
    public partial class Post
    {
        [Key]
        public int P_ID { get; set; }
        [Required]
        public int S_ID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int isActive { get; set; }
        [Required]
        public DateTime Post_Time { get; set; }
    }
}
