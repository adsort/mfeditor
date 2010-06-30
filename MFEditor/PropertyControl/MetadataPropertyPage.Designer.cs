namespace MFEditor.PropertyControl
{
    partial class MetadataPropertyPage
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewMeta = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripMeta = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItemMetaDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMeta)).BeginInit();
            this.contextMenuStripMeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewMeta
            // 
            this.dataGridViewMeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMeta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewMeta.Location = new System.Drawing.Point(8, 14);
            this.dataGridViewMeta.MultiSelect = false;
            this.dataGridViewMeta.Name = "dataGridViewMeta";
            this.dataGridViewMeta.RowTemplate.Height = 23;
            this.dataGridViewMeta.Size = new System.Drawing.Size(463, 258);
            this.dataGridViewMeta.TabIndex = 2;
            this.dataGridViewMeta.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMeta_CellMouseClick);
            this.dataGridViewMeta.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridViewMeta_RowPostPaint);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Metadata Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Metadata Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 260;
            // 
            // contextMenuStripMeta
            // 
            this.contextMenuStripMeta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemMetaDelete});
            this.contextMenuStripMeta.Name = "contextMenuStripMeta";
            this.contextMenuStripMeta.Size = new System.Drawing.Size(153, 48);
            // 
            // ToolStripMenuItemMetaDelete
            // 
            this.ToolStripMenuItemMetaDelete.Name = "ToolStripMenuItemMetaDelete";
            this.ToolStripMenuItemMetaDelete.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItemMetaDelete.Text = "Delete";
            this.ToolStripMenuItemMetaDelete.Click += new System.EventHandler(this.ToolStripMenuItemMetaDelete_Click);
            // 
            // MetadataPropertyPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewMeta);
            this.Name = "MetadataPropertyPage";
            this.Size = new System.Drawing.Size(480, 320);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMeta)).EndInit();
            this.contextMenuStripMeta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMeta;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMeta;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemMetaDelete;
    }
}
