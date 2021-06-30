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

        //返回用户名密码匹配的信息
        public static User GetStu(string name,string password)
        {
            User res =  UserDao.SelectUserByUserNameWithCourse(name);
            if (res!=null && res.Password != password)
                return null;
            else return res;
        }
        public static Admin GetAdmin(string name, string password)
        {
            Admin res = AdminDao.SelectAdminByAdminName(name);
            if (res != null && res.Password != password)
                return null;
            else return res;
        }
        //添加用户
        public static bool AddStu(User user)
        {
            return UserDao.AddUser(user);
        }


        //更新用户Stu密码
        public static void ResetStuPwd(string name,string password)
        {
            UserDao.UpdateUserPassword(name, password);
        }

        //更新admin密码
        public static void ResetAdminPwd(string name,string password)
        {
            AdminDao.UpdateUserPassword(name, password);
        }

        //更新其他信息
        public static void UpdateInformation(User user)
        {
            UserDao.UpdateUserInfo(user);
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
