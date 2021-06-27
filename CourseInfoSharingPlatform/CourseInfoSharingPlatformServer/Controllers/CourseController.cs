using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Models;
using EFDemo.Dao;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatformServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private Context context;

        public CourseController(Context context)
        {
            this.context = context;
            ContextUtil.Context = context;
        }
        [HttpGet]
        public ActionResult<Course> SelectCourseById(string id)
        {
            return CourseDao.SelectCourseById(id);
        }

        [HttpGet("all")]
        public ActionResult<List<Course>> test1()
        {
            return CourseDao.SelectAllCourse();
        }
    }
}
