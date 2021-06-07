using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatformServer.Models
{
    [Table("TAG")]
    public class Tag
    {
        public int TagId { get; set; }
        public string Detail { get; set; }
        public int LikeNum { get; set; }
        public Question RelatedQuestion { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Tag tag &&
                   TagId == tag.TagId;
        }
    }
}
