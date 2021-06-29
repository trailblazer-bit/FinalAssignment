using CourseInfoSharingPlatformServer.Service;
using Microsoft.AspNetCore.Mvc;


namespace CourseInfoSharingPlatformServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CommentController:ControllerBase
    {
        [HttpGet("addLikeNumToQuestions")]
        public ActionResult<bool> AddLikeNumToQuestions(string ids)
        {
            if (ids.Length == 0) return false;
            else return CommentService.AddLikeNumToQuestions(ids);
        }

        [HttpGet("addLikeNumToComments")]
        public ActionResult<bool> AddLikeNumToComments(string ids)
        {
            if (ids.Length == 0) return false;
            else return CommentService.AddLikeNumToQuestions(ids);
        }

        [HttpGet("addComments")]
        public ActionResult<bool> AddComments(string comment, string userName, int questionId)
        {
            return CommentService.AddComments(comment, userName, questionId);
        }

        [HttpGet("reportComment")]
        public ActionResult<bool> reportComment(int commentId, string reason)
        {
            return CommentService.ReportComment(commentId, reason);
        }
    }
}
