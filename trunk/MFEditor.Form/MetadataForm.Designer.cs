namespace MFEditorUI
{
    partial class MetadataForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MetadataForm));
            this.comboBoxName = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxMeta = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxName
            // 
            resources.ApplyResources(this.comboBoxName, "comboBoxName");
            this.comboBoxName.FormattingEnabled = true;
            this.comboBoxName.Items.AddRange(new object[] {
            resources.GetString("comboBoxName.Items")});
            this.comboBoxName.Name = "comboBoxName";
            this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
            this.comboBoxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxName_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxValue);
            this.groupBox1.Controls.Add(this.buttonEdit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxName);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // textBoxValue
            // 
            resources.ApplyResources(this.textBoxValue, "textBoxValue");
            this.textBoxValue.Name = "textBoxValue";
            // 
            // buttonEdit
            // 
            resources.ApplyResources(this.buttonEdit, "buttonEdit");
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // buttonAdd
            // 
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // buttonDel
            // 
            resources.ApplyResources(this.buttonDel, "buttonDel");
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxMeta);
            this.groupBox2.Controls.Add(this.buttonDel);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // listBoxMeta
            // 
            this.listBoxMeta.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxMeta, "listBoxMeta");
            this.listBoxMeta.Name = "listBoxMeta";
            this.listBoxMeta.SelectedIndexChanged += new System.EventHandler(this.listBoxMeta_SelectedIndexChanged);
            // 
            // FormMetadata
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FormMetadata";
            this.Load += new System.EventHandler(this.formMetadata_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxMeta;
    }
}