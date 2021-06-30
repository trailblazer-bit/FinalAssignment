using CourseInfoSharingPlatformServer.Models;
using EFDemo.Dao;
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

        // 添加问题回复（评论）
        public static bool AddComments(string comment, string userName, int questionId)
        {
            if (!CheckIfCommentValid(comment)) return false;
            Comment c = new Comment();
            c.Detail = comment;
            c.RelatedUser = UserDao.SelectUserByUserName(userName);
            c.RelatedQuestion = QuestionDao.SelectQuestionById(questionId);
            return CommentDao.AddComment(c);
        }

        // 检测评论内容是否合乎规范
        public static bool CheckIfCommentValid(string comment)
        {
            return true;
        }

        // 举报评论
        public static bool ReportComment(int commentId, string reason)
        {
            return CommentDao.ReportComment(commentId, reason);
        }

        public static Question GetQuestionById(int id)
        {
            return QuestionDao.SelectQuestionById(id);
        }

        public static bool DeleteQuestionById(int id)
        {
            return QuestionDao.DeleteQuestionById(id);
        }

        public static bool DeleteCommentById(int id)
        {
            return CommentDao.DeleteCommentById(id);
        }
    }
}
