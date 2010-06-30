namespace MFEditor
{
    partial class FillSymbolOptionsControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownOutWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.colorButtonOutline = new MFEditor.ColorButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // colorButton1
            // 
            this.colorButton1.Location = new System.Drawing.Point(93, 11);
            this.colorButton1.Size = new System.Drawing.Size(47, 23);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.Text = "Fill Color:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "OutlineWidth:";
            // 
            // numericUpDownOutWidth
            // 
            this.numericUpDownOutWidth.Location = new System.Drawing.Point(93, 49);
            this.numericUpDownOutWidth.Name = "numericUpDownOutWidth";
            this.numericUpDownOutWidth.Size = new System.Drawing.Size(48, 21);
            this.numericUpDownOutWidth.TabIndex = 3;
            this.numericUpDownOutWidth.ValueChanged += new System.EventHandler(this.numericUpDownOutWidth_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "OutlineColor:";
            // 
            // colorButtonOutline
            // 
            this.colorButtonOutline.ButtonColor = System.Drawing.Color.Transparent;
            this.colorButtonOutline.Location = new System.Drawing.Point(93, 85);
            this.colorButtonOutline.LocationAtBelow = true;
            this.colorButtonOutline.Name = "colorButtonOutline";
            this.colorButtonOutline.Size = new System.Drawing.Size(49, 23);
            this.colorButtonOutline.TabIndex = 5;
            this.colorButtonOutline.UseVisualStyleBackColor = true;
            this.colorButtonOutline.Click += new System.EventHandler(this.colorButtonOutline_Click);
            // 
            // FillSymbolOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorButtonOutline);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownOutWidth);
            this.Name = "FillSymbolOptionsControl";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.numericUpDownOutWidth, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.colorButton1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.colorButtonOutline, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOutWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownOutWidth;
        private System.Windows.Forms.Label label3;
        private ColorButton colorButtonOutline;
    }
}
