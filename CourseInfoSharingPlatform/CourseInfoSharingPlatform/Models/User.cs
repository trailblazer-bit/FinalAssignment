using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Grade { get; set; }
        public string Introduction { get; set; }
        public string Major { get; set; }

        public List<Course> LikeCourses { get; set; }
    }
}
