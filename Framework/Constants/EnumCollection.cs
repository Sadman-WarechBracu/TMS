using Framework.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Constants
{
    public class EnumCollection
    {
        #region UserType
        public enum UserTypeEnum
        {
            Admin = 1,
            Tutor = 2,
            Student = 4
        }
        public static List<EnumDetail> GetUserTypeEnums()
        {
            var list = new List<EnumDetail>();
            list.Add(new EnumDetail() {
                ID = 1, Name = "Admin"
            });
            list.Add(new EnumDetail()
            {
                ID = 2,
                Name = "Tutor"
            });
            list.Add(new EnumDetail()
            {
                ID = 4,
                Name = "Student"
            });
            return list;
        }
        #endregion
    }
}
