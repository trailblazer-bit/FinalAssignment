using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatformServer.Models
{
    [Table("QUESTION")]
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
        public List<Comment> CommentList { get; set; }


        public override bool Equals(object obj)
        {
            return obj is Question question &&
                   QuestionId == question.QuestionId;
        }
    }
}
