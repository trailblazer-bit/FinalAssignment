using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int LikeNum { get; set; }
        public string Detail { get; set; }
        public bool IsReported { get; set; }
        public User RelatedUser { get; set; }
        public Question RelatedQuestion { get; set; }
    }
}
