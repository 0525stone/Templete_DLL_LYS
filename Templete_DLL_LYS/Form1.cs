using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Templete_DLL_LYS
{
    public partial class Form1 : Form
    {
        //Templete_DLL __Templete_DLL = null;

        Thread_DataProcess __thread_DataProcess = null;

        int m_ProgramMode = 0; // 0 : Input, 1 : Process

        Mat m_mat_image;
        string m_DrawMode = "Line";
        string m_filepath = "";

        // ProgramMode 0 일 때, 사용하는 것들
        // 입력 받은 데이터들
        private Point2d m_startPoint;
        private Point2d m_endPoint;

        private List<Point2d> m_points = new List<Point2d>();
        private List<int> m_logs_drawing = new List<int>();

        private Graphics g;
        private Pen m_pen_blue = new Pen(Color.Blue, 2);
        private Pen m_pen_red = new Pen(Color.Red, 2);
        private Pen m_pen_black = new Pen(Color.Black, 2);
        private int m_radius = 1;

        private Bitmap bitmap;

        #region 구간 주석
        // working??

        #endregion

        public Form1()
        {
            InitializeComponent();
            InitMembers();

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

        public void InitMembers()
        {
            // Legend of button guide
            this.richTextBox_legend.Text = "D : Undo recent Action";

            this.__thread_DataProcess = new Thread_DataProcess();
        }

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
                m_startPoint = new Point2d(e.Location.X, e.Location.Y);

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

                    g.DrawEllipse(m_pen_blue, centerX, centerY, 2 * m_radius, 2 * m_radius);
                }
            }
        }

        private void MainPalette_MouseUp(object sender, MouseEventArgs e)
        {
            m_endPoint = new Point2d(e.Location.X, e.Location.Y);
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

                    g.DrawEllipse(m_pen_blue, centerX, centerY, 2 * m_radius, 2 * m_radius);
                    m_points.Add(m_endPoint);
                    m_logs_drawing.Add(1);
                }
                else
                {
                    g = MainPalette.CreateGraphics(); // Graphics 객체 생성(원)
                    g.DrawLine(m_pen_blue, (float)m_startPoint.X, (float)m_startPoint.Y, (float)m_endPoint.X, (float)m_endPoint.Y);
                    m_points.Add(m_startPoint);
                    m_points.Add(m_endPoint);
                    m_logs_drawing.Add(2);
                }
            }
        }

        private void MainPalette_KeyDown(object sender, KeyEventArgs e)
        {
            if (m_ProgramMode == 0)
            {
                if ((e.KeyCode == Keys.D) && (m_logs_drawing.Count > 0))
                {
                    int log_current = m_logs_drawing[m_logs_drawing.Count - 1];

                    if (log_current == 1)
                    {
                        if (m_points.Count > 0)
                        {
                            m_points.RemoveAt(m_points.Count - 1);
                            m_logs_drawing.RemoveAt(m_logs_drawing.Count - 1);
                        }
                    }
                    if (log_current == 2)
                    {
                        if (m_points.Count > 0)
                        {
                            m_points.RemoveAt(m_points.Count - 1);
                            m_points.RemoveAt(m_points.Count - 1);
                            m_logs_drawing.RemoveAt(m_logs_drawing.Count - 1);
                        }

                    }
                    MainPalette.Invalidate(); // Request the panel to be repainted
                    MainPallete_repaint();
                }
            }
        }

        private void MainPallete_repaint()
        {
            if (this.m_filepath.Length == 0)
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.White);
                    int index_point = 0;
                    foreach (int index_logs in m_logs_drawing)
                    {
                        if (index_logs == 1)
                        {
                            g.DrawEllipse(m_pen_blue, (float)m_points[index_point].X, (float)m_points[index_point].Y, 2 * m_radius, 2 * m_radius);
                            index_point += index_logs;
                        }
                        else if (index_logs == 2)
                        {
                            g.DrawLine(m_pen_blue, (float)m_points[index_point].X, (float)m_points[index_point].Y, (float)m_points[index_point + 1].X, (float)m_points[index_point + 1].Y);
                            index_point += index_logs;
                        }
                    }

                }
            }
            else
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.White); 
                    Image image = ReadImage(this.m_filepath);
                    g.DrawImage(image, new System.Drawing.Point(0, 0));

                    int index_point = 0;
                    foreach (int index_logs in m_logs_drawing)
                    {
                        if (index_logs == 1)
                        {
                            g.DrawEllipse(m_pen_blue, (float)m_points[index_point].X, (float)m_points[index_point].Y, 2 * m_radius, 2 * m_radius);
                            index_point += index_logs;
                        }
                        else if (index_logs == 2)
                        {
                            g.DrawLine(m_pen_blue, (float)m_points[index_point].X, (float)m_points[index_point].Y, (float)m_points[index_point + 1].X, (float)m_points[index_point + 1].Y);
                            index_point += index_logs;
                        }
                    }
                }
            }

            MainPalette.Invalidate();
        }

        #endregion Program Mode 0 부분 끝


        private void button_Fitting_Click(object sender, EventArgs e)
        {
            //this.__Templete_DLL = new Templete_DLL_LYS();
            this.textBox_DrawMode.Text = "Fitting";
            m_DrawMode = "Fitting";

            if (this.__thread_DataProcess.IsRunning())
            {
                MessageBox.Show("Stop Graphic Thread", "Caution!!", MessageBoxButtons.OK);
                return;
            }

            //double x0, y0, x1, y1;
            this.__thread_DataProcess.SetData(m_points, m_logs_drawing, m_mat_image);
            this.__thread_DataProcess.StartGraphics();
            this.__thread_DataProcess.FittingLine(out double x0, out double y0, out double x1, out double y1);

            g = MainPalette.CreateGraphics(); // Graphics 객체 생성(원)
            g.DrawLine(m_pen_red, (float)x0, (float)y0, (float)x1, (float)y1);

        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_DrawMode.Text = "Clear, Reset";
            m_points.Clear();
            m_logs_drawing.Clear();
            this.m_filepath = "";

            MainPallete_repaint();
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            radiobuttonChanged(1);

            this.m_filepath = ReadDataPath("Image");
            Console.WriteLine("filename : ", this.m_filepath);

            if (this.m_filepath.Length == 0)
                return;

            if (this.m_filepath == "")
            {
                this.m_mat_image = null;
            }
            else
            {
                // TODO : 다른 파일 형식에 대한 케이스를 나눠서 할 수 있어야함
                string[] split_data = this.m_filepath.Split('.');

                Image image = ReadImage(this.m_filepath);
                g.DrawImage(image, new System.Drawing.Point(0, 0));

            }



            ////// Memo => 그림을 그릴 수는 없음 (Graphics 객체에 이미지가 있는 것이 아니라 PictureBox 에 있는 것이니까)
            //this.MainPalette.Image = bitmap;
            //this.MainPalette.SizeMode = PictureBoxSizeMode.StretchImage; // mainpallette 사이즈를 읽은 이미지에 맞춰서 수정 => PictureBox resize
        }

        private string ReadDataPath(string title)
        {
            //파일오픈창 생성 및 설정
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = title;
            ofd.FileName = "test";
            ofd.Filter = "Data (*.png, *.tif, *.tiff, *.csv) | *.png; *.tif; *.tiff; *.csv; | All Data (*.*) | *.*";

            //파일 오픈창 로드
            DialogResult dr = ofd.ShowDialog();

            //OK버튼 클릭시
            if (dr == DialogResult.OK)
            {
                string fileFullName = ofd.FileName;

                return fileFullName;
            }
            else
            {
                return "";
            }
        }

        private Image ReadImage(string filepath)
        {
            Image image;
            string[] split_data = filepath.Split('.');

            if (split_data[1] == "csv")
            {
                //this.m_mat_image = csvToMat(filepath);
                image = csvToBitmap(filepath); // TODO 검증 필요
            }
            else
            {
                // 프로그램 PictureBox에 이미지 로드
                Bitmap bitmap = new Bitmap(filepath);
                g = MainPalette.CreateGraphics();
                image = Image.FromFile(filepath);
                //this.m_mat_image = imageToMat(this.m_filepath); // imageToMat 확인 필요
            }
            return image;
        }


        private Mat csvToMat(string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath))
            {
                string line;
                int rowCount = 0;
                int columnCount = 0;

                // 행 수와 열 수 계산
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    columnCount = values.Length;
                    rowCount++;
                }

                // 이미지 데이터 배열 초기화
                double[,] imageData = new double[rowCount, columnCount];

                // CSV 파일 다시 읽어서 이미지 데이터 저장
                using (var fileReader = new StreamReader(csvFilePath))
                {
                    int row = 0;
                    while ((line = fileReader.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        for (int col = 0; col < columnCount; col++)
                        {
                            double value = double.Parse(values[col]);
                            imageData[row, col] = value;
                        }
                        row++;
                    }
                }

                // 이미지 데이터로부터 Mat 객체 생성
                int width = imageData.GetLength(1); // 이미지의 가로 크기
                int height = imageData.GetLength(0); // 이미지의 세로 크기

                return new Mat(height, width, MatType.CV_64FC1, imageData);
            }
        }

        private Bitmap csvToBitmap(string csvFilePath)
        {
            // TODO : csv to bitmap 잘되는지 검증 필요
            var lines = File.ReadAllLines(csvFilePath);
            int width = lines[0].Split(',').Length;
            int height = lines.Length;

            Bitmap bitmap = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                var pixels = lines[y].Split(',');
                for (int x = 0; x < width; x++)
                {
                    int pixelValue = int.Parse(pixels[x]);
                    // 여기서는 그레이스케일 값으로 가정
                    bitmap.SetPixel(x, y, Color.FromArgb(pixelValue, pixelValue, pixelValue));
                }
            }

            return bitmap;
        }

        private Mat imageToMat(string imageFilePath)
        {
            Mat srcImage = Cv2.ImRead(imageFilePath, ImreadModes.Unchanged);

            return srcImage;
        }

        private void radiobuttonChanged(int mode)
        {
            if (mode == 0)
            {
                radioButton_Input.Checked = true;
                radioButton_Process.Checked = false;
                m_ProgramMode = mode;
            }
            else if (mode == 1)
            {
                radioButton_Input.Checked = false;
                radioButton_Process.Checked = true;
                m_ProgramMode = mode;
            }
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