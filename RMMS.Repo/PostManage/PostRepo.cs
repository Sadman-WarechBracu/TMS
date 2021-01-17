using Framework.Objects;
using RMMS.Entities;
using RMMS.Model.PostManage;
using RMMS.Model.ProfileManage;
using RMMS.Repo.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Repo.PostManage
{
    public class PostRepo:BaseRepo
    {
        public Result<Post> createNewPost(PostModel model, int id)
        {
            var result = new Result<Post>();
            var objectToSave = new Post();
            try
            {
                
                DbContext.Posts.Add(objectToSave);
                objectToSave.Description = model.description;
                objectToSave.Post_Time = DateTime.Now;
                objectToSave.isActive = 1;
                objectToSave.S_ID = id;
                DbContext.SaveChanges();
                result.Data = objectToSave;

            }
            catch(Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }
        public Result<List<PostHomeModel>> getAllPost()
        {
            var result = new Result<List<PostHomeModel>>();
            result.Data = new List<PostHomeModel>();
            try
            {
                var posts = DbContext.Posts.Where(p => p.isActive == 1).OrderByDescending(o=>o.Post_Time).ToList();
                foreach (var v in posts)
                {
                    var PostModel = new PostHomeModel();
                    var UserInfos = DbContext.UserInfos.FirstOrDefault(u => u.ID == v.S_ID);
                    PostModel.UserName = UserInfos.UserName;
                    PostModel.Description = v.Description;
                    PostModel.P_ID = v.P_ID;
                    result.Data.Add(PostModel);
                }

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }
        public Result<List<PostModel>> getMyPosts(int id)
        {
            var result = new Result<List<PostModel>>();
            result.Data = new List<PostModel>();
            try
            {
                var posts = DbContext.Posts.Where(p => p.isActive == 1 && p.S_ID==id).OrderByDescending(o => o.Post_Time).ToList();
                foreach (var v in posts)
                {
                    var PostModel = new PostModel();
                    //var UserInfos = DbContext.UserInfos.FirstOrDefault(u => u.ID == v.S_ID);
                    PostModel.P_ID = v.P_ID;
                    PostModel.description = v.Description;
                    result.Data.Add(PostModel);
                }

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }
        public Result<Post> deletePost(int id)
        {
            var result = new Result<Post>();
            var objectToDelete = DbContext.Posts.FirstOrDefault(p=>p.P_ID == id);
            try
            {
                objectToDelete.isActive = 0;
                DbContext.SaveChanges();
                result.Data = objectToDelete;

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }
        public Result<Request> ApplyPost(int P_id, int T_id)
        {
            var result = new Result<Request>();
            var objectToSave = new Request();
            try
            {
                var requests = DbContext.Requests.FirstOrDefault(r => r.P_ID == P_id && r.T_ID == T_id);
                if(requests != null)
                {
                    result.HasError = true;
                    result.Message = "You have already done with request for this post";
                    return result;
                }
                DbContext.Requests.Add(objectToSave);
                objectToSave.P_ID = P_id;
                objectToSave.T_ID = T_id;
                DbContext.SaveChanges();
                result.Data = objectToSave;

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }


        public Result<List<PendingRequestModel>> AllPendingRequests(int S_id)
        {
            var result = new Result<List<PendingRequestModel>>();
            result.Data = new List<PendingRequestModel>();
            var Myposts = DbContext.Posts.Where(p => p.S_ID == S_id && p.isActive == 1).OrderByDescending(o => o.Post_Time).ToList();
            try
            {
                foreach (var v in Myposts)
                {
                    var PendingRequests = new PendingRequestModel();
                    
                    PendingRequests.P_ID = v.P_ID;
                    PendingRequests.description = v.Description;
                    result.Data.Add(PendingRequests);
                }
                foreach (var v in result.Data)
                {
                    var teachers = DbContext.Requests.Where(u => u.P_ID == v.P_ID).ToList();
                    v.TeacherList = new List<TeacherProfileModel>();
                    foreach(var v1 in teachers)
                    {
                        var UserInfo = DbContext.UserInfos.FirstOrDefault(u => u.ID == v1.T_ID);
                        var teacher = DbContext.Teachers.FirstOrDefault(u => u.T_ID == v1.T_ID);
                        var teacherProfileModel = new TeacherProfileModel();
                        try
                        {
                            teacherProfileModel.ContactNo = teacher.ContactNo;
                        }
                        catch (Exception ex)
                        {
                            teacherProfileModel.ContactNo = "";
                        }
                        try
                        {
                            teacherProfileModel.Email = UserInfo.Email;
                        }
                        catch(Exception ex)
                        {
                            teacherProfileModel.Email = "";
                        }
                        try
                        {
                            teacherProfileModel.Location = teacher.Location;
                        }
                        catch (Exception ex)
                        {
                            teacherProfileModel.Location = "";
                        }
                        teacherProfileModel.Name = UserInfo.Name;
                        v.TeacherList.Add(teacherProfileModel);
                    }
                }

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
