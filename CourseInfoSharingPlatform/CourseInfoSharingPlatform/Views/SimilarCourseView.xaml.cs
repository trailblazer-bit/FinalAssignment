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
    /// SimilarCourseView.xaml 的交互逻辑
    /// </summary>
    public delegate void GetCourseId(string courseId);  //声明委托

    public partial class SimilarCourseView : Window
    {      
        public GetCourseId getCourseId;

        private User user;
        public SimilarCourseView(User user,List<Course> courses)
        {
            InitializeComponent();
            this.user = user;
            this.courseList.ItemsSource = courses;
        }

        //整个窗口移动按钮
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        //详情
        private void specificCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            Course c = btn.DataContext as Course;
            getCourseId(c.CourseId);
            this.Close();

        }
        //返回按钮
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            getCourseId(null);
            this.Close();
        }
    }
}
