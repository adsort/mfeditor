namespace MFEditor
{
    partial class MFTextEditor
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
            this.richTextBoxMapfile = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxMapfile
            // 
            this.richTextBoxMapfile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxMapfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMapfile.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxMapfile.Name = "richTextBoxMapfile";
            this.richTextBoxMapfile.Size = new System.Drawing.Size(566, 419);
            this.richTextBoxMapfile.TabIndex = 1;
            this.richTextBoxMapfile.Text = "";
            this.richTextBoxMapfile.TextChanged += new System.EventHandler(this.richTextBoxMapfile_TextChanged);
            // 
            // MFTextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxMapfile);
            this.Name = "MFTextEditor";
            this.Size = new System.Drawing.Size(566, 419);
            this.Load += new System.EventHandler(this.MFTextEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxMapfile;


    }
}
