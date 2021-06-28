using CourseInfoSharingPlatform.ClientHttp;
using CourseInfoSharingPlatform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class QueryCourseView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<Course> courses;
        private int _pageIndex=1;
        private int _pageCount=0;

        
        public QueryCourseView()
        {
            InitializeComponent();
            InitialCourseList();
            //先算总页数
            this.pageIndexTB.Text = _pageIndex.ToString();
            this.pageCountTB.Text = _pageCount.ToString();

        }

        //初始化课程列表
        private void InitialCourseList()
        {

            courses = CourseHttpClient.GetAllCourse((_pageIndex-1)*4,4);
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
            string searchCondition=null;
            ComboBoxItem item = this.searchConditionCB.SelectedItem as ComboBoxItem;
            if (item != null)
                searchCondition = item.Content.ToString();
            string sortCondition = (this.sortConditionLB.SelectedItem as ListBoxItem).Content.ToString();
            Console.WriteLine(searchCondition+"--->"+sortCondition);
        }

        //首页
        private void headPageBtn_Click(object sender, RoutedEventArgs e)
        {
            _pageIndex = 1;
            this.pageIndexTB.Text = _pageIndex.ToString();
            this.lastPageBtn.IsEnabled = false;
            if (_pageIndex == _pageCount) this.nextPageBtn.IsEnabled = false;
            else this.nextPageBtn.IsEnabled = true;
        }

        //上一页
        private void lastPageBtn_Click(object sender, RoutedEventArgs e)
        {
            _pageIndex--;
            if (_pageIndex <= 1) this.lastPageBtn.IsEnabled = false;
            this.nextPageBtn.IsEnabled = true;
            this.pageIndexTB.Text = _pageIndex.ToString();
        }

        //下一页
        private void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            _pageIndex++;
            if (_pageIndex == _pageCount) this.nextPageBtn.IsEnabled = false;
            this.lastPageBtn.IsEnabled = true;
            this.pageIndexTB.Text = _pageIndex.ToString();
        }
    }
}
