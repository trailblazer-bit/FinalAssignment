#pragma checksum "..\..\..\Views\loginPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "35967021F30CA1A6AA3B788F3A06B5B0CFCD813346468876077DAB33E86EDA23"
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
    /// loginPage
    /// </summary>
    public partial class loginPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\Views\loginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UserNameInput;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Views\loginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox UserPwdInput;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Views\loginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton stuRB;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Views\loginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton adminRB;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Views\loginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock warning;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Views\loginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button loginBtn;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Views\loginPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logonBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseInfoSharingPlatform;component/views/loginpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\loginPage.xaml"
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
            
            #line 12 "..\..\..\Views\loginPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 23 "..\..\..\Views\loginPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.closeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.UserNameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.UserPwdInput = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            this.stuRB = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.adminRB = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.warning = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.loginBtn = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Views\loginPage.xaml"
            this.loginBtn.Click += new System.Windows.RoutedEventHandler(this.loginBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.logonBtn = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\Views\loginPage.xaml"
            this.logonBtn.Click += new System.Windows.RoutedEventHandler(this.logonBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

