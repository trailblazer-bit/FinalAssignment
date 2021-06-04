using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Dao
{
    class UserDao
    {
        // 根据用户名查询相应的用户，返回User对象
        public static User SelectUserByUserName(string name)
        {
            User user = null;

            return user;
        }

        // 根据用户名查询相应的用户，返回User对象，同时查询用户的收藏课程
        public static User SelectUserByUserNameWithCourse(string name)
        {
            User user = null;

            return user;
        }

        // 删除用户喜爱课程
        public static bool DeleteFavouriteCourse(string userName, string courseId)
        {
            bool flag = false;

            return flag;
        }

        // 传入User对象
        public static bool AddUser(User user)
        {
            bool flag = false;

            return flag;
        }

        // 传入User对象进行用户信息更新
        public static bool UpdateUserInfo(User user) 
        {
            bool flag = false;

            return flag;
        }

        // 传入User对象进行密码更改
        public static bool UpdateUserPassword(string name, string pwd)
        {
            bool flag = false;

            return flag;
        }
    }
}
