using ExamSystem.Core.Utilities.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ExamSystem.Core.ViewModels.LoginPanel
{
    public class LoginScreenForgotPanelViewModel : ViewModel
    {
        public static Type Parent;

        public LoginScreenForgotPanelViewModel()
        {

            Localization.SetDefaultLocalization(this);
        }

        #region Properties
        public string EmailTextBoxText { get; set; }


        #endregion

        #region LocalizableProperties

        [LocalizableProperty]
        public string ForgotEmailButtonText { get; set; }

        [LocalizableProperty]
        public string BackText { get; set; }
        #endregion

        #region Commands
        public ICommand BackLabelClickedCommand => new RelayCommand((sender) =>
        {
            BackLabelClicked?.Invoke(sender);
        });
        #endregion

        #region Events
        public event Action<object> BackLabelClicked;
        #endregion

    }
}
