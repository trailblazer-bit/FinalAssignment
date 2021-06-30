using CourseInfoSharingPlatformServer.Models;
using EFDemo.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatformServer.Service
{

    //处理和标签有关的操作
    public class TagService
    {
        public static bool AddLikeNumToTags(string ids)
        {
            if (ids.Length <= 0) return false;
            string[] idList = ids.Split(",");
            foreach (string id in idList)
            {
                if (!TagDao.AddLikeNumToTag(int.Parse(id)))return false;
            }
            return true;
        }

        //用户添加标签
        public static bool AddTag(string detail, int questionId)
        {
            if (!CheckIfTagValid(detail)) return false;
            Tag tag = new Tag();
            tag.Detail = detail;
            tag.RelatedQuestion = QuestionDao.SelectQuestionById(questionId);
            if (tag.RelatedQuestion == null) return false;
            return TagDao.AddTag(tag);
        }

        // 判断标签内容是否符合规范
        public static bool CheckIfTagValid(string detail)
        {
            return true;
        }
    }
}
