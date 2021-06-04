using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Dao
{
    class CourseDao
    {
        // 根据课头号增加课程
        public static Course SelectCourseById(string id)
        {
            Course course = null;

            return course;
        }

        // 查询所有课程
        public static List<Course> SelectAllCourse()
        {
            List<Course> courses = null;

            return courses;
        }

        // 根据课程类型查询课程
        public static List<Course> SelectCourseByType(string type)
        {
            List<Course> courses = null;

            return courses;
        }

        // 根据授课老师名查询课程
        public static List<Course> SelectCourseByTeacherName(string name)
        {
            List<Course> courses = null;

            return courses;
        }

        // 根据课程名查询课程
        public static List<Course> SelectCourseByCourseName(string name)
        {
            List<Course> courses = null;

            return courses;
        }

        // 增添课程
        public static bool AddCourse(Course course) 
        {
            bool flag = false;


            return flag;
        }

        // 修改课程
        public static bool UpdateCourse(Course course)
        {
            bool flag = false;


            return flag;
        }
    }
}
