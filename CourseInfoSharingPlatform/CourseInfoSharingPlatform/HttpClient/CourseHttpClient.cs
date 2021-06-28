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
        //默认按照评分查询所有课程
        public static List<Course> GetAllCourse(int startIndex, int pageSize)
        {
            string url = baseUrl + "/all";
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("startIndex", startIndex.ToString());
            d.Add("pageSize", pageSize.ToString());
            var result = ClientHttp.GET(url, d);
            List<Course> courses = Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Course>)) as List<Course>;
            return courses;
        }

        //默认查询所有课程时总页数
        public  static int GetTotalPageNum()
        {
            string url = baseUrl + "/totalPageNum";
            Dictionary<string, string> d = new Dictionary<string, string>();
            var result = ClientHttp.GET(url, d);
            int num=(int) Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(int));
            return num;
        }


        // 根据类型查询课程，默认按照评分排序，startIndex从0开始
        public static List<Course> GetCourseByType(string type, int startIndex, int pageSize)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl + "?type=" + type+"&startIndex="+startIndex+"&pageSize="+pageSize);
            request.Method = "Get";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
            string result = streamReader.ReadToEnd();
            stream.Close();
            streamReader.Close();

            List<Course> c = Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Course>))
                as List<Course>;
            return c;
        }

        // 根据教师名查询课程，默认按照评分排序，startIndex从0开始
        public static List<Course> GetCourseByTeacherName(string name, int startIndex, int pageSize)
        {
            return null;
        }

        // 根据课程名查询课程，默认按照评分排序，startIndex从0开始
        public static List<Course> GetCourseByCourseName(string name, int startIndex, int pageSize)
        {
            return null;
        }
        
    }
}
