namespace lab3
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
            Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            lblDetectionPass = new Label();
            lblFalseAlarm = new Label();
            lblSum = new Label();
            ((System.ComponentModel.ISupportInitialize)Chart).BeginInit();
            SuspendLayout();
            // 
            // Chart
            // 
            Chart.Location = new Point(-14, -4);
            Chart.Name = "Chart";
            Chart.Size = new Size(1000, 590);
            Chart.TabIndex = 0;
            // 
            // lblDetectionPass
            // 
            lblDetectionPass.AutoSize = true;
            lblDetectionPass.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblDetectionPass.Location = new Point(998, 215);
            lblDetectionPass.Name = "lblDetectionPass";
            lblDetectionPass.Size = new Size(139, 25);
            lblDetectionPass.TabIndex = 4;
            lblDetectionPass.Text = "Detection pass:";
            // 
            // lblFalseAlarm
            // 
            lblFalseAlarm.AutoSize = true;
            lblFalseAlarm.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblFalseAlarm.Location = new Point(998, 150);
            lblFalseAlarm.Name = "lblFalseAlarm";
            lblFalseAlarm.Size = new Size(115, 25);
            lblFalseAlarm.TabIndex = 7;
            lblFalseAlarm.Text = "False alarm: ";
            // 
            // lblSum
            // 
            lblSum.AutoSize = true;
            lblSum.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblSum.Location = new Point(998, 272);
            lblSum.Name = "lblSum";
            lblSum.Size = new Size(53, 25);
            lblSum.TabIndex = 8;
            lblSum.Text = "Sum:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 561);
            Controls.Add(lblSum);
            Controls.Add(lblFalseAlarm);
            Controls.Add(lblDetectionPass);
            Controls.Add(Chart);
            Name = "MainForm";
            Text = "Lab 3";
            ((System.ComponentModel.ISupportInitialize)Chart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private Label lblDetectionPass;
        private Label lblFalseAlarm;
        private Label lblSum;
    }
}