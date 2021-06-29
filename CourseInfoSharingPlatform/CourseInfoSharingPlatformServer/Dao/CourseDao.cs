using CourseInfoSharingPlatformServer.Dao;
using CourseInfoSharingPlatformServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.Dao
{
    class CourseDao
    {
        private static Context context = ContextUtil.Context;
        // 根据课头号查询课程
        public static Course SelectCourseById(string id)
        {
            var course = context.Courses.Include(c => c.QuestionList).ThenInclude(q => q.QuestionTags)
                .Include(c => c.QuestionList).ThenInclude(q => q.RelatedUser)
                .Include(c => c.QuestionList).ThenInclude(q => q.CommentList).ThenInclude(r=>r.RelatedUser)
                .SingleOrDefault(c => c.CourseId.Equals(id));
            return course;
        }

        // 根据课头号查询课程以及喜爱该课程的用户对象
        public static Course SelectCourseByIdWithUserWhoLikeIt(string id)
        {
            var course = context.Courses.Include(c => c.UserWhoLikedCourse).SingleOrDefault(c => c.CourseId.Equals(id));
            return course;
        }

        // 查询所有课程
        public static List<Course> SelectAllCourse()
        {
            var courses = context.Courses.Include(c => c.QuestionList).ThenInclude(q => q.QuestionTags).ToList();
            return courses;
        }

        // 根据课程类型查询课程
        public static List<Course> SelectCourseByType(string type)
        {
            var courses = context.Courses.Include(c => c.QuestionList).ThenInclude(q => q.QuestionTags)
                .Where(c => c.Type.Contains(type)).ToList();
            return courses;
        }

        // 根据授课老师名查询课程
        public static List<Course> SelectCourseByTeacherName(string name)
        {
            var courses = context.Courses.Include(c => c.QuestionList).ThenInclude(q => q.QuestionTags)
            .Where(c => c.TeacherName.Contains(name)).ToList();
            return courses;
        }

        // 根据课程名查询课程
        public static List<Course> SelectCourseByCourseName(string name)
        {
            var courses = context.Courses.Include(c => c.QuestionList).ThenInclude(q => q.QuestionTags)
                .Where(c => c.Name.Contains(name)).ToList();
            return courses;
        }

        // 增添课程
        public static bool AddCourse(Course course)
        {
            var c = SelectCourseById(course.CourseId);
            if (c != null) return false;
            context.Courses.Add(course);
            int flag = context.SaveChanges();
            if (flag > 0) return true;
            return false;
        }

        // 删除课程
        public static bool DeleteCourse(string id)
        {
            var queryCourse = context.Courses.Where(c => c.CourseId.Equals(id)).SingleOrDefault();
            if (queryCourse == null) return false;

            context.Courses.Remove(queryCourse);
            context.SaveChanges();
            return true;
        }

        // 修改课程
        public static bool UpdateCourse(Course course)
        {
            if (!DeleteCourse(course.CourseId)) return false;
            return AddCourse(course);
        }
    }
}
