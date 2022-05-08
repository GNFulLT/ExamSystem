#ifndef STUDENTQUESTIONSUBINFO_H
#define STUDENTQUESTIONSUBINFO_H

#include <boost/cstdint.hpp> 
#include <boost/container/string.hpp>
#include <boost/date_time/gregorian/gregorian.hpp>
#include <boost/move/unique_ptr.hpp>
#include "DLLEXPORT.h"
#include "StudentQuestionSubInfoMeasureContainer.h"
class ROOTERLIB_API StudentQuestionSubInfo
{
public:
	StudentQuestionSubInfo();

	//Getters
	boost::gregorian::date* GetLastDate() const;
	boost::gregorian::date* GetNowDate() const;
	boost::gregorian::date* GetNextDate() const;

	uint_fast8_t GetTotalSolveCount() const;
	uint_fast8_t GetRightSolveCount() const;
	uint_fast8_t GetRightSolveCountInARow() const;

	//Setters 
	void SetLastDate(boost::container::string date);
	void SetNowDate(boost::container::string date); 
	void SetNextDate(boost::container::string date);

	void SetTotalSolveCount(uint_fast8_t value);
	void SetRightSolveCount(uint_fast8_t value);
	void SetRightSolveCountInARow(uint_fast8_t value);


	void SetNowDateCurrent();
	
	void CreateMeasureInfo(uint_fast8_t ratio);
	StudentQuestionSubInfoMeasureContainer* GetMeasureInfo() const;
	bool IsMeasured() const;

private:
	boost::movelib::unique_ptr<boost::gregorian::date> lastDate;
	boost::movelib::unique_ptr<boost::gregorian::date> nowDate;
	boost::movelib::unique_ptr<boost::gregorian::date> nextDate;
	boost::movelib::unique_ptr<StudentQuestionSubInfoMeasureContainer> _measureInfos;

	uint_fast8_t totalSolveCount;	
	uint_fast8_t rightSolveCount;
	uint_fast8_t rightSolveCountInARow;

	bool _isMeasured = false;

};




#endif