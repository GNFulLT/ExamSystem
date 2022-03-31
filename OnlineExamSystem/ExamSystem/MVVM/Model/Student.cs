using ExamSystem.Core;
using ExamSystem.Core.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.MVVM.Model
{
    public class Student : ObservableObject
    {
        private Account _account;

        public Account _Account
        {
            get { return _account; }
            set { _account = value;
                NotifyPropertyChanged();
            }
        }

        private StudentInfo _info;

        public StudentInfo Info
        {
            get { return _info; }
            set { _info = value;
                NotifyPropertyChanged();
            }
        }


        public Student(Account account,StudentInfo info)
        {
            _Account = account;
            Info = info;
        }

    }
}
