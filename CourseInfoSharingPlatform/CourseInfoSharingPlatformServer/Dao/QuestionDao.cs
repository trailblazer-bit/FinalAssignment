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
    class QuestionDao
    {
        private static Context context = ContextUtil.Context;

        // 添加问题
        public static bool AddQuestion(Question question)
        {
            var q = context.Questions.FirstOrDefault(q => q.QuestionId.Equals(question.QuestionId));
            if (q != null) return false;

            context.Questions.Add(question);
            context.SaveChanges();
            return true;
        }

        // 删除问题（并且级联删除Tag和Comment）
        public static bool DeleteQuestionById(int id)
        {
            var q = context.Questions.Include(q => q.QuestionTags).Include(q => q.CommentList)
                .FirstOrDefault(q => q.QuestionId.Equals(id));
            if (q == null) return false;

            for (int i = 0; i < q.QuestionTags.Count; i++)
            {
                TagDao.RemoveTagById(q.QuestionTags[i].TagId);
            }

            for (int i = 0; i < q.CommentList.Count; i++)
            {
                CommentDao.DeleteCommentById(q.CommentList[i].CommentId);
            }

            context.Questions.Remove(q);
            context.SaveChanges();
            return true;
        }

        // 更新问题
        public static bool UpdateQuestion(Question question)
        {
            if (!DeleteQuestionById(question.QuestionId)) return false;
            return AddQuestion(question);
        }

        public static Question SelectQuestionById(int id)
        {
            return context.Questions
                .Include(q => q.QuestionTags).Include(q => q.RelatedCourse)
                .Include(q => q.RelatedUser).Include(q => q.CommentList).ThenInclude(r=>r.RelatedUser)
               .SingleOrDefault(q => q.QuestionId.Equals(id));
        }

        public static bool AddLikeNumToQuestion(int id)
        {
            var q = context.Questions.SingleOrDefault(q => q.QuestionId.Equals(id));
            if (q == null) return false;
            q.LikeNum++;
            context.SaveChanges();
            return true;
        }
    }
}
