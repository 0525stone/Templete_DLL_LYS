#include "Templete_DLL_LYS.h"

// �߰��� ���� �Լ�
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
	//pyramids.push_back(originalImage); // ���� �̹����� ù ��° ������ �߰��մϴ�.

	//// �̹����� �ٿ���ø��Ͽ� �Ƕ�̵带 �����մϴ�.
	//for (int i = 0; i < 3; ++i) { // 3�ܰ��� �Ƕ�̵带 �����մϴ�.
	//	cv::Mat downsampled;
	//	pyrDown(pyramids[i], downsampled);070
	//	pyramids.push_back(downsampled);
	//}

	//// ������ �Ƕ�̵� �̹����� ȭ�鿡 ǥ���մϴ�.
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
	//	cv::waitKey(0); // Ű �Է��� ��ٸ��ϴ�.
	//}
