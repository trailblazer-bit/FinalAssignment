using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int LikeNum { get; set; }
        public string Detail { get; set; }
        public bool IsReported { get; set; }
        public string Reason { get; set; }
        public Course RelatedCourse { get; set; }
        public List<Tag> QuestionTags { get; set; }
        public User RelatedUser { get; set; }
    }
}
