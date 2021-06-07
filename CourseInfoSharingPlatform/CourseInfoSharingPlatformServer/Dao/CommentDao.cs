using CourseInfoSharingPlatformServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Dao
{
    class CommentDao
    {
        // 根据问题查询评论
        public static List<Comment> SelectCommentByQuestionId(int id)
        {
            return null;
        }

        // 根据id删除评论
        public static bool DeleteCommentById(int id)
        {
            return false;
        }

        // 根据id删除评论
        public static bool UpdateCommentById(Comment comment)
        {
            return false;
        }

        // 添加评论（需要在Comment中设置Question引用）
        public static bool AddComment(Comment comment)
        {
            return false;
        }
    }
}
