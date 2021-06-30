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
    /// ReportView.xaml 的交互逻辑
    /// </summary>
    public partial class ReportView : Window
    {
        private Comment comment;
        private Question question;
        public ReportView(Comment c,Question q)
        {
            InitializeComponent();
            this.comment = c;
            this.question = q;
            TextBlock.SetLineHeight(this.reportReason, 18);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        //关闭按钮
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {           
            this.Close();
        }

        //提交举报评论
        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {
            string reason = this.reportReason.Text;
            if (question == null)
                CommentHttpClient.reportComment(comment.CommentId, reason);
            else CommentHttpClient.reportQuestion(question.QuestionId, reason);
            this.Close();
        }
    }
}
