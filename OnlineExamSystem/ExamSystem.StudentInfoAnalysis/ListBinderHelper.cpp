#ifndef LISTBINDERHELPER_CPP
#define LISTBINDERHELPER_CPP

#include "ListBinderHelper.h"

template <typename  T>
ListBinderHelper<T>::ListBinderHelper(){
	_isStarted = false;
}

template <typename  T>
void ListBinderHelper<T>::StartBinding() {
	if (_isStarted == true) {
		return;
	}
	_isStarted = true;
	_list.reset(new boost::container::list<T>);
}

template <typename  T>
void ListBinderHelper<T>::EndBinding() {
	_isStarted = false;
}

template <typename  T>
void ListBinderHelper<T>::Bind(T value) {
	if (_isStarted == false) {
		return;
	}
	_list.get()->push_back(value);
}

template <typename  T>
void ListBinderHelper<T>::ResetList() {
	_list.reset();
}

template <typename  T>
boost::container::list<T>* ListBinderHelper<T>::GetList() const{
	return _list.get();
}

template <typename  T>
int ListBinderHelper<T>::Length() const {
	boost::container::list<T>* a = _list.get();
	return (a->end() - a->begin()) + 1;
}



#endif