using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Model.PostManage
{
    public class PostModel
    {
        public int P_ID { get; set; }
        [Required]
        public string description { get; set; }
        public int isActive { get; set; }
    }
}
