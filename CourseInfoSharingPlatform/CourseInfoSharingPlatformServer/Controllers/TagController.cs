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
        [HttpGet("addLikeNumToTags")]
        public ActionResult<bool> AddLikeNumToTags(string ids)
        {
            if (ids.Length == 0) return false;
            else return TagService.AddLikeNumToTags(ids);
        }
    }
}
