using CourseInfoSharingPlatform.ClientHttp;
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
    /// CourseDetailedInfoView.xaml 的交互逻辑
    /// </summary>
    public partial class CourseDetailedInfoView : Window
    {
        public Course Course { get; set; }
        public CourseDetailedInfoView()
        {
            InitializeComponent();
            //Course = new Course()
            //{
            //    Name = "Python程序设计与基础",
            //    CourseId = "12345",
            //    Type = "专业课",
            //    TeacherName = "李四",
            //    Department = "计算机学院",
            //    BookName = "精通Python",
            //    Introduction = "Python课程共分为八大阶段：阶段一是Python语言(用时5周，包括基础语法、面向对象、高级课程、经典课程)；阶段二是Linux初级(用时1周，包括Linux系统基本指令、常用服务安装)；" +
            //    "阶段三是Web开发之Diango(5周 + 2周前端 + 3周diango)；阶段四是Web开发之Flask(用时2周)；阶段五是Web框架之Tornado(用时1周)；阶段六是docker容器及服务发现(用时2周)；阶段七是爬虫(用时2周)；阶段八是数据挖掘和人工智能(用时3周)。",
            //    Score = 4.7,
            //    tags = new List<Tag>()
            //    {
            //        new Tag() { Detail = "作业多",LikeNum=24 },
            //        new Tag() { Detail = "作业不多",LikeNum=8 },
            //        new Tag() { Detail = "作业不",LikeNum=45 },
            //        new Tag() { Detail = "作不多",LikeNum=23 },
            //        new Tag() { Detail = "作多" ,LikeNum=21}
            //    },
            //    QuestionList = new List<Question>()
            //    {
            //        new Question()
            //        {
            //            Detail="这门课作业多吗?",
            //             RelatedUser=new User(){UserName="左嘉龙"},
            //             LikeNum=23,
            //             QuestionTags=new List<Tag>()
            //            {
            //                new Tag() { Detail = "作业多",LikeNum=24 },
            //                new Tag() { Detail = "作业不多",LikeNum=8 },
            //                new Tag() { Detail = "作业不",LikeNum=45 },
            //                new Tag() { Detail = "作不多",LikeNum=23 },
            //                new Tag() { Detail = "作多" ,LikeNum=21}
            //            }
            //        },
            //        new Question()
            //        {
            //            Detail="这门课作业多吗?黄寺大街打开数据库就速度快放的萨克健康的骄傲的骄傲打卡机打卡机爱哭的就爱看大家啊看大家卡德加安康的骄傲肯德基ad",
            //            RelatedUser=new User(){UserName="左嘉龙"},
            //            LikeNum=12,
            //              QuestionTags=new List<Tag>()
            //            {
            //                new Tag() { Detail = "作业多",LikeNum=24 },
            //                new Tag() { Detail = "作业不多",LikeNum=8 },
            //                new Tag() { Detail = "作业不",LikeNum=45 },
            //                new Tag() { Detail = "作不多",LikeNum=23 },
            //                new Tag() { Detail = "作多" ,LikeNum=21}
            //            }
            //        },
            //         new Question()
            //        {
            //            Detail="这门课作业多吗?黄寺大街打开数据库就速度快放的萨克健康的骄傲的骄傲打卡机打卡机爱哭的就爱看大家啊看大家卡德加安康的骄傲肯德基ad",
            //            RelatedUser=new User(){UserName="左嘉龙"},
            //            LikeNum=8,
            //              QuestionTags=new List<Tag>()
            //            {
            //                new Tag() { Detail = "作业多",LikeNum=24 },
            //                new Tag() { Detail = "作业不多",LikeNum=8 },
            //                new Tag() { Detail = "作业不",LikeNum=45 },
            //                new Tag() { Detail = "作不多",LikeNum=23 },
            //                new Tag() { Detail = "作多" ,LikeNum=21}
            //            }
            //        }

            //    }

            //};
            //this.courseGrid.DataContext = course;

            //Course c = CourseHttpClient.GetCourseById("20202057459");

            //this.courseGrid.DataContext = Course;

            //Console.WriteLine(c.BookName);
            //Console.WriteLine(c.CourseId);
            //Console.WriteLine(c.Department);
            //Console.WriteLine(c.QuestionList.Count);
            //Console.WriteLine(c.Name);

        }

        //整个窗口移动按钮
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        //按下评论按钮，窗口滑到底部，提问
        private void quizBtn_Click(object sender, RoutedEventArgs e)
        {
            this.scrollViewer.ScrollToVerticalOffset(scrollViewer.ActualHeight);
        }

        //按下举报按钮
        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {
            ReportView view = new ReportView();
            view.WindowStartupLocation = this.WindowStartupLocation;
            //this.Visibility = Visibility.Hidden;
            view.ShowDialog();
            //this.Visibility = Visibility.Visible;
        }

        //点击查看问题的回复
        private void commentBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = e.OriginalSource as Button;
            Question q = btn.DataContext as Question;
            CommentView commentView = new CommentView(q);
            commentView.WindowStartupLocation = this.WindowStartupLocation;
            //传具体的问题对象
            //this.Visibility = Visibility.Hidden;
            commentView.ShowDialog();
            //this.Visibility = Visibility.Visible;
        }

        //按下点赞按钮
        private void likeBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckBox btn = e.OriginalSource as CheckBox;
            Question q = btn.DataContext as Question;
            if (btn.IsChecked == false || btn.IsChecked == null)
                q.LikeNum--;
            else
                q.LikeNum++;
        }

        //返回按钮
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
