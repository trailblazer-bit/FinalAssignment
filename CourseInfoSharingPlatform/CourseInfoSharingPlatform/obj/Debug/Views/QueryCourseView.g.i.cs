// Updated by XamlIntelliSenseFileGenerator 2021/6/28 21:50:48
#pragma checksum "..\..\..\Views\QueryCourseView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E825BD5AACF5D50C646A3C7EB81EC6DE15B518745B46BEE22345B14F762D21CC"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using CourseInfoSharingPlatform.Converters;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CourseInfoSharingPlatform.Views
{


    /// <summary>
    /// QueryCourseView
    /// </summary>
    public partial class QueryCourseView : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector
    {


#line 102 "..\..\..\Views\QueryCourseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox searchConditionCB;

#line default
#line hidden


#line 127 "..\..\..\Views\QueryCourseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox sortConditionLB;

#line default
#line hidden


#line 142 "..\..\..\Views\QueryCourseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxCourses;

#line default
#line hidden


#line 158 "..\..\..\Views\QueryCourseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button headPageBtn;

#line default
#line hidden


#line 159 "..\..\..\Views\QueryCourseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button lastPageBtn;

#line default
#line hidden


#line 160 "..\..\..\Views\QueryCourseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock pageIndexTB;

#line default
#line hidden


#line 162 "..\..\..\Views\QueryCourseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock pageCountTB;

#line default
#line hidden


#line 163 "..\..\..\Views\QueryCourseView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextPageBtn;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CourseInfoSharingPlatform;component/views/querycourseview.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Views\QueryCourseView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 2:

#line 60 "..\..\..\Views\QueryCourseView.xaml"
                    ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);

#line default
#line hidden
                    return;
                case 3:

#line 69 "..\..\..\Views\QueryCourseView.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.backBtn_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.searchConditionCB = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 5:

#line 122 "..\..\..\Views\QueryCourseView.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.searchBtn_Click);

#line default
#line hidden
                    return;
                case 6:
                    this.sortConditionLB = ((System.Windows.Controls.ListBox)(target));
                    return;
                case 7:

#line 128 "..\..\..\Views\QueryCourseView.xaml"
                    ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.listBoxItem_Selected);

#line default
#line hidden
                    return;
                case 8:

#line 131 "..\..\..\Views\QueryCourseView.xaml"
                    ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.listBoxItem_Selected);

#line default
#line hidden
                    return;
                case 9:

#line 134 "..\..\..\Views\QueryCourseView.xaml"
                    ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.listBoxItem_Selected);

#line default
#line hidden
                    return;
                case 10:
                    this.listBoxCourses = ((System.Windows.Controls.ListBox)(target));
                    return;
                case 11:
                    this.headPageBtn = ((System.Windows.Controls.Button)(target));

#line 158 "..\..\..\Views\QueryCourseView.xaml"
                    this.headPageBtn.Click += new System.Windows.RoutedEventHandler(this.headPageBtn_Click);

#line default
#line hidden
                    return;
                case 12:
                    this.lastPageBtn = ((System.Windows.Controls.Button)(target));

#line 159 "..\..\..\Views\QueryCourseView.xaml"
                    this.lastPageBtn.Click += new System.Windows.RoutedEventHandler(this.lastPageBtn_Click);

#line default
#line hidden
                    return;
                case 13:
                    this.pageIndexTB = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 14:
                    this.pageCountTB = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 15:
                    this.nextPageBtn = ((System.Windows.Controls.Button)(target));

#line 163 "..\..\..\Views\QueryCourseView.xaml"
                    this.nextPageBtn.Click += new System.Windows.RoutedEventHandler(this.nextPageBtn_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 31 "..\..\..\Views\QueryCourseView.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.specificCourseBtn_Click);

#line default
#line hidden
                    break;
            }
        }

        internal System.Windows.Controls.TextBox searchInput;
    }
}

