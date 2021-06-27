using CourseInfoSharingPlatform.HttpClient;
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
    /// QueryCourseView.xaml 的交互逻辑
    /// </summary>
    public partial class QueryCourseView : Window
    {
        private List<Course> courses;
        public QueryCourseView()
        {
            InitializeComponent();
            InitialCourseList();
        }

        //初始化课程列表
        private void InitialCourseList()
        {
            courses = CourseHttpClient.GetCourseList();
            this.listBoxCourses.ItemsSource = courses;
        }

        //移动窗口
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        //课程详情按钮
        private void specificCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            var o = e.OriginalSource as Button;
            Course c = o.DataContext as Course;
            //Console.WriteLine(c.CourseId);

            CourseDetailedInfoView courseDetailedInfoView = new CourseDetailedInfoView();
            courseDetailedInfoView.courseGrid.DataContext = CourseHttpClient.GetCourseById(c.CourseId);
            courseDetailedInfoView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Visibility = Visibility.Hidden;
            courseDetailedInfoView.ShowDialog();
            this.Visibility = Visibility.Visible;
            //this.Close();
        }

        //返回按钮
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //查询按钮
        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        //首页
        private void headPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        //上一页
        private void lastPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        //下一页
        private void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
