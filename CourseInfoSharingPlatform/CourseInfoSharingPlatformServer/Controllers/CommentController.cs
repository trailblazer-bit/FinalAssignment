using CourseInfoSharingPlatformServer.Service;
using Microsoft.AspNetCore.Mvc;


namespace CourseInfoSharingPlatformServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CommentController:ControllerBase
    {
        [HttpGet("addLikeNumToQuestions")]
        public ActionResult<bool> GetAllCourseOrderByHeatNum(string ids)
        {
            if (ids.Length == 0) return false;
            else CommentService.AddLikeNumToQuestions(ids);
            return true;
        }
    }
}
