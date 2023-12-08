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
    // TODO : 구조체 구현... 아직 어떤 변수들이 필요할지에 대해 정의가 안됨
    public struct Info_points
    {
        public List<int> points_p;
    }

    public List<Point2d> m_points = new List<Point2d>();
    public List<int> m_logs_drawing = new List<int>();

    private Thread __thread = null;

    private bool __isRunning_thread = false;

    private Templete_DLL __Templete_DLL = null;

    // 전역 변수
    private int m_ProgramMode = 0;


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
    
    public void SetData(List<Point2d> m_points, List<int> m_logs_drawing)
    {
        this.m_points = m_points;
        this.m_logs_drawing = m_logs_drawing;
    }

    //public void SetData(Mat data_3D, Mat data_luminance, List<Rect> embosList, List<Rect> m_burnSpatterList, int material, int masterjig)
    //{
        //this.m_masterjig = masterjig;

        //if (this.m_data_3D != null || this.m_data_luminance != null)
        //{
        //    this.m_data_3D.Release();
        //    this.m_data_luminance.Release();
        //}


        //if (data_3D == null || data_luminance == null)
        //{
        //    this.m_data_3D = null;
        //    this.m_data_luminance = null;
        //}
        //else
        //{
        //    this.m_data_3D = data_3D.Clone();
        //    this.m_data_luminance = data_luminance.Clone();
        //}

        //this.m_embosList.Clear();

        //this.m_embosList = new List<Rect>();

        //this.m_burnSpatterList.Clear();

        //this.m_burnSpatterList = new List<Rect>();

        //this.m_material = material;

        //for (int index_0 = 0; index_0 < embosList.Count(); index_0++)
        //{
        //    if (embosList[index_0].Width <= 0 || embosList[index_0].Height <= 0)
        //        continue;

        //    this.m_embosList.Add(new Rect(embosList[index_0].X, embosList[index_0].Y, embosList[index_0].Width, embosList[index_0].Height));
        //}

        //for (int index_0 = 0; index_0 < m_burnSpatterList.Count(); index_0++)
        //{
        //    this.m_burnSpatterList.Add(new Rect(m_burnSpatterList[index_0].X, m_burnSpatterList[index_0].Y, m_burnSpatterList[index_0].Width, m_burnSpatterList[index_0].Height));
        //}
    //}

    public void StartGraphics()
    {
        // TODO : 조건식 추가 필요 Form1.cs 에서 이부분을 콜하면 스레드 시작하여 프로그램 돌아가는 것임
        //if () // Point 들이 3개 이상 있으면 돌아가게끔
        //this.__isRunning_thread = true;

    }

    public void FittingLine(out double x0, out double y0, out double x1, out double y1)
    {
        x0 = 0;
        y0 = 0;
        x1 = 0;
        y1 = 0;

        if (this.m_points.Count == 0)
        {
            Console.WriteLine("No points to fit line");
            return;
        }

        // Point2f 배열로 변환 (FitLine 메소드가 Point2f를 요구)
        Point2f[] pointArray = new Point2f[this.m_points.Count];
        for (int i = 0; i < this.m_points.Count; i++)
        {
            pointArray[i] = new Point2f((float)this.m_points[i].X, (float)this.m_points[i].Y);
        }

        // Line Fitting 하는 부분
        DistanceTypes distType = DistanceTypes.L2;
        double param = 0.0, reps = 0.01, aeps = 0.01;

        Line2D line_result = Cv2.FitLine(pointArray, distType, param, reps, aeps);

        x0 = line_result.X1;
        y0 = line_result.Y1;
        x1 = x0 - (200.0 * line_result.Vx);
        y1 = y0 - (200.0 * line_result.Vy);

        Console.WriteLine("fitting line");
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

            //if ()


            this.__isRunning_thread = false;
            GC.Collect();

        }
    }
}

