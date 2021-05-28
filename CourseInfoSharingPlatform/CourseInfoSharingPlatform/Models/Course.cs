using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.Models
{
    class Course
    {
        public string Name { get; set; }
        public string CNo { get; set; }
        public string TeacherName { get; set; }
        public string CType { get; set; }
        public List<String> Tags { get; set; }
        public Double Score { get; set; }
    }
}
