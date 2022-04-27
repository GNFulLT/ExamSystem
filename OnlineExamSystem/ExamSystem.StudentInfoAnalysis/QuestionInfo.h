#ifndef QUESTIONINFO_H
#define QUESTIONINFO_H

#include <string>

class QuestionInfo {
public:
	QuestionInfo();
	std::string GetQuestionText();
	void SetQuestionText(std::string text);

	std::string GetWrongAnswer0();
	std::string GetWrongAnswer1();
	std::string GetWrongAnswer2();
	std::string GetCorrectAnswer0();

	void SetWrongAnswer0(std::string text);
	void SetWrongAnswer1(std::string text);
	void SetWrongAnswer2(std::string text);
	void SetCorrectAnswer0(std::string text);

	int GetGlobalRightCount();
	int GetGlobalCount();
	int GetDifficultyMultiplier();

	void SetGlobalRightCount(int value);
	void SetGlobalCount(int value);
	void SetDifficultyMultiplier(int value);

private:

	std::string _questionText;
	std::string _wrongAnswer0;
	std::string _wrongAnswer1;
	std::string _wrongAnswer2;
	std::string _correctAnswer0;
	int _globalRightCount;
	int _globalCount;
	int _difficultyMultiplier;
};

#endif