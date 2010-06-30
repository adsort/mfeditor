namespace MFEditor.Control
{
    partial class MapControl
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
            this.pictureBoxPan = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPan)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPan
            // 
            this.pictureBoxPan.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxPan.Location = new System.Drawing.Point(159, 137);
            this.pictureBoxPan.Name = "pictureBoxPan";
            this.pictureBoxPan.Size = new System.Drawing.Size(114, 99);
            this.pictureBoxPan.TabIndex = 0;
            this.pictureBoxPan.TabStop = false;
            this.pictureBoxPan.Visible = false;
            // 
            // MapControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictureBoxPan);
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(322, 265);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.msView_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.msView_MouseDown);
            this.Resize += new System.EventHandler(this.msView_Resize);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.msView_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPan;
    }
}
