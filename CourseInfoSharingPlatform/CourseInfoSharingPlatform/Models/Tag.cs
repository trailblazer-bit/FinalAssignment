using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseInfoSharingPlatform.Models
{
    public class Tag : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int TagId { get; set; }
        private string detail;
        public string Detail
        {
            get { return detail; }
            set
            {
                detail = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Detail"));
            }
        }
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
        public Question RelatedQuestion { get; set; }
    }
}
