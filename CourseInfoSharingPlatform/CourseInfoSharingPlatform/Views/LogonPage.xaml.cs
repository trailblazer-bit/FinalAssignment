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
        Window login;
        public LogonPage(Window login)
        {
            InitializeComponent();
            UserTypeCombobox.SelectedIndex = 1;
            this.login = login;
        }

        private async void LogonBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserNameInput.Text != "" || UserPwdInput.Text != "")
            {
                UserHttpClient userHttpClient = UserHttpClient.GetInstance();
                User user = new User();
                user.UserName = UserNameInput.Text;
                user.Password = UserPwdInput.Text;
                if (await userHttpClient.CreateAccount(user))
                {
                    //跳转登录
                    this.Close();
                    login.Visibility = Visibility.Visible;

                }
                else
                {
                    warning.Content = "用户名已存在";
                    warning.Visibility = Visibility.Visible;
                }
            }
            else
            {
                warning.Content = "请正确输入";
                warning.Visibility = Visibility.Visible;
            }
        }
    }
}
