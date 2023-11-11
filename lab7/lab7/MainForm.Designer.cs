namespace lab7
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
            btnTemplateIsOver = new Button();
            btnCandidateIsOver = new Button();
            btnGenerateImage = new Button();
            SuspendLayout();
            // 
            // btnTemplateIsOver
            // 
            btnTemplateIsOver.BackColor = Color.FromArgb(255, 128, 0);
            btnTemplateIsOver.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnTemplateIsOver.ForeColor = SystemColors.ActiveCaptionText;
            btnTemplateIsOver.Location = new Point(90, 451);
            btnTemplateIsOver.Margin = new Padding(4);
            btnTemplateIsOver.Name = "btnTemplateIsOver";
            btnTemplateIsOver.Size = new Size(200, 62);
            btnTemplateIsOver.TabIndex = 0;
            btnTemplateIsOver.Text = "Template is over";
            btnTemplateIsOver.UseVisualStyleBackColor = false;
            btnTemplateIsOver.Click += TemplateIsOver;
            // 
            // btnCandidateIsOver
            // 
            btnCandidateIsOver.BackColor = Color.FromArgb(255, 128, 0);
            btnCandidateIsOver.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCandidateIsOver.ForeColor = SystemColors.ActiveCaptionText;
            btnCandidateIsOver.Location = new Point(695, 451);
            btnCandidateIsOver.Margin = new Padding(4);
            btnCandidateIsOver.Name = "btnCandidateIsOver";
            btnCandidateIsOver.Size = new Size(200, 62);
            btnCandidateIsOver.TabIndex = 1;
            btnCandidateIsOver.Text = "Candidate is over";
            btnCandidateIsOver.UseVisualStyleBackColor = false;
            btnCandidateIsOver.Click += CandidateIsOver;
            // 
            // btnGenerateImage
            // 
            btnGenerateImage.BackColor = Color.FromArgb(255, 128, 0);
            btnGenerateImage.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerateImage.ForeColor = SystemColors.ActiveCaptionText;
            btnGenerateImage.Location = new Point(393, 451);
            btnGenerateImage.Name = "btnGenerateImage";
            btnGenerateImage.Size = new Size(200, 62);
            btnGenerateImage.TabIndex = 2;
            btnGenerateImage.Text = "Generate image";
            btnGenerateImage.UseVisualStyleBackColor = false;
            btnGenerateImage.Click += GenerateImage;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(984, 561);
            Controls.Add(btnGenerateImage);
            Controls.Add(btnCandidateIsOver);
            Controls.Add(btnTemplateIsOver);
            Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Lab7";
            MouseDown += MainForm_MouseDown;
            MouseUp += MainForm_MouseUp;
            ResumeLayout(false);
        }

        #endregion

        private Button btnTemplateIsOver;
        private Button btnCandidateIsOver;
        private Button btnGenerateImage;
    }
}