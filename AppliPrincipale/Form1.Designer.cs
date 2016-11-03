namespace AppliPrincipale
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
            this.gridData = new System.Windows.Forms.DataGridView();
            this.btLoadDataSet = new System.Windows.Forms.Button();
            this.btDataTable = new System.Windows.Forms.Button();
            this.btDataView = new System.Windows.Forms.Button();
            this.btList = new System.Windows.Forms.Button();
            this.txtMatricule = new System.Windows.Forms.TextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.btSaveAll = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridData
            // 
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Location = new System.Drawing.Point(27, 109);
            this.gridData.Name = "gridData";
            this.gridData.Size = new System.Drawing.Size(823, 216);
            this.gridData.TabIndex = 0;
            // 
            // btLoadDataSet
            // 
            this.btLoadDataSet.Location = new System.Drawing.Point(27, 342);
            this.btLoadDataSet.Name = "btLoadDataSet";
            this.btLoadDataSet.Size = new System.Drawing.Size(128, 61);
            this.btLoadDataSet.TabIndex = 1;
            this.btLoadDataSet.Text = "Load DataSet";
            this.btLoadDataSet.UseVisualStyleBackColor = true;
            this.btLoadDataSet.Click += new System.EventHandler(this.btLoadDataSet_Click);
            // 
            // btDataTable
            // 
            this.btDataTable.Location = new System.Drawing.Point(205, 342);
            this.btDataTable.Name = "btDataTable";
            this.btDataTable.Size = new System.Drawing.Size(128, 61);
            this.btDataTable.TabIndex = 2;
            this.btDataTable.Text = "Load DataTable";
            this.btDataTable.UseVisualStyleBackColor = true;
            this.btDataTable.Click += new System.EventHandler(this.btDataTable_Click);
            // 
            // btDataView
            // 
            this.btDataView.Location = new System.Drawing.Point(356, 342);
            this.btDataView.Name = "btDataView";
            this.btDataView.Size = new System.Drawing.Size(128, 61);
            this.btDataView.TabIndex = 3;
            this.btDataView.Text = "Load DataView";
            this.btDataView.UseVisualStyleBackColor = true;
            this.btDataView.Click += new System.EventHandler(this.btDataView_Click);
            // 
            // btList
            // 
            this.btList.Location = new System.Drawing.Point(523, 342);
            this.btList.Name = "btList";
            this.btList.Size = new System.Drawing.Size(128, 61);
            this.btList.TabIndex = 4;
            this.btList.Text = "Load List";
            this.btList.UseVisualStyleBackColor = true;
            this.btList.Click += new System.EventHandler(this.btList_Click);
            // 
            // txtMatricule
            // 
            this.txtMatricule.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatricule.Location = new System.Drawing.Point(27, 52);
            this.txtMatricule.Name = "txtMatricule";
            this.txtMatricule.Size = new System.Drawing.Size(162, 29);
            this.txtMatricule.TabIndex = 5;
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(230, 52);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(82, 26);
            this.btSearch.TabIndex = 6;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btSaveAll
            // 
            this.btSaveAll.Location = new System.Drawing.Point(686, 342);
            this.btSaveAll.Name = "btSaveAll";
            this.btSaveAll.Size = new System.Drawing.Size(153, 54);
            this.btSaveAll.TabIndex = 7;
            this.btSaveAll.Text = "Save All";
            this.btSaveAll.UseVisualStyleBackColor = true;
            this.btSaveAll.Click += new System.EventHandler(this.btSaveAll_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(982, 24);
            this.menuStrip2.TabIndex = 9;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.newToolStripMenuItem.Text = "new";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 521);
            this.Controls.Add(this.btSaveAll);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.txtMatricule);
            this.Controls.Add(this.btList);
            this.Controls.Add(this.btDataView);
            this.Controls.Add(this.btDataTable);
            this.Controls.Add(this.btLoadDataSet);
            this.Controls.Add(this.gridData);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.Button btLoadDataSet;
        private System.Windows.Forms.Button btDataTable;
        private System.Windows.Forms.Button btDataView;
        private System.Windows.Forms.Button btList;
        private System.Windows.Forms.TextBox txtMatricule;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.Button btSaveAll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    }
}

