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

extern "C"	_declspec(dllexport)  BSTR GetNextDate(StudentQuestionSubInfo * info) {
	return _com_util::ConvertStringToBSTR(CasterHelper::DateToString(info->GetNextDate()).c_str());
}

extern "C"	_declspec(dllexport) int GetRightSolveCount(StudentQuestionSubInfo * info) {
	return info->GetRightSolveCount();
}
extern "C"	_declspec(dllexport) int GetRightSolveInARowCount(StudentQuestionSubInfo * info) {
	return info->GetRightSolveCountInARow();
}
extern "C"	_declspec(dllexport) int GetTotalSolveCount(StudentQuestionSubInfo * info) {
	return info->GetTotalSolveCount();
}
extern "C"	_declspec(dllexport) bool GetIsMeasured(StudentQuestionSubInfo * info) {
	return info->IsMeasured();
}
extern "C"	_declspec(dllexport) int GetMeasureInfo(StudentQuestionSubInfo * info) {
	if (info->GetMeasureInfo() == nullptr)
		return 0;
	return info->GetMeasureInfo()->_questionLocalRate;

}
//Setters

extern "C"	_declspec(dllexport)  void SetLastDate(StudentQuestionSubInfo * info, const char* s) {
	info->SetLastDate(s);
}

extern "C"	_declspec(dllexport)  void SetNowDate(StudentQuestionSubInfo * info, const char* s) {
	info->SetNowDate(s);
}

extern "C"	_declspec(dllexport)  void SetNextDate(StudentQuestionSubInfo * info, const char* s) {
	info->SetNextDate(s);
}

extern "C"	_declspec(dllexport)  void SetRightSolveCount(StudentQuestionSubInfo * info, int value) {
	value = value % 100;
	info->SetRightSolveCount(value);
}

extern "C"	_declspec(dllexport)  void SetRightSolveCountInARow(StudentQuestionSubInfo * info, int value) {
	value = value % 100;
	info->SetRightSolveCountInARow(value);
}


extern "C"	_declspec(dllexport)  void SetTotalSolveCount(StudentQuestionSubInfo * info, int value) {
	value = value % 100;
	info->SetTotalSolveCount(value);
}