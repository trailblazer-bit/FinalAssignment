using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Dao
{
    class UserDao
    {
        private static Context context = ContextUtil.Context;
        // 根据用户名查询相应的用户，返回User对象
        public static User SelectUserByUserName(string name)
        {
            var user = context.Users.SingleOrDefault(u => u.UserName.Equals(name));
            return user;
        }

        // 根据用户名查询相应的用户，返回User对象，同时查询用户的收藏课程
        public static User SelectUserByUserNameWithCourse(string name)
        {
            var user = context.Users.Include("LikeCourses").SingleOrDefault(u => u.UserName.Equals(name));
            return user;
        }


        // 删除用户喜爱课程
        public static bool DeleteFavouriteCourse(string userName, string courseId)
        {
            var course = context.Courses.FirstOrDefault(c => c.CourseId.Equals(courseId));
            if (course == null) return false;

            var user = context.Users.Include("LikeCourses")
                .SingleOrDefault(u => u.UserName.Equals(userName));

            if (user == null) return false;
            if (!user.LikeCourses.Contains(course)) return false;

            user.LikeCourses.Remove(course);
            context.SaveChanges();
            return true;
        }

        //查询用户是否收藏某课
        public static bool IsLikedCourse(string courseId,string userName)
        {
            var course = context.Courses.FirstOrDefault(c => c.CourseId.Equals(courseId));
            var user = context.Users.Include("LikeCourses")
                .SingleOrDefault(u => u.UserName.Equals(userName));
            if (user.LikeCourses.Contains(course)) return true;
            return false;
        }

        // 添加用户喜爱课程
        public static bool AddFavouriteCourse(string userName, string courseId)
        {

            var course = context.Courses.FirstOrDefault(c => c.CourseId.Equals(courseId));
            if (course == null) return false;

            var user = context.Users.Include("LikeCourses")
                .SingleOrDefault(u => u.UserName.Equals(userName));

            if (user == null) return false;
            if (user.LikeCourses.Contains(course)) return false;

            user.LikeCourses.Add(course);
            context.SaveChanges();
            return true;

        }

        // 添加User对象
        public static bool AddUser(User user)
        {

            context.Users.Add(user);
            var flag = context.SaveChanges();
            if (flag == 1) return true;
            return false;

        }

        // 传入User对象进行用户信息更新(除了用户名、密码和收藏课程)
        public static bool UpdateUserInfo(User user)
        {

            var queryUser = context.Users.SingleOrDefault(u => u.UserName.Equals(user.UserName));
            if (queryUser == null) return false;

            queryUser.Gender = user.Gender;
            queryUser.Grade = user.Grade;
            queryUser.Introduction = user.Introduction;
            queryUser.Major = user.Major;

            int flag = context.SaveChanges();
            if (flag == 1) return true;
            return false;

        }

        // 传入User对象进行密码更改
        public static bool UpdateUserPassword(string name, string pwd)
        {

            var queryUser = context.Users.SingleOrDefault(u => u.UserName.Equals(name));
            if (queryUser == null) return false;

            queryUser.Password = pwd;

            int flag = context.SaveChanges();
            if (flag == 1) return true;
            return false;

        }
    }
}
