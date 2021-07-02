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
    /// AdminAddCourseView.xaml 的交互逻辑
    /// </summary>
    public partial class AdminAddCourse : Window
    {
        public AdminAddCourse()
        {
            InitializeComponent();
        }

        //窗口移动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        //清空所有内容
        private void ClearAllTextBox()
        {
            this.courseIdTB.Text = null;
            this.courseNameTB.Text = null;
            this.courseTeacherTB.Text = null;
            this.courseTypeTB.Text = null;
            this.departmentTB.Text = null;
            this.introduceTB.Text = null;      
            this.bookNameTB.Text = null;
        }

        //返回按钮
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //添加课程按钮
        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            //五个必填信息填写后才允许提交
            if (this.hiddenTB.Text == "")
            {
                //判断课程是否存在
                if (CourseHttpClient.GetCourseById(courseIdTB.Text) != null)
                {
                    MessageBoxView view = new MessageBoxView("要填加的课程已经存在,添加失败");
                    view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    view.ShowDialog();
                }
                else
                {
                    Course c = new Course { CourseId = courseIdTB.Text, Name = courseNameTB.Text, Type = courseTypeTB.Text,
                        TeacherName = courseTeacherTB.Text, Introduction = introduceTB.Text, BookName = bookNameTB.Text };
                    bool result=CourseHttpClient.AddCourse(c);
                    if (result) 
                    {
                        MessageBoxSuccessView view = new MessageBoxSuccessView("添加课程成功！");
                        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        view.ShowDialog();                     
                        ClearAllTextBox(); 
                    }
                    //这里不处理数据库操作异常
                }
            }
        }
    }
}
