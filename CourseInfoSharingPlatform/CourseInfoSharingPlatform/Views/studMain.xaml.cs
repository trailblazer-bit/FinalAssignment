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
        public UserMain()
        {
            InitializeComponent();
        }

        //窗口移动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void QueryCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            new QueryCourseView().Show();
        }

        private void CollectionsBtn_Click(object sender, RoutedEventArgs e)
        {
            new StuCourseCollection().ShowDialog();
        }

        private void SelfInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            new SelfMainPage().Show();
        }

        private void RestPwdBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SwitchBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            new loginPage().Show();
            
        }

        private void SettingBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
