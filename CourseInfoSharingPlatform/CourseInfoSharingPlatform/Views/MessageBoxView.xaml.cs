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
    /// MessageBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxView : Window
    {
        public MessageBoxView(string info)
        {
            InitializeComponent();
            this.infoTB.Text = info;
        }

        //确认按钮
        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //整个窗口移动按钮
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
