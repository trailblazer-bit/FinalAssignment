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
    }
}
