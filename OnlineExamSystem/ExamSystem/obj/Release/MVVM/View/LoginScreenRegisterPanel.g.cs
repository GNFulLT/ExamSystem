﻿#pragma checksum "..\..\..\..\MVVM\View\LoginScreenRegisterPanel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B736DB39B1AD0319E0A990E4AE34C3AF2C5968F74B10879B085EFFB3A7E50848"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ExamSystem.MVVM.View;
using ExamSystem.MVVM.ViewModel;
using MaterialDesignThemes.MahApps;
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


namespace ExamSystem.MVVM.View {
    
    
    /// <summary>
    /// LoginScreenRegisterPanel
    /// </summary>
    public partial class LoginScreenRegisterPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\MVVM\View\LoginScreenRegisterPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UsernameTextBox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\MVVM\View\LoginScreenRegisterPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EmailTextBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\MVVM\View\LoginScreenRegisterPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\MVVM\View\LoginScreenRegisterPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameSurnameTextBox;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\MVVM\View\LoginScreenRegisterPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RegisterButton;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\MVVM\View\LoginScreenRegisterPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ExamSystem.MVVM.View.LoadingContentBar LoadingBar;
        
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
            System.Uri resourceLocater = new System.Uri("/ExamSystem;component/mvvm/view/loginscreenregisterpanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVM\View\LoginScreenRegisterPanel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.UsernameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\..\MVVM\View\LoginScreenRegisterPanel.xaml"
            this.UsernameTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Username_InputHandle);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\MVVM\View\LoginScreenRegisterPanel.xaml"
            this.UsernameTextBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.UsernameTextBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.EmailTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PasswordTextBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.NameSurnameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.RegisterButton = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\..\..\MVVM\View\LoginScreenRegisterPanel.xaml"
            this.RegisterButton.Click += new System.Windows.RoutedEventHandler(this.RegisterButtonClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 135 "..\..\..\..\MVVM\View\LoginScreenRegisterPanel.xaml"
            ((System.Windows.Controls.Label)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.BackLabelClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LoadingBar = ((ExamSystem.MVVM.View.LoadingContentBar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

