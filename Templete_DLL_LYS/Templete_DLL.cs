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
    extern public static IntPtr Templete_DLL_LYS_sayhello();

}

