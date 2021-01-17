using Framework.Objects;
using RMMS.Entities;
using RMMS.Model.ProfileManage;
using RMMS.Repo.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMS.Repo.ProfileManage
{
    public class ProfileManageRepo:BaseRepo
    {
        public int HttpUtil { get; private set; }

        public StudentProfileModel loadStudentProfile(int userID)
        {
            var result = new StudentProfileModel();
            try
            {
                //var objToSave = DbContext.UserInfos.FirstOrDefault(u => (u.Email == emailOrUserName || u.UserName == emailOrUserName) && u.Password == password);
                var userInfo = DbContext.UserInfos.FirstOrDefault(u => u.ID == userID);
                var student = DbContext.Students.FirstOrDefault(s => s.S_ID == userID);
                
                result.Email = userInfo.Email;
                result.Name = userInfo.Name;

                if (student == null)
                {
                    result.Class = "";
                    result.DOB = "";
                    result.Location = "";
                }
                else
                {
                    result.Class = student.Class;
                    result.DOB = student.DOB.ToString("dd-MMM-yyyy");
                    result.Location = student.location;
                }

            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }
        public TeacherProfileModel loadTeacherProfile(int userID)
        {
            var result = new TeacherProfileModel();
            result.AcademicResult = new List<string>();
            try
            {
                //var objToSave = DbContext.UserInfos.FirstOrDefault(u => (u.Email == emailOrUserName || u.UserName == emailOrUserName) && u.Password == password);
                var userInfo = DbContext.UserInfos.FirstOrDefault(u => u.ID == userID);
                var teacher = DbContext.Teachers.FirstOrDefault(s => s.T_ID == userID);
                var academic = DbContext.AcademicResults.FirstOrDefault(a => a.T_ID == userID);
                var subject = DbContext.Subjects.Where(s => s.T_ID == userID).ToList();

                result.Email = userInfo.Email;
                result.Name = userInfo.Name;
                string experties = "";


                foreach(var v in subject)
                {
                    experties += v.SubjectName+",";
                }
                if(experties.EndsWith(","))
                    experties = experties.Remove(experties.Length - 1, 1);

                result.Experties = experties;
                if (academic == null)
                {
                    result.AcademicResult.Add("");
                    result.AcademicResult.Add("");
                    result.AcademicResult.Add("");

                }
                else
                {
                    try
                    {
                        result.AcademicResult.Add(academic.S_Result.ToString());
                    }catch(Exception ex)
                    {
                        result.AcademicResult.Add("");
                    }

                    try
                    {
                        result.AcademicResult.Add(academic.C_Result.ToString());
                    }
                    catch (Exception ex)
                    {
                        result.AcademicResult.Add("");
                    }
                    try
                    {
                        result.AcademicResult.Add(academic.V_Result.ToString());
                    }
                    catch (Exception ex)
                    {
                        result.AcademicResult.Add("");
                    }
                }

                if (teacher == null)
                {
                    result.ContactNo = "";
                    result.Description = "";
                    result.Location = "";
                } 
                else
                {
                    result.ContactNo = teacher.ContactNo;
                    result.Description = teacher.Description;
                    result.Location = teacher.Location;
                }

            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }
        public StudentEditModel editStudentProfile(int userID)
        {
            var result = new StudentEditModel();
            try
            {
                //var objToSave = DbContext.UserInfos.FirstOrDefault(u => (u.Email == emailOrUserName || u.UserName == emailOrUserName) && u.Password == password);
                var userInfo = DbContext.UserInfos.FirstOrDefault(u => u.ID == userID);
                var student = DbContext.Students.FirstOrDefault(s => s.S_ID == userID);

                result.Email = userInfo.Email;
                result.Name = userInfo.Name;
                result.UserName = userInfo.UserName;

                if (student == null)
                {
                    result.Class = "";
                    result.DOB = "";
                    result.Location = "";
                }
                else
                {
                    result.Class = student.Class;
                    result.DOB = student.DOB.ToString("dd-MM-yyyy");
                    result.Location = student.location;
                }

            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }
        public TeacherEditModel editTeacherProfile(int userID)
        {
            var result = new TeacherEditModel();
            //result.AcademicResult = new List<string>();
            try
            {
                //var objToSave = DbContext.UserInfos.FirstOrDefault(u => (u.Email == emailOrUserName || u.UserName == emailOrUserName) && u.Password == password);
                var userInfo = DbContext.UserInfos.FirstOrDefault(u => u.ID == userID);
                var teacher = DbContext.Teachers.FirstOrDefault(s => s.T_ID == userID);
                var academic = DbContext.AcademicResults.FirstOrDefault(a => a.T_ID == userID);
                var subject = DbContext.Subjects.Where(s => s.T_ID == userID).ToList();

                result.Email = userInfo.Email;
                result.Name = userInfo.Name;
                result.UserName = userInfo.UserName;
                string experties = "";


                foreach (var v in subject)
                {
                    experties += v.SubjectName + ",";
                }
                if (experties.EndsWith(","))
                    experties = experties.Remove(experties.Length - 1, 1);

                result.Experties = experties;
                if (academic == null)
                {
                    result.S_Result="";
                    result.C_Result="";
                    result.V_Result="";

                }
                else
                {
                    try
                    {
                        result.S_Result=academic.S_Result.ToString();
                    }
                    catch (Exception ex)
                    {
                        result.S_Result = "";
                    }

                    try
                    {
                        result.C_Result=academic.C_Result.ToString();
                    }
                    catch (Exception ex)
                    {
                        result.C_Result = "";
                    }
                    try
                    {
                        result.V_Result=academic.V_Result.ToString();
                    }
                    catch (Exception ex)
                    {
                        result.V_Result = "";
                    }
                }

                if (teacher == null)
                {
                    result.ContactNo = "";
                    result.Description = "";
                    result.Location = "";
                }
                else
                {
                    result.ContactNo = teacher.ContactNo;
                    result.Description = teacher.Description;
                    result.Location = teacher.Location;
                }

            }
            catch (Exception ex)
            {
                result = null;
            }
            return result;
        }


        public Result<UserInfo> saveStudentProfile(StudentEditModel model,int id)
        {
            var result = new Result<UserInfo>();
            try
            {
                if (DbContext.UserInfos.Any(u => u.UserName == model.UserName && u.ID != id))
                {
                    result.HasError = true;
                    result.Message = "Username Exists";
                    return result;
                }
                if (DbContext.UserInfos.Any(u => u.Email == model.Email && u.ID != id))
                {
                    result.HasError = true;
                    result.Message = "Email Exists";
                    return result;
                }
                var objToSaveUserInfo = DbContext.UserInfos.FirstOrDefault(u => u.ID == id);
                var studentObj = DbContext.Students.FirstOrDefault(u => u.S_ID == id);
                objToSaveUserInfo.UserName = model.UserName;
                objToSaveUserInfo.Name = model.Name;
                objToSaveUserInfo.Email = model.Email;




                if (!string.IsNullOrEmpty(model.OldPassword) || !string.IsNullOrWhiteSpace(model.OldPassword))
                {
                    if (!string.IsNullOrEmpty(model.NewPassword) || !string.IsNullOrWhiteSpace(model.NewPassword))
                    {
                        if (!string.IsNullOrEmpty(model.ConfirmPassword) || !string.IsNullOrWhiteSpace(model.ConfirmPassword))
                        {
                            if (objToSaveUserInfo.Password == model.OldPassword)
                            {
                                if (model.NewPassword == model.ConfirmPassword)
                                {
                                    objToSaveUserInfo.Password = model.NewPassword;
                                }
                                else
                                {
                                    result.HasError = true;
                                    result.Message = "New password and confirm password are not matched";
                                    return result;
                                }
                            }
                            else
                            {
                                result.HasError = true;
                                result.Message = "Old password is not matched";
                                return result;
                            }

                        }
                        else
                        {
                            result.HasError = true;
                            result.Message = "Confirm Password field can not remain empty";
                            return result;
                        }

                    }
                    else
                    {
                        result.HasError = true;
                        result.Message = "New password field can not remain empty";
                        return result;
                    }
                    
                 

                }
                else if (!string.IsNullOrEmpty(model.NewPassword) || !string.IsNullOrWhiteSpace(model.NewPassword))
                {
                    result.HasError = true;
                    result.Message = "You must need to fill the old password first";
                    return result;
                }
                else if (!string.IsNullOrEmpty(model.ConfirmPassword) || !string.IsNullOrWhiteSpace(model.ConfirmPassword))
                {
                    result.HasError = true;
                    result.Message = "You need to fill the perious fields first";
                    return result;
                }
                try
                {
                    if (!string.IsNullOrEmpty(model.DOB) || !string.IsNullOrWhiteSpace(model.DOB))
                    {

                        string sDOB = model.DOB;
                        if (sDOB.Contains("-"))
                        {
                            var strings = sDOB.Split('-');
                            if (strings.Count() == 3)
                            {
                                try
                                {
                                    if ((Int32.Parse(strings[0]) > 0 && Int32.Parse(strings[0]) <= 31) && (Int32.Parse(strings[1]) > 0 && Int32.Parse(strings[1]) <= 12) && (Int32.Parse(strings[2]) > 1900 && Int32.Parse(strings[2]) <= Int32.Parse(DateTime.Now.Year.ToString())))
                                    {
                                        studentObj.DOB = DateTime.Parse(model.DOB);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    result.HasError = true;
                                    result.Message = "DOB is not in correct format";
                                    return result;
                                }

                            }
                            else
                            {
                                result.HasError = true;
                                result.Message = "DOB is not in correct format";
                                return result;
                            }
                        }
                        else
                        {
                            result.HasError = true;
                            result.Message = "DOB is not in correct format";
                            return result;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                try
                {
                    studentObj.Class = model.Class;
                }
                catch (Exception ex)
                {
                    studentObj.Class = "";
                }
                try
                {
                    studentObj.location = model.Location;
                }
                catch (Exception ex)
                {
                    studentObj.location = "";
                }
                DbContext.SaveChanges();
                result.Data = objToSaveUserInfo;
            }
            catch(Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
                return result;
            }
            
            

            return result;
        }
        public Result<UserInfo> saveTeacherProfile(TeacherEditModel model, int id)
        {
            var result = new Result<UserInfo>();
            try
            {
                if (DbContext.UserInfos.Any(u => u.UserName == model.UserName && u.ID != id))
                {
                    result.HasError = true;
                    result.Message = "Username Exists";
                    return result;
                }
                if (DbContext.UserInfos.Any(u => u.Email == model.Email && u.ID != id))
                {
                    result.HasError = true;
                    result.Message = "Email Exists";
                    return result;
                }
                var objToSaveUserInfo = DbContext.UserInfos.FirstOrDefault(u => u.ID == id);
                
                objToSaveUserInfo.UserName = model.UserName;
                objToSaveUserInfo.Name = model.Name;
                objToSaveUserInfo.Email = model.Email;


                if (!string.IsNullOrEmpty(model.OldPassword) || !string.IsNullOrWhiteSpace(model.OldPassword))
                {
                    if (!string.IsNullOrEmpty(model.NewPassword) || !string.IsNullOrWhiteSpace(model.NewPassword))
                    {
                        if (!string.IsNullOrEmpty(model.ConfirmPassword) || !string.IsNullOrWhiteSpace(model.ConfirmPassword))
                        {
                            if (objToSaveUserInfo.Password == model.OldPassword)
                            {
                                if (model.NewPassword == model.ConfirmPassword)
                                {
                                    objToSaveUserInfo.Password = model.NewPassword;
                                }
                                else
                                {
                                    result.HasError = true;
                                    result.Message = "New password and confirm password are not matched";
                                    return result;
                                }
                            }
                            else
                            {
                                result.HasError = true;
                                result.Message = "Old password is not matched";
                                return result;
                            }

                        }
                        else
                        {
                            result.HasError = true;
                            result.Message = "Confirm Password field can not remain empty";
                            return result;
                        }

                    }
                    else
                    {
                        result.HasError = true;
                        result.Message = "New password field can not remain empty";
                        return result;
                    }



                }
                else if (!string.IsNullOrEmpty(model.NewPassword) || !string.IsNullOrWhiteSpace(model.NewPassword))
                {
                    result.HasError = true;
                    result.Message = "You must need to fill the old password first";
                    return result;
                }
                else if (!string.IsNullOrEmpty(model.ConfirmPassword) || !string.IsNullOrWhiteSpace(model.ConfirmPassword))
                {
                    result.HasError = true;
                    result.Message = "You need to fill the perious fields first";
                    return result;
                }
                




                var academicObj = DbContext.AcademicResults.FirstOrDefault(u => u.T_ID == id);
                if (academicObj == null)
                {
                    academicObj = new AcademicResult();
                    academicObj.T_ID = id;
                    DbContext.AcademicResults.Add(academicObj);
                    
                }


                

                try
                {
                    academicObj.SchoolName = "";
                    academicObj.S_Result = Double.Parse(model.S_Result);
                }
                catch (Exception ex)
                {
                    academicObj.S_Result = 0;
                }
                try
                {
                    academicObj.CollageName = "";
                    academicObj.C_Result = Double.Parse(model.C_Result);
                }
                catch (Exception ex)
                {
                    academicObj.C_Result = 0;
                }
                try
                {
                    academicObj.VarsityName = "";
                    academicObj.V_Result = Double.Parse(model.V_Result);
                }
                catch (Exception ex)
                {
                    academicObj.V_Result = 0;
                }

                var teacherObj = DbContext.Teachers.FirstOrDefault(u => u.T_ID == id);
                if (teacherObj == null)
                {
                    teacherObj = new Teacher();
                    teacherObj.T_ID = id;
                    DbContext.Teachers.Add(teacherObj);
                }


                try
                {
                    teacherObj.Location = model.Location;
                }
                catch (Exception ex)
                {
                    teacherObj.Location = "";
                }
                try
                {
                    teacherObj.ContactNo = model.ContactNo;
                }
                catch (Exception ex)
                {
                    teacherObj.ContactNo = "";
                }
                try
                {
                    teacherObj.Description = model.Description;
                }
                catch (Exception ex)
                {
                    teacherObj.Description = "";
                }


                DbContext.SaveChanges();
                result.Data = objToSaveUserInfo;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
                return result;
            }



            return result;
        }

    }
}
