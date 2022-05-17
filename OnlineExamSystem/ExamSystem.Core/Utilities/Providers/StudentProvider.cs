using ExamSystem.Core.Models;
using ExamSystem.Core.SubModels;
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
            return _loginedStudentQuestionInfos.Value.Result is object ? _loginedStudentQuestionInfos.Value.Result : new List<StudentQuestionInfo>();
        }

        private static Lazy<Task<List<StudentExamInfo>>> _loginedStudentExamInfos;

        public static List<StudentExamInfo> GetStudentExamInfos()
        {
            return _loginedStudentExamInfos.Value.Result is object ? _loginedStudentExamInfos.Value.Result : new List<StudentExamInfo>();
        }

        private static Exam _todayExam;

        public static Exam TodayExam { get => _todayExam; set => _todayExam = value; }

        private static StudentExamInfo _todayStudentExamInfo;

        public static StudentExamInfo TodayStudentExamInfo
        {
            get => _todayStudentExamInfo;
            set => _todayStudentExamInfo = value;
        }

        public static StudentQuestionInfo GetStudentQuestionInfo(Question q)
        {
            return _loginedStudentQuestionInfos.Value.Result is object ?
                _loginedStudentQuestionInfos.Value.Result.Where(q2 => q2.Question == q).FirstOrDefault() : null;
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

            _loginedStudentExamInfos = new Lazy<Task<List<StudentExamInfo>>>(() =>
            {
                StudentExamInfoService service = new StudentExamInfoService();
                return service.GetAllByStudent(LoginedStudent);
            });

            _isInitialized = true;

            Student std = LoginedStudent;

            List<StudentQuestionInfo> infos = GetStudentQuestionInfos();
            List<StudentExamInfo> infos2 = GetStudentExamInfos();
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
