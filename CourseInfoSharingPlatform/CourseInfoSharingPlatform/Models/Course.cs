using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.Models
{
    public class Course: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 

        public string CourseId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TeacherName { get; set; }
        public string Department { get; set; }
        public string BookName { get; set; }
        public string Introduction { get; set; }

        public double Score { get; set; }
        public List<Question> QuestionList { get; set; }
        public List<User> UserWhoLikedCourse { get; set; }

        public int LikeNum { get; set; }
        public int HeatNum { get; set; }

        public List<Tag> tags { get; set; }

    }
}
