#ifndef STUDENTQUESTIONSUBINFOMEASURECONTAINER_H
#define STUDENTQUESTIONSUBINFOMEASURECONTAINER_H

#include "DLLEXPORT.h"
#include <boost/cstdint.hpp> 

class ROOTERLIB_API StudentQuestionSubInfoMeasureContainer {
public:
	StudentQuestionSubInfoMeasureContainer(uint_fast8_t rate);
	uint_fast8_t _questionLocalRate;

private:


};

#endif