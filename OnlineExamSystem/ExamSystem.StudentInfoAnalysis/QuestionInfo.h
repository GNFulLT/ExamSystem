#ifndef QUESTIONINFO_H
#define QUESTIONINFO_H

#include <string>
#include <boost/cstdint.hpp> 
#include <boost/container/string.hpp>

class QuestionInfo {
public:
	QuestionInfo();
	boost::container::string GetQuestionText();
	void SetQuestionText(boost::container::string text);

	boost::container::string GetWrongAnswer0();
	boost::container::string GetWrongAnswer1();
	boost::container::string GetWrongAnswer2();
	boost::container::string GetCorrectAnswer0();

	void SetWrongAnswer0(boost::container::string text);
	void SetWrongAnswer1(boost::container::string text);
	void SetWrongAnswer2(boost::container::string text);
	void SetCorrectAnswer0(boost::container::string text);

	uintmax_t GetGlobalRightCount();
	uintmax_t  GetGlobalCount();
	uintmax_t  GetDifficultyMultiplier();

	void SetGlobalRightCount(uintmax_t value);
	void SetGlobalCount(uintmax_t value);
	void SetDifficultyMultiplier(uintmax_t value);

private:

	boost::container::string _questionText;
	boost::container::string _wrongAnswer0;
	boost::container::string _wrongAnswer1;
	boost::container::string _wrongAnswer2;
	boost::container::string _correctAnswer0;
	uintmax_t  _globalRightCount;
	uintmax_t  _globalCount;
	uintmax_t  _difficultyMultiplier;
};

#endif