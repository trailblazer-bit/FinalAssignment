#pragma checksum "..\..\..\Views\AdminManagement.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1247B28EE4AF6ECCCF49CCB2EA743F1C5CB8D21933AD9192D7553703B55FCB3F"
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


namespace CourseInfoSharingPlatform.Views {
    
    
    /// <summary>
    /// AdminManagement
    /// </summary>
    public partial class AdminManagement : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\Views\AdminManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem SwitchBtn;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Views\AdminManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem LogoutBtn;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Views\AdminManagement.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock adminNameTB;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CourseInfoSharingPlatform;component/views/adminmanagement.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\AdminManagement.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 12 "..\..\..\Views\AdminManagement.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SwitchBtn = ((System.Windows.Controls.MenuItem)(target));
            
            #line 40 "..\..\..\Views\AdminManagement.xaml"
            this.SwitchBtn.Click += new System.Windows.RoutedEventHandler(this.SwitchBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LogoutBtn = ((System.Windows.Controls.MenuItem)(target));
            
            #line 42 "..\..\..\Views\AdminManagement.xaml"
            this.LogoutBtn.Click += new System.Windows.RoutedEventHandler(this.LogoutBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.adminNameTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            
            #line 55 "..\..\..\Views\AdminManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addCourseBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 59 "..\..\..\Views\AdminManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.modifyCourseBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 63 "..\..\..\Views\AdminManagement.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.mangementCommentBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

