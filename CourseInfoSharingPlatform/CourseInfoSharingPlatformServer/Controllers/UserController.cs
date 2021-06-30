using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
