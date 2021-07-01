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
using CourseInfoSharingPlatform.ClientHttp;
using CourseInfoSharingPlatform.Models;
namespace CourseInfoSharingPlatform.Views
{
    /// <summary>
    /// StuCourseCollection.xaml 的交互逻辑
    /// </summary>
    public partial class StuCourseCollection : Window
    {
        private User user;
        public StuCourseCollection(User user)
        {
            InitializeComponent();
            this.user = user;
            InitializeCourseList();
        }
        private void InitializeCourseList()
        {
            //调用StuADOService,通过Controller请求api
            this.courseList.ItemsSource = user.LikeCourses;
        }

        //详情按钮
        private void specificCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            Course c = btn.DataContext as Course;
            CourseDetailedInfoView courseDetailedInfoView = new CourseDetailedInfoView(CourseHttpClient.GetCourseById(c.CourseId), this.user);
            courseDetailedInfoView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            courseDetailedInfoView.Show();
        }

        //整个窗口移动按钮
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        //取消收藏按钮
        private void cancelCollectBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            Course c = btn.DataContext as Course;
            if (c != null) UserHttpClient.DeleteFavouriteCourse(user.UserName, c.CourseId);
            user = UserHttpClient.GetUser(user.UserName);
            this.courseList.ItemsSource = user.LikeCourses;
        }
        //返回按钮
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            new UserMain(user).Show();
            this.Close();
        }
    }
}
