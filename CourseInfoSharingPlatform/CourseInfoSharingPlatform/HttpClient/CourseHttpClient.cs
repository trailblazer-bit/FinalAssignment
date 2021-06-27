using CourseInfoSharingPlatform.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.HttpClient
{
    class CourseHttpClient
    {
        private static string url = "https://localhost:44386/api/course";

        //private static string url = "https://localhost:44367/api/course";

        public static Course GetCourseById(string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "?id=" + id);
            request.Method = "Get";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
            string result = streamReader.ReadToEnd();
            stream.Close();
            streamReader.Close();

            Course c = Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(Course))
                as Course;
            return c;
            //return null;
        }

        public static List<Course> GetCourseList()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/all");
            request.Method = "Get";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
            string result = streamReader.ReadToEnd();
            stream.Close();
            streamReader.Close();

            List<Course> courses = Newtonsoft.Json.JsonConvert.DeserializeObject(result, typeof(List<Course>)) as List<Course>;
            return courses;
        }
    }
}
