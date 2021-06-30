using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Dao
{
    class TagDao
    {
        private static Context context = ContextUtil.Context;

        public static bool RemoveTagById(int id)
        {
            var tag = context.Tags.SingleOrDefault(t => t.TagId.Equals(id));
            if (tag == null) return false;

            context.Tags.Remove(tag);
            context.SaveChanges();
            return true;
        }

        // 添加标签（id可以不指定）
        public static bool AddTag(Tag tag)
        {
            if (QuestionDao.SelectQuestionById(tag.RelatedQuestion.QuestionId) == null) 
                return false;
            context.Tags.Add(tag);
            var flag = context.SaveChanges();
            return flag >= 1;
        }

        // 更新标签
        public static bool UpdateTag(Tag tag)
        {
            bool flag1 = RemoveTagById(tag.TagId);
            if (!flag1) return false;

            bool flag2 = AddTag(tag);
            return flag2;
        }

        public static List<Tag> SelectTagsByQuestionId(int id)
        {
            return context.Tags.Where(t => t.RelatedQuestion.QuestionId.Equals(id)).ToList();
        }

        public static bool AddLikeNumToTag(int id)
        {
            var tag = context.Tags.SingleOrDefault(t => t.TagId.Equals(id));
            if (tag == null) return false;
            tag.LikeNum++;
            context.SaveChanges();
            return true;
        }
    }
}
