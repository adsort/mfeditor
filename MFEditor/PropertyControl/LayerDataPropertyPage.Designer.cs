
namespace MFEditor.PropertyControl
{
    partial class LayerDataPropertyPage
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelExtentRight = new System.Windows.Forms.Label();
            this.labelExtentBottom = new System.Windows.Forms.Label();
            this.labelExtentLeft = new System.Windows.Forms.Label();
            this.labelExtentTop = new System.Windows.Forms.Label();
            this.comboBoxConnType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxDataType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textConnection = new System.Windows.Forms.TextBox();
            this.buttonShpPath = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelExtentRight);
            this.groupBox2.Controls.Add(this.labelExtentBottom);
            this.groupBox2.Controls.Add(this.labelExtentLeft);
            this.groupBox2.Controls.Add(this.labelExtentTop);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 94);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Extent";
            // 
            // labelExtentRight
            // 
            this.labelExtentRight.AutoSize = true;
            this.labelExtentRight.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelExtentRight.Location = new System.Drawing.Point(256, 46);
            this.labelExtentRight.Name = "labelExtentRight";
            this.labelExtentRight.Size = new System.Drawing.Size(41, 12);
            this.labelExtentRight.TabIndex = 3;
            this.labelExtentRight.Text = "Right:";
            // 
            // labelExtentBottom
            // 
            this.labelExtentBottom.AutoSize = true;
            this.labelExtentBottom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelExtentBottom.Location = new System.Drawing.Point(138, 68);
            this.labelExtentBottom.Name = "labelExtentBottom";
            this.labelExtentBottom.Size = new System.Drawing.Size(47, 12);
            this.labelExtentBottom.TabIndex = 2;
            this.labelExtentBottom.Text = "Bottom:";
            // 
            // labelExtentLeft
            // 
            this.labelExtentLeft.AutoSize = true;
            this.labelExtentLeft.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelExtentLeft.Location = new System.Drawing.Point(9, 46);
            this.labelExtentLeft.Name = "labelExtentLeft";
            this.labelExtentLeft.Size = new System.Drawing.Size(35, 12);
            this.labelExtentLeft.TabIndex = 1;
            this.labelExtentLeft.Text = "Left:";
            // 
            // labelExtentTop
            // 
            this.labelExtentTop.AutoSize = true;
            this.labelExtentTop.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelExtentTop.Location = new System.Drawing.Point(138, 17);
            this.labelExtentTop.Name = "labelExtentTop";
            this.labelExtentTop.Size = new System.Drawing.Size(29, 12);
            this.labelExtentTop.TabIndex = 0;
            this.labelExtentTop.Text = "Top:";
            // 
            // comboBoxConnType
            // 
            this.comboBoxConnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConnType.Font = new System.Drawing.Font("宋体", 9F);
            this.comboBoxConnType.FormattingEnabled = true;
            this.comboBoxConnType.Items.AddRange(new object[] {
            "INLINE",
            "SHAPEFILE",
            "TILED_SHAPEFILE",
            "SDE",
            "OGR",
            "UNUSED_1",
            "POSTGIS",
            "WMS",
            "ORACLESPATIAL",
            "WFS",
            "GRATICULE",
            "MYGIS",
            "RASTER",
            "PLUGIN"});
            this.comboBoxConnType.Location = new System.Drawing.Point(24, 198);
            this.comboBoxConnType.Name = "comboBoxConnType";
            this.comboBoxConnType.Size = new System.Drawing.Size(183, 20);
            this.comboBoxConnType.TabIndex = 37;
            this.comboBoxConnType.SelectedIndexChanged += new System.EventHandler(this.comboBoxConnType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(21, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "DataPath:";
            // 
            // textData
            // 
            this.textData.Font = new System.Drawing.Font("宋体", 9F);
            this.textData.Location = new System.Drawing.Point(23, 150);
            this.textData.Name = "textData";
            this.textData.ReadOnly = true;
            this.textData.Size = new System.Drawing.Size(335, 21);
            this.textData.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(227, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "DataType:";
            // 
            // comboBoxDataType
            // 
            this.comboBoxDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataType.Font = new System.Drawing.Font("宋体", 9F);
            this.comboBoxDataType.FormattingEnabled = true;
            this.comboBoxDataType.Items.AddRange(new object[] {
            "POINT",
            "LINE",
            "POLYGON",
            "RASTER",
            "ANNOTATION",
            "QUERY",
            "CIRCLE",
            "TILEINDEX",
            "CHART"});
            this.comboBoxDataType.Location = new System.Drawing.Point(230, 198);
            this.comboBoxDataType.Name = "comboBoxDataType";
            this.comboBoxDataType.Size = new System.Drawing.Size(183, 20);
            this.comboBoxDataType.TabIndex = 35;
            this.comboBoxDataType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDataType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(21, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "ConnectionType:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(21, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "Connection:";
            // 
            // textConnection
            // 
            this.textConnection.Font = new System.Drawing.Font("宋体", 9F);
            this.textConnection.Location = new System.Drawing.Point(24, 248);
            this.textConnection.Name = "textConnection";
            this.textConnection.Size = new System.Drawing.Size(334, 21);
            this.textConnection.TabIndex = 39;
            this.textConnection.TextChanged += new System.EventHandler(this.textConnection_TextChanged);
            // 
            // buttonShpPath
            // 
            this.buttonShpPath.Image = global::MFEditor.Properties.Resources.Open;
            this.buttonShpPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonShpPath.Location = new System.Drawing.Point(364, 148);
            this.buttonShpPath.Name = "buttonShpPath";
            this.buttonShpPath.Size = new System.Drawing.Size(32, 24);
            this.buttonShpPath.TabIndex = 33;
            this.buttonShpPath.UseVisualStyleBackColor = true;
            this.buttonShpPath.Click += new System.EventHandler(this.buttonShpPath_Click);
            // 
            // LayerDataPropertyPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboBoxConnType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxDataType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textConnection);
            this.Controls.Add(this.buttonShpPath);
            this.Name = "LayerDataPropertyPage";
            this.Size = new System.Drawing.Size(480, 320);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelExtentRight;
        private System.Windows.Forms.Label labelExtentBottom;
        private System.Windows.Forms.Label labelExtentLeft;
        private System.Windows.Forms.Label labelExtentTop;
        private System.Windows.Forms.ComboBox comboBoxConnType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxDataType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textConnection;
        private System.Windows.Forms.Button buttonShpPath;
    }
}
