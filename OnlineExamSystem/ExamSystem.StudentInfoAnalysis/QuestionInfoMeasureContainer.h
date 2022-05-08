#ifndef QUESTIONINFOMEASURECONTAINER_H
#define QUESTIONINFOMEASURECONTAINER_H


#include "DLLEXPORT.h"
#include <boost/cstdint.hpp> 

class ROOTERLIB_API QuestionInfoMeasureContainer
{
public:
	QuestionInfoMeasureContainer(uint_fast8_t rate);
	uint_fast8_t _questionGlobalRate;
};

#endif