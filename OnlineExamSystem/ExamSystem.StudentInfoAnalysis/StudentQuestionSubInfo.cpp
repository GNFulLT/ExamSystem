#include "StudentQuestionSubInfo.h"

StudentQuestionSubInfo::StudentQuestionSubInfo() {
	rightSolveCount = 0;
	rightSolveCountInARow = 0;
	totalSolveCount = 0;

	lastDate.reset(new boost::gregorian::date(boost::gregorian::date_from_iso_string("00000000")));
}

//Getters
boost::gregorian::date* StudentQuestionSubInfo::GetLastDate() const {
	return this->lastDate.get();
}
boost::gregorian::date* StudentQuestionSubInfo::GetNowDate() const {
	return this->nowDate.get();
}
boost::gregorian::date* StudentQuestionSubInfo::GetNextDate() const {
	return this->nextDate.get();
}

uint_fast8_t StudentQuestionSubInfo::GetTotalSolveCount() const {
	return this->totalSolveCount;
}
uint_fast8_t StudentQuestionSubInfo::GetRightSolveCount() const {
	return this->rightSolveCount;
}
uint_fast8_t StudentQuestionSubInfo::GetRightSolveCountInARow() const {
	return this->rightSolveCountInARow;
}

//Setters
void StudentQuestionSubInfo::SetLastDate(boost::container::string date) {
	this->lastDate.reset(new boost::gregorian::date(boost::gregorian::date_from_iso_string(date.c_str())));
}
void StudentQuestionSubInfo::SetNowDate(boost::container::string date) {
	this->nowDate.reset(new boost::gregorian::date(boost::gregorian::date_from_iso_string(date.c_str())));
}
void StudentQuestionSubInfo::SetNextDate(boost::container::string date) {
	this->nextDate.reset(new boost::gregorian::date(boost::gregorian::date_from_iso_string(date.c_str())));
}
void StudentQuestionSubInfo::SetTotalSolveCount(uint_fast8_t value) {
	this->totalSolveCount = value;
}
void StudentQuestionSubInfo::SetRightSolveCount(uint_fast8_t value) {
	this->rightSolveCount = value;
}
void StudentQuestionSubInfo::SetRightSolveCountInARow(uint_fast8_t value) {
	this->rightSolveCountInARow = value;
}




void StudentQuestionSubInfo::CreateMeasureInfo(uint_fast8_t ratio) {
	this->_isMeasured = true;
	_measureInfos.reset(new StudentQuestionSubInfoMeasureContainer(ratio));
}

StudentQuestionSubInfoMeasureContainer* StudentQuestionSubInfo::GetMeasureInfo() const{
	if (_isMeasured == false) {
		throw std::invalid_argument("Info is not measured");
	}
	return _measureInfos.get();
}

bool StudentQuestionSubInfo::IsMeasured() const {
	return _isMeasured;
}

void StudentQuestionSubInfo::SetNowDateCurrent() {
	nowDate.reset(new boost::gregorian::date(boost::gregorian::day_clock::local_day()));
}
