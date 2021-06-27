using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.Models
{
    public class Question : INotifyPropertyChanged
    {
        public int QuestionId { get; set; }
        private int likeNum;
        public int LikeNum
        {
            get { return likeNum; }
            set
            {
                likeNum = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("LikeNum"));
            }
        }
        //public int LikeNum { get; set; }
        public string Detail { get; set; }
        public bool IsReported { get; set; }
        public string Reason { get; set; }
        public Course RelatedCourse { get; set; }
        public List<Tag> QuestionTags { get; set; }
        public User RelatedUser { get; set; }
        public List<Comment> CommentList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
