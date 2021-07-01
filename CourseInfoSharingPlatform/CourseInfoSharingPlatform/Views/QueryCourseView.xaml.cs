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
        private bool isAdmin;
        private User user;
        private Admin Admin { get; set; }
        private List<Course> courses = new List<Course>();
        private int _pageIndex=1;
        private int _pageCount=0;
  
        public QueryCourseView(User user,bool isAdmin)
        {
            InitializeComponent();
            this.user = user;
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

            CourseDetailedInfoView courseDetailedInfoView = new CourseDetailedInfoView(CourseHttpClient.GetCourseById(c.CourseId),this.user);
            courseDetailedInfoView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Visibility = Visibility.Hidden;
            courseDetailedInfoView.ShowDialog();
            this.Visibility = Visibility.Visible;
            //this.Close();
        }

        //返回按钮
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!isAdmin) new UserMain(user).Show();
            else new AdminManagement(this.Admin).Show();
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
                    courses = CourseHttpClient.GetAllCourseOrderByHeatNum((_pageIndex - 1) * 4, 4);
                else if (sortCondition.Equals("按评分"))
                    courses = CourseHttpClient.GetAllCourse((_pageIndex - 1) * 4, 4);
                else if (sortCondition.Equals("按收藏量"))
                    courses = CourseHttpClient.GetAllCourseOrderByLikeNum((_pageIndex - 1) * 4, 4);
            }
            else //查询条件不为空时
            {
                string input = this.searchInput.Text;
                //只按课程号查询时
                if (searchCondition.Equals("课头号"))
                {
                    var course= CourseHttpClient.GetCourseById(input);
                    if (course == null) { SetPaginationBtn(0); courses = new List<Course>(); }
                    else
                    {
                        SetPaginationBtn(1);
                        courses = new List<Course>() { course };
                    }
                }
                else if (sortCondition.Equals("按热度"))
                {
                    if (searchCondition.Equals("课程类型"))
                    {
                        totalPageNum = CourseHttpClient.GetPageNumByType(input);
                        SetPaginationBtn(totalPageNum);
                        courses = CourseHttpClient.GetCourseByTypeOrderByHeatNum(input, (_pageIndex - 1) * 4, 4);
                    }
                    if (searchCondition.Equals("课程老师"))
                    {
                        totalPageNum = CourseHttpClient.GetPageNumByTeacherName(input);
                        SetPaginationBtn(totalPageNum);
                        courses = CourseHttpClient.GetCourseByTeacherNameOrderByHeatNum(input, (_pageIndex - 1) * 4, 4);
                    }
                    if (searchCondition.Equals("课程名"))
                    {
                        totalPageNum = CourseHttpClient.GetPageNumByCourseName(input);
                        SetPaginationBtn(totalPageNum);
                        courses = CourseHttpClient.GetCourseByCourseNameOrderByHeatNum(input, (_pageIndex - 1) * 4, 4);
                    }
                }
                else if (sortCondition.Equals("按评分"))
                {
                    if (searchCondition.Equals("课程类型"))
                    {
                        totalPageNum = CourseHttpClient.GetPageNumByType(input);
                        SetPaginationBtn(totalPageNum);
                        courses = CourseHttpClient.GetCourseByType(input, (_pageIndex - 1) * 4, 4);
                    }
                    if (searchCondition.Equals("课程老师"))
                    {
                        totalPageNum = CourseHttpClient.GetPageNumByTeacherName(input);
                        SetPaginationBtn(totalPageNum);
                        courses = CourseHttpClient.GetCourseByTeacherName(input, (_pageIndex - 1) * 4, 4);
                    }
                    if (searchCondition.Equals("课程名"))
                    {
                        totalPageNum = CourseHttpClient.GetPageNumByCourseName(input);
                        SetPaginationBtn(totalPageNum);
                        courses = CourseHttpClient.GetCourseByCourseName(input, (_pageIndex - 1) * 4, 4);
                    }
                }
                else if (sortCondition.Equals("按收藏量"))
                {
                    if (searchCondition.Equals("课程类型"))
                    {
                        totalPageNum = CourseHttpClient.GetPageNumByType(input);
                        SetPaginationBtn(totalPageNum);
                        courses = CourseHttpClient.GetCourseByTypeOrderByLikeNum(input, (_pageIndex - 1) * 4, 4);
                    }
                    if (searchCondition.Equals("课程老师"))
                    {
                        totalPageNum = CourseHttpClient.GetPageNumByTeacherName(input);
                        SetPaginationBtn(totalPageNum);
                        courses = CourseHttpClient.GetCourseByTeacherNameOrderByLikeNum(input, (_pageIndex - 1) * 4, 4);
                    }
                    if (searchCondition.Equals("课程名"))
                    {
                        totalPageNum = CourseHttpClient.GetPageNumByCourseName(input);
                        SetPaginationBtn(totalPageNum);
                        courses = CourseHttpClient.GetCourseByCourseNameOrderByLikeNum(input, (_pageIndex - 1) * 4, 4);
                    }
                }
            }
            this.listBoxCourses.ItemsSource = courses;
        }

        //根据总页数，设置分页相关按钮,和初始分页数据显示
        private void SetPaginationBtn(int totalPageNum)
        {
            //分页总数为0时
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
            SetCourses();
        }

        //上一页
        private void lastPageBtn_Click(object sender, RoutedEventArgs e)
        {
            _pageIndex--;
            if (_pageIndex <= 1) this.lastPageBtn.IsEnabled = false;
            this.nextPageBtn.IsEnabled = true;
            this.pageIndexTB.Text = _pageIndex.ToString();
            SetCourses();
        }

        //下一页
        private void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            _pageIndex++;
            if (_pageIndex == _pageCount) this.nextPageBtn.IsEnabled = false;
            this.lastPageBtn.IsEnabled = true;
            this.pageIndexTB.Text = _pageIndex.ToString();
            SetCourses();
        }

        //根据当前页显示课程信息
        private void  SetCourses()
        {
            string searchCondition = null;
            ComboBoxItem item = this.searchConditionCB.SelectedItem as ComboBoxItem;
            if (item != null)
                searchCondition = item.Content.ToString();
            string sortCondition = (this.sortConditionLB.SelectedItem as ListBoxItem).Content.ToString();
            if (searchCondition == null)
            {
                if (sortCondition.Equals("按热度"))
                    courses = CourseHttpClient.GetAllCourseOrderByHeatNum((_pageIndex - 1) * 4, 4);
                else if (sortCondition.Equals("按评分"))
                    courses = CourseHttpClient.GetAllCourse((_pageIndex - 1) * 4, 4);
                else if (sortCondition.Equals("按收藏量"))
                    courses = CourseHttpClient.GetAllCourseOrderByLikeNum((_pageIndex - 1) * 4, 4);
            }
            else //查询条件不为空时
            {
                string input = this.searchInput.Text;
                //只按课程号查询时
                if (searchCondition.Equals("课头号"))
                {
                    var course = CourseHttpClient.GetCourseById(input);
                    if (course == null) SetPaginationBtn(0);
                    else courses = new List<Course>() { course };
                }
                else if (sortCondition.Equals("按热度"))
                {
                    if (searchCondition.Equals("课程类型"))
                        courses = CourseHttpClient.GetCourseByTypeOrderByHeatNum(input, (_pageIndex - 1) * 4, 4);
                    if (searchCondition.Equals("课程老师"))
                        courses = CourseHttpClient.GetCourseByTeacherNameOrderByHeatNum(input, (_pageIndex - 1) * 4, 4);
                    if (searchCondition.Equals("课程名"))
                        courses = CourseHttpClient.GetCourseByCourseNameOrderByHeatNum(input, (_pageIndex - 1) * 4, 4);
                }
                else if (sortCondition.Equals("按评分"))
                {
                    if (searchCondition.Equals("课程类型"))
                        courses = CourseHttpClient.GetCourseByType(input, (_pageIndex - 1) * 4, 4);
                    if (searchCondition.Equals("课程老师"))
                        courses = CourseHttpClient.GetCourseByTeacherName(input, (_pageIndex - 1) * 4, 4);
                    if (searchCondition.Equals("课程名"))
                        courses = CourseHttpClient.GetCourseByCourseName(input, (_pageIndex - 1) * 4, 4);
                }
                else if (sortCondition.Equals("按收藏量"))
                {
                    if (searchCondition.Equals("课程类型"))
                        courses = CourseHttpClient.GetCourseByTypeOrderByLikeNum(input, (_pageIndex - 1) * 4, 4);
                    if (searchCondition.Equals("课程老师"))
                        courses = CourseHttpClient.GetCourseByTeacherNameOrderByLikeNum(input, (_pageIndex - 1) * 4, 4);
                    if (searchCondition.Equals("课程名"))
                        courses = CourseHttpClient.GetCourseByCourseNameOrderByLikeNum(input, (_pageIndex - 1) * 4, 4);
                }
            }
            this.listBoxCourses.ItemsSource = courses;
        }
    }
}
