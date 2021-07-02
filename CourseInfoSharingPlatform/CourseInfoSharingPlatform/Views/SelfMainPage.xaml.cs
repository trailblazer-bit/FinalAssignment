using Microsoft.Win32;
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
using CourseInfoSharingPlatform.Models;
using CourseInfoSharingPlatform.ClientHttp;
namespace CourseInfoSharingPlatform.Views
{
    /// <summary>
    /// SelfMainPage.xaml 的交互逻辑
    /// </summary>
    public partial class SelfMainPage : Window
    {
        private User user;
        public SelfMainPage(User user)
        {
            InitializeComponent();
            this.user = user;
            Init();
        }
        private void Init()
        {
            //UserHttpClient userHttpClient = UserHttpClient.GetInstance();
            //user = userHttpClient.GetUser();
            this.userNameTB.IsReadOnly = true;
            this.majorTB.IsReadOnly = true;
            this.gradeTB.IsReadOnly = true;
            this.introductionTB.IsReadOnly = true;
            if (user != null)
            {
                this.userNameTB.Text = user.UserName;
                this.majorTB.Text = user.Major;
                this.gradeTB.Text = user.Grade;
                this.introductionTB.Text = user.Introduction;

                if (user.Gender != null && user.Gender == "男")
                    this.male.IsChecked = true;
                else if (user.Gender != null && user.Gender == "女")
                    this.female.IsChecked = true;
                else this.secret.IsChecked = true;
            }
        }

        //整个窗口移动按钮
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        //返回按钮
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //编辑资料
        private void ModifyInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.majorTB.IsReadOnly = false;
            this.introductionTB.IsReadOnly = false;
            this.gradeTB.IsReadOnly = false;
            ModifyInfoBtn.Visibility = Visibility.Collapsed;
            PutChangeBtn.Visibility = Visibility.Visible;
        }
        //提交修改
        private void PutChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            user.Major = this.majorTB.Text;
            user.Introduction = introductionTB.Text;
            user.Grade= this.gradeTB.Text;
            if (this.male.IsChecked == true)
                user.Gender = "男";
            else if (this.female.IsChecked == true)
                user.Gender = "女";
            else user.Gender = null;
            //发送修改请求
            bool result=UserHttpClient.UpdateUserInfo(user);
            if(!result)
            {
                MessageBoxView view1 = new MessageBoxView("修改个人信息失败！");
                view1.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                view1.ShowDialog();
                return;
            }
            MessageBoxSuccessView view2 = new MessageBoxSuccessView("修改个人信息成功！");
            view2.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view2.ShowDialog();
            Init();
            ModifyInfoBtn.Visibility = Visibility.Visible;
            PutChangeBtn.Visibility = Visibility.Collapsed;
        }
        //重置
        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            Init();
            ModifyInfoBtn.Visibility = Visibility.Visible;
            PutChangeBtn.Visibility = Visibility.Collapsed;
        }      
    }
}
