namespace MFEditor.PropertyControl
{
    partial class LayerClassesPropertyPage
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
            this.comboBoxClassItem = new System.Windows.Forms.ComboBox();
            this.dataGridViewClass = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonAddAll = new System.Windows.Forms.Button();
            this.comboBoxLabelItem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Expression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClass)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxClassItem
            // 
            this.comboBoxClassItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClassItem.FormattingEnabled = true;
            this.comboBoxClassItem.Location = new System.Drawing.Point(92, 17);
            this.comboBoxClassItem.Name = "comboBoxClassItem";
            this.comboBoxClassItem.Size = new System.Drawing.Size(135, 20);
            this.comboBoxClassItem.TabIndex = 48;
            // 
            // dataGridViewClass
            // 
            this.dataGridViewClass.AllowUserToAddRows = false;
            this.dataGridViewClass.AllowUserToDeleteRows = false;
            this.dataGridViewClass.AllowUserToResizeColumns = false;
            this.dataGridViewClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Expression,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewClass.Location = new System.Drawing.Point(9, 44);
            this.dataGridViewClass.Name = "dataGridViewClass";
            this.dataGridViewClass.ReadOnly = true;
            this.dataGridViewClass.RowTemplate.Height = 23;
            this.dataGridViewClass.Size = new System.Drawing.Size(462, 231);
            this.dataGridViewClass.TabIndex = 47;
            this.dataGridViewClass.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClass_CellDoubleClick);
            this.dataGridViewClass.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClass_CellClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(8, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "ClassItem:";
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Location = new System.Drawing.Point(290, 281);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(97, 28);
            this.buttonRemoveAll.TabIndex = 52;
            this.buttonRemoveAll.Text = "Remove All";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            this.buttonRemoveAll.Click += new System.EventHandler(this.buttonRemoveAll_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(203, 281);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(80, 28);
            this.buttonRemove.TabIndex = 51;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(115, 281);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(80, 28);
            this.buttonAdd.TabIndex = 50;
            this.buttonAdd.Text = "Add Values";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonAddAll
            // 
            this.buttonAddAll.Location = new System.Drawing.Point(9, 281);
            this.buttonAddAll.Name = "buttonAddAll";
            this.buttonAddAll.Size = new System.Drawing.Size(97, 28);
            this.buttonAddAll.TabIndex = 49;
            this.buttonAddAll.Text = "Add All Values";
            this.buttonAddAll.UseVisualStyleBackColor = true;
            this.buttonAddAll.Click += new System.EventHandler(this.buttonAddAll_Click);
            // 
            // comboBoxLabelItem
            // 
            this.comboBoxLabelItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLabelItem.FormattingEnabled = true;
            this.comboBoxLabelItem.Location = new System.Drawing.Point(336, 18);
            this.comboBoxLabelItem.Name = "comboBoxLabelItem";
            this.comboBoxLabelItem.Size = new System.Drawing.Size(135, 20);
            this.comboBoxLabelItem.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(252, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 53;
            this.label1.Text = "LabelItem:";
            // 
            // Expression
            // 
            this.Expression.HeaderText = "Name";
            this.Expression.Name = "Expression";
            this.Expression.ReadOnly = true;
            this.Expression.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Expression";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Style";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Label";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LayerClassesPropertyPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxLabelItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRemoveAll);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonAddAll);
            this.Controls.Add(this.comboBoxClassItem);
            this.Controls.Add(this.dataGridViewClass);
            this.Controls.Add(this.label10);
            this.Name = "LayerClassesPropertyPage";
            this.Size = new System.Drawing.Size(480, 320);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxClassItem;
        private System.Windows.Forms.DataGridView dataGridViewClass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonRemoveAll;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonAddAll;
        private System.Windows.Forms.ComboBox comboBoxLabelItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expression;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
