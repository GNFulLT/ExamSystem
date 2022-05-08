#ifndef ANALYSISWRAPPER_H
#define ANALYSISWRAPPER_H

#include "QuestionInfo.h"
#include "StudentQuestionSubInfo.h"
#include "AnalysisHelper.h"
#include "DLLEXPORT.h"

class ROOTERLIB_API AnalysisWrapper {
public:
	void StartAnalysis();
	void EndAnalysis();
	void Add(QuestionInfo* quest, StudentQuestionSubInfo* subQuest);
	void Analysis();
private:

};

#endif