namespace MFEditor
{
    partial class PointSymbolOptionsControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAngel = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngel)).BeginInit();
            this.SuspendLayout();
            // 
            // colorButton1
            // 
            this.colorButton1.Location = new System.Drawing.Point(78, 9);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 14);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Angel:";
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.DecimalPlaces = 1;
            this.numericUpDownSize.Location = new System.Drawing.Point(78, 46);
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(53, 21);
            this.numericUpDownSize.TabIndex = 4;
            this.numericUpDownSize.ValueChanged += new System.EventHandler(this.numericUpDownSize_ValueChanged);
            // 
            // numericUpDownAngel
            // 
            this.numericUpDownAngel.DecimalPlaces = 1;
            this.numericUpDownAngel.Location = new System.Drawing.Point(78, 81);
            this.numericUpDownAngel.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownAngel.Name = "numericUpDownAngel";
            this.numericUpDownAngel.Size = new System.Drawing.Size(53, 21);
            this.numericUpDownAngel.TabIndex = 5;
            this.numericUpDownAngel.ValueChanged += new System.EventHandler(this.numericUpDownAngel_ValueChanged);
            // 
            // PointSymbolOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownSize);
            this.Controls.Add(this.numericUpDownAngel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "PointSymbolOptionsControl";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.numericUpDownAngel, 0);
            this.Controls.SetChildIndex(this.numericUpDownSize, 0);
            this.Controls.SetChildIndex(this.colorButton1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.NumericUpDown numericUpDownAngel;
    }
}
