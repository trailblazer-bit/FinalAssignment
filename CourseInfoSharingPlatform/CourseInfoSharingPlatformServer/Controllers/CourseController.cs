using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Models;
using CourseInfoSharingPlatformServer.Service;
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
        //根据课程id查询课程
        [HttpGet]
        public ActionResult<Course> GetCourseById(string id)
        {        
            return CourseService.GetCourseById(id);
        }

        //默认按照分数排序查找所有课程
        [HttpGet("orderByScore")]
        public ActionResult<List<Course>> GetAllCourse(int startIndex,int pageSize)
        {
            return CourseService.GetAllCourse(startIndex,pageSize);
        }

        [HttpGet("totalPageNum")]
        public  ActionResult<int> GetTotalPageNum()
        {
            return CourseService.GetTotalPageNum();
        }
    }
}
