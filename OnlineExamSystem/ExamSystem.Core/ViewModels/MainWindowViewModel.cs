using ExamSystem.Core.ViewModels.LoginPanel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamSystem.Core.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public static Type Parent;


        public MainWindowViewModel()
        {
             LoginPanelViewModel =  Resolver.Resolve<LoginScreenLoginPanelViewModel>();

             RegisterPanelViewModel = Resolver.Resolve<LoginScreenRegisterPanelViewModel>();

            ForgotEmailPanelViewModel = Resolver.Resolve<LoginScreenForgotPanelViewModel>();

            LoginPanel = Activator.CreateInstance(LoginScreenLoginPanelViewModel.Parent, LoginPanelViewModel);

            RegisterPanel = Activator.CreateInstance(LoginScreenRegisterPanelViewModel.Parent, RegisterPanelViewModel);

            ForgotPanel = Activator.CreateInstance(LoginScreenForgotPanelViewModel.Parent, ForgotEmailPanelViewModel);

            LoginPanelViewModel.RegisterLabelClicked += OnRegisterLabelClick;

            LoginPanelViewModel.ForgotLabelClicked += OnForgotLabelClick;

            RegisterPanelViewModel.BackLabelClicked += OnBackLabelClick;

            RegisterPanelViewModel.RegisteredSuccesfully += OnRegisteredSuccesfully;

            ForgotEmailPanelViewModel.BackLabelClicked += OnBackLabelClick;
            CurrentPanel = LoginPanel;
        }

        #region NestedViewModels
        public LoginScreenForgotPanelViewModel ForgotEmailPanelViewModel { get; set; }
        public LoginScreenLoginPanelViewModel LoginPanelViewModel { get; set; }
        public LoginScreenRegisterPanelViewModel RegisterPanelViewModel { get; set; }
        #endregion

        #region Properties
        public object CurrentPanel { get; set; }
        
        public object LoginPanel { get; set; }

        public object RegisterPanel { get; set; }

        public object ForgotPanel { get; set; }
        #endregion

        #region EventActionsForNestedViewModels
        public void OnForgotLabelClick(object sender)
        {
            CurrentPanel = ForgotPanel;
        }
        public void OnRegisterLabelClick(object sender)
        {
            CurrentPanel = RegisterPanel;
        }
        public void OnBackLabelClick(object sender)
        {
            CurrentPanel = LoginPanel;
        }
        public void OnRegisteredSuccesfully(object sender)
        {
            CurrentPanel = LoginPanel;
            LoginPanelViewModel.RegisteredSuccesfullyCommand?.Execute(sender);
        }
        #endregion
    }
}
