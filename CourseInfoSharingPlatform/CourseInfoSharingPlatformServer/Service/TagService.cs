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
    }
}
