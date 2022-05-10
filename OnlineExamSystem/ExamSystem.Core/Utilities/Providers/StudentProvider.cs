using ExamSystem.Core.Models;
using ExamSystem.Core.Utilities.Services.SubServices.StudentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Core.Utilities.Providers
{
    public static class StudentProvider
    {
        private static Lazy<Task<Student>> _loginedStudent;

        public static Student LoginedStudent
        {
            get { Checker(); return _loginedStudent.Value.Result; }
        }

        private static Lazy<Task<List<StudentQuestionInfo>>> _loginedStudentQuestionInfos;

        public static List<StudentQuestionInfo> GetStudentQuestionInfos()
        {
            return _loginedStudentQuestionInfos.Value.Result;
        }

        public static StudentQuestionInfo GetStudentQuestionInfo(Question q)
        {
            return _loginedStudentQuestionInfos.Value.Result.Where(q2 => q2.Question == q).First();
        }

        private static bool _isInitialized = false;

        public static void InitializeInfos()
        {
            if (_isInitialized)
                return;

            _loginedStudent = new Lazy<Task<Student>>(() =>
            {
                StudentService service = new StudentService();
 
                return service.GetStudentByAccount(AccountProvider.LoginedAccount);
            });

            _loginedStudentQuestionInfos = new Lazy<Task<List<StudentQuestionInfo>>>(() =>
            {
                StudentQuestionInfoService service = new StudentQuestionInfoService();
                return service.GetAllByStudent(LoginedStudent);
            });

            _isInitialized = true;

            Student std = LoginedStudent;

            List<StudentQuestionInfo> infos = GetStudentQuestionInfos();
        }

        private static void Checker()
        {
            if (!_isInitialized)
            {
                throw new Exception("Unit Sections doesn't initialized");
            }
        }
    }
}
