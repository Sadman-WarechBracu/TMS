using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Model.ProfileManage
{
    public class TeacherEditModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Experties { get; set; }
        public string S_Result { get; set; }
        public string C_Result { get; set; }
        public string V_Result { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
