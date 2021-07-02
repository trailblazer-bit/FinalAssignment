using CourseInfoSharingPlatform.ClientHttp;
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
            InitDataSource();
        }
        private void InitDataSource()
        {
            this.commentsReport = CommentHttpClient.GetAllCommentReport();
            this.questionsReport = CommentHttpClient.GetAllQuestionReport();
            this.commentReportList.ItemsSource = commentsReport;
            this.questionReportList.ItemsSource = questionsReport;
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
            Button btn = e.OriginalSource as Button;
            Comment c = btn.DataContext as Comment;
            if(c!=null)
            {
                CommentHttpClient.deleteCommentById(c.CommentId);
                InitDataSource();
            }
        }
        //忽略回复
        private void ignoreCommentBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            Comment c = btn.DataContext as Comment;
            if (c != null)
            {
                CommentHttpClient.IgnoreCommentReport(c.CommentId);
                InitDataSource();
            }
        }
        //删除问题
        private void deleteQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            Question q = btn.DataContext as Question;
            if (q != null)
            {
                CommentHttpClient.deleteQuestionById(q.QuestionId);
                InitDataSource();
            }
        }
        //忽略问题
        private void ignoreQuestionBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.OriginalSource as Button;
            Question q = btn.DataContext as Question;
            if (q != null)
            {
                CommentHttpClient.IgnoreQuestionReport(q.QuestionId);
                InitDataSource();
            }
        }
        //返回
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
