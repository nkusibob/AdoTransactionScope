namespace WinMDI
{
    partial class StudentGrid
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
            this.components = new System.ComponentModel.Container();
            this.txtBoxNomSearch = new System.Windows.Forms.TextBox();
            this.btnNomSearch = new System.Windows.Forms.Button();
            this.GridStudentMDI = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.GridStudentMDI)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxNomSearch
            // 
            this.txtBoxNomSearch.Location = new System.Drawing.Point(12, 33);
            this.txtBoxNomSearch.Name = "txtBoxNomSearch";
            this.txtBoxNomSearch.Size = new System.Drawing.Size(148, 20);
            this.txtBoxNomSearch.TabIndex = 0;
            // 
            // btnNomSearch
            // 
            this.btnNomSearch.Location = new System.Drawing.Point(178, 30);
            this.btnNomSearch.Name = "btnNomSearch";
            this.btnNomSearch.Size = new System.Drawing.Size(75, 23);
            this.btnNomSearch.TabIndex = 1;
            this.btnNomSearch.Text = "search";
            this.btnNomSearch.UseVisualStyleBackColor = true;
            // 
            // GridStudentMDI
            // 
            this.GridStudentMDI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridStudentMDI.Location = new System.Drawing.Point(12, 70);
            this.GridStudentMDI.Name = "GridStudentMDI";
            this.GridStudentMDI.Size = new System.Drawing.Size(362, 179);
            this.GridStudentMDI.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.updateToolStripMenuItem.Text = "update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // StudentGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.GridStudentMDI);
            this.Controls.Add(this.btnNomSearch);
            this.Controls.Add(this.txtBoxNomSearch);
            this.Name = "StudentGrid";
            this.Text = "StudentGrid";
           
            ((System.ComponentModel.ISupportInitialize)(this.GridStudentMDI)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxNomSearch;
        private System.Windows.Forms.Button btnNomSearch;
        private System.Windows.Forms.DataGridView GridStudentMDI;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
    }
}