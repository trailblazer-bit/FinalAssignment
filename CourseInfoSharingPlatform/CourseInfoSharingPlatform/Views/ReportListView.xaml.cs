using CourseInfoSharingPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseInfoSharingPlatform.Views
{
    /// <summary>
    /// ReportListView.xaml 的交互逻辑
    /// </summary>
    public partial class ReportListView : Window
    {
        private List<Comment> commentsReport = new List<Comment>();
        private List<Question> questionsReport = new List<Question>();
        public ReportListView()
        {
            InitializeComponent();
            questionsReport = new List<Question>()
            {
                new Question()
                {
                    Detail="这门课作业多吗?",
                    RelatedUser=new User(){UserName="左嘉龙"},
                    LikeNum=23,
                    QuestionTags=new List<Tag>()
                    {
                        new Tag() { Detail = "作业多",LikeNum=24 },
                        new Tag() { Detail = "作业不多",LikeNum=8 },
                        new Tag() { Detail = "作业不",LikeNum=45 },
                        new Tag() { Detail = "作不多",LikeNum=23 },
                        new Tag() { Detail = "作多" ,LikeNum=21}
                    }
                },
                new Question()
                {
                    Detail="这门课作业多吗?黄寺大街打开数据库就速度快放的萨克健康的骄傲的骄傲打卡机打卡机爱哭的就爱看大家啊看大家卡德加安康的骄傲肯德基ad",
                    RelatedUser=new User(){UserName="左嘉龙"},
                    LikeNum=12,
                     QuestionTags=new List<Tag>()
                    {
                        new Tag() { Detail = "作业多",LikeNum=24 },
                        new Tag() { Detail = "作业不多",LikeNum=8 },
                        new Tag() { Detail = "作业不",LikeNum=45 },
                        new Tag() { Detail = "作不多",LikeNum=23 },
                        new Tag() { Detail = "作多" ,LikeNum=21}
                    }
                },
                new Question()
                {
                    Detail="这门课作业多吗?黄寺大街打开数据库就速度快放的萨克健康的骄傲的骄傲打卡机打卡机爱哭的就爱看大家啊看大家卡德加安康的骄傲肯德基ad",
                    RelatedUser=new User(){UserName="左嘉龙"},
                    LikeNum=8,
                    QuestionTags=new List<Tag>()
                    {
                        new Tag() { Detail = "作业多",LikeNum=24 },
                        new Tag() { Detail = "作业不多",LikeNum=8 },
                        new Tag() { Detail = "作业不",LikeNum=45 },
                        new Tag() { Detail = "作不多",LikeNum=23 },
                        new Tag() { Detail = "作多" ,LikeNum=21}
                    }
                }
            };
            commentsReport = new List<Comment>()
            {
                new Comment(){Detail="这门课作业多吗?成岑军军",LikeNum=23,RelatedUser=new User(){ UserName="左嘉龙"} },
                new Comment(){Detail="这门课作业多吗?成绩岑长长岑长惆怅长岑长",LikeNum=12,RelatedUser=new User(){ UserName="左嘉龙"} },
                new Comment(){Detail="这门课作业多吗?成绩岑长长岑长惆怅长岑长",LikeNum=12,RelatedUser=new User(){ UserName="左嘉龙"} },
                new Comment(){Detail="这门课作业多吗?成岑军军",LikeNum=23,RelatedUser=new User(){ UserName="左嘉龙"} },
                new Comment(){Detail="这门课作业多吗?成绩岑长长岑长惆怅长岑长",LikeNum=12,RelatedUser=new User(){ UserName="左嘉龙"} },
                new Comment(){Detail="这门课作业多吗?成岑军军",LikeNum=23,RelatedUser=new User(){ UserName="左嘉龙"} },
                new Comment(){Detail="这门课作业多吗?成绩岑长长岑长惆怅长岑长",LikeNum=12,RelatedUser=new User(){ UserName="左嘉龙"} }
            };
            this.commentReportList.ItemsSource = commentsReport;
            this.questionReportList.ItemsSource = questionsReport;
        }

        //整个窗口移动按钮
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
