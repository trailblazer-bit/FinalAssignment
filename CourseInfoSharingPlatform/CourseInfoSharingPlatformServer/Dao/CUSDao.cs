using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Dao
{
    class CUSDao
    {
        private static Context context = ContextUtil.Context;
        // 根据用户名和课程id查询用户对该课程的打分
        public static int GetScoreByUserNameAndCourseId(string name, string id)
        {
            var cus = context.CUS.SingleOrDefault(cus => cus.UserName.Equals(name) && cus.CourseId.Equals(id));
            if (cus == null) return 0;
            return cus.Score;
        }

        // 添加用户对课程的打分
        public static bool AddScore(CUS cus)
        {
            if (CourseDao.SelectCourseById(cus.CourseId) == null) return false;
            if (UserDao.SelectUserByUserName(cus.UserName) == null) return false;
            context.CUS.Add(cus);
            return context.SaveChanges() >= 1;
        }

        // 查询课程平均分
        public static double GetAveScoreByCourseId(string id)
        {
            if (CourseDao.SelectCourseById(id) == null) return 0;
            List<CUS> cusList = context.CUS.Where(cus => cus.CourseId.Equals(id)).ToList();
            int totalScore = 0;
            foreach (CUS cus in cusList)
            {
                totalScore += cus.Score;
            }
            return totalScore * 1.0 / cusList.Count;
        }
    }
}
