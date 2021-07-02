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

        //返回用户对象
        public static User GetUser(string userName)
        {
            User user = UserDao.SelectUserByUserNameWithCourse(userName);
            if (user == null) return null;
            CourseService.GetAndSetLikeNum(user.LikeCourses);
            CourseService.SetCourseScore(user.LikeCourses);
            for (int i = 0; i < user.LikeCourses.Count; i++)
            {
                CourseService.SetCourseTag(user.LikeCourses[i], 6);
            }
            user.LikeCourses = user.LikeCourses.OrderByDescending(c => c.Score).ToList();
            return user;
        }
        //返回管理员
        public static Admin GetAdmin(string adminName)
        {
            Admin admin = AdminDao.SelectAdminByAdminName(adminName);
            return admin;
        }

        //添加用户
        public static bool AddUser(User user)
        {
            return UserDao.AddUser(user);
        }

        // 删除用户喜爱课程
        public static bool DeleteFavouriteCourse(string userName, string courseId)
        {
            return UserDao.DeleteFavouriteCourse(userName, courseId);
        }

        //更新用户Stu密码
        public static bool ResetStuPwd(string name,string password)
        {
            return UserDao.UpdateUserPassword(name, password);
        }

        //更新admin密码
        public static void ResetAdminPwd(string name,string password)
        {
            AdminDao.UpdateUserPassword(name, password);
        }

        //更新其他信息
        public static bool UpdateInformation(User user)
        {
           return  UserDao.UpdateUserInfo(user);
        }

        //注销账户
        public static void DeleteStu(String Name)
        {

        }

        public static void DeleteAdmin(String Name)
        {

        }
    }
}
