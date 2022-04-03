#include "QuestionInfo.h"

QuestionInfo::QuestionInfo() {

}

std::string QuestionInfo::GetQuestionText() {
	return _questionText;
}

void QuestionInfo::SetQuestionText(std::string text) {
	_questionText = text;
}

std::string QuestionInfo::GetWrongAnswer0(){
	return _wrongAnswer0;
}
std::string QuestionInfo::GetWrongAnswer1() {
	return _wrongAnswer1;
}
std::string QuestionInfo::GetWrongAnswer2() {
	return _wrongAnswer2;
}
std::string QuestionInfo::GetCorrectAnswer0() {
	return _correctAnswer0;
}

void QuestionInfo::SetWrongAnswer0(std::string text) {
	_wrongAnswer0 = text;
}
void QuestionInfo::SetWrongAnswer1(std::string text) {
	_wrongAnswer1 = text;
}
void QuestionInfo::SetWrongAnswer2(std::string text) {
	_wrongAnswer2 = text;
}
void QuestionInfo::SetCorrectAnswer0(std::string text) {
	_correctAnswer0 = text;
}
int QuestionInfo::GetGlobalRightCount() {
	return _globalRightCount;
}
int QuestionInfo::GetGlobalCount() {
	return _globalCount;
}
int QuestionInfo::GetDifficultyMultiplier() {
	return _difficultyMultiplier;
}
void QuestionInfo::SetGlobalRightCount(int value) {
	_globalRightCount = value;

}
void QuestionInfo::SetGlobalCount(int value) {
	_globalCount = value;

}
void QuestionInfo::SetDifficultyMultiplier(int value) {
	_difficultyMultiplier = value;

}