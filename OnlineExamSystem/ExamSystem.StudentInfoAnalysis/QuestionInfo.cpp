#include "QuestionInfo.h"

QuestionInfo::QuestionInfo() {
	_difficultyMultiplier = 0;
	_globalCount = 0;
	_globalRightCount = 0;
}

boost::container::string QuestionInfo::GetQuestionText() {
	return _questionText;
}

void QuestionInfo::SetQuestionText(boost::container::string text) {
	_questionText = text;
}

boost::container::string QuestionInfo::GetWrongAnswer0() {
	return _wrongAnswer0;
}
boost::container::string QuestionInfo::GetWrongAnswer1() {
	return _wrongAnswer1;
}
boost::container::string QuestionInfo::GetWrongAnswer2() {
	return _wrongAnswer2;
}
boost::container::string QuestionInfo::GetCorrectAnswer0() {
	return _correctAnswer0;
}

void QuestionInfo::SetWrongAnswer0(boost::container::string text) {
	_wrongAnswer0 = text;
}
void QuestionInfo::SetWrongAnswer1(boost::container::string text) {
	_wrongAnswer1 = text;
}
void QuestionInfo::SetWrongAnswer2(boost::container::string text) {
	_wrongAnswer2 = text;
}
void QuestionInfo::SetCorrectAnswer0(boost::container::string text) {
	_correctAnswer0 = text;
}
uintmax_t  QuestionInfo::GetGlobalRightCount() {
	return _globalRightCount;
}
uintmax_t  QuestionInfo::GetGlobalCount() {
	return _globalCount;
}
uintmax_t  QuestionInfo::GetDifficultyMultiplier() {
	return _difficultyMultiplier;
}
void QuestionInfo::SetGlobalRightCount(uintmax_t value) {
	_globalRightCount = value;

}
void QuestionInfo::SetGlobalCount(uintmax_t value) {

	_globalCount = value;

}
void QuestionInfo::SetDifficultyMultiplier(uintmax_t value) {
	_difficultyMultiplier =  value;
}