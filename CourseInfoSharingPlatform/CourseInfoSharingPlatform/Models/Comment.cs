using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.Models
{
    public class Comment : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int CommentId { get; set; }
        //public int LikeNum { get; set; }
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
        public string Detail { get; set; }
        public bool IsReported { get; set; }
        public string Reason { get; set; }
        public User RelatedUser { get; set; }
        public Question RelatedQuestion { get; set; }
    }
}
