using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatformServer.Models
{
    [Table("ADMIN")]
    public class Admin
    {
        [Key]
        public string AdminName { get; set; }
        public string Password { get; set; }
    }
}
