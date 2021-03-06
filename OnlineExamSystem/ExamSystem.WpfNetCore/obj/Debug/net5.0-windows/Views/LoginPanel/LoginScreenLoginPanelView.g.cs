#pragma checksum "..\..\..\..\..\Views\LoginPanel\LoginScreenLoginPanelView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3CC4B6FBA87C61162052F65A1726328EE8D9406D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ExamSystem.WpfNetCore.Converters;
using ExamSystem.WpfNetCore.CustomControls;
using ExamSystem.WpfNetCore.Views.LoginPanel;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ExamSystem.WpfNetCore.Views.LoginPanel {
    
    
    /// <summary>
    /// LoginScreenLoginPanelView
    /// </summary>
    public partial class LoginScreenLoginPanelView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\..\Views\LoginPanel\LoginScreenLoginPanelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UsernameTextBox;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\Views\LoginPanel\LoginScreenLoginPanelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoginButton;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\..\Views\LoginPanel\LoginScreenLoginPanelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ExamSystem.WpfNetCore.CustomControls.LoadingContentBar LoadingBar;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\..\..\Views\LoginPanel\LoginScreenLoginPanelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ErrorLabel;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\..\Views\LoginPanel\LoginScreenLoginPanelView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ErrorLabel2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ExamSystem.WpfNetCore;component/views/loginpanel/loginscreenloginpanelview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\LoginPanel\LoginScreenLoginPanelView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UsernameTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 21 "..\..\..\..\..\Views\LoginPanel\LoginScreenLoginPanelView.xaml"
            this.UsernameTextBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.UsernameTextBox_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\..\..\Views\LoginPanel\LoginScreenLoginPanelView.xaml"
            this.UsernameTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.UsernameTextBox_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LoginButton = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.LoadingBar = ((ExamSystem.WpfNetCore.CustomControls.LoadingContentBar)(target));
            return;
            case 4:
            this.ErrorLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.ErrorLabel2 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

