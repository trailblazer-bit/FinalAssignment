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
        public SelfMainPage()
        {
            InitializeComponent();
            init();
        }
        private User user;
        private void init()
        {
            UserHttpClient userHttpClient = UserHttpClient.GetInstance();
            //user = userHttpClient.GetUser();
            if(user != null)
            {
                this.UserNameTextBlock.Text = user.UserName;
                this.UserNameTextBox.Text = user.UserName;

                if (user.Gender != null && user.Gender == "male")
                    this.male.IsChecked = true;
                else if (user.Gender != null && user.Gender == "female")
                    this.female.IsChecked = true;
                else this.secret.IsChecked = true;

                this.Instruction.Text = user.Introduction;
                this.Major.Text = user.Major;
                this.GradeTextBox.Text = user.Grade;
                this.selfInstructionTextBlock.Text = user.Introduction;
               
            }
            else
            {
                if (MessageBox.Show("服务器异常，请重新登录！", "通知", MessageBoxButton.OK) == MessageBoxResult.OK)
                    this.Close();
                else init();
            }
        }
        private void ChooseBgPicBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //设置这个对话框的起始打开路径
            ofd.InitialDirectory = "C:\\";
            //设置打开的文件的类型，注意过滤器的语法
            ofd.Filter = "PNG图片|*.png|JPG图片|*.jpg|JPEG图片|*.jpeg";
            //调用ShowDialog()方法显示该对话框，该方法的返回值代表用户是否点击了确定按钮
            if (ofd.ShowDialog() == true)
            {
                ImageBrush imageBrush = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(ofd.FileName)),
                    Stretch = Stretch.UniformToFill
                };
                this.BgBorder.Background = imageBrush;
            }
            else
            {
                MessageBox.Show("没有选择图片");
            }
        }

        private void ModifyInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            //UserNameTextBox.IsReadOnly = false;
            GradeTextBox.IsReadOnly = false;
            Major.IsReadOnly = false;
            Instruction.IsReadOnly = false;
            ModifyInfoBtn.Visibility = Visibility.Collapsed;
            PutChangeBtn.Visibility = Visibility.Visible;
        }

        private void PutChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.male.IsChecked == true)
                user.Gender = "male";
            else if (this.female.IsChecked == true)
                user.Gender = "female";
            else user.Gender = "secret";

            user.Grade = this.GradeTextBox.Text;
            user.Major = this.Major.Text;
            user.Introduction = this.Instruction.Text;
            UserHttpClient userHttpClient = UserHttpClient.GetInstance();
            userHttpClient.ModifyInformation(user);
            ModifyInfoBtn.Visibility = Visibility.Collapsed;
            ModifyInfoBtn.Visibility = Visibility.Visible;
        }
    }
}
