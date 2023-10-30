using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Templete_DLL_LYS
{
    public partial class Form1 : Form
    {
        int m_ProgramMode = 0; // 0 : Input, 1 : Process

        string m_DrawMode = "Line";

        // TODO 그림 그리는
        private bool isDrawing = false;
        private Point startPoint;
        private Point endPoint;
        private Pen drawPen = new Pen(Color.Black, 2); // 선의 색상과 두께를 설정합니다.

        #region 구간 주석
        // working??

        #endregion


        public Form1()
        {
            InitializeComponent();

            //// Palette
            MainPalette.MouseClick += new MouseEventHandler(MainPalette_MouseClick);
            MainPalette.MouseDown += new MouseEventHandler(MainPalette_MouseDown);



            //// Example 할 때 사용한 변수들
            //this.MouseDown += Form1_MouseDown;
            //this.MouseMove += Form1_MouseMove;
            //this.MouseUp += Form1_MouseUp;
        }

        

        private void radioButton_Input_CheckedChanged(object sender, EventArgs e)
        {
            this.m_ProgramMode = 0;
        }

        private void radioButton_Process_CheckedChanged(object sender, EventArgs e)
        {
            this.m_ProgramMode = 1;
        }

    // Program Mode 0 : Data 입력
        // 직접 Data 입력 받는 모드
        private void MainPalette_MouseClick(object sender, MouseEventArgs e)
        {
            // PictureBox에서 마우스 클릭된 위치를 가져옵니다.
            int x = e.X;
            int y = e.Y;

            // 원을 그릴 Graphics 객체를 생성합니다.
            Graphics g = MainPalette.CreateGraphics();

            // 원을 그리는 색상과 펜을 생성합니다.
            Pen pen = new Pen(Color.Red, 2);

            // 원의 중심 좌표와 반지름을 계산합니다.
            int radius = 1;
            int centerX = x - radius;
            int centerY = y - radius;

            // 원을 그립니다.
            g.DrawEllipse(pen, centerX, centerY, 2 * radius, 2 * radius);

            // 리소스를 해제합니다.
            pen.Dispose();
            g.Dispose();
        }

        private void MainPalette_MouseDown(object sender, MouseEventArgs e)
        {
            // PictureBox에서 마우스 클릭된 위치를 가져옵니다.
            int x = e.X;
            int y = e.Y;

            // 원을 그릴 Graphics 객체를 생성합니다.
            Graphics g = MainPalette.CreateGraphics();

            // 원을 그리는 색상과 펜을 생성합니다.
            Pen pen = new Pen(Color.Blue, 2);

            // 원의 중심 좌표와 반지름을 계산합니다.
            int radius = 1;
            int centerX = x - radius;
            int centerY = y - radius;

            // 원을 그립니다.
            g.DrawEllipse(pen, centerX, centerY, 2 * radius, 2 * radius);

            // 리소스를 해제합니다.
            pen.Dispose();
            g.Dispose();
        }

        private void button_Point_Click(object sender, EventArgs e)
        {
            this.textBox_DrawMode.Text = "Point";
            m_DrawMode = "Point";
        }

        private void button_Line_Click(object sender, EventArgs e)
        {
            this.textBox_DrawMode.Text = "Line";
            m_DrawMode = "Line";
        }

#region ================= MouseDown, Up, Move Example ====================
        //private void Form1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        isDrawing = true;
        //        startPoint = e.Location;
        //        endPoint = e.Location;
        //    }
        //}

        //private void Form1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (isDrawing)
        //    {
        //        endPoint = e.Location;
        //        this.Invalidate(); // 폼을 다시 그리도록 합니다.
        //    }
        //}

        //private void Form1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    Console.WriteLine("MouseUp?");
        //    isDrawing = false;
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);

        //    if (isDrawing)
        //    {
        //        // 선을 그립니다.
        //        e.Graphics.DrawLine(drawPen, startPoint, endPoint);
        //    }
        //}
#endregion


    }

}