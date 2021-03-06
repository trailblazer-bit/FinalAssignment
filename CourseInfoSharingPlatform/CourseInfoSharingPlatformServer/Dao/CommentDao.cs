using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Dao
{
    class CommentDao
    {
        private static Context context = ContextUtil.Context;
        // 根据问题查询评论
        public static List<Comment> SelectCommentByQuestionId(int id)
        {
            return context.Comments.Include("RelatedUser").Include("RelatedQuestion").Where(c => c.RelatedQuestion.QuestionId.Equals(id)).ToList();
        }

        // 根据id删除评论
        public static bool DeleteCommentById(int id)
        {
            var comment = context.Comments.SingleOrDefault(c => c.CommentId.Equals(id));
            if (comment == null) return false;

            context.Comments.Remove(comment);
            context.SaveChanges();
            return true;
        }

        // 根据id更新评论
        public static bool UpdateComment(Comment comment)
        {
            bool flag1 = DeleteCommentById(comment.CommentId);
            if (!flag1) return false;

            return AddComment(comment);
        }

        // 添加评论（需要在Comment中设置Question引用）
        public static bool AddComment(Comment comment)
        {
            if (context.Comments.SingleOrDefault(c => c.CommentId.Equals(comment.CommentId)) != null) return false;
            context.Comments.Add(comment);
            return context.SaveChanges() >= 1;
        }

        // 将评论的LikeNum字段加1
        public static bool AddLikeNumToComment(int id)
        {
            var q = context.Comments.SingleOrDefault(c => c.CommentId.Equals(id));
            if (q == null) return false;
            q.LikeNum++;
            context.SaveChanges();
            return true;
        }

        //举报评论
        public static bool ReportComment(int commentId, string reason)
        {
            var c = context.Comments.SingleOrDefault(c => c.CommentId.Equals(commentId));
            if (c == null) return false;
            c.IsReported = true;
            c.Reason = reason;
            context.SaveChanges();
            return true;
        }

        // 获取所有被举报评论
        public static List<Comment> GetReportedComments()
        {
            return context.Comments.Where(c => c.IsReported == true).Include(c=>c.RelatedUser).ToList();
        }

        public static bool IgnoreCommentReport(int id)
        {
            var c = context.Comments.SingleOrDefault(c => c.CommentId.Equals(id) && c.IsReported == true);
            if (c == null) return false;
            c.IsReported = false;
            context.SaveChanges();
            return true;
        }
    }
}
