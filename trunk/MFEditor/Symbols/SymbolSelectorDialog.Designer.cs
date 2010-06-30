namespace MFEditor
{
    partial class SymbolSelectorDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SymbolSelectorDialog));
            this.listViewSymbol = new System.Windows.Forms.ListView();
            this.imageListPreview = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.groupBoxOption = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewSymbol
            // 
            this.listViewSymbol.LargeImageList = this.imageListPreview;
            resources.ApplyResources(this.listViewSymbol, "listViewSymbol");
            this.listViewSymbol.MultiSelect = false;
            this.listViewSymbol.Name = "listViewSymbol";
            this.listViewSymbol.UseCompatibleStateImageBehavior = false;
            this.listViewSymbol.SelectedIndexChanged += new System.EventHandler(this.listViewSymbol_SelectedIndexChanged);
            // 
            // imageListPreview
            // 
            this.imageListPreview.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageListPreview, "imageListPreview");
            this.imageListPreview.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Controls.Add(this.pictureBoxPreview);
            resources.ApplyResources(this.groupBoxPreview, "groupBoxPreview");
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.TabStop = false;
            // 
            // pictureBoxPreview
            // 
            resources.ApplyResources(this.pictureBoxPreview, "pictureBoxPreview");
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.TabStop = false;
            // 
            // groupBoxOption
            // 
            resources.ApplyResources(this.groupBoxOption, "groupBoxOption");
            this.groupBoxOption.Name = "groupBoxOption";
            this.groupBoxOption.TabStop = false;
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SymbolSelectorDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxOption);
            this.Controls.Add(this.groupBoxPreview);
            this.Controls.Add(this.listViewSymbol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SymbolSelectorDialog";
            this.Load += new System.EventHandler(this.formSymbolSelector_Load);
            this.groupBoxPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewSymbol;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.GroupBox groupBoxOption;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.ImageList imageListPreview;
    }
}