#include "Templete_DLL_LYS.h"

// 추가할 예시 함수
// 1. NURBS
// 2. PCA?!


Templete_DLL_LYS::Templete_DLL_LYS()
{

}

Templete_DLL_LYS::~Templete_DLL_LYS()
{

}

char* Templete_DLL_LYS::say_hello()
{
	std::string msg_hello = "hello ";

	std::cout << msg_hello << std::endl;
	char* result = NULL;
	result = new char[msg_hello.length() + 1];
	std::strcpy(result, msg_hello.c_str());

	return result;
}

char* Templete_DLL_LYS::function()
{

}


Templete_DLL_LYS* Templete_DLL_LYS_Create()
{
	return new Templete_DLL_LYS();
}

void Templete_DLL_LYS_Delete(Templete_DLL_LYS* obj)
{
	delete obj;
	obj = nullptr;
}

char* Templete_DLL_LYS_sayhello(Templete_DLL_LYS* obj)
{
	return obj->say_hello();
}

char* Templete_DLL_LYS_function(Templete_DLL_LYS* obj, double* data_image)
{
	return obj->function();
}