using CourseInfoSharingPlatform.Models;
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
        //添加问题
        public static bool AddQuestion(string detail,string userName,string courseId)
        {
            string url = baseUrl + "/addQuestion";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("detail", detail);
            d.Add("userName", userName);
            d.Add("courseId", courseId);                  
            var result = ClientHttp.GET(url, d);
            return bool.Parse(result);
        }

        //举报评论
        public static bool reportComment(int commentId, string reason)
        {
            string url = baseUrl + "/reportComment";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("commentId", commentId.ToString());
            d.Add("reason", reason);
            var result = ClientHttp.GET(url, d);
            return bool.Parse(result);
        }
        // 举报问题
        public static bool reportQuestion(int questionId, string reason)
        {
            string url = baseUrl + "/reportQuestion";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("questionId",questionId.ToString());
            d.Add("reason", reason);
            var result = ClientHttp.GET(url, d);
            return bool.Parse(result);
        }

        //添加回复
        public  static bool AddComments(string comment, string userName, int questionId)
        {
            string url = baseUrl + "/addComments";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("comment", comment);
            d.Add("userName", userName);
            d.Add("questionId", questionId.ToString());
            var result = ClientHttp.GET(url, d);
            return bool.Parse(result);
        }
        public static bool ById(string url,int id)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("id", id.ToString());
            var result = ClientHttp.GET(url, d);
            return bool.Parse(result);
        }
        //根据id获取问题
        public static Question GetQuestionById(int id)
        {
            string url = baseUrl + "/getQuestionById";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("id", id.ToString());
            var result = ClientHttp.GET(url, d);
            Question q = Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(Question)) as Question;
            return q;
        }
        //根据id删除问题
        public static bool deleteQuestionById(int id)
        {
            string url = baseUrl + "/deleteQuestionById";
            return ById(url, id);
        }
        //根据id删除回复
        public static bool deleteCommentById(int id)
        {
            string url = baseUrl + "/deleteCommentById";
            return ById(url,id);
        }
        //忽略被举报的问题
        public static bool IgnoreQuestionReport(int id)
        {
            string url = baseUrl + "/ignoreQuestionReport";
            return ById(url, id);
        }
        //忽略被举报的评论
        public static bool IgnoreCommentReport(int id)
        {
            string url = baseUrl + "/ignoreCommentReport";
            return ById(url, id);
        }
        //查询所有被举报的问题
        public static List<Question> GetAllQuestionReport()
        {
            string url = baseUrl + "/getAllQuestionReport";
            Dictionary<string, string> d = new Dictionary<string, string>();
            var result = ClientHttp.GET(url, d);
            if (result == null) return null;
            List<Question> questions=Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Question>)) as List<Question>;
            return questions;
        }
        //查询所有被举报的回复
        public static List<Comment> GetAllCommentReport()
        {
            string url = baseUrl + "/getAllCommentReport";
            Dictionary<string, string> d = new Dictionary<string, string>();
            var result = ClientHttp.GET(url, d);
            if (result == null) return null;
            List<Comment> comments = Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Comment>)) as List<Comment>;
            return comments;
        }
    }
}
