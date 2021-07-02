using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Models;
using CourseInfoSharingPlatformServer.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        // 举报问题
        [HttpGet("reportQuestion")]
        public ActionResult<bool> reportQuestion(int questionId, string reason)
        {
            return CommentService.ReportQuestion(questionId, reason);
        }

        //添加问题
        [HttpGet("addQuestion")]
        public ActionResult<bool> AddQuestion(string detail, string userName, string courseId)
        {
            return CommentService.AddQuestion(detail, userName, courseId);

        }
        // 根据id获取问题
        [HttpGet("getQuestionById")]
        public ActionResult<Question> GetQuestionById(int id)
        {
            return CommentService.GetQuestionById(id);
        }

        //根据id删除问题
        [HttpGet("deleteQuestionById")]
        public ActionResult<bool> DeleteQuestionById(int id)
        {
            return CommentService.DeleteQuestionById(id);
        }

        // 根据id删除评论
        [HttpGet("deleteCommentById")]
        public ActionResult<bool> DeleteCommentById(int id)
        {
            return CommentService.DeleteCommentById(id);
        }

        //忽略被举报的问题
        [HttpGet("ignoreQuestionReport")]
        public ActionResult<bool> IgnoreQuestionReport(int id)
        {
           return  CommentService.IgnoreQuestionReport(id);
        }
        //忽略被举报的评论
        [HttpGet("ignoreCommentReport")]
        public ActionResult<bool> IgnoreCommentReport(int id)
        {
            return CommentService.IgnoreCommentReport(id);
        }
        //查询所有被举报的问题
        [HttpGet("getAllQuestionReport")]
        public ActionResult<List<Question>> GetAllQuestionReport()
        {
            return CommentService.GetAllReportedQuestion();        
        }
        //查询所有被举报的回复
        [HttpGet("getAllCommentReport")]
        public ActionResult<List<Comment>> GetAllCommentReport()
        {
            return CommentService.GetAllReportedComment();
        }
    }
}
