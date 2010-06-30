namespace MFEditor.Control
{
    partial class LegendControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegendControl));
            this.treeViewLegend = new System.Windows.Forms.TreeView();
            this.imageListLeg = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeViewLegend
            // 
            this.treeViewLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewLegend.Font = new System.Drawing.Font("宋体", 11F);
            this.treeViewLegend.HideSelection = false;
            this.treeViewLegend.ImageIndex = 0;
            this.treeViewLegend.ImageList = this.imageListLeg;
            this.treeViewLegend.Location = new System.Drawing.Point(0, 0);
            this.treeViewLegend.Name = "treeViewLegend";
            this.treeViewLegend.SelectedImageIndex = 0;
            this.treeViewLegend.Size = new System.Drawing.Size(184, 257);
            this.treeViewLegend.TabIndex = 0;
            this.treeViewLegend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeViewLegend_MouseDown);
            // 
            // imageListLeg
            // 
            this.imageListLeg.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLeg.ImageStream")));
            this.imageListLeg.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLeg.Images.SetKeyName(0, "tree_map.gif");
            this.imageListLeg.Images.SetKeyName(1, "tree_layer.gif");
            this.imageListLeg.Images.SetKeyName(2, "tree_class.gif");
            this.imageListLeg.Images.SetKeyName(3, "tree_label.gif");
            this.imageListLeg.Images.SetKeyName(4, "tree_style.gif");
            this.imageListLeg.Images.SetKeyName(5, "tree_web.gif");
            this.imageListLeg.Images.SetKeyName(6, "tree_layers.gif");
            this.imageListLeg.Images.SetKeyName(7, "checked.png");
            this.imageListLeg.Images.SetKeyName(8, "unchecked.png");
            this.imageListLeg.Images.SetKeyName(9, "scalelock1.png");
            // 
            // LegendControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.treeViewLegend);
            this.Name = "LegendControl";
            this.Size = new System.Drawing.Size(184, 257);
            this.Resize += new System.EventHandler(this.LegendControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewLegend;
        private System.Windows.Forms.ImageList imageListLeg;
    }
}
