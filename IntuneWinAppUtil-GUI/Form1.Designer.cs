namespace IntuneWinAppUtil_GUI
{
    partial class Form1
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
            buttonStart = new System.Windows.Forms.Button();
            textBoxInput = new System.Windows.Forms.TextBox();
            textBoxOutput = new System.Windows.Forms.TextBox();
            listBoxFiles = new System.Windows.Forms.ListBox();
            textBoxSoftware = new System.Windows.Forms.TextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            buttonInput = new System.Windows.Forms.Button();
            buttonOutput = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            textBoxCli = new System.Windows.Forms.RichTextBox();
            groupBox1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.Location = new System.Drawing.Point(542, 45);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new System.Drawing.Size(80, 85);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // textBoxInput
            // 
            textBoxInput.Location = new System.Drawing.Point(6, 24);
            textBoxInput.Name = "textBoxInput";
            textBoxInput.Size = new System.Drawing.Size(432, 23);
            textBoxInput.TabIndex = 3;
            textBoxInput.Text = "Input";
            textBoxInput.Enter += textBoxInput_Enter;
            textBoxInput.Leave += textBoxInput_Leave;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new System.Drawing.Point(6, 53);
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.Size = new System.Drawing.Size(432, 23);
            textBoxOutput.TabIndex = 4;
            textBoxOutput.Text = "Output";
            textBoxOutput.Enter += textBoxOutput_Enter;
            textBoxOutput.Leave += textBoxOutput_Leave;
            // 
            // listBoxFiles
            // 
            listBoxFiles.BackColor = System.Drawing.SystemColors.Control;
            listBoxFiles.Dock = System.Windows.Forms.DockStyle.Right;
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.ItemHeight = 15;
            listBoxFiles.Location = new System.Drawing.Point(90, 0);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new System.Drawing.Size(519, 109);
            listBoxFiles.TabIndex = 7;
            // 
            // textBoxSoftware
            // 
            textBoxSoftware.Location = new System.Drawing.Point(260, 60);
            textBoxSoftware.Name = "textBoxSoftware";
            textBoxSoftware.ReadOnly = true;
            textBoxSoftware.Size = new System.Drawing.Size(80, 23);
            textBoxSoftware.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonInput);
            groupBox1.Controls.Add(buttonOutput);
            groupBox1.Controls.Add(textBoxInput);
            groupBox1.Controls.Add(textBoxOutput);
            groupBox1.Location = new System.Drawing.Point(12, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(524, 93);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Directories";
            // 
            // buttonInput
            // 
            buttonInput.Location = new System.Drawing.Point(443, 24);
            buttonInput.Name = "buttonInput";
            buttonInput.Size = new System.Drawing.Size(75, 23);
            buttonInput.TabIndex = 5;
            buttonInput.Text = "Browse...";
            buttonInput.UseVisualStyleBackColor = true;
            buttonInput.Click += buttonOutput_Click;
            // 
            // buttonOutput
            // 
            buttonOutput.Location = new System.Drawing.Point(443, 53);
            buttonOutput.Name = "buttonOutput";
            buttonOutput.Size = new System.Drawing.Size(75, 23);
            buttonOutput.TabIndex = 6;
            buttonOutput.Text = "Browse...";
            buttonOutput.UseVisualStyleBackColor = true;
            buttonOutput.Click += buttonOutput_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(633, 24);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { updateToolStripMenuItem, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Enabled = false;
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            updateToolStripMenuItem.Text = "Check for Updates";
            updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new System.Drawing.Point(12, 136);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listBoxFiles);
            splitContainer1.Panel1.Controls.Add(textBoxSoftware);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(textBoxCli);
            splitContainer1.Size = new System.Drawing.Size(609, 234);
            splitContainer1.SplitterDistance = 109;
            splitContainer1.TabIndex = 18;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(4, 40);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(80, 30);
            label1.TabIndex = 10;
            label1.Text = "Included files \r\nand Folders";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(5, 49);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(63, 15);
            label2.TabIndex = 11;
            label2.Text = "CLI output";
            // 
            // textBoxCli
            // 
            textBoxCli.BackColor = System.Drawing.SystemColors.Control;
            textBoxCli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBoxCli.Dock = System.Windows.Forms.DockStyle.Right;
            textBoxCli.Location = new System.Drawing.Point(90, 0);
            textBoxCli.Name = "textBoxCli";
            textBoxCli.Size = new System.Drawing.Size(519, 121);
            textBoxCli.TabIndex = 16;
            textBoxCli.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(633, 381);
            Controls.Add(splitContainer1);
            Controls.Add(buttonStart);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "IntuneWinAppUtil GUI";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonInput;
        private System.Windows.Forms.Button buttonOutput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.ListBox listBoxFiles;
        private System.Windows.Forms.TextBox textBoxSoftware;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox textBoxCli;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
