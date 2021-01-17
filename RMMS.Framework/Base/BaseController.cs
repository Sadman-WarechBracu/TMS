using RMMS.Data;
using RMMS.Repo.Account;
using RMMS.Repo.PostManage;
using RMMS.Repo.ProfileManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RMMS.Framework.Base
{
    public class BaseController: Controller
    {
        private static RMMSDbContext _context;
        public static RMMSDbContext DbContext
        {
            get {
                if(_context==null)
                    _context = new RMMSDbContext();
                return _context;
            }
        }
        private static UserInfoRepo _userInfoRepo;
        public static UserInfoRepo UserInfoRepo
        {
            get
            {
                if (_userInfoRepo == null)
                    _userInfoRepo = new UserInfoRepo();
                return _userInfoRepo;
            }
        }
        private static ResetPasswordRequestRepo _resetPasswordRequestRepo;
        public static ResetPasswordRequestRepo ResetPasswordRequestRepo
        {
            get
            {
                if (_resetPasswordRequestRepo == null)
                    _resetPasswordRequestRepo = new ResetPasswordRequestRepo();
                return _resetPasswordRequestRepo;
            }
        }
        private static ProfileManageRepo _profileManageRepo;
        public static ProfileManageRepo ProfileManageRepo
        {
            get
            {
                if (_profileManageRepo == null)
                    _profileManageRepo = new ProfileManageRepo();
                return _profileManageRepo;
            }
        }
        private static PostRepo _postRepo;
        public static PostRepo PostRepo
        {
            get
            {
                if (_postRepo == null)
                    _postRepo = new PostRepo();
                return _postRepo;
            }
        }
    }
}
