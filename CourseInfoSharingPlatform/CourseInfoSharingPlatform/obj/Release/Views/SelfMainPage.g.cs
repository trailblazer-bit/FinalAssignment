﻿#pragma checksum "..\..\..\Views\SelfMainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99923051E25A4AF1A6E84C2FDC09610FD05EDF3C51A7B7BEF4C46338E4CD7F34"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using CourseInfoSharingPlatform.Views;
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
    /// SelfMainPage
    /// </summary>
    public partial class SelfMainPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Views\SelfMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ModifyInfoBtn;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Views\SelfMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PutChangeBtn;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Views\SelfMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox userNameTB;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\Views\SelfMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox gradeTB;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Views\SelfMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox majorTB;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Views\SelfMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton male;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Views\SelfMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton female;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Views\SelfMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton secret;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\Views\SelfMainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox introductionTB;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseInfoSharingPlatform;component/views/selfmainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\SelfMainPage.xaml"
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
            
            #line 11 "..\..\..\Views\SelfMainPage.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 23 "..\..\..\Views\SelfMainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.backBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ModifyInfoBtn = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Views\SelfMainPage.xaml"
            this.ModifyInfoBtn.Click += new System.Windows.RoutedEventHandler(this.ModifyInfoBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PutChangeBtn = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\Views\SelfMainPage.xaml"
            this.PutChangeBtn.Click += new System.Windows.RoutedEventHandler(this.PutChangeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.userNameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.gradeTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.majorTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.male = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.female = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this.secret = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 11:
            this.introductionTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            
            #line 84 "..\..\..\Views\SelfMainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.resetBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

