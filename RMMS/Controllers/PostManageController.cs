using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RMMS.Framework.Base;
using RMMS.Model.PostManage;
using RMMS.Framework.Util;

namespace RMMS.Controllers
{
    public class PostManageController : BaseController
    {
        // GET: PostManage
        [Authorize]
        public ActionResult CreatePost()
        {
            var model = new PostModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreatePost(PostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = PostRepo.createNewPost(model,HttpUtil.UserProfile.ID);
            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
            else
            {
                ViewBag.Success = "A post has been created successfully";
            }
            return View();
        }
        [Authorize]
        public ActionResult PostHomeStudent()
        {
            var model = PostRepo.getAllPost();
            return View(model.Data);
        }
        [Authorize]
        public ActionResult MyPosts()
        {
            var model = PostRepo.getMyPosts(HttpUtil.UserProfile.ID);
            return View(model.Data);
        }
        public ActionResult DeletePosts(int id)
        {
            var model = PostRepo.deletePost(id);

            return RedirectToAction("MyPosts");
        }
        [Authorize]
        public ActionResult PostHomeTeacher()
        {
            var model = PostRepo.getAllPost();
            return View(model.Data);
        }
        public ActionResult SendRequest(int id)
        {
            var model = PostRepo.ApplyPost(id, HttpUtil.UserProfile.ID);
            if(model.HasError)
            {
                ViewBag.Error = model.Message;
            }
            else
            {
                ViewBag.Success = "You have applied for this post";
            }
            
            return RedirectToAction("PostHomeTeacher");
        }
        [Authorize]
        public ActionResult PendingRequest()
        {
            var model = PostRepo.AllPendingRequests(HttpUtil.UserProfile.ID);

            return View(model.Data);
        }
    }
}