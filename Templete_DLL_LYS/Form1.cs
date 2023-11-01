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
        private Point m_startPoint;
        private Point m_endPoint;

        private List<Point> m_points = new List<Point>();
        private List<List<Point>> m_lines = new List<List<Point>>();
        private List<int> logs_drawing = new List<int>();
        private Graphics g;
        private Pen m_pen = new Pen(Color.Blue, 2);
        private int m_radius = 1;

        private Bitmap bitmap;

        #region 구간 주석
        // working??

        #endregion

        public Form1()
        {
            InitializeComponent();

            //// Palette
            bitmap = new Bitmap(MainPalette.Width, MainPalette.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            MainPalette.Image = bitmap;

            MainPalette.MouseDown += new MouseEventHandler(MainPalette_MouseDown);
            //MainPalette.MouseMove += new MouseEventHandler(MainPalette_MouseMove);
            MainPalette.MouseUp += new MouseEventHandler(MainPalette_MouseUp);
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(MainPalette_KeyDown);


            //// Example 할 때 사용한 변수들
            //this.MouseDown += Form1_MouseDown;
            //this.MouseMove += Form1_MouseMove;
            //this.MouseUp += Form1_MouseUp;
        }

        // 전역 변수 해제 메서드
        //private void ReleaseGlobals()
        //{
        //    points.Clear(); // 리스트 초기화
        //    g.Dispose(); // Graphics 해제
        //    pen.Dispose(); // 펜 객체 해제
        //}

        private void radioButton_Input_CheckedChanged(object sender, EventArgs e)
        {
            this.m_ProgramMode = 0;
        }

        private void radioButton_Process_CheckedChanged(object sender, EventArgs e)
        {
            this.m_ProgramMode = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO 어떤 역할을 수행하는지 모르겠슴..
        }

#region Program Mode 0 : Data 입력
        // 직접 Data 입력 받는 모드
        private void MainPalette_MouseDown(object sender, MouseEventArgs e)
        {
            if (m_ProgramMode == 0)
            {
                // PictureBox에서 마우스 클릭된 위치를 가져옵니다.
                int x = e.X;
                int y = e.Y;
                m_startPoint = e.Location;

                g = MainPalette.CreateGraphics(); // Graphics 객체 생성(원)

                // 그림 그릴 원 관련 파라미터
                int centerX = x;
                int centerY = y;

                //g.DrawEllipse(m_pen, centerX, centerY, 2 * m_radius, 2 * m_radius);
            }
        }

        private void MainPalette_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_ProgramMode == 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // PictureBox에서 마우스 클릭된 위치를 가져옵니다.
                    int x = e.X;
                    int y = e.Y;

                    g = MainPalette.CreateGraphics(); // Graphics 객체 생성(원)

                    // 그림 그릴 원 관련 파라미터
                    int centerX = x - m_radius;
                    int centerY = y - m_radius;

                    g.DrawEllipse(m_pen, centerX, centerY, 2 * m_radius, 2 * m_radius);
                }
            }
        }

        private void MainPalette_MouseUp(object sender, MouseEventArgs e)
        {
            m_endPoint = e.Location;
            if (m_ProgramMode == 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // PictureBox에서 마우스 클릭된 위치를 가져옵니다.
                    int x = e.X;
                    int y = e.Y;

                    // 그림 그릴 원 관련 파라미터
                    int centerX = x - m_radius;
                    int centerY = y - m_radius;

                    g.DrawEllipse(m_pen, centerX, centerY, 2 * m_radius, 2 * m_radius);
                    m_points.Add(m_endPoint);
                    logs_drawing.Add(1);
                }
                else
                {
                    g = MainPalette.CreateGraphics(); // Graphics 객체 생성(원)
                    g.DrawLine(m_pen, m_startPoint, m_endPoint);
                    m_points.Add(m_startPoint);
                    m_points.Add(m_endPoint);
                    logs_drawing.Add(2);
                }
            }
        }

        private void MainPalette_KeyDown(object sender, KeyEventArgs e)
        {
            if (m_ProgramMode == 0)
            {
                if ((e.KeyCode == Keys.D) && (logs_drawing.Count > 0))
                {
                    int log_current = logs_drawing[logs_drawing.Count - 1];

                    if (log_current == 1)
                    {
                        if (m_points.Count > 0)
                        {
                            m_points.RemoveAt(m_points.Count - 1);
                            logs_drawing.RemoveAt(logs_drawing.Count - 1);
                        }
                    }
                    if (log_current == 2)
                    {
                        if (m_points.Count > 0)
                        {
                            m_points.RemoveAt(m_points.Count - 1);
                            m_points.RemoveAt(m_points.Count - 1);
                            logs_drawing.RemoveAt(logs_drawing.Count - 1);
                        }

                    }
                    MainPalette.Invalidate(); // Request the panel to be repainted
                    MainPallete_repaint();
                }
            }
        }

        private void MainPallete_repaint()
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                int index_point = 0;
                foreach (int index_logs in logs_drawing)
                {
                    if (index_logs == 1)
                    {
                        g.DrawEllipse(m_pen, m_points[index_point].X, m_points[index_point].Y, 2 * m_radius, 2 * m_radius);
                        index_point += index_logs;
                    }
                    else if (index_logs == 2)
                    {
                        g.DrawLine(m_pen, m_points[index_point], m_points[index_point+1]);
                        index_point += index_logs;
                    }
                }

            }

            MainPalette.Invalidate();
        }

        #endregion Program Mode 0 부분 끝


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