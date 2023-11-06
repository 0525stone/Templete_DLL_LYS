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

