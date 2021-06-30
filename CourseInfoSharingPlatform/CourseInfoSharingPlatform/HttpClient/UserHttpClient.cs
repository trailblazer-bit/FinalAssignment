using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.ClientHttp
{
    class UserHttpClient
    {
        private static string baseUrl = "https://localhost:44386/api/user";

        public static bool LikedCourse(string url,string courseId,string userName)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("courseId", courseId);
            d.Add("userName", userName);
            var result = ClientHttp.GET(url, d);
            bool flag = (bool)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(bool));
            return flag;
        }

        //判断用户是否收藏课程
        public static bool IsLikedCourse(string courseId,string userName)
        {
            string url = baseUrl + "/isLikedCourse";
            return LikedCourse(url, courseId, userName);
        }
        //用户收藏课程
        public static bool AddFavoriteCourse(string courseId,string userName)
        {
            string url = baseUrl + "/addLikeCourse";
            return LikedCourse(url, courseId, userName);
        }

        // 获取用户给课程打分
        public static int GetScore(string courseId, string userName)
        {
            string url = baseUrl + "/getScore";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("courseId", courseId);
            d.Add("userName", userName);
            var result = ClientHttp.GET(url, d);
            int score = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(int));
            return score;
        }

        // 用户给课程打分
        public static bool AddScore(string courseId, string userName, int score)
        {
            string url = baseUrl + "/addScore";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("courseId", courseId);
            d.Add("userName", userName);
            d.Add("score", score.ToString());
            var result = ClientHttp.GET(url, d);
            bool flag = (bool)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(bool));
            return flag;
        }
    }
}
