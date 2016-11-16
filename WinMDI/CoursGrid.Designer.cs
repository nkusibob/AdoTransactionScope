namespace WinMDI
{
    partial class CoursWinForm
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
            this.CoursGrid = new System.Windows.Forms.DataGridView();
            this.SaveCours = new System.Windows.Forms.Button();
            this.SearchCours = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CoursGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CoursGrid
            // 
            this.CoursGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoursGrid.Location = new System.Drawing.Point(12, 54);
            this.CoursGrid.Name = "CoursGrid";
            this.CoursGrid.Size = new System.Drawing.Size(353, 185);
            this.CoursGrid.TabIndex = 0;
            // 
            // SaveCours
            // 
            this.SaveCours.Location = new System.Drawing.Point(265, 263);
            this.SaveCours.Name = "SaveCours";
            this.SaveCours.Size = new System.Drawing.Size(100, 42);
            this.SaveCours.TabIndex = 1;
            this.SaveCours.Text = "SaveAll";
            this.SaveCours.UseVisualStyleBackColor = true;
            this.SaveCours.Click += new System.EventHandler(this.SaveCours_Click);
            // 
            // SearchCours
            // 
            this.SearchCours.Location = new System.Drawing.Point(12, 12);
            this.SearchCours.Name = "SearchCours";
            this.SearchCours.Size = new System.Drawing.Size(146, 20);
            this.SearchCours.TabIndex = 2;
            // 
            // CoursWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 341);
            this.Controls.Add(this.SearchCours);
            this.Controls.Add(this.SaveCours);
            this.Controls.Add(this.CoursGrid);
            this.Name = "CoursWinForm";
            this.Text = "CoursWinForm";
            ((System.ComponentModel.ISupportInitialize)(this.CoursGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CoursGrid;
        private System.Windows.Forms.Button SaveCours;
        private System.Windows.Forms.TextBox SearchCours;
    }
}