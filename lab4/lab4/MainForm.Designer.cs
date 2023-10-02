namespace lab4
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
            lblClassesNum_Text = new Label();
            lblDistinctionsNum_Text = new Label();
            lblObjectsNum_Text = new Label();
            lblSeparatingFunctions = new Label();
            tbSeparatingFunctions = new TextBox();
            tbGeneratedClasses = new TextBox();
            label5 = new Label();
            btnGenerateSeparatingFunctions = new Button();
            tbClassesNum = new TrackBar();
            tbObjectsNum = new TrackBar();
            tbDistinctionsNum = new TrackBar();
            lblClassesNum_Value = new Label();
            lblObjectsNum_Value = new Label();
            lblDistinctionsNum_Value = new Label();
            ((System.ComponentModel.ISupportInitialize)tbClassesNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbObjectsNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbDistinctionsNum).BeginInit();
            SuspendLayout();
            // 
            // lblClassesNum_Text
            // 
            lblClassesNum_Text.AutoSize = true;
            lblClassesNum_Text.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblClassesNum_Text.Location = new Point(16, 45);
            lblClassesNum_Text.Margin = new Padding(4, 0, 4, 0);
            lblClassesNum_Text.Name = "lblClassesNum_Text";
            lblClassesNum_Text.Size = new Size(170, 25);
            lblClassesNum_Text.TabIndex = 3;
            lblClassesNum_Text.Text = "Number of classes:";
            // 
            // lblDistinctionsNum_Text
            // 
            lblDistinctionsNum_Text.AutoSize = true;
            lblDistinctionsNum_Text.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblDistinctionsNum_Text.Location = new Point(16, 328);
            lblDistinctionsNum_Text.Margin = new Padding(4, 0, 4, 0);
            lblDistinctionsNum_Text.Name = "lblDistinctionsNum_Text";
            lblDistinctionsNum_Text.Size = new Size(208, 25);
            lblDistinctionsNum_Text.TabIndex = 4;
            lblDistinctionsNum_Text.Text = "Number of distinctions:";
            // 
            // lblObjectsNum_Text
            // 
            lblObjectsNum_Text.AutoSize = true;
            lblObjectsNum_Text.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblObjectsNum_Text.Location = new Point(16, 192);
            lblObjectsNum_Text.Margin = new Padding(4, 0, 4, 0);
            lblObjectsNum_Text.Name = "lblObjectsNum_Text";
            lblObjectsNum_Text.Size = new Size(172, 25);
            lblObjectsNum_Text.TabIndex = 5;
            lblObjectsNum_Text.Text = "Number of objects:";
            // 
            // lblSeparatingFunctions
            // 
            lblSeparatingFunctions.AutoSize = true;
            lblSeparatingFunctions.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblSeparatingFunctions.Location = new Point(910, 28);
            lblSeparatingFunctions.Margin = new Padding(4, 0, 4, 0);
            lblSeparatingFunctions.Name = "lblSeparatingFunctions";
            lblSeparatingFunctions.Size = new Size(190, 25);
            lblSeparatingFunctions.TabIndex = 6;
            lblSeparatingFunctions.Text = "Separating functions:";
            // 
            // tbSeparatingFunctions
            // 
            tbSeparatingFunctions.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbSeparatingFunctions.Location = new Point(740, 79);
            tbSeparatingFunctions.Margin = new Padding(4);
            tbSeparatingFunctions.Multiline = true;
            tbSeparatingFunctions.Name = "tbSeparatingFunctions";
            tbSeparatingFunctions.ReadOnly = true;
            tbSeparatingFunctions.ScrollBars = ScrollBars.Both;
            tbSeparatingFunctions.Size = new Size(500, 480);
            tbSeparatingFunctions.TabIndex = 7;
            // 
            // tbGeneratedClasses
            // 
            tbGeneratedClasses.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbGeneratedClasses.Location = new Point(232, 79);
            tbGeneratedClasses.Margin = new Padding(4);
            tbGeneratedClasses.Multiline = true;
            tbGeneratedClasses.Name = "tbGeneratedClasses";
            tbGeneratedClasses.ReadOnly = true;
            tbGeneratedClasses.ScrollBars = ScrollBars.Both;
            tbGeneratedClasses.Size = new Size(500, 480);
            tbGeneratedClasses.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(383, 19);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(167, 25);
            label5.TabIndex = 9;
            label5.Text = "Generated classes:";
            // 
            // btnGenerateSeparatingFunctions
            // 
            btnGenerateSeparatingFunctions.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnGenerateSeparatingFunctions.Location = new Point(16, 447);
            btnGenerateSeparatingFunctions.Margin = new Padding(4);
            btnGenerateSeparatingFunctions.Name = "btnGenerateSeparatingFunctions";
            btnGenerateSeparatingFunctions.Size = new Size(208, 63);
            btnGenerateSeparatingFunctions.TabIndex = 10;
            btnGenerateSeparatingFunctions.Text = "Generate";
            btnGenerateSeparatingFunctions.UseVisualStyleBackColor = true;
            btnGenerateSeparatingFunctions.Click += On_btnGenerateSeparatingFunctions_Click;
            // 
            // tbClassesNum
            // 
            tbClassesNum.LargeChange = 2;
            tbClassesNum.Location = new Point(16, 84);
            tbClassesNum.Minimum = 1;
            tbClassesNum.Name = "tbClassesNum";
            tbClassesNum.Size = new Size(208, 45);
            tbClassesNum.TabIndex = 11;
            tbClassesNum.Value = 1;
            tbClassesNum.Scroll += On_tbClassesNum_Scroll;
            // 
            // tbObjectsNum
            // 
            tbObjectsNum.Location = new Point(16, 231);
            tbObjectsNum.Maximum = 100;
            tbObjectsNum.Minimum = 10;
            tbObjectsNum.Name = "tbObjectsNum";
            tbObjectsNum.Size = new Size(208, 45);
            tbObjectsNum.TabIndex = 12;
            tbObjectsNum.Value = 10;
            tbObjectsNum.Scroll += On_tbObjectsNum_Scroll;
            // 
            // tbDistinctionsNum
            // 
            tbDistinctionsNum.LargeChange = 2;
            tbDistinctionsNum.Location = new Point(16, 366);
            tbDistinctionsNum.Minimum = 1;
            tbDistinctionsNum.Name = "tbDistinctionsNum";
            tbDistinctionsNum.Size = new Size(208, 45);
            tbDistinctionsNum.TabIndex = 13;
            tbDistinctionsNum.Value = 1;
            tbDistinctionsNum.Scroll += On_tbDistinctionsNum_Scroll;
            // 
            // lblClassesNum_Value
            // 
            lblClassesNum_Value.AutoSize = true;
            lblClassesNum_Value.Location = new Point(121, 121);
            lblClassesNum_Value.Name = "lblClassesNum_Value";
            lblClassesNum_Value.Size = new Size(0, 25);
            lblClassesNum_Value.TabIndex = 14;
            // 
            // lblObjectsNum_Value
            // 
            lblObjectsNum_Value.AutoSize = true;
            lblObjectsNum_Value.Location = new Point(121, 266);
            lblObjectsNum_Value.Name = "lblObjectsNum_Value";
            lblObjectsNum_Value.Size = new Size(0, 25);
            lblObjectsNum_Value.TabIndex = 15;
            // 
            // lblDistinctionsNum_Value
            // 
            lblDistinctionsNum_Value.AutoSize = true;
            lblDistinctionsNum_Value.Location = new Point(121, 397);
            lblDistinctionsNum_Value.Name = "lblDistinctionsNum_Value";
            lblDistinctionsNum_Value.Size = new Size(0, 25);
            lblDistinctionsNum_Value.TabIndex = 16;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 561);
            Controls.Add(lblDistinctionsNum_Value);
            Controls.Add(lblObjectsNum_Value);
            Controls.Add(lblClassesNum_Value);
            Controls.Add(tbDistinctionsNum);
            Controls.Add(tbObjectsNum);
            Controls.Add(tbClassesNum);
            Controls.Add(btnGenerateSeparatingFunctions);
            Controls.Add(label5);
            Controls.Add(tbGeneratedClasses);
            Controls.Add(tbSeparatingFunctions);
            Controls.Add(lblSeparatingFunctions);
            Controls.Add(lblObjectsNum_Text);
            Controls.Add(lblDistinctionsNum_Text);
            Controls.Add(lblClassesNum_Text);
            Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Lab 4";
            ((System.ComponentModel.ISupportInitialize)tbClassesNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbObjectsNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbDistinctionsNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblClassesNum_Text;
        private Label lblDistinctionsNum_Text;
        private Label lblObjectsNum_Text;
        private Label lblSeparatingFunctions;
        private TextBox tbSeparatingFunctions;
        private TextBox tbGeneratedClasses;
        private Label label5;
        private Button btnGenerateSeparatingFunctions;
        private TrackBar tbClassesNum;
        private TrackBar tbObjectsNum;
        private TrackBar tbDistinctionsNum;
        private Label lblClassesNum_Value;
        private Label lblObjectsNum_Value;
        private Label lblDistinctionsNum_Value;
    }
}