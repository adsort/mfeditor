namespace MFEditor.PropertyControl
{
    partial class LayerBasicPropertyPage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSetScale = new System.Windows.Forms.RadioButton();
            this.radioButtonClearScale = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.textMinScale = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textMaxScale = new System.Windows.Forms.TextBox();
            this.textGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.comboUnits = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSetScale);
            this.groupBox1.Controls.Add(this.radioButtonClearScale);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textMinScale);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textMaxScale);
            this.groupBox1.Location = new System.Drawing.Point(22, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 157);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scale Range";
            // 
            // radioButtonSetScale
            // 
            this.radioButtonSetScale.AutoSize = true;
            this.radioButtonSetScale.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButtonSetScale.Location = new System.Drawing.Point(24, 51);
            this.radioButtonSetScale.Name = "radioButtonSetScale";
            this.radioButtonSetScale.Size = new System.Drawing.Size(155, 16);
            this.radioButtonSetScale.TabIndex = 40;
            this.radioButtonSetScale.TabStop = true;
            this.radioButtonSetScale.Text = "Don\'t show layer when:";
            this.radioButtonSetScale.UseVisualStyleBackColor = true;
            this.radioButtonSetScale.CheckedChanged += new System.EventHandler(this.radioButtonSetScale_CheckedChanged);
            // 
            // radioButtonClearScale
            // 
            this.radioButtonClearScale.AutoSize = true;
            this.radioButtonClearScale.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButtonClearScale.Location = new System.Drawing.Point(24, 22);
            this.radioButtonClearScale.Name = "radioButtonClearScale";
            this.radioButtonClearScale.Size = new System.Drawing.Size(167, 16);
            this.radioButtonClearScale.TabIndex = 39;
            this.radioButtonClearScale.TabStop = true;
            this.radioButtonClearScale.Text = "show layer at all scales";
            this.radioButtonClearScale.UseVisualStyleBackColor = true;
            this.radioButtonClearScale.CheckedChanged += new System.EventHandler(this.radioButtonClearScale_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(21, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "MinScale:";
            // 
            // textMinScale
            // 
            this.textMinScale.Font = new System.Drawing.Font("宋体", 9F);
            this.textMinScale.Location = new System.Drawing.Point(95, 82);
            this.textMinScale.Name = "textMinScale";
            this.textMinScale.Size = new System.Drawing.Size(183, 21);
            this.textMinScale.TabIndex = 36;
            this.textMinScale.Text = "-1";
            this.textMinScale.TextChanged += new System.EventHandler(this.textMinScale_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(21, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 12);
            this.label7.TabIndex = 37;
            this.label7.Text = "MaxScale:";
            // 
            // textMaxScale
            // 
            this.textMaxScale.Font = new System.Drawing.Font("宋体", 9F);
            this.textMaxScale.Location = new System.Drawing.Point(95, 113);
            this.textMaxScale.Name = "textMaxScale";
            this.textMaxScale.Size = new System.Drawing.Size(183, 21);
            this.textMaxScale.TabIndex = 38;
            this.textMaxScale.Text = "-1";
            this.textMaxScale.TextChanged += new System.EventHandler(this.textMaxScale_TextChanged);
            // 
            // textGroup
            // 
            this.textGroup.Font = new System.Drawing.Font("宋体", 9F);
            this.textGroup.Location = new System.Drawing.Point(74, 46);
            this.textGroup.Name = "textGroup";
            this.textGroup.Size = new System.Drawing.Size(183, 21);
            this.textGroup.TabIndex = 43;
            this.textGroup.TextChanged += new System.EventHandler(this.textGroup_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(28, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 40;
            this.label1.Text = "Name:";
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("宋体", 9F);
            this.textName.Location = new System.Drawing.Point(74, 16);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(183, 21);
            this.textName.TabIndex = 41;
            this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(19, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 42;
            this.label3.Text = "Group:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(19, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 44;
            this.label16.Text = "Units:";
            // 
            // comboUnits
            // 
            this.comboUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUnits.Font = new System.Drawing.Font("宋体", 9F);
            this.comboUnits.FormattingEnabled = true;
            this.comboUnits.Items.AddRange(new object[] {
            "FEET",
            "INCHES",
            "KILOMETERS",
            "METERS",
            "MILES",
            "DD"});
            this.comboUnits.Location = new System.Drawing.Point(74, 75);
            this.comboUnits.Name = "comboUnits";
            this.comboUnits.Size = new System.Drawing.Size(81, 20);
            this.comboUnits.TabIndex = 45;
            this.comboUnits.SelectedIndexChanged += new System.EventHandler(this.comboUnits_SelectedIndexChanged);
            // 
            // LayerBasicPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.comboUnits);
            this.Name = "LayerBasicPage";
            this.Size = new System.Drawing.Size(480, 320);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSetScale;
        private System.Windows.Forms.RadioButton radioButtonClearScale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textMinScale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textMaxScale;
        private System.Windows.Forms.TextBox textGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboUnits;
    }
}
