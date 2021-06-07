using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Detail { get; set; }
        public int LikeNum { get; set; }
        public Question RelatedQuestion { get; set; }
    }
}
