namespace MFEditor
{
    partial class formErr
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
            this.labelErr = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelErr
            // 
            this.labelErr.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelErr.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelErr.Location = new System.Drawing.Point(12, 9);
            this.labelErr.Name = "labelErr";
            this.labelErr.Size = new System.Drawing.Size(391, 189);
            this.labelErr.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(251, 205);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(113, 26);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "关闭(&C)";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // formErr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 237);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelErr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formErr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "错误报告";
            this.Load += new System.EventHandler(this.formErr_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelErr;
        private System.Windows.Forms.Button buttonClose;
    }
}