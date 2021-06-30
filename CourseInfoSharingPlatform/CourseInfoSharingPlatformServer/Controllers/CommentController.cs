using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Models;
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

        [HttpGet("getQuestionById")]
        public ActionResult<Question> GetQuestionById(int id)
        {
            return CommentService.GetQuestionById(id);
        }

        [HttpGet("deleteQuestionById")]
        public ActionResult<bool> DeleteQuestionById(int id)
        {
            return CommentService.DeleteQuestionById(id);
        }

        [HttpGet("deleteCommentById")]
        public ActionResult<bool> DeleteCommentById(int id)
        {
            return CommentService.DeleteCommentById(id);
        }
    }
}
