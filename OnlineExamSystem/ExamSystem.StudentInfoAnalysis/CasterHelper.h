#ifndef CASTERHELPER_H
#define CASTERHELPER_H

#include <boost/date_time/gregorian/gregorian.hpp>
#include "DLLEXPORT.h"

class ROOTERLIB_API CasterHelper {
public:
	static uintmax_t IntTo(int value);

	static std::string DateToString(boost::gregorian::date* value);
private:
	CasterHelper();
};


#endif