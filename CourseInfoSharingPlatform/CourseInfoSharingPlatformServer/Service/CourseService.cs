using CourseInfoSharingPlatformServer.Models;
using EFDemo.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatformServer.Service
{
    // 处理和课程有关的操作
    public class CourseService
    {

        // 接受一个Course对象，读取点赞最高的n个标签赋给Tags
        public static void SetCourseTag(Course course, int n)
        {
            if (course == null) return;
            List<Tag> tempTagsList = new List<Tag>();
            List<Tag> resTagsList = new List<Tag>();

            // 提取该课程的所有tag
            for (int i = 0; i < course.QuestionList.Count; i++)
            {
                for (int j = 0; j < course.QuestionList[i].QuestionTags.Count; j++)
                {
                    tempTagsList.Add(course.QuestionList[i].QuestionTags[j]);
                }
            }

            tempTagsList = tempTagsList.OrderBy(t => t.LikeNum).ToList();

            for (int i = 0; i < n && i < tempTagsList.Count; i++)
            {
                resTagsList.Add(tempTagsList[i]);
            }

            course.Tags = resTagsList;
        }

        // 设置课程的6个默认问题，更新到数据库中
        public static void SetDefaultQuestionToDataBase(Course course)
        {
            List<string> detailList = new List<string>();
            detailList.Add("这门课平时作业多吗？");
            detailList.Add("这门课的结课方式是怎么样的？");
            detailList.Add("老师期末给分怎么样？");
            detailList.Add("平时上课签到多吗，老师点名吗？");
            detailList.Add("老师讲课效果怎么样？");
            detailList.Add("这门课难度大吗，需要什么先修课程，不会听不懂吧?");

            for (int i = 0; i < 6; i++)
            {
                QuestionDao.AddQuestion(GetQuestion(detailList[i], course.CourseId));
            }
        }

        private static Question GetQuestion(string detail, string courseID)
        {
            Question question = new Question();
            question.RelatedUser = UserDao.SelectUserByUserName("admin");
            question.RelatedCourse = CourseDao.SelectCourseById(courseID);
            question.Detail = detail;
            return question;
        }




        // 根据课程id查询课程
        public static Course GetCourseById(string id)
        {
            Course course = CourseDao.SelectCourseById(id);
            SetCourseTag(course, 6);
            SetCourseScore(course);
            return course;
        }




        //默认按照分数查询所有的课程
        public static List<Course> GetAllCourse(int startIndex, int pageSize)
        {
            List<Course> resultList = new List<Course>();
            List<Course> courses = CourseDao.SelectAllCourse();
            for (int i = 0; i < courses.Count; i++)
            {
                SetCourseScore(courses[i]);
            }

            courses = courses.OrderByDescending(c => c.Score).ToList();
            for (int i = 0; i < pageSize && i + startIndex < courses.Count; i++)
            {
                SetCourseTag(courses[startIndex + i], 6);
                resultList.Add(courses[startIndex + i]);
            }

            return resultList;

        }

        // 根据类型查询课程，默认按照评分排序，startIndex从0开始
        public static List<Course> GetCourseByType(string type, int startIndex, int pageSize)
        {
            List<Course> resultList = new List<Course>();
            List<Course> courses = CourseDao.SelectCourseByType(type);
            for (int i = 0; i < courses.Count; i++)
            {
                SetCourseScore(courses[i]);
            }

            courses = courses.OrderByDescending(c => c.Score).ToList();
            for (int i = 0; i < pageSize&&(startIndex+i)<courses.Count; i++)
            {
                SetCourseTag(courses[startIndex + i], 6);
                resultList.Add(courses[startIndex + i]);
            }

            return resultList;
        }

        // 根据教师名查询课程，默认按照评分排序，startIndex从0开始
        public static List<Course> GetCourseByTeacherName(string name, int startIndex, int pageSize)
        {
            List<Course> resultList = new List<Course>();
            List<Course> courses = CourseDao.SelectCourseByTeacherName(name);
            for (int i = 0; i < courses.Count; i++)
            {
                SetCourseScore(courses[i]);
            }

            courses = courses.OrderByDescending(c => c.Score).ToList();
            for (int i = 0; i < pageSize && i + startIndex < courses.Count; i++)
            {
                SetCourseTag(courses[startIndex + i], 6);
                resultList.Add(courses[startIndex + i]);
            }

            return resultList;
        }

        // 根据课程名查询课程，默认按照评分排序，startIndex从0开始
        public static List<Course> GetCourseByCourseName(string name, int startIndex, int pageSize)
        {
            List<Course> resultList = new List<Course>();
            List<Course> courses = CourseDao.SelectCourseByCourseName(name);
            for (int i = 0; i < courses.Count; i++)
            {
                SetCourseScore(courses[i]);
            }

            courses = courses.OrderByDescending(c => c.Score).ToList();
            for (int i = 0; i < pageSize && i + startIndex < courses.Count; i++)
            {
                SetCourseTag(courses[startIndex + i], 6);
                resultList.Add(courses[startIndex + i]);
            }

            return resultList;
        }

        // 按照收藏数查询所有的课程
        public static List<Course> GetAllCourseOrderByLikeNum(int startIndex, int pageSize)
        {
            List<Course> resultList = new List<Course>();
            List<Course> courses = CourseDao.SelectAllCourse();
            for (int i = 0; i < courses.Count; i++)
            {
                SetCourseScore(courses[i]);
            }
            GetAndSetLikeNum(courses);

            courses = courses.OrderByDescending(c => c.LikeNum).ToList();
            for (int i = 0; i < pageSize && i + startIndex < courses.Count; i++)
            {
                SetCourseTag(courses[startIndex + i], 6);
                resultList.Add(courses[startIndex + i]);
            }

            return resultList;

        }

        // 根据类型查询课程，按照收藏数排序，startIndex从0开始
        public static List<Course> GetCourseByTypeOrderByLikeNum(string type, int startIndex, int pageSize)
        {
            List<Course> resultList = new List<Course>();
            List<Course> courses = CourseDao.SelectCourseByType(type);
            for (int i = 0; i < courses.Count; i++)
            {
                SetCourseScore(courses[i]);
            }
            GetAndSetLikeNum(courses);

            courses = courses.OrderByDescending(c => c.LikeNum).ToList();
            for (int i = 0; i < pageSize&&(startIndex+i)<courses.Count; i++)
            {
                SetCourseTag(courses[startIndex + i], 6);
                resultList.Add(courses[startIndex + i]);
            }

            return resultList;
        }

        // 根据教师名查询课程，按照收藏数排序，startIndex从0开始
        public static List<Course> GetCourseByTeacherNameOrderByLikeNum(string name, int startIndex, int pageSize)
        {
            List<Course> resultList = new List<Course>();
            List<Course> courses = CourseDao.SelectCourseByTeacherName(name);
            for (int i = 0; i < courses.Count; i++)
            {
                SetCourseScore(courses[i]);
            }
            GetAndSetLikeNum(courses);

            courses = courses.OrderByDescending(c => c.LikeNum).ToList();
            for (int i = 0; i < pageSize && i + startIndex < courses.Count; i++)
            {
                SetCourseTag(courses[startIndex + i], 6);
                resultList.Add(courses[startIndex + i]);
            }

            return resultList;
        }

        // 根据课程名查询课程，按照收藏数排序，startIndex从0开始
        public static List<Course> GetCourseByCourseNameOrderByLikeNum(string name, int startIndex, int pageSize)
        {
            List<Course> resultList = new List<Course>();
            List<Course> courses = CourseDao.SelectCourseByCourseName(name);
            for (int i = 0; i < courses.Count; i++)
            {
                SetCourseScore(courses[i]);
            }
            GetAndSetLikeNum(courses);

            courses = courses.OrderByDescending(c => c.LikeNum).ToList();
            for (int i = 0; i < pageSize && i + startIndex < courses.Count; i++)
            {
                SetCourseTag(courses[startIndex + i], 6);
                resultList.Add(courses[startIndex + i]);
            }

            return resultList;
        }

        // 按照热度查询所有的课程
        public static List<Course> GetAllCourseOrderByHeatNum(int startIndex, int pageSize)
        {
            List<Course> resultList = new List<Course>();
            List<Course> courses = CourseDao.SelectAllCourse();
            for (int i = 0; i < courses.Count; i++)
            {
                SetCourseScore(courses[i]);
            }

            courses = courses.OrderByDescending(c => c.HeatNum).ToList();
            for (int i = 0; i < pageSize && i + startIndex < courses.Count; i++)
            {
                SetCourseTag(courses[startIndex + i], 6);
                resultList.Add(courses[startIndex + i]);
            }

            return resultList;

        }

        // 根据类型查询课程，按照热度排序，startIndex从0开始
        public static List<Course> GetCourseByTypeOrderByHeatNum(string type, int startIndex, int pageSize)
        {
            List<Course> resultList = new List<Course>();
            List<Course> courses = CourseDao.SelectCourseByType(type);
            for (int i = 0; i < courses.Count; i++)
            {
                SetCourseScore(courses[i]);
            }

            courses = courses.OrderByDescending(c => c.HeatNum).ToList();
            for (int i = 0; i < pageSize&&(startIndex+i)<courses.Count; i++)
            {
                SetCourseTag(courses[startIndex + i], 6);
                resultList.Add(courses[startIndex + i]);
            }

            return resultList;
        }

        // 根据教师名查询课程，按照热度排序，startIndex从0开始
        public static List<Course> GetCourseByTeacherNameOrderByHeatNum(string name, int startIndex, int pageSize)
        {
            List<Course> resultList = new List<Course>();
            List<Course> courses = CourseDao.SelectCourseByTeacherName(name);
            for (int i = 0; i < courses.Count; i++)
            {
                SetCourseScore(courses[i]);
            }

            courses = courses.OrderByDescending(c => c.HeatNum).ToList();
            for (int i = 0; i < pageSize && i + startIndex < courses.Count; i++)
            {
                SetCourseTag(courses[startIndex + i], 6);
                resultList.Add(courses[startIndex + i]);
            }

            return resultList;
        }

        // 根据课程名查询课程，按照热度排序，startIndex从0开始
        public static List<Course> GetCourseByCourseNameOrderByHeatNum(string name, int startIndex, int pageSize)
        {
            List<Course> resultList = new List<Course>();
            List<Course> courses = CourseDao.SelectCourseByCourseName(name);
            for (int i = 0; i < courses.Count; i++)
            {
                SetCourseScore(courses[i]);
            }

            courses = courses.OrderByDescending(c => c.HeatNum).ToList();
            for (int i = 0; i < pageSize && i + startIndex < courses.Count; i++)
            {
                SetCourseTag(courses[startIndex + i], 6);
                resultList.Add(courses[startIndex + i]);
            }

            return resultList;
        }

        // 根据类型查询，返回页面数量
        public static int GetPageNumByType(string type, int pageSize)
        {
            return (CourseDao.SelectCourseByType(type).Count - 1) / pageSize + 1;
        }

        // 根据类型查询，返回页面数量,默认页面大小为4
        public static int GetPageNumByType(string type)
        {
            return (CourseDao.SelectCourseByType(type).Count - 1) / 4 + 1;
        }

        // 根据教师名查询，返回页面数量
        public static int GetPageNumByTeacherName(string name, int pageSize)
        {
            return (CourseDao.SelectCourseByTeacherName(name).Count - 1) / pageSize + 1;
        }

        // 根据教师名查询，返回页面数量,默认页面大小为4
        public static int GetPageNumByTeacherName(string name)
        {
            return (CourseDao.SelectCourseByTeacherName(name).Count - 1) / 4 + 1;
        }

        // 根据课程名称查询，返回页面数量
        public static int GetPageNumByCourseName(string name, int pageSize)
        {
            return (CourseDao.SelectCourseByCourseName(name).Count - 1) / pageSize + 1;
        }

        // 根据类型查询，返回页面数量,默认页面大小为4
        public static int GetPageNumByCourseName(string name)
        {
            return (CourseDao.SelectCourseByCourseName(name).Count - 1) / 4 + 1;
        }

        // 返回总页面数
        public static int GetTotalPageNum(int pageSize)
        {
            return (CourseDao.SelectAllCourse().Count - 1) / pageSize + 1;
        }

        // 返回总页面数，默认页面大小为4
        public static int GetTotalPageNum()
        {
            return (CourseDao.SelectAllCourse().Count - 1) / 4 + 1;
        }

        // 获得该课程的收藏数
        private static void GetAndSetLikeNum(Course course)
        {
            course.LikeNum = CourseDao.SelectCourseByIdWithUserWhoLikeIt(course.CourseId).UserWhoLikedCourse.Count;
        }

        // 获得课程的收藏数
        private static void GetAndSetLikeNum(List<Course> courses)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                courses[i].LikeNum = CourseDao.SelectLikeNumById(courses[i].CourseId);
            }
        }

        // 获得课程平均评分
        public static void SetCourseScore(Course course)
        {
            if (course == null) return;
            course.Score = CUSDao.GetAveScoreByCourseId(course.CourseId);
        }

        // 获得课程平均评分
        public static void SetCourseScore(List<Course> courses)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                courses[i].Score = CUSDao.GetAveScoreByCourseId(courses[i].CourseId);
            }
        }
    }
}
