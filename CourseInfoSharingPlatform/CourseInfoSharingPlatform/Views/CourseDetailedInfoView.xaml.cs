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
        private User user = new User { UserName = "whuanle" };
        private List<int> likedQuestionId = new List<int>();

        public CourseDetailedInfoView(Course c)
        {
            InitializeComponent();
            this.courseGrid.DataContext = c;
            this.Course = c;
            Init();
            //this.courseGrid.DataContext = Course;
        }

        //窗口初始化
        private  void Init()
        {
            //用户收藏按钮
            if(UserHttpClient.IsLikedCourse(Course.CourseId,user.UserName))
            {
                this.collectBtn.IsEnabled = false;
                this.collectBtn.Content = "已收藏";
                this.collectBtn.Opacity = .4;
            }
            //获取用户评分
            int score = UserHttpClient.GetScore(Course.CourseId, user.UserName);
            if(score!=0)
            {
                this.userRatingBar.Value = score;
                this.userRatingBar.IsEnabled = false;
                this.userRatingBar.Opacity = 1;
            }
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
            //重新查一次相应的课程
            this.Course = CourseHttpClient.GetCourseById(Course.CourseId);
            //this.Visibility = Visibility.Visible;
        }

        //按下点赞按钮
        private void likeBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckBox btn = e.OriginalSource as CheckBox;
            Question q = btn.DataContext as Question;
            if (btn.IsChecked == false || btn.IsChecked == null)
            {
                q.LikeNum--;
                this.likedQuestionId.Remove(q.QuestionId);
            }
            else
            {
                q.LikeNum++;
                this.likedQuestionId.Add(q.QuestionId);
            }
        }

        //返回按钮
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            //先将当前页面的点赞的问题处理
            CommentHttpClient.AddLikeNumToQuestion(likedQuestionId);
            //处理用户的评分
            int score = this.userRatingBar.Value;
            if (score != 0&&this.userRatingBar.IsEnabled)
            {
                UserHttpClient.AddScore(Course.CourseId, user.UserName, score);
            }
            this.Close();
        }

        //用户收藏按钮
        private void collectBtn_Click(object sender, RoutedEventArgs e)
        {
            //获取用户名和课程id
            bool succeed = UserHttpClient.AddFavoriteCourse(Course.CourseId, user.UserName);
            this.collectBtn.IsEnabled = false;
            this.collectBtn.Content = "已收藏";
            this.collectBtn.Opacity = .4;
        }

        //提出问题
        private void askQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            //清空问题填写区
            this.commentArea.Text = null;
            //展示更新后的问题

        }
    }
}
