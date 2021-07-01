using CourseInfoSharingPlatform.Models;
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
    /// ReportListView.xaml 的交互逻辑
    /// </summary>
    public partial class ReportListView : Window
    {
        private List<Comment> commentsReport = new List<Comment>();
        private List<Question> questionsReport = new List<Question>();
        public ReportListView()
        {
            InitializeComponent();
            
            this.commentReportList.ItemsSource = commentsReport;
            this.questionReportList.ItemsSource = questionsReport;
        }
        private void InitDataSource()
        {

        }

        //整个窗口移动按钮
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        //删除回复
        private void deleteCommentBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        //忽略回复
        private void ignoreCommentBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        //删除问题
        private void deleteQuestionBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        //忽略问题
        private void ignoreQuestionBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
