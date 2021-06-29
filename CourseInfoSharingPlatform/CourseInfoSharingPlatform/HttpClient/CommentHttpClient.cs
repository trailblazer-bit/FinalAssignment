using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.ClientHttp
{
    class CommentHttpClient
    {
       
        private static string baseUrl = "https://localhost:44386/api/comment";

        public static void AddLikeNumToQuestion(List<int> likedQuestionId)
        {
            string url = baseUrl;
            if(likedQuestionId.Count!=0)
            {
                url += "/addLikeNumToQuestions?ids=";
                string str = null;
                int i;
                for (i=0;i<likedQuestionId.Count-1;i++)
                {
                    str += (likedQuestionId[i] + ",");
                }
                str += likedQuestionId[i];
            }
            Dictionary<string, string> d = new Dictionary<string, string>();
            ClientHttp.GET(url, d);
        }
    }
}
