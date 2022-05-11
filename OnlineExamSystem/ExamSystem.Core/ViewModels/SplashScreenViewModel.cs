using ExamSystem.Core.Models;
using ExamSystem.Core.SubModels;
using ExamSystem.Core.Utilities.Builders.Exams;
using ExamSystem.Core.Utilities.NavigationSource;
using ExamSystem.Core.Utilities.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamSystem.Core.ViewModels
{
  

    public class SplashScreenViewModel : ViewModel
    {
        public static Type Parent;
        
        private Account acc;

        public SplashScreenViewModel(Account account)
        {
            acc = account;
            AccountProvider.InitializeInfos(account);
        }


        public string InfoText { get; set; }


        public async void Initialize()
        {
            InfoText = "Checking connection";

            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
            
            if(acc._AccountType == Account.AccountType.Teacher)
            {
                await InitializeEducator();

                var currentWindow = Activator.CreateInstance(EducatorScreenViewModel.Parent, new EducatorScreenViewModel());

                Navigation.CurrentWindow = currentWindow;
            }
           else if (acc._AccountType == Account.AccountType.Student)
            {
                await InitializeStudent();

                var currentWindow = Activator.CreateInstance(StudentScreenViewModel.Parent, new StudentScreenViewModel());

                Navigation.CurrentWindow = currentWindow;
            }
        }

        private Task InitializeStudent()
        {
            return Task.Run(() =>
            {
                InfoText = "Loading Units";

                UnitSectionProvider.InitializeMaps();

                InfoText = "Loading Questions";

                QuestionProvider.InitializeMaps();

                InfoText = "Loading Student Infos";

                StudentProvider.InitializeInfos();

                var eb = new StudentExamBuilder(10);


                ExamDirector director = new ExamDirector(eb);

                director.CreateExam();

                Exam exam = eb.GetExam();
            });
        }

        private Task InitializeEducator()
        {
            return Task.Run(() =>
            {
                InfoText = "Loading Units";

                UnitSectionProvider.InitializeMaps();

                InfoText = "Loading Questions";

                QuestionProvider.InitializeMaps();

                Thread.Sleep(200);

                InfoText = "Loading Exams";

                Thread.Sleep(1000);

            });
        

         
        }
    }
}
