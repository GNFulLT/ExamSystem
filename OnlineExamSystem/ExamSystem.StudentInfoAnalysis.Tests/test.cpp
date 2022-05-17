#include "pch.h"
#include "../ExamSystem.StudentInfoAnalysis/AnalysisWrapper.h"
#include "../ExamSystem.StudentInfoAnalysis/CasterHelper.h"
#include "../ExamSystem.StudentInfoAnalysis/QuestionInfo.h"
#include "../ExamSystem.StudentInfoAnalysis/StudentQuestionSubInfo.h"
#include <comdef.h>

TEST(TestCaseName, TestName) {
	AnalysisWrapper wrapper;
	wrapper.StartAnalysis();
	std::unique_ptr<QuestionInfo> questInfo1(new QuestionInfo());
	std::unique_ptr<StudentQuestionSubInfo> studentInfo1(new StudentQuestionSubInfo());

	studentInfo1->SetLastDate(CasterHelper::DateToString(&boost::gregorian::date(boost::gregorian::from_string("2020/1/25"))).c_str());
	studentInfo1->SetNowDate(CasterHelper::DateToString(&boost::gregorian::date(boost::gregorian::from_string("2020/1/25"))).c_str());
	studentInfo1->SetNowDateCurrent();
	studentInfo1->SetRightSolveCountInARow(1);
	studentInfo1->SetRightSolveCount(5);
	studentInfo1->SetTotalSolveCount(7);
	

	wrapper.Add(questInfo1.get(), studentInfo1.get());

	wrapper.Analysis();

	if (questInfo1.get()->IsMeasured() && studentInfo1->IsMeasured()) {
		auto measure1 = questInfo1->GetMeasureInfo();
		auto measure2 = studentInfo1->GetMeasureInfo();
		int x = 5;
		x = x * x;
	}

	wrapper.EndAnalysis();

}