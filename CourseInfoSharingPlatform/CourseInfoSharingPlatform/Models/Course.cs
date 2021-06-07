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

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
        public string Type { get; set; }
        public string TeacherName { get; set; }
        public string Department { get; set; }
        public string BookName { get; set; }
        public string Introduction { get; set; }

        public double Score { get; set; }
        public List<Question> QuestionList { get; set; }
        public List<User> UserWhoLikedCourse { get; set; }

        public List<Tag> tags { get; set; }

    }
}
