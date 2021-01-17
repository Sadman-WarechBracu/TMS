using RMMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Data
{
    public class RMMSDbContext:DbContext
    {
        public RMMSDbContext():base("RMMSConnectionString")
        {

        }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<ResetPasswordRequest> ResetPasswordRequests { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<AcademicResult> AcademicResults { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}
