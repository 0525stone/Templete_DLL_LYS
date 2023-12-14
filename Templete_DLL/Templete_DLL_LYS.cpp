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
	std::cout << "in the c++ code through thread" << std::endl;
	char* result = NULL;
	return result;
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

//// Archive

	//// TODO : Pyramid Image (Scalable)
	//vector<cv::Mat> pyramids;
	//cv::Mat originalImage = data_luminance.clone();
	//pyramids.push_back(originalImage); // 원본 이미지를 첫 번째 레벨로 추가합니다.

	//// 이미지를 다운샘플링하여 피라미드를 생성합니다.
	//for (int i = 0; i < 3; ++i) { // 3단계의 피라미드를 생성합니다.
	//	cv::Mat downsampled;
	//	pyrDown(pyramids[i], downsampled);070
	//	pyramids.push_back(downsampled);
	//}

	//// 생성된 피라미드 이미지를 화면에 표시합니다.
	//for (size_t i = 0; i < pyramids.size(); ++i) {
	//	for (int index_0 = 0; index_0 < vSrcROI_embos.size(); index_0++)
	//	{
	//		double ratio = pow(0.5, i);
	//		std::cout << "ratio : " << ratio << std::endl;
	//		cv::Rect temp_rect = cv::Rect((int)(vSrcROI_embos[index_0].x * ratio), (int)(vSrcROI_embos[index_0].y * ratio), (int)(vSrcROI_embos[index_0].width * ratio), (int)(vSrcROI_embos[index_0].height * ratio));
	//		cv::rectangle(pyramids[i], temp_rect, cv::Scalar(255, 0, 0), 2);

	//		// 


	//	}
	//	imshow("Pyramid level " + to_string(i), pyramids[i]);
	//	cv::waitKey(0); // 키 입력을 기다립니다.
	//}
