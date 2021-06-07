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
namespace CourseInfoSharingPlatform.Views
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            InitializeCourseList();
        }
        private void InitializeCourseList()
        {
            //调用StuADOService,通过Controller请求api

            List<Course> courses = new List<Course>()
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

        private void listBoxCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
