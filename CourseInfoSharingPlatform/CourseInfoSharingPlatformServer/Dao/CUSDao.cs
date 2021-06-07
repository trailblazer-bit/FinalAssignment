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
        // 根据用户名和课程id查询用户对该课程的打分
        public static int GetScoreByUserNameAndQuestionId(string name, int id)
        {
            return 0;
        }

        // 根据用户名和课程id查询用户对该课程的打分
        public static bool AddScoreByUserNameAndQuestionId(CUS cus)
        {
            return false;
        }

        // 查询课程平均分
        public static double GetAveScoreByCourseId(string id)
        {
            return 0;
        }
    }
}
