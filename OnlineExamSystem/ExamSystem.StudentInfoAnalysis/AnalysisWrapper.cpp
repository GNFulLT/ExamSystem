#include "AnalysisWrapper.h" 

	void AnalysisWrapper::StartAnalysis() {
		AnalysisHelper::StartAnalysis();
	}
	void AnalysisWrapper::EndAnalysis() {
		AnalysisHelper::EndAnalysis();
		
	}
	void AnalysisWrapper::Add(QuestionInfo* quest, StudentQuestionSubInfo* subQuest) {
		AnalysisHelper::Add(quest, subQuest);
	}
	void AnalysisWrapper::Analysis() {
		AnalysisHelper::Analysis();
	}

BSTR AnalysisWrapper::GetCurrent() {
		return _com_util::ConvertStringToBSTR(boost::gregorian::to_iso_string(boost::gregorian::day_clock::local_day()).c_str());

	}

	extern "C"	_declspec(dllexport)  float MixRate(float value1, float value2) {
		return AnalysisHelper::MixMeasureInfo(value1, value2).convert_to<float>();
	}


	extern "C"	_declspec(dllexport)  void StartAnalysis() {
		AnalysisHelper::StartAnalysis();
	}

	extern "C"	_declspec(dllexport)  void EndAnalysis() {
		AnalysisHelper::EndAnalysis();
	}
	extern "C"	_declspec(dllexport)  void Add(QuestionInfo * quest, StudentQuestionSubInfo * subQuest) {
		AnalysisHelper::Add(quest, subQuest);
	}
	extern "C"	_declspec(dllexport)  void Analysis() {
		AnalysisHelper::Analysis();
	}
	