namespace lab2
{
    partial class InitialForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sbDotsNum = new HScrollBar();
            lblNumber = new Label();
            btnStart = new Button();
            lblName = new Label();
            SuspendLayout();
            // 
            // sbDotsNum
            // 
            sbDotsNum.Location = new Point(113, 47);
            sbDotsNum.Maximum = 50000;
            sbDotsNum.Minimum = 5000;
            sbDotsNum.Name = "sbDotsNum";
            sbDotsNum.Size = new Size(276, 37);
            sbDotsNum.TabIndex = 0;
            sbDotsNum.Value = 5000;
            sbDotsNum.Scroll += sbDotsNum_Scroll;
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblNumber.Location = new Point(52, 47);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(52, 25);
            lblNumber.TabIndex = 1;
            lblNumber.Text = "5000";
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location = new Point(176, 106);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(102, 42);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(162, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(144, 25);
            lblName.TabIndex = 3;
            lblName.Text = "Number of dots";
            // 
            // InitialForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 206);
            Controls.Add(lblName);
            Controls.Add(btnStart);
            Controls.Add(lblNumber);
            Controls.Add(sbDotsNum);
            Name = "InitialForm";
            Text = "Initial";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private HScrollBar sbDotsNum;
        private Label lblNumber;
        private Button btnStart;
        private Label lblName;
    }
}