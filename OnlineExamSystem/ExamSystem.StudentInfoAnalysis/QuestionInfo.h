#ifndef QUESTIONINFO_H
#define QUESTIONINFO_H

#include <string>
#include <boost/cstdint.hpp> 

#include <boost/container/string.hpp>
#include <boost/move/unique_ptr.hpp>
#include "DLLEXPORT.h"
#include "QuestionInfoMeasureContainer.h"
class ROOTERLIB_API QuestionInfo {
public:
	QuestionInfo();
	boost::container::string GetQuestionText();
	void SetQuestionText(boost::container::string text);

	boost::container::string GetWrongAnswer0() const;
	boost::container::string GetWrongAnswer1() const;
	boost::container::string GetWrongAnswer2() const;
	boost::container::string GetCorrectAnswer0() const;

	void SetWrongAnswer0(boost::container::string text);
	void SetWrongAnswer1(boost::container::string text);
	void SetWrongAnswer2(boost::container::string text);
	void SetCorrectAnswer0(boost::container::string text);

	uintmax_t GetGlobalRightCount() const;
	uintmax_t  GetGlobalCount() const;
	uintmax_t  GetDifficultyMultiplier() const;

	void SetGlobalRightCount(uintmax_t value);

	template <typename T>
	void SetGlobalRightCount(T value) = delete;

	void SetGlobalCount(uintmax_t value);

	template <typename T>
	void SetGlobalCount(T value) = delete;

	void SetDifficultyMultiplier(uintmax_t value);

	template <typename T>
	void SetDifficultyMultiplier(T value) = delete;

	void CreateMeasureInfo(uint_fast8_t rate);
	QuestionInfoMeasureContainer* GetMeasureInfo() const;
	bool IsMeasured() const;

private:
	void StrainDifficultyMultiplier();

	boost::movelib::unique_ptr<QuestionInfoMeasureContainer> _measureInfos;
	bool _isMeasured = false;


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