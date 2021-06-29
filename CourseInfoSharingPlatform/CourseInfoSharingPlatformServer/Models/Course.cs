using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatformServer.Models
{
    [Table("COURSE")]
    public class Course
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TeacherName { get; set; }
        public string Department { get; set; }
        public string BookName { get; set; }
        public string Introduction { get; set; }
        [NotMapped]
        public double Score { get; set; }
        public List<Question> QuestionList { get; set; }
        public List<User> UserWhoLikedCourse { get; set; }

        public int LikeNum { get; set; }
        public int HeatNum { get; set; }

        [NotMapped]
        public List<Tag> Tags { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Course course &&
                   CourseId == course.CourseId;
        }
    }
}
