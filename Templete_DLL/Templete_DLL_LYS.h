#pragma once
#include <math.h>
#include "opencv2/opencv.hpp"
#include <string>

#ifdef CREATEDLL_EXPORTS
#define TEMPLETE_DLL_LYS_DECLSPEC __declspec(dllexport)
#else
#define TEMPLETE_DLL_LYS_DECLSPEC __declspec(dllimport)
#endif

class Templete_DLL_LYS
{
public:
	Templete_DLL_LYS();
	~Templete_DLL_LYS();

	char* say_hello();
	char* function();

};

extern "C"
{
	TEMPLETE_DLL_LYS_DECLSPEC Templete_DLL_LYS* Templete_DLL_LYS_Create();
	TEMPLETE_DLL_LYS_DECLSPEC char* Templete_DLL_LYS_sayhello();
	TEMPLETE_DLL_LYS_DECLSPEC char* Templete_DLL_LYS_function(Templete_DLL_LYS* obj, double* data_image);

}