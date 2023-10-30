namespace Templete_DLL_LYS
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPalette = new System.Windows.Forms.PictureBox();
            this.textBox_DrawMode = new System.Windows.Forms.TextBox();
            this.button_Point = new System.Windows.Forms.Button();
            this.button_Line = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainPalette)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPalette
            // 
            this.MainPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPalette.Location = new System.Drawing.Point(12, 43);
            this.MainPalette.Name = "MainPalette";
            this.MainPalette.Size = new System.Drawing.Size(922, 443);
            this.MainPalette.TabIndex = 0;
            this.MainPalette.TabStop = false;
            // 
            // textBox_DrawMode
            // 
            this.textBox_DrawMode.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox_DrawMode.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox_DrawMode.Location = new System.Drawing.Point(940, 16);
            this.textBox_DrawMode.Name = "textBox_DrawMode";
            this.textBox_DrawMode.Size = new System.Drawing.Size(90, 21);
            this.textBox_DrawMode.TabIndex = 1;
            // 
            // button_Point
            // 
            this.button_Point.Location = new System.Drawing.Point(940, 43);
            this.button_Point.Name = "button_Point";
            this.button_Point.Size = new System.Drawing.Size(70, 31);
            this.button_Point.TabIndex = 2;
            this.button_Point.Text = "Point";
            this.button_Point.UseVisualStyleBackColor = true;
            this.button_Point.Click += new System.EventHandler(this.button_Point_Click);
            // 
            // button_Line
            // 
            this.button_Line.Location = new System.Drawing.Point(940, 71);
            this.button_Line.Name = "button_Line";
            this.button_Line.Size = new System.Drawing.Size(70, 31);
            this.button_Line.TabIndex = 3;
            this.button_Line.Text = "Line";
            this.button_Line.UseVisualStyleBackColor = true;
            this.button_Line.Click += new System.EventHandler(this.button_Line_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.button_Line);
            this.Controls.Add(this.button_Point);
            this.Controls.Add(this.textBox_DrawMode);
            this.Controls.Add(this.MainPalette);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainPalette)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPalette;
        private System.Windows.Forms.Button button_Point;
        private System.Windows.Forms.Button button_Line;
        private System.Windows.Forms.TextBox textBox_DrawMode;
    }
}

