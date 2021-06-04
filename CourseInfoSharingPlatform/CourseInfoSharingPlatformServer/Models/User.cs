using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatformServer.Models
{
    [Table("USER")]
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Grade { get; set; }
        public string Introduction { get; set; }
        public string Major { get; set; }

        public List<Course> LikeCourses { get; set; }
    }
}
