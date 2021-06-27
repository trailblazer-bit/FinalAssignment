using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatformServer.Models
{
    [Table("COURSE_USER_SCORE")]
    public class CUS
    {
        public int CUSId { get; set; }
        public string UserName { get; set; }
        public string CourseId { get; set; }
        public int Score { get; set; }
    }
}
