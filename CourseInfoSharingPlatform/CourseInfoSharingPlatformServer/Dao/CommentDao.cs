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
    }
}
