namespace WinMDI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etudiantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveALLMDI = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(958, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coursToolStripMenuItem,
            this.etudiantsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "file";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // coursToolStripMenuItem
            // 
            this.coursToolStripMenuItem.Name = "coursToolStripMenuItem";
            this.coursToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.coursToolStripMenuItem.Text = "cours";
            this.coursToolStripMenuItem.Click += new System.EventHandler(this.coursToolStripMenuItem_Click);
            // 
            // etudiantsToolStripMenuItem
            // 
            this.etudiantsToolStripMenuItem.Name = "etudiantsToolStripMenuItem";
            this.etudiantsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.etudiantsToolStripMenuItem.Text = "Etudiants";
            // 
            // SaveALLMDI
            // 
            this.SaveALLMDI.Location = new System.Drawing.Point(703, 214);
            this.SaveALLMDI.Name = "SaveALLMDI";
            this.SaveALLMDI.Size = new System.Drawing.Size(156, 71);
            this.SaveALLMDI.TabIndex = 3;
            this.SaveALLMDI.Text = "SaveALL";
            this.SaveALLMDI.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 349);
            this.Controls.Add(this.SaveALLMDI);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etudiantsToolStripMenuItem;
        private System.Windows.Forms.Button SaveALLMDI;
    }
}

