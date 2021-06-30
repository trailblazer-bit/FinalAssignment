using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Service;
using Microsoft.AspNetCore.Mvc;


namespace CourseInfoSharingPlatformServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CommentController:ControllerBase
    {
        private Context context;

        public CommentController(Context context)
        {
            this.context = context;
            ContextUtil.Context = context;
        }
        //给指定的问题点赞
        [HttpGet("addLikeNumToQuestions")]
        public ActionResult<bool> AddLikeNumToQuestions(string ids)
        {
            if (ids.Length == 0) return false;
            else return CommentService.AddLikeNumToQuestions(ids);
        }

        //给指定的评论点赞
        [HttpGet("addLikeNumToComments")]
        public ActionResult<bool> AddLikeNumToComments(string ids)
        {
            if (ids.Length == 0) return false;
            else return CommentService.AddLikeNumToComments(ids);
        }
    }
}
