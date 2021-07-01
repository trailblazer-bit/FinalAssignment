using CourseInfoSharingPlatformServer.Models;
using EFDemo.Dao;
using System.IO;
using System.Net;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatformServer.Service
{

    //处理和评论区有关的操作，包括展示、点赞、举报、回复等
    public class CommentService
    {
        // 根据问题id字符串将相应问题的LikeNum字段加1
        public static bool AddLikeNumToQuestions(string ids)
        {
            if (ids.Length <= 0) return false;
            string[] idList = ids.Split(",");
            foreach (string id in idList)
            {
                if (!QuestionDao.AddLikeNumToQuestion(int.Parse(id))) return false;
            }
            return true;
        }

        // 根据评论id字符串将相应问题的LikeNum字段加1
        public static bool AddLikeNumToComments(string ids)
        {
            if (ids.Length <= 0) return false;
            string[] idList = ids.Split(",");
            foreach (string id in idList)
            {
                if (!CommentDao.AddLikeNumToComment(int.Parse(id))) return false;
            }
            return true;
        }
        //用户添加问题
        public static bool AddQuestion(string detail,string userName,string courseId)
        {
            if (!CheckIfTextValid(detail)) return false;
            Question q = new Question();
            q.Detail = detail;
            q.RelatedUser = UserDao.SelectUserByUserName(userName);
            q.RelatedCourse = CourseDao.SelectCourseById(courseId);
            return QuestionDao.AddQuestion(q);
        }

        // 添加问题回复（评论）
        public static bool AddComments(string comment, string userName, int questionId)
        {
            if (!CheckIfTextValid(comment)) return false;
            Comment c = new Comment();
            c.Detail = comment;
            c.RelatedUser = UserDao.SelectUserByUserName(userName);
            c.RelatedQuestion = QuestionDao.SelectQuestionById(questionId);
            return CommentDao.AddComment(c);
        }

        // 检测评论内容是否合乎规范
        public static bool CheckIfTextValid(string s)
        {
            try
            {
                string token = "24.84eb94dbc913fe93db82f59485fe4a0e.2592000.1627659899.282335-24470031";
                string host = "https://aip.baidubce.com/rest/2.0/solution/v1/text_censor/v2/user_defined?access_token=" + token;
                Encoding encoding = Encoding.Default;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
                request.Method = "post";
                request.KeepAlive = true;
                String str = "text=" + s;
                byte[] buffer = encoding.GetBytes(str);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string result = reader.ReadToEnd();
                ///Console.WriteLine("文本审核接口:");
                ///Console.WriteLine(result);
                return !result.Contains("不合规");
            }
            catch (Exception e)
            {
                return true;
            }           
        }

        // 举报评论
        public static bool ReportComment(int commentId, string reason)
        {
            return CommentDao.ReportComment(commentId, reason);
        }

        // 举报问题
        public static bool ReportQuestion(int questionId, string reason)
        {
            return QuestionDao.ReportQuestion(questionId, reason);
        }

        // 根据id获取问题
        public static Question GetQuestionById(int id)
        {
            return QuestionDao.SelectQuestionById(id);
        }

        // 根据id删除问题
        public static bool DeleteQuestionById(int id)
        {
            return QuestionDao.DeleteQuestionById(id);
        }

        // 根据id删除评论
        public static bool DeleteCommentById(int id)
        {
            return CommentDao.DeleteCommentById(id);
        }

        // 获取所有被举报问题
        public static List<Question> GetAllReportedQuestion()
        {
            return QuestionDao.GetAllReportedQuestion();
        }

        // 获取所有被举报评论
        public static List<Comment> GetAllReportedComment()
        {
            return CommentDao.GetReportedComments();
        }


        // 根据id将指定问题举报字段置为False
        public static bool IgnoreQuestionReport(int id)
        {
            return QuestionDao.IgnoreQuestionReport(id);
        }


        // 根据id将指定回复举报字段置为False
        public static bool IgnoreCommentReport(int id)
        {
            return CommentDao.IgnoreCommentReport(id);
        }
    }
}
