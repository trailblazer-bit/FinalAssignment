using CourseInfoSharingPlatform.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.ClientHttp
{
    class CourseHttpClient
    {
        private static string baseUrl = "https://localhost:44386/api/course";

        //private static string url = "https://localhost:44367/api/course";

        //根据课程id获取某门课程
        public static Course GetCourseById(string id)
        {
            string url = baseUrl;
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("id",id.ToString());
            var result = ClientHttp.GET(url, d);
            Course course = Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(Course)) as Course;
            return course;
        }    

        //默认按照某种规则查询所有课程
        public static List<Course> GetAllCourseOrderBy(string url,int startIndex,int pageSize)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("startIndex", startIndex.ToString());
            d.Add("pageSize", pageSize.ToString());
            var result = ClientHttp.GET(url, d);
            List<Course> courses = Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Course>)) as List<Course>;
            return courses;
        }

        //默认按照评分查询所有课程
        public static List<Course> GetAllCourse(int startIndex, int pageSize)
        {
            string url = baseUrl + "/orderByScore";
            return GetAllCourseOrderBy(url, startIndex, pageSize);
        }
        // 按照收藏数查询所有的课程
        public static List<Course> GetAllCourseOrderByLikeNum(int startIndex, int pageSize)
        {
            string url = baseUrl + "/orderByLikeNum";
            return GetAllCourseOrderBy(url, startIndex, pageSize);
        }
        // 按照热度查询所有的课程
        public static List<Course> GetAllCourseOrderByHeatNum(int startIndex, int pageSize)
        {
            string url = baseUrl + "/orderByHeatNum";
            return GetAllCourseOrderBy(url, startIndex, pageSize);
        }

        //按课程类型查询
        public static List<Course> ByType(string url, string type,int startIndex,int pageSize)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("type", type.ToString());
            d.Add("startIndex", startIndex.ToString());
            d.Add("pageSize", pageSize.ToString());
            var result = ClientHttp.GET(url, d);
            List<Course> courses = Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Course>)) as List<Course>;
            return courses;
        }

        //按课程名或者教师名查询
        public static List<Course> ByName(string url, string name, int startIndex, int pageSize)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("name", name.ToString());
            d.Add("startIndex", startIndex.ToString());
            d.Add("pageSize", pageSize.ToString());
            var result = ClientHttp.GET(url, d);
            List<Course> courses = Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Course>)) as List<Course>;
            return courses;
        }

        // 根据类型查询课程，按照热度排序，startIndex从0开始
        public static List<Course> GetCourseByTypeOrderByHeatNum(string type, int startIndex, int pageSize)
        {
            string url = baseUrl + "/orderByHeatNum/byType";
            return ByType(url,type,startIndex,pageSize);
        }
        // 根据教师名查询课程，按照热度排序，startIndex从0开始
        public static List<Course> GetCourseByTeacherNameOrderByHeatNum(string name, int startIndex, int pageSize)
        {
            string url = baseUrl + "/orderByHeatNum/byTeacherName";
            return ByName(url, name, startIndex, pageSize);
        }

        // 根据课程名查询课程，按照热度排序，startIndex从0开始
        public static List<Course> GetCourseByCourseNameOrderByHeatNum(string name, int startIndex, int pageSize)
        {
            string url = baseUrl + "/orderByHeatNum/byCourseName";
            return ByName(url,name,startIndex,pageSize);
        }

        // 根据类型查询课程，按照收藏数排序，startIndex从0开始
        public static List<Course> GetCourseByTypeOrderByLikeNum(string type, int startIndex, int pageSize)
        {
            string url = baseUrl + "/orderByLikeNum/byType";
            return ByType(url, type, startIndex, pageSize);
        }

        // 根据教师名查询课程，按照收藏数排序，startIndex从0开始
        public static List<Course> GetCourseByTeacherNameOrderByLikeNum(string name, int startIndex, int pageSize)
        {
            string url = baseUrl + "/orderByLikeNum/byTeacherName";
            return ByName(url, name, startIndex, pageSize);
        }

        // 根据课程名查询课程，按照收藏数排序，startIndex从0开始
        public static List<Course> GetCourseByCourseNameOrderByLikeNum(string name, int startIndex, int pageSize)
        {
            string url = baseUrl + "/orderByLikeNum/byCourseName";
            return ByName(url, name, startIndex,pageSize);
        }

        // 根据类型查询课程，默认按照评分排序，startIndex从0开始
        public static List<Course> GetCourseByType(string type, int startIndex, int pageSize)
        {
            string url = baseUrl + "/orderByScore/byType";
            return ByType(url, type, startIndex, pageSize);
        }

        // 根据教师名查询课程，默认按照评分排序，startIndex从0开始
        public static List<Course> GetCourseByTeacherName(string name, int startIndex, int pageSize)
        {
            string url = baseUrl + "/orderByScore/byTeacherName";
            return ByName(url, name, startIndex, pageSize);
        }

        // 根据课程名查询课程，默认按照评分排序，startIndex从0开始
        public static List<Course> GetCourseByCourseName(string name, int startIndex, int pageSize)
        {
            string url = baseUrl + "/orderByScore/byCourseName";
            return ByName(url, name, startIndex, pageSize);
        }

        //查询总页数
        public static int GetTotalPageNum(string url, Dictionary<string, string> d)
        {
            var result = ClientHttp.GET(url, d);
            Int32 num = (Int32)Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(Int32));
            return num;
        }

        //默认查询所有课程时总页数
        public static int GetTotalPageNum()
        {
            string url = baseUrl + "/totalPageNum";
            Dictionary<string, string> d = new Dictionary<string, string>();
            return GetTotalPageNum(url, d);
        }

        // 根据类型查询，返回页面数量,默认页面大小为4
        public static int GetPageNumByType(string type)
        {
            string url = baseUrl + "/totalPageNum/byType";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("type", type);
            return GetTotalPageNum(url, d);
        }

        // 根据教师名查询，返回页面数量,默认页面大小为4
        public static int GetPageNumByTeacherName(string name)
        {
            string url = baseUrl + "/totalPageNum/byTeacherName";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("name", name);
            return GetTotalPageNum(url, d);
        }

        // 根据课程名查询，返回页面数量,默认页面大小为4
        public static int GetPageNumByCourseName(string name)
        {
            string url = baseUrl + "/totalPageNum/byCourseName";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("name", name);
            return GetTotalPageNum(url, d);
        }
        //添加课程
        public static bool AddCourse(Course course)
        {
            string url = baseUrl + "/addCourse";
            string parameters = Newtonsoft.Json.JsonConvert.SerializeObject(course);
            return ClientHttp.POST(url, parameters);
        }
        //获得三个相似课程
        public static List<Course> GetSimilarCourses(string id)
        {
            string url = baseUrl + "/getSimilarCourses";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("id", id);
            var result = ClientHttp.GET(url, d);
            List<Course> courses = Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Course>)) as List<Course>;
            return courses;
        }

    }
}
