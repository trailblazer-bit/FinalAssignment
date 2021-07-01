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
    /// AdminManagement.xaml 的交互逻辑
    /// </summary>
    public partial class AdminManagement : Window
    {
        private Admin admin;
        public AdminManagement(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            this.adminNameTB.Text = admin.AdminName;
        }
        //切换用户
        private void SwitchBtn_Click(object sender, RoutedEventArgs e)
        {
            new loginPage().Show();
            this.Close();
        }
        //退出系统
        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        //窗口移动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        //添加课程
        private void addCourseBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        //修改课程
        private void modifyCourseBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        //管理评论
        private void mangementCommentBtn_Click(object sender, RoutedEventArgs e)
        {
            ReportListView view = new ReportListView();
            this.Visibility = Visibility.Hidden;
            view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view.Show();
            this.Visibility = Visibility.Visible;
        }
    }
}
