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
         
            //this.courseGrid.DataContext = course;
            //Course c = CourseHttpClient.GetCourseById("20202057459");
            //this.courseGrid.DataContext = Course;

            //Console.WriteLine(c.BookName);
            //Console.WriteLine(c.CourseId);
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

        //用户开始评分
        private void userRate_Click(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine(this.userRate.Value); 
        }
    }
}
