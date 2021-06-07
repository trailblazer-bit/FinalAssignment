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
    /// QueryCourseView.xaml 的交互逻辑
    /// </summary>
    public partial class QueryCourseView : Window
    {
        private List<Course> courses;
        public QueryCourseView()
        {
            InitializeComponent();
            InitialCourseList();
        }

        private void InitialCourseList()
        {
            courses = new List<Course>()
            {
                new Course(){Name="Python程序设计",CourseId="123",Type="公选课",TeacherName="张三",Score=4.2,
                    tags=new List<Tag>{ new Tag() { Detail="作业不多"} , new Tag() { Detail = "作业不多" },new Tag() { Detail="作业不多"}} },

                new Course(){Name="Python程序设计",CourseId="123",Type="公选课",TeacherName="张三",Score=4.4,
                    tags=new List<Tag>{ new Tag() { Detail="作业不多"} , new Tag() { Detail = "作业不多" },new Tag() { Detail="作业不多"}} },

                new Course(){Name="Python程序设计",CourseId="123",Type="公选课",TeacherName="张三",Score=4.7,
                    tags=new List<Tag>{ new Tag() { Detail="作业不多"} , new Tag() { Detail = "作业不多" },new Tag() { Detail="作业不多"} } },

                new Course(){Name="Python程序设计",CourseId="123",Type="公选课",TeacherName="张三",Score=4.9,
                    tags=new List<Tag>{ new Tag() { Detail="作业不多"} , new Tag() { Detail = "作业不多" },new Tag() { Detail="作业不多"}} },
            };


            this.listBoxCourses.ItemsSource = courses;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            courses[0].Name = "张三";
        }
    }
}
