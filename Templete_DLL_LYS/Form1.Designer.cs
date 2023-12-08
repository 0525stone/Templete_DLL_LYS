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
            this.button_Fitting = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.radioButton_Input = new System.Windows.Forms.RadioButton();
            this.radioButton_Process = new System.Windows.Forms.RadioButton();
            this.richTextBox_legend = new System.Windows.Forms.RichTextBox();
            this.button_Load = new System.Windows.Forms.Button();
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
            this.textBox_DrawMode.Enabled = false;
            this.textBox_DrawMode.Location = new System.Drawing.Point(940, 16);
            this.textBox_DrawMode.Name = "textBox_DrawMode";
            this.textBox_DrawMode.Size = new System.Drawing.Size(90, 21);
            this.textBox_DrawMode.TabIndex = 1;
            // 
            // button_Fitting
            // 
            this.button_Fitting.Location = new System.Drawing.Point(940, 43);
            this.button_Fitting.Name = "button_Fitting";
            this.button_Fitting.Size = new System.Drawing.Size(70, 31);
            this.button_Fitting.TabIndex = 2;
            this.button_Fitting.Text = "Fitting";
            this.button_Fitting.UseVisualStyleBackColor = true;
            this.button_Fitting.Click += new System.EventHandler(this.button_Fitting_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(1080, 56);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(70, 31);
            this.button_Clear.TabIndex = 3;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // radioButton_Input
            // 
            this.radioButton_Input.AutoSize = true;
            this.radioButton_Input.Checked = true;
            this.radioButton_Input.Location = new System.Drawing.Point(1080, 12);
            this.radioButton_Input.Name = "radioButton_Input";
            this.radioButton_Input.Size = new System.Drawing.Size(50, 16);
            this.radioButton_Input.TabIndex = 4;
            this.radioButton_Input.TabStop = true;
            this.radioButton_Input.Text = "Input";
            this.radioButton_Input.UseVisualStyleBackColor = true;
            this.radioButton_Input.CheckedChanged += new System.EventHandler(this.radioButton_Input_CheckedChanged);
            // 
            // radioButton_Process
            // 
            this.radioButton_Process.AutoSize = true;
            this.radioButton_Process.Location = new System.Drawing.Point(1080, 34);
            this.radioButton_Process.Name = "radioButton_Process";
            this.radioButton_Process.Size = new System.Drawing.Size(70, 16);
            this.radioButton_Process.TabIndex = 5;
            this.radioButton_Process.Text = "Process";
            this.radioButton_Process.UseVisualStyleBackColor = true;
            this.radioButton_Process.CheckedChanged += new System.EventHandler(this.radioButton_Process_CheckedChanged);
            // 
            // richTextBox_legend
            // 
            this.richTextBox_legend.Location = new System.Drawing.Point(940, 390);
            this.richTextBox_legend.Name = "richTextBox_legend";
            this.richTextBox_legend.Size = new System.Drawing.Size(190, 96);
            this.richTextBox_legend.TabIndex = 7;
            this.richTextBox_legend.Text = "";
            // 
            // button_Load
            // 
            this.button_Load.Location = new System.Drawing.Point(1080, 93);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(70, 31);
            this.button_Load.TabIndex = 8;
            this.button_Load.Text = "Open";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.button_Load);
            this.Controls.Add(this.richTextBox_legend);
            this.Controls.Add(this.radioButton_Process);
            this.Controls.Add(this.radioButton_Input);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Fitting);
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
        private System.Windows.Forms.Button button_Fitting;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.TextBox textBox_DrawMode;
        private System.Windows.Forms.RadioButton radioButton_Input;
        private System.Windows.Forms.RadioButton radioButton_Process;
        private System.Windows.Forms.RichTextBox richTextBox_legend;
        private System.Windows.Forms.Button button_Load;
    }
}

