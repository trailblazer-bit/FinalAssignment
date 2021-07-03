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
        // 按照收藏数查询所有的课程
        [HttpGet("orderByLikeNum")]
        public ActionResult<List<Course>> GetAllCourseOrderByLikeNum(int startIndex, int pageSize)
        {
            return CourseService.GetAllCourseOrderByLikeNum(startIndex, pageSize);
        }

        // 按照热度查询所有的课程
        [HttpGet("orderByHeatNum")]
        public ActionResult<List<Course>> GetAllCourseOrderByHeatNum(int startIndex, int pageSize)
        {
            return CourseService.GetAllCourseOrderByHeatNum(startIndex, pageSize);
        }

        // 根据类型查询课程，按照热度排序，startIndex从0开始
        [HttpGet("orderByHeatNum/byType")]
        public ActionResult<List<Course>> GetCourseByTypeOrderByHeatNum(string type, int startIndex, int pageSize)
        {
            return CourseService.GetCourseByTypeOrderByHeatNum(type, startIndex, pageSize);
        }

        // 根据教师名查询课程，按照热度排序，startIndex从0开始
        [HttpGet("orderByHeatNum/byTeacherName")]
        public ActionResult<List<Course>> GetCourseByTeacherNameOrderByHeatNum(string name, int startIndex, int pageSize)
        {
            return CourseService.GetCourseByTeacherNameOrderByHeatNum(name, startIndex, pageSize);
        }

        // 根据课程名查询课程，按照热度排序，startIndex从0开始
        [HttpGet("orderByHeatNum/byCourseName")]
        public ActionResult<List<Course>> GetCourseByCourseNameOrderByHeatNum(string name, int startIndex, int pageSize)
        {
            return CourseService.GetCourseByCourseNameOrderByLikeNum(name, startIndex, pageSize);
        }

        // 根据类型查询课程，按照收藏数排序，startIndex从0开始
        [HttpGet("orderByLikeNum/byType")]
        public ActionResult<List<Course>> GetCourseByTypeOrderByLikeNum(string type, int startIndex, int pageSize)
        {
            return CourseService.GetCourseByTypeOrderByLikeNum(type, startIndex, pageSize);
        }

        // 根据教师名查询课程，按照收藏数排序，startIndex从0开始
        [HttpGet("orderByLikeNum/byTeacherName")]
        public ActionResult<List<Course>> GetCourseByTeacherNameOrderByLikeNum(string name, int startIndex, int pageSize)
        {
            return CourseService.GetCourseByTeacherNameOrderByLikeNum(name, startIndex, pageSize);
        }

        // 根据课程名查询课程，按照收藏数排序，startIndex从0开始
        [HttpGet("orderByLikeNum/byCourseName")]
        public ActionResult<List<Course>> GetCourseByCourseNameOrderByLikeNum(string name, int startIndex, int pageSize)
        {
            return CourseService.GetCourseByCourseNameOrderByLikeNum(name, startIndex, pageSize);
        }

        // 根据类型查询课程，默认按照评分排序，startIndex从0开始
        [HttpGet("orderByScore/byType")]
        public ActionResult<List<Course>> GetCourseByType(string type, int startIndex, int pageSize)
        {
            return CourseService.GetCourseByType(type, startIndex, pageSize);
        }

        // 根据课程名查询课程，默认按照评分排序，startIndex从0开始
        [HttpGet("orderByScore/byCourseName")]
        public ActionResult<List<Course>> GetCourseByCourseName(string name, int startIndex, int pageSize)
        {
            return CourseService.GetCourseByCourseName(name, startIndex, pageSize);
        }

        // 根据教师名查询课程，默认按照评分排序，startIndex从0开始
        [HttpGet("orderByScore/byTeacherName")]
        public ActionResult<List<Course>> GetCourseByTeacherName(string name, int startIndex, int pageSize)
        {
            return CourseService.GetCourseByTeacherName(name, startIndex, pageSize);
        }

        //默认查询所有课程时总页数
        [HttpGet("totalPageNum")]
        public  ActionResult<int> GetTotalPageNum()
        {
            return CourseService.GetTotalPageNum();
        }

        // 根据类型查询，返回页面数量,默认页面大小为4
        [HttpGet("totalPageNum/byType")]
        public ActionResult<int> GetPageNumByType(string type)
        {
            return CourseService.GetPageNumByType(type);
        }

        // 根据教师名查询，返回页面数量,默认页面大小为4
        [HttpGet("totalPageNum/byTeacherName")]
        public ActionResult<int> GetPageNumByTeacherName(string name)
        {
            return CourseService.GetPageNumByTeacherName(name);
        }

        // 根据课程名查询，返回页面数量,默认页面大小为4
        [HttpGet("totalPageNum/byCourseName")]
        public ActionResult<int> GetPageNumByCourseName(string name)
        {
            return CourseService.GetPageNumByCourseName(name);
        }

        //新添加一门课程
        [HttpPost("addCourse")]
        public ActionResult<bool> AddCourse(Course course)
        {
            return CourseService.AddCourse(course);
        }

        //获得三个相似课程
        [HttpGet("getSimilarCourses")]
        public ActionResult<List<Course>> GetSimilarCourses(string id)
        {
            return CourseService.GetSimilarCourses(id);
        }
    }
}
