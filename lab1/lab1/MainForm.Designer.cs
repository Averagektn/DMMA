namespace lab1
{
    partial class MainForm
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
            numClustersNum = new NumericUpDown();
            lblDotsNum = new Label();
            lblDotsTotal = new Label();
            btnStart = new Button();
            lblClustersNum = new Label();
            tbWidth = new TextBox();
            tbHeight = new TextBox();
            lblWidth = new Label();
            lblHeight = new Label();
            ((System.ComponentModel.ISupportInitialize)numClustersNum).BeginInit();
            SuspendLayout();
            // 
            // sbDotsNum
            // 
            sbDotsNum.Location = new Point(86, 89);
            sbDotsNum.Maximum = 50000;
            sbDotsNum.Minimum = 5000;
            sbDotsNum.Name = "sbDotsNum";
            sbDotsNum.Size = new Size(313, 35);
            sbDotsNum.TabIndex = 0;
            sbDotsNum.Value = 5000;
            sbDotsNum.Scroll += sbDotsNum_Scroll;
            // 
            // numClustersNum
            // 
            numClustersNum.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            numClustersNum.Location = new Point(419, 92);
            numClustersNum.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numClustersNum.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numClustersNum.Name = "numClustersNum";
            numClustersNum.ReadOnly = true;
            numClustersNum.Size = new Size(120, 32);
            numClustersNum.TabIndex = 1;
            numClustersNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblDotsNum
            // 
            lblDotsNum.AutoSize = true;
            lblDotsNum.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblDotsNum.Location = new Point(187, 50);
            lblDotsNum.Name = "lblDotsNum";
            lblDotsNum.Size = new Size(144, 25);
            lblDotsNum.TabIndex = 2;
            lblDotsNum.Text = "Number of dots";
            // 
            // lblDotsTotal
            // 
            lblDotsTotal.AutoSize = true;
            lblDotsTotal.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblDotsTotal.Location = new Point(31, 89);
            lblDotsTotal.Name = "lblDotsTotal";
            lblDotsTotal.Size = new Size(52, 25);
            lblDotsTotal.TabIndex = 3;
            lblDotsTotal.Text = "5000";
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnStart.Location = new Point(187, 209);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(112, 41);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblClustersNum
            // 
            lblClustersNum.AutoSize = true;
            lblClustersNum.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblClustersNum.Location = new Point(419, 50);
            lblClustersNum.Name = "lblClustersNum";
            lblClustersNum.Size = new Size(172, 25);
            lblClustersNum.TabIndex = 5;
            lblClustersNum.Text = "Number of clusters";
            // 
            // tbWidth
            // 
            tbWidth.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbWidth.Location = new Point(187, 127);
            tbWidth.Name = "tbWidth";
            tbWidth.Size = new Size(112, 32);
            tbWidth.TabIndex = 6;
            tbWidth.Text = "0";
            // 
            // tbHeight
            // 
            tbHeight.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbHeight.Location = new Point(187, 171);
            tbHeight.Name = "tbHeight";
            tbHeight.Size = new Size(112, 32);
            tbHeight.TabIndex = 7;
            tbHeight.Text = "0";
            // 
            // lblWidth
            // 
            lblWidth.AutoSize = true;
            lblWidth.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblWidth.Location = new Point(96, 130);
            lblWidth.Name = "lblWidth";
            lblWidth.Size = new Size(63, 25);
            lblWidth.TabIndex = 8;
            lblWidth.Text = "Width";
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblHeight.Location = new Point(96, 178);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(68, 25);
            lblHeight.TabIndex = 9;
            lblHeight.Text = "Height";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 273);
            Controls.Add(lblHeight);
            Controls.Add(lblWidth);
            Controls.Add(tbHeight);
            Controls.Add(tbWidth);
            Controls.Add(lblClustersNum);
            Controls.Add(btnStart);
            Controls.Add(lblDotsTotal);
            Controls.Add(lblDotsNum);
            Controls.Add(numClustersNum);
            Controls.Add(sbDotsNum);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Location = new Point(100, 100);
            Name = "MainForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Lab1";
            ((System.ComponentModel.ISupportInitialize)numClustersNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private HScrollBar sbDotsNum;
        private NumericUpDown numClustersNum;
        private Label lblDotsNum;
        private Label lblDotsTotal;
        private Button btnStart;
        private Label lblClustersNum;
        private TextBox tbWidth;
        private TextBox tbHeight;
        private Label lblWidth;
        private Label lblHeight;
    }
}