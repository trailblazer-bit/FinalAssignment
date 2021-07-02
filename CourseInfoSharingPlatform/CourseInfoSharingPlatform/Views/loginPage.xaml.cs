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
    /// loginPage.xaml 的交互逻辑
    /// </summary>
    public partial class loginPage : Window
    {
        private bool isAdmin;
        public loginPage()
        {
            InitializeComponent();
        }

        //整个窗口移动按钮
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        //关闭按钮
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        //登录
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string userName = this.UserNameInput.Text;
            string passWord = this.UserPwdInput.Password;
            this.isAdmin = (bool)this.adminRB.IsChecked;         
            if (userName != "" && passWord != "")
            {
                if (!isAdmin) StudentLogin(userName, passWord);
                else AdminLogin(userName, passWord);
                
            }
            else
                warning.Text = "用户名或密码未填写";         
        }
        //学生登录
        private void StudentLogin(string userName,string passWord)
        {
            User user = UserHttpClient.GetUser(userName);
            //用户存在
            if (user != null)
            {
                if (user.Password == passWord)
                {
                    UserMain view = new UserMain(user);
                    view.WindowStartupLocation = this.WindowStartupLocation;
                    view.Show();
                    this.Close();
                }
                else warning.Text = "输入密码错误";
            }
            else this.warning.Text = "用户不存在!";
        }
        //管理员登录
        private void AdminLogin(string userName,string passWord)
        {
            Admin admin = UserHttpClient.GetAdmin(userName);
            //用户存在
            if (admin != null)
            {
                if (admin.Password == passWord)
                {
                    AdminManagement view = new AdminManagement(admin);
                    view.WindowStartupLocation = this.WindowStartupLocation;
                    view.Show();
                    this.Close();
                }
                else warning.Text = "输入密码错误";
            }
            else this.warning.Text = "用户不存在!";
        }

        //注册
        private void logonBtn_Click(object sender, RoutedEventArgs e)
        {       
            this.isAdmin =(bool) this.adminRB.IsChecked;
            LogonPage view = new LogonPage();
            view.WindowStartupLocation = this.WindowStartupLocation;
            this.Visibility = Visibility.Hidden;
            view.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
