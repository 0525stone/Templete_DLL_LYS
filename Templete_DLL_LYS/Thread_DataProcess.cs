using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

class Thread_DataProcess
{
    public struct Info_points
    {
        public List<int> points_p;
    }

    private Thread __thread = null;

    private bool __isRunning_thread = false;

    private Templete_DLL __Templete_DLL = null;

    public Thread_DataProcess()
    {
        this.__isRunning_thread = false;

        this.__thread = new Thread(new ThreadStart(Run));
        this.__thread.Name = "Thread_DataProcess";
        this.__thread.IsBackground = true;
        this.__thread.Start();
    }

    ~Thread_DataProcess()
    {

    }

    public bool IsRunning()
    {
        return this.__isRunning_thread;
    }

    public void TerminateThread()
    {
        if (this.__thread != null && this.__thread.Join(100))
        {
            this.__thread.Abort();
            this.__thread = null;
        }
    }

    public void StartGraphics()
    {
        // TODO : 조건식 추가 필요 Form1.cs 에서 이부분을 콜하면 스레드 시작하여 프로그램 돌아가는 것임
        //if () // Point 들이 3개 이상 있으면 돌아가게끔
        
        this.__isRunning_thread = true;

    }

    private void Run()
    {
        while (true)
        {
            if (!this.__isRunning_thread)
            {
                Thread.Sleep(100);
                continue;
            }

            Console.WriteLine("In the Run, In the Thread");

            // TODO : Run 할 때 할 작업들 여기에 배치
            this.__Templete_DLL = new Templete_DLL();


            this.__isRunning_thread = false;
            GC.Collect();

        }

        
    }

}
