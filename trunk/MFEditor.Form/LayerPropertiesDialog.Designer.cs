namespace MFEditorUI
{
    partial class LayerPropertiesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerPropertiesDialog));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.tabPageClass = new System.Windows.Forms.TabPage();
            this.tabPageLabel = new System.Windows.Forms.TabPage();
            this.tabPageMeta = new System.Windows.Forms.TabPage();
            this.buttonAdvantage = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageBasic);
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Controls.Add(this.tabPageClass);
            this.tabControl1.Controls.Add(this.tabPageLabel);
            this.tabControl1.Controls.Add(this.tabPageMeta);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageBasic
            // 
            resources.ApplyResources(this.tabPageBasic, "tabPageBasic");
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // tabPageData
            // 
            resources.ApplyResources(this.tabPageData, "tabPageData");
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // tabPageClass
            // 
            resources.ApplyResources(this.tabPageClass, "tabPageClass");
            this.tabPageClass.Name = "tabPageClass";
            this.tabPageClass.UseVisualStyleBackColor = true;
            // 
            // tabPageLabel
            // 
            resources.ApplyResources(this.tabPageLabel, "tabPageLabel");
            this.tabPageLabel.Name = "tabPageLabel";
            this.tabPageLabel.UseVisualStyleBackColor = true;
            // 
            // tabPageMeta
            // 
            resources.ApplyResources(this.tabPageMeta, "tabPageMeta");
            this.tabPageMeta.Name = "tabPageMeta";
            this.tabPageMeta.UseVisualStyleBackColor = true;
            // 
            // buttonAdvantage
            // 
            resources.ApplyResources(this.buttonAdvantage, "buttonAdvantage");
            this.buttonAdvantage.Name = "buttonAdvantage";
            this.buttonAdvantage.UseVisualStyleBackColor = true;
            this.buttonAdvantage.Click += new System.EventHandler(this.buttonAdvantage_Click);
            // 
            // LayerPropertiesDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonAdvantage);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayerPropertiesDialog";
            this.Load += new System.EventHandler(this.formLayerSet_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBasic;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.TabPage tabPageLabel;
        private System.Windows.Forms.TabPage tabPageClass;
        private System.Windows.Forms.Button buttonAdvantage;
        private System.Windows.Forms.TabPage tabPageMeta;
    }
}