namespace MFEditor
{
    partial class formLayerSet
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
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textGroup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonShpPath = new System.Windows.Forms.Button();
            this.textData = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxDataType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxConnType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textConnection = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboUnits = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textMaxScale = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textMinScale = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textLabelItem = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textClassItem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.tabPageLabel = new System.Windows.Forms.TabPage();
            this.tabPageClass = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.tabPageLabel.SuspendLayout();
            this.tabPageClass.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboStatus
            // 
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "ON",
            "OFF"});
            this.comboStatus.Location = new System.Drawing.Point(130, 81);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(81, 22);
            this.comboStatus.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(42, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Status:";
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textName.Location = new System.Drawing.Point(130, 21);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(183, 23);
            this.textName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(60, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // textGroup
            // 
            this.textGroup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textGroup.Location = new System.Drawing.Point(130, 52);
            this.textGroup.Name = "textGroup";
            this.textGroup.Size = new System.Drawing.Size(183, 23);
            this.textGroup.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(51, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Group:";
            // 
            // buttonShpPath
            // 
            this.buttonShpPath.Image = global::MFEditor.Properties.Resources.Open;
            this.buttonShpPath.Location = new System.Drawing.Point(383, 37);
            this.buttonShpPath.Name = "buttonShpPath";
            this.buttonShpPath.Size = new System.Drawing.Size(32, 28);
            this.buttonShpPath.TabIndex = 23;
            this.buttonShpPath.UseVisualStyleBackColor = true;
            this.buttonShpPath.Click += new System.EventHandler(this.buttonShpPath_Click);
            // 
            // textData
            // 
            this.textData.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textData.Location = new System.Drawing.Point(42, 40);
            this.textData.Name = "textData";
            this.textData.Size = new System.Drawing.Size(335, 23);
            this.textData.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(39, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "DataPath:";
            // 
            // comboBoxDataType
            // 
            this.comboBoxDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxDataType.FormattingEnabled = true;
            this.comboBoxDataType.Items.AddRange(new object[] {
            "POINT",
            "LINE",
            "POLYGON",
            "RASTER",
            "QUERY"});
            this.comboBoxDataType.Location = new System.Drawing.Point(42, 95);
            this.comboBoxDataType.Name = "comboBoxDataType";
            this.comboBoxDataType.Size = new System.Drawing.Size(183, 22);
            this.comboBoxDataType.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(39, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "DataType:";
            // 
            // comboBoxConnType
            // 
            this.comboBoxConnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConnType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.comboBoxConnType.Location = new System.Drawing.Point(42, 152);
            this.comboBoxConnType.Name = "comboBoxConnType";
            this.comboBoxConnType.Size = new System.Drawing.Size(183, 22);
            this.comboBoxConnType.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(39, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "ConnectionType:";
            // 
            // textConnection
            // 
            this.textConnection.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textConnection.Location = new System.Drawing.Point(42, 206);
            this.textConnection.Name = "textConnection";
            this.textConnection.Size = new System.Drawing.Size(233, 23);
            this.textConnection.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(39, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Connection:";
            // 
            // comboUnits
            // 
            this.comboUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUnits.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboUnits.FormattingEnabled = true;
            this.comboUnits.Items.AddRange(new object[] {
            "FEET",
            "INCHES",
            "KILOMETERS",
            "METERS",
            "MILES",
            "DD"});
            this.comboUnits.Location = new System.Drawing.Point(130, 185);
            this.comboUnits.Name = "comboUnits";
            this.comboUnits.Size = new System.Drawing.Size(81, 22);
            this.comboUnits.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(59, 186);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 16);
            this.label16.TabIndex = 33;
            this.label16.Text = "Units:";
            // 
            // textMaxScale
            // 
            this.textMaxScale.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textMaxScale.Location = new System.Drawing.Point(130, 151);
            this.textMaxScale.Name = "textMaxScale";
            this.textMaxScale.Size = new System.Drawing.Size(183, 23);
            this.textMaxScale.TabIndex = 38;
            this.textMaxScale.Text = "-1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(24, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "MaxScale:";
            // 
            // textMinScale
            // 
            this.textMinScale.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textMinScale.Location = new System.Drawing.Point(130, 120);
            this.textMinScale.Name = "textMinScale";
            this.textMinScale.Size = new System.Drawing.Size(183, 23);
            this.textMinScale.TabIndex = 36;
            this.textMinScale.Text = "-1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(24, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "MinScale:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(364, 307);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 30);
            this.buttonCancel.TabIndex = 41;
            this.buttonCancel.Text = "取消(&C)";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(244, 307);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 30);
            this.buttonOK.TabIndex = 40;
            this.buttonOK.Text = "确定(&O)";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textLabelItem
            // 
            this.textLabelItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textLabelItem.Location = new System.Drawing.Point(41, 43);
            this.textLabelItem.Name = "textLabelItem";
            this.textLabelItem.Size = new System.Drawing.Size(160, 23);
            this.textLabelItem.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(38, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 16);
            this.label9.TabIndex = 44;
            this.label9.Text = "LabelItem:";
            // 
            // textClassItem
            // 
            this.textClassItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textClassItem.Location = new System.Drawing.Point(41, 43);
            this.textClassItem.Name = "textClassItem";
            this.textClassItem.Size = new System.Drawing.Size(160, 23);
            this.textClassItem.TabIndex = 43;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(38, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 16);
            this.label10.TabIndex = 42;
            this.label10.Text = "ClassItem:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageBasic);
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Controls.Add(this.tabPageLabel);
            this.tabControl1.Controls.Add(this.tabPageClass);
            this.tabControl1.Location = new System.Drawing.Point(7, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(489, 289);
            this.tabControl1.TabIndex = 46;
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.Controls.Add(this.textGroup);
            this.tabPageBasic.Controls.Add(this.label1);
            this.tabPageBasic.Controls.Add(this.textName);
            this.tabPageBasic.Controls.Add(this.label2);
            this.tabPageBasic.Controls.Add(this.comboStatus);
            this.tabPageBasic.Controls.Add(this.label3);
            this.tabPageBasic.Controls.Add(this.textMaxScale);
            this.tabPageBasic.Controls.Add(this.label16);
            this.tabPageBasic.Controls.Add(this.comboUnits);
            this.tabPageBasic.Controls.Add(this.label7);
            this.tabPageBasic.Controls.Add(this.label8);
            this.tabPageBasic.Controls.Add(this.textMinScale);
            this.tabPageBasic.Location = new System.Drawing.Point(4, 21);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBasic.Size = new System.Drawing.Size(481, 264);
            this.tabPageBasic.TabIndex = 0;
            this.tabPageBasic.Text = "Basic";
            this.tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.comboBoxConnType);
            this.tabPageData.Controls.Add(this.label11);
            this.tabPageData.Controls.Add(this.textData);
            this.tabPageData.Controls.Add(this.buttonShpPath);
            this.tabPageData.Controls.Add(this.label4);
            this.tabPageData.Controls.Add(this.comboBoxDataType);
            this.tabPageData.Controls.Add(this.label5);
            this.tabPageData.Controls.Add(this.label6);
            this.tabPageData.Controls.Add(this.textConnection);
            this.tabPageData.Location = new System.Drawing.Point(4, 21);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(481, 264);
            this.tabPageData.TabIndex = 1;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // tabPageLabel
            // 
            this.tabPageLabel.Controls.Add(this.textLabelItem);
            this.tabPageLabel.Controls.Add(this.label9);
            this.tabPageLabel.Location = new System.Drawing.Point(4, 21);
            this.tabPageLabel.Name = "tabPageLabel";
            this.tabPageLabel.Size = new System.Drawing.Size(481, 264);
            this.tabPageLabel.TabIndex = 2;
            this.tabPageLabel.Text = "Label";
            this.tabPageLabel.UseVisualStyleBackColor = true;
            // 
            // tabPageClass
            // 
            this.tabPageClass.Controls.Add(this.textClassItem);
            this.tabPageClass.Controls.Add(this.label10);
            this.tabPageClass.Location = new System.Drawing.Point(4, 21);
            this.tabPageClass.Name = "tabPageClass";
            this.tabPageClass.Size = new System.Drawing.Size(481, 264);
            this.tabPageClass.TabIndex = 3;
            this.tabPageClass.Text = "Class";
            this.tabPageClass.UseVisualStyleBackColor = true;
            // 
            // formLayerSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 345);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formLayerSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图层设置";
            this.Load += new System.EventHandler(this.formLayerSet_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageBasic.ResumeLayout(false);
            this.tabPageBasic.PerformLayout();
            this.tabPageData.ResumeLayout(false);
            this.tabPageData.PerformLayout();
            this.tabPageLabel.ResumeLayout(false);
            this.tabPageLabel.PerformLayout();
            this.tabPageClass.ResumeLayout(false);
            this.tabPageClass.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonShpPath;
        private System.Windows.Forms.TextBox textData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBoxDataType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxConnType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textConnection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboUnits;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textMaxScale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textMinScale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textLabelItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textClassItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageBasic;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.TabPage tabPageLabel;
        private System.Windows.Forms.TabPage tabPageClass;
    }
}