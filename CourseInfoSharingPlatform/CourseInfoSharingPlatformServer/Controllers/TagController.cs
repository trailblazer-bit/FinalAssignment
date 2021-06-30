using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatformServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TagController
    {
        private Context context;

        public TagController(Context context)
        {
            this.context = context;
            ContextUtil.Context = context;
        }
        //给指定的标签点赞
        [HttpGet("addLikeNumToTags")]
        public ActionResult<bool> AddLikeNumToTags(string ids)
        {
            if (ids.Length == 0) return false;
            else return TagService.AddLikeNumToTags(ids);
        }

        [HttpGet("addTag")]
        public ActionResult<bool> AddTag(string detail, int questionId)
        {
            return TagService.AddTag(detail, questionId);
        }
    }
}
