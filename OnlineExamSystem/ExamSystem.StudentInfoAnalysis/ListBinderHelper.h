#ifndef LISTBINDERHELPER_H
#define LISTBINDERHELPER_H

#include <boost/mpl/bool.hpp>
#include <boost/move/unique_ptr.hpp>
#include <boost/container/list.hpp>
#include <boost/any.hpp>

template<typename T>
class ListBinderHelper
{
public:
	ListBinderHelper();

	 void StartBinding();

	 void EndBinding();

	 void ResetList();

	 void Bind(T);

	 boost::container::list<T>* GetList() const;

	 int Length() const;

	 
private:

	 bool _isStarted;


	 boost::movelib::unique_ptr<boost::container::list<T>> _list;
	
};


#include "ListBinderHelper.cpp"

#endif

