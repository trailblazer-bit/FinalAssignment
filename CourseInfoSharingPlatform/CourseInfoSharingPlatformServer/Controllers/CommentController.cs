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

        //添加回复
        [HttpGet("addComments")]
        public ActionResult<bool> AddComments(string comment, string userName, int questionId)
        {
            return CommentService.AddComments(comment, userName, questionId);
        }

        //举报评论
        [HttpGet("reportComment")]
        public ActionResult<bool> reportComment(int commentId, string reason)
        {
            return CommentService.ReportComment(commentId, reason);
        }

        //添加问题
        [HttpGet("addQuestion")]
        public ActionResult<bool> AddQuestion(string detail, string userName, string courseId)
        {
            return CommentService.AddQuestion(detail, userName, courseId);
<<<<<<< HEAD
        }
        //根据id获取问题
=======

        }

        // 根据id获取问题
>>>>>>> ef08cf7531f19a757de9c3bdf31b045b04fd26cb
        [HttpGet("getQuestionById")]
        public ActionResult<Question> GetQuestionById(int id)
        {
            return CommentService.GetQuestionById(id);
        }

<<<<<<< HEAD
        //根据id删除问题
=======
        // 根绝id删除问题
>>>>>>> ef08cf7531f19a757de9c3bdf31b045b04fd26cb
        [HttpGet("deleteQuestionById")]
        public ActionResult<bool> DeleteQuestionById(int id)
        {
            return CommentService.DeleteQuestionById(id);
        }
<<<<<<< HEAD
        //根据id删除评论
=======

        // 根据id删除评论
>>>>>>> ef08cf7531f19a757de9c3bdf31b045b04fd26cb
        [HttpGet("deleteCommentById")]
        public ActionResult<bool> DeleteCommentById(int id)
        {
            return CommentService.DeleteCommentById(id);
        }
    }
}
