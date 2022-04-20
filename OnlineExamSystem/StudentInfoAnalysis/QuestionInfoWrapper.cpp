#include "QuestionInfo.h"
#include <comdef.h>
extern "C"	_declspec(dllexport) QuestionInfo * CreateQuestionInfo() {
	return new QuestionInfo();
}


extern "C"	_declspec(dllexport)  void DeleteQuestionInfo(QuestionInfo* info) {
	return delete info;
}

extern "C"	_declspec(dllexport)  BSTR GetQuestionText(QuestionInfo* info) {
	return _com_util::ConvertStringToBSTR(info->GetQuestionText().c_str());
}

extern "C" _declspec(dllexport) void SetQuestionText(QuestionInfo* info,const char* text) {
	info->SetQuestionText(text);
}
extern "C"	_declspec(dllexport) BSTR GetWrongAnswer0(QuestionInfo * info) {
	return _com_util::ConvertStringToBSTR(info->GetWrongAnswer0().c_str());
}
extern "C"	_declspec(dllexport) BSTR GetWrongAnswer1(QuestionInfo * info) {
	return _com_util::ConvertStringToBSTR(info->GetWrongAnswer1().c_str());
}
extern "C"	_declspec(dllexport) BSTR GetWrongAnswer2(QuestionInfo * info) {
	return _com_util::ConvertStringToBSTR(info->GetWrongAnswer2().c_str());
}
extern "C"	_declspec(dllexport) BSTR GetCorrectAnswer0(QuestionInfo * info) {
	return _com_util::ConvertStringToBSTR(info->GetCorrectAnswer0().c_str());
}
extern "C"	_declspec(dllexport) void SetWrongAnswer0(QuestionInfo * info,const char* text) {
	info->SetWrongAnswer0(text);
}
extern "C"	_declspec(dllexport) void SetWrongAnswer1(QuestionInfo * info, const char* text) {
	info->SetWrongAnswer1(text);
}

extern "C"	_declspec(dllexport) void SetWrongAnswer2(QuestionInfo * info, const char* text) {
	info->SetWrongAnswer2(text);
}

extern "C"	_declspec(dllexport) void SetCorrectAnswer0(QuestionInfo * info, const char* text) {
	info->SetCorrectAnswer0(text);
}

extern "C"	_declspec(dllexport) int GetGlobalCount(QuestionInfo * info) {
	return info->GetGlobalCount();
}
extern "C"	_declspec(dllexport) int GetGlobaRightlCount(QuestionInfo * info) {
	return info->GetGlobalRightCount();
}extern "C"	_declspec(dllexport) int GetDifficulty(QuestionInfo * info) {
	return info->GetDifficultyMultiplier();
}

extern "C"	_declspec(dllexport) void SetGlobalCount(QuestionInfo * info,int value) {
	info->SetGlobalCount(value);
}
extern "C"	_declspec(dllexport) void SetGlobalRightCount(QuestionInfo * info,int value) {
	info->SetGlobalRightCount(value);
}extern "C"	_declspec(dllexport) void SetDifficulty(QuestionInfo * info,int value) {
	info->SetDifficultyMultiplier(value);
}

