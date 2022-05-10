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


	extern "C"	_declspec(dllexport)  float MixRate(float value1, float value2) {
		return AnalysisHelper::MixMeasureInfo(value1, value2).convert_to<float>();
	}