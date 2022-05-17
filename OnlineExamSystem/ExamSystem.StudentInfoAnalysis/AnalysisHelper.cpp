#include "AnalysisHelper.h"

#include "ListBinderHelper.h"
#include "CasterHelper.h"

#include<boost/range/algorithm/min_element.hpp>
#include <boost/multiprecision/cpp_bin_float.hpp>


bool AnalysisHelper::_isStarted = false;

boost::movelib::unique_ptr<ListBinderHelper<QuestionInfo*>> AnalysisHelper::questInfo;

boost::movelib::unique_ptr<ListBinderHelper<StudentQuestionSubInfo*>> AnalysisHelper::studentInfo;

int AnalysisHelper::_globalNextDay = 7;
int AnalysisHelper::_globalDifficultyCount = 5;
void AnalysisHelper::Add(QuestionInfo* questInfo, StudentQuestionSubInfo* studentInfo) {
	AnalysisHelper::questInfo.get()->Bind(questInfo);
	AnalysisHelper::studentInfo.get()->Bind(studentInfo);
}

void  AnalysisHelper::Analysis() {
	auto list1 = questInfo.get()->GetList();
	auto list2 = studentInfo.get()->GetList();

	auto iterator1 = list1->begin();
	auto iterator2 = list2->begin();

	while (iterator1 != list1->end() && iterator2 != list2->end()) {
		QuestionInfo* question = iterator1.get()->get_data();
		StudentQuestionSubInfo* subInfo = iterator2.get()->get_data();

		


		//SET NEXT DAY
		int rightSolveCount = subInfo->GetRightSolveCountInARow();
		subInfo->SetNowDateCurrent();
		boost::gregorian::date* nowDate = subInfo->GetNowDate();
		
		boost::gregorian::date newNextDate = boost::gregorian::date(nowDate->year(),nowDate->month(),nowDate->day())
			+ boost::gregorian::days(_globalNextDay * rightSolveCount);

		subInfo->SetNextDate(CasterHelper::DateToString(&newNextDate).c_str());
		
		subInfo->SetLastDate(CasterHelper::DateToString(nowDate).c_str());

		//Student understand question ratio
		boost::multiprecision::cpp_bin_float_100 q1 = question->GetGlobalCount() + 50;
		boost::multiprecision::cpp_bin_float_100 q2 = question->GetGlobalRightCount() + 45;
		boost::multiprecision::cpp_bin_float_100 q6 = question->GetDifficultyMultiplier();

		float val = q1.convert_to<float>();
		float val2 = q2.convert_to<float>();

		boost::multiprecision::cpp_bin_float_100 q3 =  subInfo->GetTotalSolveCount()+1;
		boost::multiprecision::cpp_bin_float_100 q4 = subInfo->GetRightSolveCount();
		boost::multiprecision::cpp_bin_float_100 q5 = subInfo->GetRightSolveCountInARow();

		boost::multiprecision::cpp_bin_float_100 expectedRatio = ((100/(_globalDifficultyCount+1))*(_globalDifficultyCount-q6+1))/100;

		boost::multiprecision::cpp_bin_float_100 questionGlobalRate =  ((q2 / q1)*2 + expectedRatio*3)/5;

		float rate = questionGlobalRate.convert_to<float>();

		boost::multiprecision::cpp_bin_float_100 difGap = q3 - q4;


		boost::multiprecision::cpp_bin_float_100 questionLocalRate = (q4 / q3) + ((1 - (q4/q3)) * q5 / (3 + q5));



		subInfo->CreateMeasureInfo(ceil(questionLocalRate.convert_to<float>()*100));

		question->CreateMeasureInfo(ceil(questionGlobalRate.convert_to<float>()*100));




		iterator1++;
		iterator2++;
	}
}


boost::multiprecision::cpp_bin_float_100 AnalysisHelper::MixMeasureInfo
(boost::multiprecision::cpp_bin_float_100 info1, boost::multiprecision::cpp_bin_float_100 info2) {
	return (info1 * 3 + info2 * 2) / 5;
}

void AnalysisHelper::EndAnalysis() {
	_isStarted = false;
	questInfo.get()->EndBinding();
	studentInfo.get()->EndBinding();

	questInfo.get()->ResetList();
	studentInfo.get()->ResetList();

	questInfo.reset();
	studentInfo.reset();
 }

void AnalysisHelper::StartAnalysis() {
	_isStarted = true;
	questInfo.reset(new ListBinderHelper<QuestionInfo*>());
	studentInfo.reset(new ListBinderHelper<StudentQuestionSubInfo*>());
	questInfo.get()->StartBinding();
	studentInfo.get()->StartBinding();
}
