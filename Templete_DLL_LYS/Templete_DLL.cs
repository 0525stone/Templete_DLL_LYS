using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;


class Templete_DLL
{
    private const string DllPath = "Templete_DLL_LYS.dll";

    [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
    extern public static IntPtr Templete_DLL_LYS_Create();

    [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
    extern public static IntPtr Templete_DLL_LYS_Delete(IntPtr obj);

    [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
    extern public static IntPtr Templete_DLL_LYS_sayhello();

    private IntPtr __templete_DLL_LYS = IntPtr.Zero;

    public Templete_DLL()
    {
        if (this.__templete_DLL_LYS != IntPtr.Zero)
        {
            Delete();
        }

        this.__templete_DLL_LYS = Templete_DLL_LYS_Create();
    }

    public void Delete()
    {
        Templete_DLL_LYS_Delete(this.__templete_DLL_LYS);
        this.__templete_DLL_LYS = IntPtr.Zero;
    }

}

//// TODO : SetParam, StartInspection을 cpp 쪽에서 받는 부분도 필요
//public void SetParam(
//    double interval_inspection,
//    double threshold_weld1, double threshold_weld2, double width_weld,
//    double length_weldLength_thr_lowest, double length_weldLength_thr_highest,
//    double length_oneSidedWelding_thr, double length_between_weldSide_slithole_oneSidedWelding_thr, double margin_pixel,
//    double length_cellTab, double height_cellTab,
//    double length_lackOfDiffusion, double height_lackOfDiffusion,
//    double height_offWeldingWithTab, double length_offWeldingWithTab,
//    double area_burnAndSpatter, double thresh_burnAndSpatter,
//    double width_embos)
//{
//    Inspection3D_SetParam(this.__inspection3D,
//        interval_inspection,
//        threshold_weld1, threshold_weld2, width_weld,
//        length_weldLength_thr_lowest, length_weldLength_thr_highest,
//        length_oneSidedWelding_thr, length_between_weldSide_slithole_oneSidedWelding_thr, margin_pixel,
//        length_cellTab, height_cellTab,
//        length_lackOfDiffusion, height_lackOfDiffusion,
//        height_offWeldingWithTab, length_offWeldingWithTab,
//        area_burnAndSpatter, thresh_burnAndSpatter,
//        width_embos);
//}

//public string StartInspection(double[] data3D, Byte[] dataLuminance, int width_data, int heigt_data, double pitch_x, double pitch_y, Rect[] list_roi_embos, int length_list_roi_embos, Rect[] list_roi_burnSpatter, int length_list_roi_burnSpatter, double value_null, int material)
//{
//    return Marshal.PtrToStringAnsi(Inspection3D_StartInspection(this.__inspection3D, data3D, dataLuminance, width_data, heigt_data, pitch_x, pitch_y, list_roi_embos, length_list_roi_embos, list_roi_burnSpatter, length_list_roi_burnSpatter, value_null, material));
//}