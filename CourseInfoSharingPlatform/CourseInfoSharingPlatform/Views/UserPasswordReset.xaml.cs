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
using System.Globalization;
using CourseInfoSharingPlatform.Models;

namespace CourseInfoSharingPlatform.Views
{
    /// <summary>
    /// UserPasswordReset.xaml 的交互逻辑
    /// </summary>
    public class PassWordConverter: IValueConverter
    {     
        private string realWord = "";
        private char replaceChar = '*';

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                string temp = parameter.ToString();
                if (!string.IsNullOrEmpty(temp))
                {
                    replaceChar = temp.First();
                }
            }
            if (value != null)
            {
                realWord = value.ToString();
            }
            string replaceWord = "";
            for (int index = 0; index < realWord.Length; ++index)
            {
                replaceWord += replaceChar;
            }
            return replaceWord;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string backValue = "";
            if (value != null)
            {
                string strValue = value.ToString();
                for (int index = 0; index < strValue.Length; ++index)
                {
                    if (strValue.ElementAt(index) == replaceChar)
                    {
                        backValue += realWord.ElementAt(index);
                    }
                    else
                    {
                        backValue += strValue.ElementAt(index);
                    }
                }
            }
            return backValue;
        }
    }
    public partial class UserPasswordReset : Window
    {
        private User user;
        public UserPasswordReset(User user)
        {
            InitializeComponent();
            this.user = user;
            this.UserNameBlock.Text = user.UserName;        
        }
       
        //整个窗口移动按钮
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        //修改
        private void ModifyBtn_Click(object sender, RoutedEventArgs e)
        {
            string oldPassWord = this.OldPwdTextBox.Password;
            string newPassWord = this.NewPwdTextBox.Password;
            if (user.Password != oldPassWord) this.PwdStatusText.Text = "原密码错误！";
            else
            {
                UserHttpClient.UpdateUserPassword(user.UserName, newPassWord);
                this.PwdStatusText.Text = "修改成功!";
                //返回登录界面
                new loginPage().Show();
                this.Close();
            }
        }
        //返回按钮
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            new UserMain(this.user).Show();
            this.Close();
        }
    }
}
