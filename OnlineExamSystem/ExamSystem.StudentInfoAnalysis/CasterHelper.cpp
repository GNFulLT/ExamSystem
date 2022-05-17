#include "CasterHelper.h"

#include <boost/numeric/conversion/cast.hpp>
using namespace boost;

uintmax_t CasterHelper::IntTo(int value) {
	if (value < 0) {
		value = 0;
	}
	try {
		uintmax_t newVal = boost::numeric_cast<uintmax_t>(value);
		return newVal;
	}
	catch(boost::exception const& e){
		return 0;
	}
}


std::string CasterHelper::DateToString(boost::gregorian::date* value) {
	std::string s = boost::gregorian::to_iso_string(*value);
	return s;
}

