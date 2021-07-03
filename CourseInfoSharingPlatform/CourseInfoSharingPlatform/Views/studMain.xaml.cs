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
    /// UserMain.xaml 的交互逻辑
    /// </summary>
    public partial class UserMain : Window
    {
        private User user;
        public UserMain(User u)
        {
            InitializeComponent();
            this.user = u;
            this.userNameTB.Text = user.UserName;
        }

        //窗口移动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        //查询课程
        private void QueryCourseBtn_Click(object sender, RoutedEventArgs e)
        {         
            new QueryCourseView(user,false).Show();          
            this.Close();
        }

        //收藏课程夹
        private void CollectionsBtn_Click(object sender, RoutedEventArgs e)
        {
            //重查一次用户
            user = UserHttpClient.GetUser(user.UserName);
            new StuCourseCollection(this.user).Show();
            this.Close();
        }
        //个人信息
        private void SelfInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            SelfMainPage view = new SelfMainPage(this.user);
            this.Visibility = Visibility.Hidden;
            view.ShowDialog();
            this.Visibility = Visibility.Visible;
            this.user = UserHttpClient.GetUser(user.UserName);
        }

        //修改密码
        private void RestPwdBtn_Click(object sender, RoutedEventArgs e)
        {
            UserPasswordReset view = new UserPasswordReset(this.user);
            view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view.Show();
            this.Close();
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
    }
}
