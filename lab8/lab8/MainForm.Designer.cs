namespace lab8
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
            tbVerifyngString = new TextBox();
            btnGenerateGrammar = new Button();
            btnGenetateChains = new Button();
            btnVerify = new Button();
            dgvGrammar = new DataGridView();
            Grammar = new DataGridViewTextBoxColumn();
            dgvChains = new DataGridView();
            Chains = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvGrammar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChains).BeginInit();
            SuspendLayout();
            // 
            // tbVerifyngString
            // 
            tbVerifyngString.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbVerifyngString.Location = new Point(409, 442);
            tbVerifyngString.Margin = new Padding(4);
            tbVerifyngString.Name = "tbVerifyngString";
            tbVerifyngString.Size = new Size(167, 32);
            tbVerifyngString.TabIndex = 0;
            // 
            // btnGenerateGrammar
            // 
            btnGenerateGrammar.Font = new Font("Snap ITC", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerateGrammar.Location = new Point(41, 482);
            btnGenerateGrammar.Margin = new Padding(4);
            btnGenerateGrammar.Name = "btnGenerateGrammar";
            btnGenerateGrammar.Size = new Size(275, 66);
            btnGenerateGrammar.TabIndex = 1;
            btnGenerateGrammar.Text = "Generate grammar";
            btnGenerateGrammar.UseVisualStyleBackColor = true;
            btnGenerateGrammar.Click += GenerateGrammar;
            // 
            // btnGenetateChains
            // 
            btnGenetateChains.Font = new Font("Snap ITC", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenetateChains.Location = new Point(669, 482);
            btnGenetateChains.Margin = new Padding(4);
            btnGenetateChains.Name = "btnGenetateChains";
            btnGenetateChains.Size = new Size(275, 66);
            btnGenetateChains.TabIndex = 2;
            btnGenetateChains.Text = "Generate chains";
            btnGenetateChains.UseVisualStyleBackColor = true;
            btnGenetateChains.Click += GenetateChains;
            // 
            // btnVerify
            // 
            btnVerify.Font = new Font("Snap ITC", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnVerify.Location = new Point(355, 482);
            btnVerify.Margin = new Padding(4);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(275, 66);
            btnVerify.TabIndex = 3;
            btnVerify.Text = "Verify";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += Verify;
            // 
            // dgvGrammar
            // 
            dgvGrammar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrammar.Columns.AddRange(new DataGridViewColumn[] { Grammar });
            dgvGrammar.Location = new Point(-4, 3);
            dgvGrammar.Margin = new Padding(4);
            dgvGrammar.Name = "dgvGrammar";
            dgvGrammar.RowTemplate.Height = 28;
            dgvGrammar.Size = new Size(490, 400);
            dgvGrammar.TabIndex = 5;
            // 
            // Grammar
            // 
            Grammar.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grammar.HeaderText = "Grammar";
            Grammar.Name = "Grammar";
            // 
            // dgvChains
            // 
            dgvChains.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChains.Columns.AddRange(new DataGridViewColumn[] { Chains });
            dgvChains.Location = new Point(494, 3);
            dgvChains.Margin = new Padding(4);
            dgvChains.Name = "dgvChains";
            dgvChains.RowTemplate.Height = 28;
            dgvChains.Size = new Size(490, 400);
            dgvChains.TabIndex = 6;
            // 
            // Chains
            // 
            Chains.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Chains.HeaderText = "Chains";
            Chains.Name = "Chains";
            Chains.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(984, 561);
            Controls.Add(dgvChains);
            Controls.Add(dgvGrammar);
            Controls.Add(btnVerify);
            Controls.Add(btnGenetateChains);
            Controls.Add(btnGenerateGrammar);
            Controls.Add(tbVerifyngString);
            Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Lab 8";
            ((System.ComponentModel.ISupportInitialize)dgvGrammar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChains).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbVerifyngString;
        private Button btnGenerateGrammar;
        private Button btnGenetateChains;
        private Button btnVerify;
        private DataGridView dgvGrammar;
        private DataGridViewTextBoxColumn Grammar;
        private DataGridView dgvChains;
        private DataGridViewTextBoxColumn Chains;
    }
}