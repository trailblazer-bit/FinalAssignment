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
namespace CourseInfoSharingPlatform.Views
{
    /// <summary>
    /// UserPasswordReset.xaml 的交互逻辑
    /// </summary>
    public class PassWordConverter
            : IValueConverter
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
        public UserPasswordReset()
        {
            InitializeComponent();

            this.UserNameBlock.Text = UserHttpClient.GetInstance().GetName();

            //密码框黑点
            this.OldPwdTextBox.TextDecorations = new TextDecorationCollection(new TextDecoration[] {
                new TextDecoration() {
                     Location= TextDecorationLocation.Strikethrough,
                      Pen= new Pen(Brushes.Black, 20f) {
                          DashCap =  PenLineCap.Round,
                           StartLineCap= PenLineCap.Round,
                            EndLineCap= PenLineCap.Round,
                             DashStyle= new DashStyle(new double[] {0.0,0.8 }, 0.6f)
                      }
                }

            });
            this.NewPwdTextBox.TextDecorations = new TextDecorationCollection(new TextDecoration[] {
                new TextDecoration() {
                     Location= TextDecorationLocation.Strikethrough,
                      Pen= new Pen(Brushes.Black, 20f) {
                          DashCap =  PenLineCap.Round,
                           StartLineCap= PenLineCap.Round,
                            EndLineCap= PenLineCap.Round,
                             DashStyle= new DashStyle(new double[] {0.0,0.8 }, 0.6f)
                      }
                }

            });

        }
        private async void ModifyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (await UserHttpClient.GetInstance().ResetPassword(OldPwdTextBox.Text, NewPwdTextBox.Text) == true)
            {
                PwdStatusText.Visibility = Visibility.Visible;
                PwdStatusText.Text = "成功";

            }
            else
            {
                PwdStatusText.Visibility = Visibility.Visible;
                PwdStatusText.Text = "密码错误，请重新输入！";
            }
        }
    }
}
