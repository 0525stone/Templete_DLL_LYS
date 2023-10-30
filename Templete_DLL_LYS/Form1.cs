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

        string m_DrawMode = "Point";

        public Form1()
        {
            InitializeComponent();

            // Palette
            if (m_DrawMode == "Point")
            {
                MainPalette.MouseClick += new MouseEventHandler(MainPalette_MouseClick);
            }
            else if (m_DrawMode == "Line")
            {
                MainPalette.MouseClick += new MouseEventHandler(MainPalette_MouseDrag);
            }

        }



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

        private void MainPalette_MouseDrag(object sender, MouseEventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {

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
    }

}