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

        //给指定的问题点赞
        public static void AddLikeNumToQuestion(List<int> likedQuestionId)
        {
            string url = baseUrl;
            if (likedQuestionId.Count == 0) return;
            url += "/addLikeNumToQuestions?ids=";
            int i;
            for (i = 0; i < likedQuestionId.Count - 1; i++)
            {
                url += (likedQuestionId[i] + ",");
            }
            url += likedQuestionId[i]; 
            Dictionary<string, string> d = new Dictionary<string, string>();
            ClientHttp.GET(url, d);
        }

        //给指定的评论点赞
        public static void AddLikeNumToComments(List<int> likedCommentId)
        {
            string url = baseUrl + "/addLikeNumToComments?ids=";
            if (likedCommentId.Count == 0) return ;
            int i;
            for (i = 0; i < likedCommentId.Count - 1; i++)
            {
                url += (likedCommentId[i] + ",");
            }
            url += likedCommentId[i];
            Dictionary<string, string> d = new Dictionary<string, string>();
            ClientHttp.GET(url, d);
        }
    }
}
