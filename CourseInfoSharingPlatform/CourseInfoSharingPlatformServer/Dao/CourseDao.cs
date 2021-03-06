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

        // 根据课头号查询收藏该课程的用户数量
        public static int SelectLikeNumById(string id)
        {
            var course = context.Courses.Include(c => c.UserWhoLikedCourse).SingleOrDefault(c => c.CourseId.Equals(id));
            if (course == null) return 0;
            else return course.UserWhoLikedCourse.Count;
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

        // 根据课程id将课程LikeNum字段加1
        public static bool AddLikeNum(string id)
        {
            var course = context.Courses.SingleOrDefault(c => c.CourseId.Equals(id));
            if (course == null) return false;
            course.LikeNum++;
            context.SaveChanges();
            return true;
        }

        public static bool AddAndCalculateHeatNum(string id)
        {
            if (SelectCourseById(id) == null) return false;
            var courses = context.Courses.ToList();
            foreach (Course course in courses)
            {
                if (course.CourseId.Equals(id)) AddHeatNum(course.CourseId, courses.Count - 1);
                else MinusHeatNum(course.CourseId, 1);
            }
            return true;
        }

        private static bool AddHeatNum(string id, int num)
        {
            var c = context.Courses.SingleOrDefault(c => c.CourseId.Equals(id));
            if (c == null) return false;
            c.HeatNum += num;
            context.SaveChanges();
            return true;
        }

        private static bool MinusHeatNum(string id, int num)
        {
            var c = context.Courses.SingleOrDefault(c => c.CourseId.Equals(id));
            if (c == null) return false;
            if (c.HeatNum - num >= 0) c.HeatNum -= num;
            context.SaveChanges();
            return true;
        }
    }
}
