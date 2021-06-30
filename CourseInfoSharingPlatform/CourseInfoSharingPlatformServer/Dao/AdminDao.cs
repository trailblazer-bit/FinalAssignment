using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Dao
{
    class AdminDao
    {

        // 根据管理员名字查询管理员信息，返回Admin对象
        public static Admin SelectAdminByAdminName(string name)
        {
            var context = ContextUtil.Context;
            var admin = context.Admins.SingleOrDefault(ad => ad.AdminName.Equals(name));
            if (admin == null) return null;
            else return admin;
        }
        // Admin进行密码更改
        public static bool UpdateUserPassword(string name, string pwd)
        {
            var context = ContextUtil.Context;
            var queryUser = context.Admins.SingleOrDefault(u => u.AdminName.Equals(name));
            if (queryUser == null) return false;

            queryUser.Password = pwd;

            int flag = context.SaveChanges();
            if (flag == 1) return true;
            return false;

        }
    }
}
