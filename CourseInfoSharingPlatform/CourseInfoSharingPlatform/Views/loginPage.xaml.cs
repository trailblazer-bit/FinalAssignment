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
namespace CourseInfoSharingPlatform.Views
{
    /// <summary>
    /// loginPage.xaml 的交互逻辑
    /// </summary>
    public partial class loginPage : Window
    {
        public loginPage()
        {
            InitializeComponent();
            UserTypeCombobox.SelectedIndex = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            //通过UserHttpClient发送一个http get请求，传入用户输入信息，服务器运行匹配
            //若账号密码正确，则返回该User对象，否则返回空信息
            //bool Authen = false;
            if (UserNameInput.Text != "" || UserPwdInput.Text != "")
            {

                UserHttpClient userHttpClient = UserHttpClient.GetInstance();
                /*if (await userHttpClient.AuthenticateAsync(UserNameInput.Text, UserPwdInput.Text, UserTypeCombobox.SelectedIndex == 1 ))
                {
                    //跳转stumain
                    this.Close();

                }
                else
                {
                    warning.Content = "用户名/密码错误";
                    warning.Visibility = Visibility.Visible;
                }*/
                new UserMain().Show();
                this.Close();
            }
            else
            {
                warning.Content = "请正确输入";
                warning.Visibility = Visibility.Visible;
            }

        }

        private void logonBtn_Click(object sender, RoutedEventArgs e)
        {
            new LogonPage(this).ShowDialog();
            this.Visibility = Visibility.Collapsed;
        }
    }
}
