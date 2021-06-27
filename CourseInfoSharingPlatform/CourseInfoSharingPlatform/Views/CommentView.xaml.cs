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
    /// CommentView.xaml 的交互逻辑
    /// </summary>
    public partial class CommentView : Window
    {
        //private List<Comment> comments;
        private Question Question { get; set; }
        public CommentView(Question question)
        {
            InitializeComponent();
            //comments = new List<Comment>()
            //{
            //    new Comment(){Detail="这门课作业多吗?成岑军军",LikeNum=23,RelatedUser=new User(){ UserName="左嘉龙"} },
            //    new Comment(){Detail="这门课作业多吗?成绩岑长长岑长惆怅长岑长",LikeNum=12,RelatedUser=new User(){ UserName="左嘉龙"} },
            //    new Comment(){Detail="这门课作业多吗?成绩出惆怅长岑长惆怅长岑长惆怅长岑长惆怅长岑长惆怅长岑长惆怅长岑长惆怅长岑长惆怅长岑长惆怅长岑长惆怅长岑长惆怅长岑长惆怅长岑长111促进经济错军军军军军军军军军军军军军军军军军军军军军军",LikeNum=231,RelatedUser=new User(){ UserName="左嘉龙"} }
            //};

            //question = new Question()
            //{
            //    Detail = "这门课作业多吗?黄寺大街打开数据库就速度快放的萨克健康的骄傲的骄傲打卡机打卡机爱哭的就爱看大家啊看大家卡德加安康的骄傲肯德基ad",
            //    RelatedUser = new User() { UserName = "左嘉龙" },
            //    LikeNum = 12,
            //    QuestionTags = new List<Tag>()
            //            {
            //                new Tag() { Detail = "作业多",LikeNum=24 },
            //                new Tag() { Detail = "作业不多",LikeNum=8 },
            //                new Tag() { Detail = "作业不",LikeNum=45 },
            //                new Tag() { Detail = "作不多",LikeNum=23 },
            //                new Tag() { Detail = "作多" ,LikeNum=21}
            //            }
            //};
            this.Question = question;
            this.questionBorder.DataContext = Question;
            this.questionTagList.ItemsSource = Question.QuestionTags;
            this.commentsList.ItemsSource = Question.CommentList;
            this.anwserNumTB.DataContext = Question;
        }

        //整个窗口移动按钮
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void answerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.scrollViewer.ScrollToVerticalOffset(scrollViewer.ActualHeight);
        }

        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {
            ReportView view = new ReportView();
            view.WindowStartupLocation = this.WindowStartupLocation;
            view.ShowDialog();
        }

        private void addTagBtn_Click(object sender, RoutedEventArgs e)
        {
            //清空输入框内容，下拉框折叠
            this.addTagTB.Text = null;
            this.tagExpander.IsExpanded = false;
        }
    }
}
