using ExamSystem.Core.ViewModels.StudentPanel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Core.ViewModels
{
    public class StudentScreenViewModel : ViewModel
    {
        public static Type Parent;

        public StudentScreenViewModel()
        {
            DashBoardPanelViewModel = new StudentScreenDashBoardPanelViewModel();

            ExamsPanelViewModel = new StudentScreenExamsPanelViewModel();

            OldExamsPanelViewModel = new StudentScreenOldExamsPanelViewModel();

            DashBoardPanel = Activator.CreateInstance(StudentScreenDashBoardPanelViewModel.Parent, DashBoardPanelViewModel);

            ExamsPanel = Activator.CreateInstance(StudentScreenExamsPanelViewModel.Parent, ExamsPanelViewModel);

            OldExamsPanel = Activator.CreateInstance(StudentScreenOldExamsPanelViewModel.Parent, OldExamsPanelViewModel);

            CurrentPanel = DashBoardPanel;
        }


        #region Properties

        public object CurrentPanel { get; set; }

        #endregion

        #region Unbinded Properties
        public object DashBoardPanel { get; set; }

        public object ExamsPanel { get; set; }

        public object OldExamsPanel { get; set; }

        public StudentScreenDashBoardPanelViewModel DashBoardPanelViewModel { get; set; }

        public StudentScreenExamsPanelViewModel ExamsPanelViewModel { get; set; }

        public StudentScreenOldExamsPanelViewModel OldExamsPanelViewModel { get; set; }
        #endregion


        #region Commands

        public RelayCommand DashBoardClickCommand => new RelayCommand((sender) =>
        {
            CurrentPanel = DashBoardPanel;
        });
        public RelayCommand ExamsClickCommand => new RelayCommand((sender) =>
        {
            CurrentPanel = ExamsPanel;
        });
        public RelayCommand OldExamsClickCommand => new RelayCommand((sender) =>
        {
            CurrentPanel = OldExamsPanel;
        });
        #endregion

    }
}
