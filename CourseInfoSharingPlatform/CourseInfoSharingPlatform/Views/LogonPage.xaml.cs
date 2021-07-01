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
    /// LogonPage.xaml 的交互逻辑
    /// </summary>
    public partial class LogonPage : Window
    {
        public LogonPage()
        {
            InitializeComponent();
        }

        //整个窗口移动按钮
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        //提交按钮
        private void commitBtn_Click(object sender, RoutedEventArgs e)
        {
            string userName = this.UserNameInput.Text;
            string passWord1 = this.UserPwdInput.Password;
            string passWord2 = this.UserNewPwdInput.Password;
            if (userName == "") { warning.Text = "用户名未填写"; return; }
            if (passWord1 == "" || passWord2 == "") { warning.Text = "密码未填写"; return; }
            if (!passWord1.Equals(passWord2)) { warning.Text = "两次密码输入不一致"; return; }
            warning.Text = null;
            //提交添加新用户请求
            User user = new User() { UserName = userName, Password = passWord1 };
            if (!UserHttpClient.AddUser(user)) warning.Text = "注册失败!";
            else
            {
                if (MessageBox.Show("注册成功！是否返回登录界面") == MessageBoxResult.OK)
                {
                    new loginPage().Show();
                    this.Close();
                }
            }
        }
        //返回按钮
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
