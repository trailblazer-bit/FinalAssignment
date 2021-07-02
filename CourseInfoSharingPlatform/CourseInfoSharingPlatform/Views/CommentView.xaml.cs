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
    /// CommentView.xaml 的交互逻辑
    /// </summary>
    public partial class CommentView : Window
    {
        //private List<Comment> comments;
        private Question Question { get; set; }
        private User user;
        private List<int> likedCommentId = new List<int>();
        private List<int> likedTagId = new List<int>();
        public CommentView(Question question,User user)
        {
            InitializeComponent();
            this.user = user;
            this.Question = question;
            Init();
        }
        private void Init()
        {
            this.questionBorder.DataContext = Question;
            this.questionTagListLB.ItemsSource = Question.QuestionTags.OrderByDescending(tag=>tag.LikeNum);
            this.commentsList.ItemsSource = Question.CommentList;
            this.anwserNumTB.DataContext = Question;
        }

        //整个窗口移动按钮
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        //关闭界面
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            //将界面中被点赞的回复,状态字段更新
            CommentHttpClient.AddLikeNumToComments(likedCommentId);
            //将界面中被点赞的标签，状态字段更新
            var items = this.questionTagListLB.SelectedItems;
            if (items != null)
            {
                foreach (var item in items)
                {
                    Tag tag = item as Tag;
                    likedTagId.Add(tag.TagId);
                }
            }
            TagHttpClient.AddLikeNumToTags(likedTagId);           
            this.Close();
        }

        //回复按钮
        private void answerBtn_Click(object sender, RoutedEventArgs e)
        {
            this.scrollViewer.ScrollToVerticalOffset(scrollViewer.ActualHeight);
        }

        //举报评论
        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {
            Button b = e.OriginalSource as Button;
            Comment c = b.DataContext as Comment;
            ReportView view = new ReportView(c,null);
            view.WindowStartupLocation = this.WindowStartupLocation;
            view.ShowDialog();
        }

        //添加标签
        private void addTagBtn_Click(object sender, RoutedEventArgs e)
        {
            string tagComment = this.addTagTB.Text;
            //清空输入框内容，下拉框折叠
            this.addTagTB.Text = null;
            this.tagExpander.IsExpanded = false;
            bool result=TagHttpClient.AddTag(tagComment, this.Question.QuestionId);
            if(!result)
            {
                MessageBoxView view = new MessageBoxView("含敏感词汇，添加失败！");
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                view.ShowDialog();
                return;
            }
            this.Question = CommentHttpClient.GetQuestionById(this.Question.QuestionId);
            Init();
        }

        //发布回复
        private void commnetBtn_Click(object sender, RoutedEventArgs e)
        {
            string comment = this.commentArea.Text;
            if (comment=="") return;
            //清空回复填写区
            this.commentArea.Text = null;
            //更新回复区,重新查一次该问题
            bool result=CommentHttpClient.AddComments(comment, user.UserName, Question.QuestionId);
            if(!result)
            {
                MessageBoxView view = new MessageBoxView("含敏感词汇，添加失败！");
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                view.ShowDialog();
                return;
            }
            this.Question = CommentHttpClient.GetQuestionById(Question.QuestionId);
            Init();
        }

        //回复点赞
        private void likeBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckBox btn = e.OriginalSource as CheckBox;
            Comment c = btn.DataContext as Comment;
            if (btn.IsChecked == false || btn.IsChecked == null)
            {
                c.LikeNum--;
                this.likedCommentId.Remove(c.CommentId);
            }
            else
            {
                c.LikeNum++;
                this.likedCommentId.Add(c.CommentId);
            }
        }

        //问题标签被点赞
        private void questionTagLikeBtn_Click(object sender, MouseButtonEventArgs e)
        {           
        }
    }
}
