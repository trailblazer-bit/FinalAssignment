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
        //用户收藏课程
        public static bool AddFavoriteCourse(string courseId,string userName)
        {
            string url = baseUrl + "/addLikeCourse";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("courseId", courseId);
            d.Add("userName", userName);
            var result = ClientHttp.GET(url, d);
            bool flag = (bool)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(bool));
            return flag;
        }
    }
}
