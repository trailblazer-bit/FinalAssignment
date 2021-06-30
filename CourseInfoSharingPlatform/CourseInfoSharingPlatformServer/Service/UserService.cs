using CourseInfoSharingPlatformServer.Models;
using EFDemo.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatformServer.Service
{
    //处理登录和注册、查看和修改个人信息，修改密码等和用户有关的操作
    public class UserService
    {
        //查询用户是否收藏某课
        public static bool IsLikedCourse(string courseId, string userName)
        {
            return UserDao.IsLikedCourse(courseId, userName);
        }

        // 用户收藏课程
        public static bool AddFavouriteCourse(string courseId, string userName)
        {
            if(!UserDao.AddFavouriteCourse(userName, courseId)) return false;
            return CourseDao.AddLikeNum(courseId);
        }

        // 获得用户给某一个课程的打分，若用户没有给该课程打分则返回0
        public static int GetScore(string courseId, string userName)
        {
            return CUSDao.GetScoreByUserNameAndCourseId(userName, courseId);
        }

        // 用户给某课程打分
        public static bool AddScore(string courseId, string userName, int score)
        {
            CUS cus = new CUS();
            cus.CourseId = courseId;
            cus.UserName = userName;
            cus.Score = score;
            return CUSDao.AddScore(cus);
        }
    }
}
