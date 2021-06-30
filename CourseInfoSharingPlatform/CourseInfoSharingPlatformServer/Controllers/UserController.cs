using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Http;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using CourseInfoSharingPlatformServer.Models;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;

namespace CourseInfoSharingPlatformServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private Context context;

        public UserController(Context context)
        {
            this.context = context;
            ContextUtil.Context = context;
        }
        //查询用户是否收藏课程
        [HttpGet("isLikedCourse")]
        public ActionResult<bool> IsLikedCourse(string courseId,string userName)
        {
            return UserService.IsLikedCourse(courseId, userName);
        }

        // 用户收藏课程
        [HttpGet("addLikeCourse")]
        public ActionResult<bool> AddLikeCourse(string courseId, string userName)
        {
            return UserService.AddFavouriteCourse(courseId, userName);
        }

        // 获取用户给课程打分
        [HttpGet("getScore")]
        public ActionResult<int> GetScore(string courseId, string userName)
        {
            return UserService.GetScore(courseId, userName);
        }

        // 用户给课程打分
        [HttpGet("addScore")]
        public ActionResult<bool> AddScore(string courseId, string userName, int score)
        {
            return UserService.AddScore(courseId, userName, score);
        }

        //验证用户并返回,经典明文传密码,硬传
        [HttpGet("stu")]
        public ActionResult<User> AuthenStu(string name, string password)
        {
            try
            {
                if (name != null && password != null)
                    return UserService.GetStu(name, password);
                else return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet("admin")]
        public ActionResult<User> AuthenAdmin(string name, string password)
        {
            try
            {
                if (name != null && password != null)
                    return UserService.GetStu(name, password);
                else return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //提交修改

        [HttpPut("stu")]
        public ActionResult<bool> UpdateUser(User user)
        {
            try
            {
                UserService.UpdateInformation(user);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpPut("admin")]
        public ActionResult<bool> UpdateAdminPwd(Admin admin)
        {
            try
            {
                UserService.ResetAdminPwd(admin.AdminName, admin.Password);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //添加新用户
        [HttpPost("stu")]
        public ActionResult<bool> PostStu(User user)
        {
            try
            {
                return UserService.AddStu(user);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //注销账户
        [HttpDelete("stu")]
        public ActionResult<bool> DeleteStuAccount(string UserName)
        {
            try
            {
                UserService.DeleteStu(UserName);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpDelete("admin")]
        public ActionResult<bool> DeleteAdminAccount(string UserName)
        {
            try
            {
                UserService.DeleteAdmin(UserName);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
