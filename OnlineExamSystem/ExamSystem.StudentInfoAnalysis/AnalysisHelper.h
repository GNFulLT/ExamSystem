#ifndef ANALYSISHELPER_H
#define ANALYSISHELPER_H

#include "QuestionInfo.h"
#include "StudentQuestionSubInfo.h"
#include "ListBinderHelper.h"
#include <boost/cstdint.hpp> 
#include <boost/multiprecision/cpp_bin_float.hpp>



class  AnalysisHelper
{
public:

	static void StartAnalysis();
	static void Add(QuestionInfo*,StudentQuestionSubInfo*);
	static void Analysis();
	static void EndAnalysis(); 
	static boost::multiprecision::cpp_bin_float_100  MixMeasureInfo(
			boost::multiprecision::cpp_bin_float_100  info1,
			boost::multiprecision::cpp_bin_float_100  info2);
private:
	AnalysisHelper();
	static bool _isStarted;
	static boost::movelib::unique_ptr<ListBinderHelper<QuestionInfo*>> questInfo;
	static boost::movelib::unique_ptr<ListBinderHelper<StudentQuestionSubInfo*>> studentInfo;
	static int _globalNextDay;
	static int _globalDifficultyCount;
};
#endif
