namespace MFEditorUI.CartoUI
{
    partial class UniqueValueRenderPage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxField = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewSymbols = new System.Windows.Forms.ListView();
            this.buttonAddAll = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.colorRampCombobox1 = new MFEditorUI.CartoUI.ColorRampCombobox(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxField);
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Value Field";
            // 
            // comboBoxField
            // 
            this.comboBoxField.FormattingEnabled = true;
            this.comboBoxField.Location = new System.Drawing.Point(6, 20);
            this.comboBoxField.Name = "comboBoxField";
            this.comboBoxField.Size = new System.Drawing.Size(210, 20);
            this.comboBoxField.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.colorRampCombobox1);
            this.groupBox2.Location = new System.Drawing.Point(237, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color Ramp";
            // 
            // listViewSymbols
            // 
            this.listViewSymbols.Location = new System.Drawing.Point(9, 58);
            this.listViewSymbols.Name = "listViewSymbols";
            this.listViewSymbols.Size = new System.Drawing.Size(457, 214);
            this.listViewSymbols.TabIndex = 2;
            this.listViewSymbols.UseCompatibleStateImageBehavior = false;
            // 
            // buttonAddAll
            // 
            this.buttonAddAll.Location = new System.Drawing.Point(9, 278);
            this.buttonAddAll.Name = "buttonAddAll";
            this.buttonAddAll.Size = new System.Drawing.Size(97, 28);
            this.buttonAddAll.TabIndex = 3;
            this.buttonAddAll.Text = "Add All Values";
            this.buttonAddAll.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(112, 278);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(80, 28);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add Values";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(199, 278);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(80, 28);
            this.buttonRemove.TabIndex = 5;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Location = new System.Drawing.Point(285, 278);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(97, 28);
            this.buttonRemoveAll.TabIndex = 6;
            this.buttonRemoveAll.Text = "Remove All";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            // 
            // colorRampCombobox1
            // 
            this.colorRampCombobox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.colorRampCombobox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorRampCombobox1.FormattingEnabled = true;
            this.colorRampCombobox1.Location = new System.Drawing.Point(6, 19);
            this.colorRampCombobox1.Name = "colorRampCombobox1";
            this.colorRampCombobox1.Size = new System.Drawing.Size(223, 22);
            this.colorRampCombobox1.TabIndex = 0;
            // 
            // UniqueValueRenderPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRemoveAll);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonAddAll);
            this.Controls.Add(this.listViewSymbols);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UniqueValueRenderPage";
            this.Size = new System.Drawing.Size(480, 320);
            this.Load += new System.EventHandler(this.UniqueValueRenderPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxField;
        private System.Windows.Forms.GroupBox groupBox2;
        private ColorRampCombobox colorRampCombobox1;
        private System.Windows.Forms.ListView listViewSymbols;
        private System.Windows.Forms.Button buttonAddAll;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonRemoveAll;
    }
}
