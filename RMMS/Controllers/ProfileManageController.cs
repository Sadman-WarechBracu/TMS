using RMMS.Framework.Base;
using RMMS.Framework.Util;
using RMMS.Model.ProfileManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RMMS.Model.ProfileManage;

namespace RMMS.Controllers
{
    public class ProfileManageController : BaseController
    {
        // GET: ProfileManage
        [Authorize]
        public ActionResult StudentProfile()
        {
            var model = new StudentProfileModel();
            model = ProfileManageRepo.loadStudentProfile(HttpUtil.UserProfile.ID);
            return View(model);
        }
        [Authorize]
        public ActionResult TeacherProfile()
        {

            var model = new TeacherProfileModel();
            model = ProfileManageRepo.loadTeacherProfile(HttpUtil.UserProfile.ID);
            return View(model);
        }
        public ActionResult TeacherEdit(int id)
        {
            var model = new TeacherEditModel();
            model = ProfileManageRepo.editTeacherProfile(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult TeacherEdit(TeacherEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = ProfileManageRepo.saveTeacherProfile(model, HttpUtil.UserProfile.ID);
            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
            return View(model);
        }
        public ActionResult StudentEdit(int id)
        {
            var model = new StudentEditModel();
            model = ProfileManageRepo.editStudentProfile(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult StudentEdit(StudentEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = ProfileManageRepo.saveStudentProfile(model,HttpUtil.UserProfile.ID);
            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }

            return View(model);
        }
    }
}