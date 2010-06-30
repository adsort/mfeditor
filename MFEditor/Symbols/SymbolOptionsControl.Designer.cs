namespace MFEditor
{
    partial class SymbolOptionsControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.colorButton1 = new MFEditor.ColorButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Color:";
            // 
            // colorButton1
            // 
            this.colorButton1.ButtonColor = System.Drawing.Color.Transparent;
            this.colorButton1.Location = new System.Drawing.Point(78, 12);
            this.colorButton1.LocationAtBelow = true;
            this.colorButton1.Name = "colorButton1";
            this.colorButton1.Size = new System.Drawing.Size(53, 23);
            this.colorButton1.TabIndex = 0;
            this.colorButton1.UseVisualStyleBackColor = true;
            this.colorButton1.Click += new System.EventHandler(this.colorButton1_Click);
            // 
            // SymbolOptionsControl
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorButton1);
            this.Name = "SymbolOptionsControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected ColorButton colorButton1;
        protected System.Windows.Forms.Label label1;
    }
}
