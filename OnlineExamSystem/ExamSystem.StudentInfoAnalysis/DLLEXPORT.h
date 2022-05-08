#ifndef DLLEXPORT_H
#define DLLEXPORT_H
#ifdef ROOTERLIB_EXPORTS
#define ROOTERLIB_API  __declspec(dllexport)
#else
#define ROOTERLIB_API __declspec(dllimport)
#endif //ROOTERLIB_EXPORTS
#endif