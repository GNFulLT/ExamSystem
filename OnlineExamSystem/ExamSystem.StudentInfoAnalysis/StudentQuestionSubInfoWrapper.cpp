#include "StudentQuestionSubInfo.h"
#include <comdef.h>
#include "CasterHelper.h"

extern "C"	_declspec(dllexport) StudentQuestionSubInfo * CreateStudentQuestionSubInfo() {
	return new StudentQuestionSubInfo();
}

extern "C"	_declspec(dllexport)  void DeleteStudentQuestionSubInfo(StudentQuestionSubInfo * info) {
	return delete info;
}

//Getters
extern "C"	_declspec(dllexport)  BSTR GetLastDate(StudentQuestionSubInfo * info) {
	return _com_util::ConvertStringToBSTR(CasterHelper::DateToString(info->GetLastDate()).c_str());
}

extern "C"	_declspec(dllexport)  BSTR GetNowDate(StudentQuestionSubInfo * info) {
	return _com_util::ConvertStringToBSTR(CasterHelper::DateToString(info->GetNowDate()).c_str());
}

//Setters

extern "C"	_declspec(dllexport)  void SetLastDate(StudentQuestionSubInfo * info, const char* s) {
	info->SetLastDate(s);
}

extern "C"	_declspec(dllexport)  void SetNowDate(StudentQuestionSubInfo * info, const char* s) {
	info->SetNowDate(s);
}