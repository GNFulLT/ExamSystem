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
