using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.ClientHttp
{
    class TagHttpClient
    {
        private static string baseUrl = "https://localhost:44386/api/tag";

        //给指定的标签点赞
        public  static void AddLikeNumToTags(List<int> likedTagId)
        {
            string url = baseUrl + "/addLikeNumToTags?ids=";
            if (likedTagId.Count == 0) return;
            int i;
            for (i = 0; i < likedTagId.Count - 1; i++)
            {
                url += (likedTagId[i] + ",");
            }
            url += likedTagId[i];
            Dictionary<string, string> d = new Dictionary<string, string>();
            ClientHttp.GET(url, d);
        }
        //添加标签
        public static bool AddTag(string detail, int questionId)
        {
            string url = baseUrl + "/addTag";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("detail", detail);
            d.Add("questionId", questionId.ToString());           
            var result = ClientHttp.GET(url, d);
            return bool.Parse(result);
        }
    }
}
