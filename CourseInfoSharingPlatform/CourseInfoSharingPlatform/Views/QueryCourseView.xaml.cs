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
        private List<Course> courses = new List<Course>();
        private int _pageIndex=1;
        private int _pageCount=0;
  
        public QueryCourseView()
        {
            InitializeComponent();
            InitialCourseList();
        }

        //初始化课程列表
        private void InitialCourseList()
        {
            //先算总页数
            var totalPageNum = CourseHttpClient.GetTotalPageNum();
            SetPaginationBtn(totalPageNum);
            if(_pageIndex>0)
                courses = CourseHttpClient.GetAllCourse((_pageIndex - 1) * 4, 4);
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
            var totalPageNum = 0;
            if(searchCondition==null)
            {
                //当查询条件为空时，查询所有的课程的总页数
                totalPageNum = CourseHttpClient.GetTotalPageNum();
                SetPaginationBtn(totalPageNum);
                if (sortCondition.Equals("按热度"))
                    courses = CourseHttpClient.GetAllCourseOrderByHeatNum(_pageIndex, _pageCount);
                else if (sortCondition.Equals("按评分"))
                    courses = CourseHttpClient.GetAllCourse(_pageIndex, _pageCount);
                else if (sortCondition.Equals("按收藏量"))
                    courses = CourseHttpClient.GetAllCourseOrderByLikeNum(_pageIndex, _pageCount);
            }
            else //查询条件不为空时
            {
                //if(searchCondition.Equals(""))
                //else if (sortCondition.Equals("按热度"))
                //{
                //    if(searchCondition.Equals())
                //}
                //else if (sortCondition.Equals("按评分"))
                //{

                //}
                //else if (sortCondition.Equals("按收藏量"))
                //{

                //}
            }
        }

        //根据总页数，设置分页相关按钮,和初始分页数据显示
        private void SetPaginationBtn(int totalPageNum)
        {
            if(totalPageNum<=0)
            {
                _pageIndex = 0;
                _pageCount = 0;
                pageIndexTB.Text = _pageIndex.ToString();
                pageCountTB.Text = _pageCount.ToString();
                this.nextPageBtn.IsEnabled = false;
                this.lastPageBtn.IsEnabled = false;
                this.headPageBtn.IsEnabled = false;
            }
            else
            {
                _pageIndex = 1;
                _pageCount = totalPageNum;
                pageIndexTB.Text = _pageIndex.ToString();
                pageCountTB.Text = _pageCount.ToString();
                if (totalPageNum > 1)
                    this.nextPageBtn.IsEnabled = true;
                else
                    this.nextPageBtn.IsEnabled = false;
                this.headPageBtn.IsEnabled = true;
                this.lastPageBtn.IsEnabled = false;
            }
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

        //选中某个排序项目
        private void listBoxItem_Selected(object sender, RoutedEventArgs e)
        {
        }
    }
}
