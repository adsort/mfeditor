// Copyright 2008, 2010 - http://code.google.com/p/mfeditor/
//
// Author:   WanliYun 
// Email:    wanliyun2009@gmail.com
// QQ Group: 81979380
// Blog:     http://blog.csdn.net/wanliyun2009
//
//
// This file is part of MFEditor.
// MFEditor is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// MFEditor is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with MFEditor; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 


using System;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml;
using System.IO;
using OSGeo.MapServer;

namespace MFEditorUI
{
	/// <summary>
	///  
	/// Form1 的摘要说明。
	/// </summary>
	public class formPrecacheKamap : System.Windows.Forms.Form
    {
	
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Label label11;
        private Button buttonOK;
        private Button buttonCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private ProgressBar progressBarInfo;
        private TabControl tabControlSetUp;
        private TabPage tabPageBasic;
        private CheckBox checkBoxTransparent;
        private ComboBox comboBoxOutType;
        private Label label6;
        private Button buttonOutPath;
        private Label label7;
        private TextBox textBoxOutPath;
        private TabPage tabPageScale;
        private TextBox textBoxScale;
        private ListBox listBoxScales;
        private Label label1;
        private Button buttonAddScale;
        private Button buttonClearScale;
        private TabPage tabPageExtents;
        private RadioButton radioButtonUser;
        private RadioButton radioButtonMap;
        private TextBox textBoxMaxY;
        private TextBox textBoxMinX;
        private TextBox textBoxMinY;
        private TextBox textBoxMaxX;
        private Panel panel1;
        private Label label2;
        private Label label5;
        private Label label3;
        private Label label4;
        private TabPage tabPageGroup;
        private Label label9;
        private Label label8;
        private Button buttonRemoveAll;
        private Button buttonRemove;
        private Button buttonAdd;
        private Button buttonAddAll;
        private ListBox listBoxUseGroup;
        private ListBox listBoxAllGroup;
        private StatusStrip statusStripPF;
        private ToolStripStatusLabel labelInfo;
        private Button buttonClear;
        private GroupBox gbExportData;
        private RadioButton radioButtonDefault;
       // private CPolygon pPolygon = null;

        private mapObj m_pMapObj = null;
        private MFEditor.Control.MapControl m_pMapcontrol = null;

        public formPrecacheKamap(MFEditor.Control.MapControl inMapcontrol)
		{
			
			InitializeComponent();

            m_pMapcontrol = inMapcontrol;
            m_pMapObj = inMapcontrol.Map;
			
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			//pPolygon = null;
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressBarInfo = new System.Windows.Forms.ProgressBar();
            this.tabControlSetUp = new System.Windows.Forms.TabControl();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.gbExportData = new System.Windows.Forms.GroupBox();
            this.comboBoxOutType = new System.Windows.Forms.ComboBox();
            this.textBoxOutPath = new System.Windows.Forms.TextBox();
            this.checkBoxTransparent = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonOutPath = new System.Windows.Forms.Button();
            this.tabPageScale = new System.Windows.Forms.TabPage();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxScale = new System.Windows.Forms.TextBox();
            this.listBoxScales = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddScale = new System.Windows.Forms.Button();
            this.buttonClearScale = new System.Windows.Forms.Button();
            this.tabPageExtents = new System.Windows.Forms.TabPage();
            this.radioButtonDefault = new System.Windows.Forms.RadioButton();
            this.radioButtonUser = new System.Windows.Forms.RadioButton();
            this.radioButtonMap = new System.Windows.Forms.RadioButton();
            this.textBoxMaxY = new System.Windows.Forms.TextBox();
            this.textBoxMinX = new System.Windows.Forms.TextBox();
            this.textBoxMinY = new System.Windows.Forms.TextBox();
            this.textBoxMaxX = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageGroup = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonAddAll = new System.Windows.Forms.Button();
            this.listBoxUseGroup = new System.Windows.Forms.ListBox();
            this.listBoxAllGroup = new System.Windows.Forms.ListBox();
            this.statusStripPF = new System.Windows.Forms.StatusStrip();
            this.labelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlSetUp.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            this.gbExportData.SuspendLayout();
            this.tabPageScale.SuspendLayout();
            this.tabPageExtents.SuspendLayout();
            this.tabPageGroup.SuspendLayout();
            this.statusStripPF.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(638, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 12);
            this.label11.TabIndex = 27;
            // 
            // buttonOK
            // 
            this.buttonOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOK.Location = new System.Drawing.Point(271, 373);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(60, 24);
            this.buttonOK.TabIndex = 32;
            this.buttonOK.Text = "确定(&O)";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCancel.Location = new System.Drawing.Point(337, 373);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(60, 24);
            this.buttonCancel.TabIndex = 24;
            this.buttonCancel.Text = "取消(&C)";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // progressBarInfo
            // 
            this.progressBarInfo.Location = new System.Drawing.Point(17, 376);
            this.progressBarInfo.Name = "progressBarInfo";
            this.progressBarInfo.Size = new System.Drawing.Size(234, 18);
            this.progressBarInfo.TabIndex = 40;
            // 
            // tabControlSetUp
            // 
            this.tabControlSetUp.Controls.Add(this.tabPageBasic);
            this.tabControlSetUp.Controls.Add(this.tabPageScale);
            this.tabControlSetUp.Controls.Add(this.tabPageExtents);
            this.tabControlSetUp.Controls.Add(this.tabPageGroup);
            this.tabControlSetUp.Location = new System.Drawing.Point(14, 12);
            this.tabControlSetUp.Name = "tabControlSetUp";
            this.tabControlSetUp.SelectedIndex = 0;
            this.tabControlSetUp.Size = new System.Drawing.Size(382, 346);
            this.tabControlSetUp.TabIndex = 41;
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.Controls.Add(this.gbExportData);
            this.tabPageBasic.Location = new System.Drawing.Point(4, 21);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Size = new System.Drawing.Size(374, 321);
            this.tabPageBasic.TabIndex = 3;
            this.tabPageBasic.Text = "基本设置";
            this.tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // gbExportData
            // 
            this.gbExportData.Controls.Add(this.comboBoxOutType);
            this.gbExportData.Controls.Add(this.textBoxOutPath);
            this.gbExportData.Controls.Add(this.checkBoxTransparent);
            this.gbExportData.Controls.Add(this.label7);
            this.gbExportData.Controls.Add(this.label6);
            this.gbExportData.Controls.Add(this.buttonOutPath);
            this.gbExportData.Location = new System.Drawing.Point(13, 16);
            this.gbExportData.Name = "gbExportData";
            this.gbExportData.Size = new System.Drawing.Size(347, 109);
            this.gbExportData.TabIndex = 65;
            this.gbExportData.TabStop = false;
            // 
            // comboBoxOutType
            // 
            this.comboBoxOutType.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.comboBoxOutType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOutType.FormattingEnabled = true;
            this.comboBoxOutType.Items.AddRange(new object[] {
            "PNG",
            "JPEG"});
            this.comboBoxOutType.Location = new System.Drawing.Point(94, 72);
            this.comboBoxOutType.Name = "comboBoxOutType";
            this.comboBoxOutType.Size = new System.Drawing.Size(121, 20);
            this.comboBoxOutType.TabIndex = 57;
            // 
            // textBoxOutPath
            // 
            this.textBoxOutPath.Location = new System.Drawing.Point(6, 37);
            this.textBoxOutPath.Name = "textBoxOutPath";
            this.textBoxOutPath.Size = new System.Drawing.Size(282, 21);
            this.textBoxOutPath.TabIndex = 54;
            this.textBoxOutPath.Text = "D:\\testpre";
            // 
            // checkBoxTransparent
            // 
            this.checkBoxTransparent.AutoSize = true;
            this.checkBoxTransparent.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.checkBoxTransparent.Location = new System.Drawing.Point(273, 74);
            this.checkBoxTransparent.Name = "checkBoxTransparent";
            this.checkBoxTransparent.Size = new System.Drawing.Size(72, 16);
            this.checkBoxTransparent.TabIndex = 58;
            this.checkBoxTransparent.Text = "背景透明";
            this.checkBoxTransparent.UseVisualStyleBackColor = true;
            this.checkBoxTransparent.CheckedChanged += new System.EventHandler(this.checkBoxTransparent_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.No;
            this.label7.Location = new System.Drawing.Point(4, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 53;
            this.label7.Text = "输出数据路径：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.No;
            this.label6.Location = new System.Drawing.Point(4, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 56;
            this.label6.Text = "输出格式：";
            // 
            // buttonOutPath
            // 
            this.buttonOutPath.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonOutPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOutPath.Location = new System.Drawing.Point(299, 34);
            this.buttonOutPath.Name = "buttonOutPath";
            this.buttonOutPath.Size = new System.Drawing.Size(42, 24);
            this.buttonOutPath.TabIndex = 55;
            this.buttonOutPath.Text = "浏览";
            this.buttonOutPath.Click += new System.EventHandler(this.buttonOutPath_Click);
            // 
            // tabPageScale
            // 
            this.tabPageScale.Controls.Add(this.buttonClear);
            this.tabPageScale.Controls.Add(this.textBoxScale);
            this.tabPageScale.Controls.Add(this.listBoxScales);
            this.tabPageScale.Controls.Add(this.label1);
            this.tabPageScale.Controls.Add(this.buttonAddScale);
            this.tabPageScale.Controls.Add(this.buttonClearScale);
            this.tabPageScale.Location = new System.Drawing.Point(4, 21);
            this.tabPageScale.Name = "tabPageScale";
            this.tabPageScale.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageScale.Size = new System.Drawing.Size(374, 321);
            this.tabPageScale.TabIndex = 0;
            this.tabPageScale.Text = "输出比例尺";
            this.tabPageScale.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonClear.Location = new System.Drawing.Point(234, 215);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(41, 24);
            this.buttonClear.TabIndex = 47;
            this.buttonClear.Text = "清空";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxScale
            // 
            this.textBoxScale.Location = new System.Drawing.Point(77, 50);
            this.textBoxScale.Name = "textBoxScale";
            this.textBoxScale.Size = new System.Drawing.Size(134, 21);
            this.textBoxScale.TabIndex = 43;
            // 
            // listBoxScales
            // 
            this.listBoxScales.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listBoxScales.FormattingEnabled = true;
            this.listBoxScales.ItemHeight = 12;
            this.listBoxScales.Items.AddRange(new object[] {
            "250000",
            "100000",
            "50000",
            "25000"});
            this.listBoxScales.Location = new System.Drawing.Point(77, 77);
            this.listBoxScales.Name = "listBoxScales";
            this.listBoxScales.Size = new System.Drawing.Size(134, 184);
            this.listBoxScales.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "新比例尺";
            // 
            // buttonAddScale
            // 
            this.buttonAddScale.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonAddScale.Location = new System.Drawing.Point(234, 50);
            this.buttonAddScale.Name = "buttonAddScale";
            this.buttonAddScale.Size = new System.Drawing.Size(41, 24);
            this.buttonAddScale.TabIndex = 44;
            this.buttonAddScale.Text = "增加";
            this.buttonAddScale.UseVisualStyleBackColor = true;
            this.buttonAddScale.Click += new System.EventHandler(this.buttonAddScale_Click);
            // 
            // buttonClearScale
            // 
            this.buttonClearScale.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonClearScale.Location = new System.Drawing.Point(234, 127);
            this.buttonClearScale.Name = "buttonClearScale";
            this.buttonClearScale.Size = new System.Drawing.Size(41, 24);
            this.buttonClearScale.TabIndex = 46;
            this.buttonClearScale.Text = "删除";
            this.buttonClearScale.UseVisualStyleBackColor = true;
            this.buttonClearScale.Click += new System.EventHandler(this.buttonClearScale_Click);
            // 
            // tabPageExtents
            // 
            this.tabPageExtents.Controls.Add(this.radioButtonDefault);
            this.tabPageExtents.Controls.Add(this.radioButtonUser);
            this.tabPageExtents.Controls.Add(this.radioButtonMap);
            this.tabPageExtents.Controls.Add(this.textBoxMaxY);
            this.tabPageExtents.Controls.Add(this.textBoxMinX);
            this.tabPageExtents.Controls.Add(this.textBoxMinY);
            this.tabPageExtents.Controls.Add(this.textBoxMaxX);
            this.tabPageExtents.Controls.Add(this.panel1);
            this.tabPageExtents.Controls.Add(this.label2);
            this.tabPageExtents.Controls.Add(this.label5);
            this.tabPageExtents.Controls.Add(this.label3);
            this.tabPageExtents.Controls.Add(this.label4);
            this.tabPageExtents.Location = new System.Drawing.Point(4, 21);
            this.tabPageExtents.Name = "tabPageExtents";
            this.tabPageExtents.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExtents.Size = new System.Drawing.Size(374, 321);
            this.tabPageExtents.TabIndex = 1;
            this.tabPageExtents.Text = "范围设置";
            this.tabPageExtents.UseVisualStyleBackColor = true;
            // 
            // radioButtonDefault
            // 
            this.radioButtonDefault.AutoSize = true;
            this.radioButtonDefault.Checked = true;
            this.radioButtonDefault.Location = new System.Drawing.Point(33, 59);
            this.radioButtonDefault.Name = "radioButtonDefault";
            this.radioButtonDefault.Size = new System.Drawing.Size(71, 16);
            this.radioButtonDefault.TabIndex = 55;
            this.radioButtonDefault.TabStop = true;
            this.radioButtonDefault.Text = "默认范围";
            this.radioButtonDefault.UseVisualStyleBackColor = true;
            this.radioButtonDefault.CheckedChanged += new System.EventHandler(this.radioButtonDefault_CheckedChanged);
            // 
            // radioButtonUser
            // 
            this.radioButtonUser.AutoSize = true;
            this.radioButtonUser.Location = new System.Drawing.Point(221, 59);
            this.radioButtonUser.Name = "radioButtonUser";
            this.radioButtonUser.Size = new System.Drawing.Size(83, 16);
            this.radioButtonUser.TabIndex = 54;
            this.radioButtonUser.Text = "自定义范围";
            this.radioButtonUser.UseVisualStyleBackColor = true;
            this.radioButtonUser.CheckedChanged += new System.EventHandler(this.radioButtonUser_CheckedChanged);
            // 
            // radioButtonMap
            // 
            this.radioButtonMap.AutoSize = true;
            this.radioButtonMap.Location = new System.Drawing.Point(127, 59);
            this.radioButtonMap.Name = "radioButtonMap";
            this.radioButtonMap.Size = new System.Drawing.Size(71, 16);
            this.radioButtonMap.TabIndex = 53;
            this.radioButtonMap.Text = "当前范围";
            this.radioButtonMap.UseVisualStyleBackColor = true;
            this.radioButtonMap.CheckedChanged += new System.EventHandler(this.radioButtonMap_CheckedChanged);
            // 
            // textBoxMaxY
            // 
            this.textBoxMaxY.Location = new System.Drawing.Point(127, 139);
            this.textBoxMaxY.Name = "textBoxMaxY";
            this.textBoxMaxY.Size = new System.Drawing.Size(110, 21);
            this.textBoxMaxY.TabIndex = 47;
            // 
            // textBoxMinX
            // 
            this.textBoxMinX.Location = new System.Drawing.Point(46, 182);
            this.textBoxMinX.Name = "textBoxMinX";
            this.textBoxMinX.Size = new System.Drawing.Size(107, 21);
            this.textBoxMinX.TabIndex = 44;
            // 
            // textBoxMinY
            // 
            this.textBoxMinY.Location = new System.Drawing.Point(127, 227);
            this.textBoxMinY.Name = "textBoxMinY";
            this.textBoxMinY.Size = new System.Drawing.Size(110, 21);
            this.textBoxMinY.TabIndex = 45;
            // 
            // textBoxMaxX
            // 
            this.textBoxMaxX.Location = new System.Drawing.Point(212, 182);
            this.textBoxMaxX.Name = "textBoxMaxX";
            this.textBoxMaxX.Size = new System.Drawing.Size(108, 21);
            this.textBoxMaxX.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Location = new System.Drawing.Point(170, 180);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(24, 24);
            this.panel1.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Location = new System.Drawing.Point(156, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 48;
            this.label2.Text = "上(YMax)";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label5.Location = new System.Drawing.Point(82, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 51;
            this.label5.Text = "左(XMin)";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label3.Location = new System.Drawing.Point(156, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 49;
            this.label3.Text = "下(YMin)";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label4.Location = new System.Drawing.Point(246, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 50;
            this.label4.Text = "右(XMax)";
            // 
            // tabPageGroup
            // 
            this.tabPageGroup.Controls.Add(this.label9);
            this.tabPageGroup.Controls.Add(this.label8);
            this.tabPageGroup.Controls.Add(this.buttonRemoveAll);
            this.tabPageGroup.Controls.Add(this.buttonRemove);
            this.tabPageGroup.Controls.Add(this.buttonAdd);
            this.tabPageGroup.Controls.Add(this.buttonAddAll);
            this.tabPageGroup.Controls.Add(this.listBoxUseGroup);
            this.tabPageGroup.Controls.Add(this.listBoxAllGroup);
            this.tabPageGroup.Location = new System.Drawing.Point(4, 21);
            this.tabPageGroup.Name = "tabPageGroup";
            this.tabPageGroup.Size = new System.Drawing.Size(374, 321);
            this.tabPageGroup.TabIndex = 2;
            this.tabPageGroup.Text = "输出组";
            this.tabPageGroup.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(208, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 65;
            this.label9.Text = "输出组：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 64;
            this.label8.Text = "所有组：";
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Location = new System.Drawing.Point(166, 155);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(28, 28);
            this.buttonRemoveAll.TabIndex = 62;
            this.buttonRemoveAll.Text = "<<";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            this.buttonRemoveAll.Click += new System.EventHandler(this.buttonRemoveAll_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(166, 121);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(28, 28);
            this.buttonRemove.TabIndex = 61;
            this.buttonRemove.Text = "<";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(166, 87);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(28, 28);
            this.buttonAdd.TabIndex = 60;
            this.buttonAdd.Text = ">";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonAddAll
            // 
            this.buttonAddAll.Location = new System.Drawing.Point(166, 53);
            this.buttonAddAll.Name = "buttonAddAll";
            this.buttonAddAll.Size = new System.Drawing.Size(28, 28);
            this.buttonAddAll.TabIndex = 59;
            this.buttonAddAll.Text = ">>";
            this.buttonAddAll.UseVisualStyleBackColor = true;
            this.buttonAddAll.Click += new System.EventHandler(this.buttonAddAll_Click);
            // 
            // listBoxUseGroup
            // 
            this.listBoxUseGroup.FormattingEnabled = true;
            this.listBoxUseGroup.ItemHeight = 12;
            this.listBoxUseGroup.Location = new System.Drawing.Point(210, 48);
            this.listBoxUseGroup.Name = "listBoxUseGroup";
            this.listBoxUseGroup.Size = new System.Drawing.Size(114, 232);
            this.listBoxUseGroup.TabIndex = 58;
            // 
            // listBoxAllGroup
            // 
            this.listBoxAllGroup.FormattingEnabled = true;
            this.listBoxAllGroup.ItemHeight = 12;
            this.listBoxAllGroup.Location = new System.Drawing.Point(32, 48);
            this.listBoxAllGroup.Name = "listBoxAllGroup";
            this.listBoxAllGroup.Size = new System.Drawing.Size(114, 232);
            this.listBoxAllGroup.TabIndex = 57;
            // 
            // statusStripPF
            // 
            this.statusStripPF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelInfo});
            this.statusStripPF.Location = new System.Drawing.Point(0, 409);
            this.statusStripPF.Name = "statusStripPF";
            this.statusStripPF.Size = new System.Drawing.Size(412, 22);
            this.statusStripPF.TabIndex = 42;
            this.statusStripPF.Text = "statusStripPF";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = false;
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(350, 17);
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // formPrecacheKamap
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(412, 431);
            this.Controls.Add(this.statusStripPF);
            this.Controls.Add(this.tabControlSetUp);
            this.Controls.Add(this.progressBarInfo);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formPrecacheKamap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "瓦片工具";
            this.Load += new System.EventHandler(this.formPrecacheKamap_Load);
            this.tabControlSetUp.ResumeLayout(false);
            this.tabPageBasic.ResumeLayout(false);
            this.gbExportData.ResumeLayout(false);
            this.gbExportData.PerformLayout();
            this.tabPageScale.ResumeLayout(false);
            this.tabPageScale.PerformLayout();
            this.tabPageExtents.ResumeLayout(false);
            this.tabPageExtents.PerformLayout();
            this.tabPageGroup.ResumeLayout(false);
            this.tabPageGroup.PerformLayout();
            this.statusStripPF.ResumeLayout(false);
            this.statusStripPF.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        const double Resolution = 72;
        const int MetaWidth = 6;
        const int MetaHeight = 6;
        const int TileWidth = 256;
        const int TileHeight = 256;
        const int MetaBuffer = 0;
        //const string GroupName = "base";
       
        //inches,feet,miles,meters,kilometers,dd
        double[] inchesPerUnit = {1, 12, 63360.0, 39.3701, 39370.1, 4374754};
        private StringCollection m_pGroupCollect = new StringCollection();
        private StringCollection m_pOutGroup = new StringCollection();


        private void buttonOK_Click(object sender, EventArgs e)
        {
            #region   "check the conditoin"
            if (listBoxScales.Items.Count <= 0)
            {
                MessageBox.Show("Please set the PreCache Scales!","Info");
                return;
            }            

            if (m_pMapObj.numlayers == 0)
            {
                MessageBox.Show("The Current Map is NULL！", "Information",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (textBoxMaxX.Text == "" || textBoxMaxY.Text == "" ||
                textBoxMinX.Text == "" || textBoxMinY.Text == "" ||
                textBoxOutPath.Text == "")
            {
                MessageBox.Show("The Output extents is wrong!", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double minx, miny, maxx, maxy;

            try
            {
                minx = System.Convert.ToDouble(textBoxMinX.Text.ToString());
                miny = System.Convert.ToDouble(textBoxMinY.Text.ToString());
                maxx = System.Convert.ToDouble(textBoxMaxX.Text.ToString());
                maxy = System.Convert.ToDouble(textBoxMaxY.Text.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("数据范围错误：" + ex.Message, "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (textBoxOutPath.Text.Trim().Length < 3)
            {
                MessageBox.Show("没有设置输出路径!", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxOutPath.Focus();
                return;
            }
            if (!(textBoxOutPath.Text.Trim().Substring(1, 2).Equals(":\\")))
            {
                MessageBox.Show("制定的数据输出路径非法,请重新指定!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!Directory.Exists(textBoxOutPath.Text.Trim().Substring(0, 3)))
            {
                MessageBox.Show("系统不存在[" + textBoxOutPath.Text.Trim().Substring(0, 1) + "盘],请重新指定配置文件输出路径!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int outFormat = comboBoxOutType.SelectedIndex;
            if (outFormat == -1)
            {
                MessageBox.Show("没有设置输出数据格式!", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (listBoxScales.Items.Count <= 0)
            {
                MessageBox.Show("没有设置输出数据比例尺!", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StringCollection pOutPutString = new StringCollection();
           
            pOutPutString.Clear();
            for (int i = 0; i < listBoxUseGroup.Items.Count; i++)
            {
                pOutPutString.Add(listBoxUseGroup.Items[i].ToString());
            }
           
            if (pOutPutString.Count <= 0)
            {
                MessageBox.Show("没有设置输出组!", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
           
#endregion
   
        
            #region "输出切片数据"
            string lasttempImgPath = "";
            try
            {
                //set the default outputformat to png         
                ImageFormat pNetFormat = ImageFormat.Png;                   
            
                string strExt = "";

                if (outFormat == 0)
                {
                    m_pMapObj.setOutputFormat(m_pMapObj.getOutputFormatByName("PNG"));                      
                    pNetFormat = ImageFormat.Png;
                    strExt = ".png";
                }
                else if (outFormat == 1)
                {
                    m_pMapObj.setOutputFormat(m_pMapObj.getOutputFormatByName("jpeg"));
                    pNetFormat = ImageFormat.Jpeg;
                    strExt = ".jpg";
                }


                DateTime startTime = DateTime.Now;
                string startinfo = "信息:开始[" + startTime.Month.ToString() +
                    "月" + startTime.Day.ToString() + "日" + startTime.Hour.ToString()
                    + "时" + startTime.Minute.ToString() + "分" + startTime.Second.ToString() + "秒];";

                            

                Rectangle pTileRect = new Rectangle(0, 0, TileWidth, TileHeight);
                Rectangle clipRec = new Rectangle(0, 0, TileWidth, TileHeight);

                //Bitmap pClipTile = new Bitmap(TileWidth, TileHeight);
                //Graphics pGrapics = Graphics.FromImage(pClipTile);
                

                foreach (string strGroup in pOutPutString)
                {

                    int iCount = m_pMapObj.numlayers;
                    for (int i = 0; i < iCount; i++)
                    {
                        layerObj pLayer = m_pMapObj.getLayer(i);
                        string strGroupName = pLayer.group;

                        if ((strGroupName != null)&&(strGroupName.Length > 0))
                        {
                            if (strGroup == pLayer.group)
                                pLayer.status = 1;
                            else
                                pLayer.status = 0;
                        }
                        else
                        {                           
                            //不存在组名的层全部设置可见
                            pLayer.status = 1;
                        }

                        pLayer.Dispose();
                        pLayer = null;

                    }

                    string dir = textBoxOutPath.Text + "\\";
                    int nCountScale = listBoxScales.Items.Count;

                    int[] scales = new int[nCountScale];//{ 250000, 50000 };
                    for (int i = 0; i < nCountScale; i++)
                    {
                        scales[i] = int.Parse(listBoxScales.Items[i].ToString());
                    }

                    double dblInches = 0;                   
                    int intUnits = (int)m_pMapObj.units;
                    dblInches = inchesPerUnit[intUnits];


                    //m_pMapObj.width = TileWidth * MetaWidth + 2 * MetaBuffer;
                    //m_pMapObj.height = TileHeight * MetaHeight + 2 * MetaBuffer;

                    m_pMapObj.setSize(TileWidth * MetaWidth + 2 * MetaBuffer
                                    , TileHeight * MetaHeight + 2 * MetaBuffer);
               

                    string strInfo = "";

                    progressBarInfo.Visible = true;

                    this.Cursor = Cursors.WaitCursor;

                    for (int it = 0; it < scales.Length; it++)
                    {
                        strInfo = "正在输出组：" + strGroup + ",当前比例尺：" + scales[it].ToString() + "\r\n";
                        double cellSize = scales[it] / (Resolution * dblInches);

                        double pixMinX = minx / cellSize;
                        double pixMaxX = maxx / cellSize;
                        double pixMinY = miny / cellSize;
                        double pixMaxY = maxy / cellSize;

                        int metaTileSize = TileWidth * MetaWidth;

                        int metaMinX = (int)Math.Floor(pixMinX / metaTileSize) * metaTileSize;
                        int metaMaxX = (int)Math.Ceiling(pixMaxX / metaTileSize) * metaTileSize;
                        int metaMinY = -1 * (int)Math.Ceiling(pixMaxY / metaTileSize) * metaTileSize;
                        int metaMaxY = -1 * (int)Math.Floor(pixMinY / metaTileSize) * metaTileSize;


                        int nWide = (metaMaxX - metaMinX) / metaTileSize;
                        int nHigh = (metaMaxY - metaMinY) / metaTileSize;

                        long iTotleCount = Math.Abs(nHigh * nWide);

                        int iCompCount = 0;

                        if (iTotleCount >= Int32.MaxValue)
                        {
                            iTotleCount = Int32.MaxValue;
                        }
                        progressBarInfo.Maximum = (int)iTotleCount;
                        progressBarInfo.Minimum = 0;

                        labelInfo.Text = strInfo;
                        Application.DoEvents();

                        string dir1 = dir + scales[it].ToString() + "\\" + strGroup + "\\def\\";
                        for (int i = 0; i < nHigh; i++)
                        {
                            for (int j = 0; j < nWide; j++)
                            {
                                iCompCount++;
                                if (iCompCount >= Int32.MaxValue || iCompCount < 0)
                                {
                                    progressBarInfo.Value = Int32.MaxValue;
                                }
                                else
                                {
                                    progressBarInfo.Value = iCompCount;
                                }
                                Application.DoEvents();

                                int tileTop = metaMinY + (i * metaTileSize);
                                int tileLeft = metaMinX + (j * metaTileSize);
                                int tileBottom = tileTop + metaTileSize;
                                int tileRight = tileLeft + metaTileSize;

                                string dir2 = dir1 + "t" + tileTop.ToString() + "\\";
                                string dir3 = dir2 + "l" + tileLeft.ToString() + "\\";

                                string strOutMete = dir3 + "temp.png";
                                lasttempImgPath = strOutMete;
                                // string strOutMete = Application.StartupPath + "\\temp.png";
                                if (File.Exists(strOutMete))
                                {
                                    continue;
                                }
                                if (!Directory.Exists(dir3))
                                    Directory.CreateDirectory(dir3);



                                m_pMapObj.extent.minx = tileLeft * cellSize;
                                m_pMapObj.extent.maxx = tileRight * cellSize;
                                m_pMapObj.extent.miny = -1 * tileBottom * cellSize;
                                m_pMapObj.extent.maxy = -1 * tileTop * cellSize;

                                
                                imageObj img = m_pMapObj.draw();
                                img.save(strOutMete, m_pMapObj);

                                img.Dispose();

                                if (!File.Exists(strOutMete))
                                    continue;


                                Image pMeteTile = Image.FromFile(strOutMete);

                                for (int vertIndex = 0; vertIndex < MetaHeight; vertIndex++)
                                {
                                    for (int horizIndex = 0; horizIndex < MetaWidth; horizIndex++)
                                    {
                                        int tileTop2 = tileTop + vertIndex * TileHeight;
                                        int tileLeft2 = tileLeft + horizIndex * TileWidth;
                                        int tileBottom2 = tileTop2 + TileHeight;
                                        int tileRight2 = tileLeft2 + TileWidth;

                                        string file = dir3 + "t" + tileTop2.ToString() + "l" +
                                            tileLeft2.ToString() + strExt;

                                        if (File.Exists(file))
                                            continue;

                                        Bitmap pClipTile = new Bitmap(TileWidth, TileHeight);
                                        Graphics pGrapics = Graphics.FromImage(pClipTile);

                                        clipRec.X = horizIndex * TileWidth;
                                        clipRec.Y = vertIndex * TileHeight;

                                        pGrapics.DrawImage(pMeteTile, pTileRect, clipRec, GraphicsUnit.Pixel);

                                        //if ((checkBoxTransparent.Checked) && (myFormat == nmImageType.nmITPng))
                                        //{
                                        //    pClipTile.MakeTransparent(pBackColor);
                                        //}

                                        pClipTile.Save(file, pNetFormat);

                                        pClipTile.Dispose();
                                        pGrapics.Dispose();

                                        //clipRec.X = horizIndex * TileWidth;
                                        //clipRec.Y = vertIndex * TileHeight;

                                        //pGrapics.DrawImage(pMeteTile, pTileRect, clipRec, GraphicsUnit.Pixel);

                                        ////if ((checkBoxTransparent.Checked) && (myFormat == nmImageType.nmITPng))
                                        ////{
                                        ////    pClipTile.MakeTransparent(pBackColor);
                                        ////}

                                        //pClipTile.Save(file, pNetFormat);
                                        //Application.DoEvents();
                                        ////if ((checkBoxTransparent.Checked) && (myFormat == nmImageType.nmITPng))
                                        ////{
                                        ////    Bitmap pBitMap = new Bitmap(file);
                                        ////    pBitMap.MakeTransparent(pBackColor);
                                        ////    // pBitMap.MakeTransparent(Color.Black);
                                        ////    pBitMap.Save(file);
                                        ////    pBitMap.Dispose();
                                        ////}
                                    }
                                }

                                pMeteTile.Dispose();

                                GC.Collect();
                                File.Delete(strOutMete);
                            }
                        }

                    }

                }
                //pClipTile.Dispose();
                //pGrapics.Dispose();       

                labelInfo.Text = "";
                progressBarInfo.Visible = false;

                this.Cursor = Cursors.Default;
                //将图层全部设置成可见状态
                 int iCount4 = m_pMapObj.numlayers;
                 for (int i = 0; i < iCount4; i++)
                 {
                     layerObj pLayer3 = m_pMapObj.getLayer(i);
                     if (pLayer3 != null)
                     {
                         pLayer3.status = 1;
                         pLayer3.Dispose();
                     }
          
                 }
                MessageBox.Show("切片完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            


            #endregion

        
            }
            catch (OutOfMemoryException ex)
            {
                if(File.Exists(lasttempImgPath))
                {
                    File.Delete(lasttempImgPath);
                    MessageBox.Show("裁切过程中操作系统发生异常，+ 请重新启动程序继续裁切!");
                }
                MessageBox.Show("OutofMemoryException:" + ex.Message);
            }
            catch (ArgumentException ex)
            {
                if (File.Exists(lasttempImgPath))
                {
                    File.Delete(lasttempImgPath);
                    MessageBox.Show("裁切过程中操作系统发生异常，+ 请重新启动程序继续裁切!");
                }
                MessageBox.Show(String.Format("\nPath contains invalid characters", ex.Message));
            }
            catch (PathTooLongException ex)
            {
                if (File.Exists(lasttempImgPath))
                {
                    File.Delete(lasttempImgPath);
                    MessageBox.Show("裁切过程中操作系统发生异常，+ 请重新启动程序继续裁切!");
                }
                MessageBox.Show(String.Format("\nPath too long", ex.Message));
            }
            catch (NotSupportedException ex)
            {
                if (File.Exists(lasttempImgPath))
                {
                    File.Delete(lasttempImgPath);
                    MessageBox.Show("裁切过程中操作系统发生异常，+ 请重新启动程序继续裁切!");
                }
                MessageBox.Show(String.Format("Column type {0} is not supported.", ex.Message));
            }
            catch (System.IO.IOException ex)
            {
                if (File.Exists(lasttempImgPath))
                {
                    File.Delete(lasttempImgPath);
                    MessageBox.Show("裁切过程中操作系统发生异常，+ 请重新启动程序继续裁切!");
                }
                MessageBox.Show(String.Format("Column type {0} is not supported.", ex.Message));
            }
            catch (SystemException ex)
            {
                if (File.Exists(lasttempImgPath))
                {
                    File.Delete(lasttempImgPath);
                    MessageBox.Show("裁切过程中操作系统发生异常，+ 请重新启动程序继续裁切!");
                }
                MessageBox.Show("SystemException:" + ex.Message);
            }

            catch (Exception ex)
            {
                if (File.Exists(lasttempImgPath))
                {
                    File.Delete(lasttempImgPath);
                    MessageBox.Show("裁切过程中操作系统发生异常，+ 请重新启动程序继续裁切!");
                }
                MessageBox.Show(ex.Message);
            }
            

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

        private void buttonAddScale_Click(object sender, EventArgs e)
        {
            string strScale = this.textBoxScale.Text;

            if (strScale.Length <= 0)
            {
                MessageBox.Show("请输入要添加的比例尺！", "提示");
                textBoxScale.Focus();
                return;
            }

            try
            {
                int newscale =  Convert.ToInt32(strScale);

                int scalesarraycount = listBoxScales.Items.Count;               

                if (scalesarraycount == 0 || 
                    newscale < Convert.ToInt32(listBoxScales.Items[scalesarraycount - 1].ToString()))
                {
                    listBoxScales.Items.Add(strScale);
                    textBoxScale.Text = "";
                }
                else
                {
                    for (int i = 0; i < scalesarraycount; i++)
                    {
                        if (newscale == Convert.ToInt32(listBoxScales.Items[i].ToString()))
                        {
                            MessageBox.Show("The scale is already exists！", "提示");
                            break;
                        }
                        else if (newscale > Convert.ToInt32(listBoxScales.Items[i].ToString()))
                        {
                            listBoxScales.Items.Insert(i, strScale);
                            textBoxScale.Text = "";
                            break;
                        }
                    }
                }
                     
            }
            catch(Exception ex)
            {
                MessageBox.Show("请正确设置比例尺：" + ex.Message ,"提示");
                textBoxScale.Focus();
            }            
        }

        private void buttonClearScale_Click(object sender, EventArgs e)
        {
            int intIndex = listBoxScales.SelectedIndex;
            if (intIndex == -1)
            {
                MessageBox.Show("请选择左侧要删除的比例尺！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            listBoxScales.Items.RemoveAt(intIndex);            
        }

        private void buttonOutPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxOutPath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void formPrecacheKamap_Load(object sender, EventArgs e)
        {
            
            if (comboBoxOutType.Items.Count >0)
                comboBoxOutType.SelectedIndex = 0;

            if (m_pMapObj == null)
            {                
                this.Close();
                return;
            }

            //wanliyun:get all the groupname from the map
            int lyrCount = m_pMapObj.numlayers;
            for (int i = 0; i < lyrCount; i++)
            {
                layerObj pLayer = m_pMapObj.getLayer(i);
                if (pLayer != null)
                {
                    string strGroup = pLayer.group;
                    if ((strGroup == "") || (strGroup == null))
                    {
                        strGroup = "base";
                    }

                    int iNum = m_pGroupCollect.Count;
                    bool blnFind = false;
                    for (int j = 0; j < iNum; j++)
                    {
                        if (m_pGroupCollect[j] == strGroup)
                        {
                            blnFind = true;
                            break;
                        }
                    }
                    if (blnFind == false)
                    {
                        m_pGroupCollect.Add(strGroup);
                        listBoxAllGroup.Items.Add(strGroup);
                    }

                    pLayer.Dispose();
                }

            }
          
            //listBoxScales.Items.Clear();            
            radioButtonDefault.Checked = true;
            progressBarInfo.Visible = false;

            radioButtonDefault_CheckedChanged(sender, e);
        }

        private void radioButtonMap_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonMap.Checked == true)
            {
                //Extents pExt = m_pMapObj.nmMap.MaxExtents;
                rectObj pExt = m_pMapObj.extent;

                if (pExt != null)
                {
                    textBoxMaxY.Text = pExt.maxy.ToString();
                    textBoxMinY.Text = pExt.miny.ToString();
                    textBoxMaxX.Text = pExt.maxx.ToString();
                    textBoxMinX.Text = pExt.minx.ToString();
                }

                textBoxMaxY.Enabled = false;
                textBoxMinY.Enabled = false;
                textBoxMaxX.Enabled = false;
                textBoxMinX.Enabled = false;

                pExt.Dispose();
            }
            
            
        }

        private void checkBoxTransparent_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBoxOutType.SelectedIndex == 0)
                checkBoxTransparent.Enabled = true;
            else
            {
                checkBoxTransparent.Enabled = false;
            }
        }

        private void buttonAddAll_Click(object sender, EventArgs e)
        {
            int  iCount=listBoxAllGroup.Items.Count;
            for(int i=0;i<iCount;i++)
            {
                listBoxUseGroup.Items.Add(listBoxAllGroup.Items[i].ToString());
            }

            listBoxAllGroup.Items.Clear();
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            int iCount = listBoxUseGroup.Items.Count;
            for (int i = 0; i < iCount; i++)
            {
                listBoxAllGroup.Items.Add(listBoxUseGroup.Items[i].ToString());
            }

            listBoxUseGroup.Items.Clear();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (listBoxAllGroup.SelectedIndex == -1)
            {
                MessageBox.Show("前选择要添加的组！");
                listBoxAllGroup.Focus();
                return;
            }

            listBoxUseGroup.Items.Add(listBoxAllGroup.SelectedItem.ToString());
            listBoxAllGroup.Items.Remove(listBoxAllGroup.SelectedItem);

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxUseGroup.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the group which you want to delete！");
                listBoxUseGroup.Focus();
                return;
            }

            listBoxAllGroup.Items.Add(listBoxUseGroup.SelectedItem.ToString());
            listBoxUseGroup.Items.Remove(listBoxUseGroup.SelectedItem);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listBoxScales.Items.Clear();
        }

        private void radioButtonDefault_CheckedChanged(object sender, EventArgs e)
        {
            

            if (radioButtonDefault.Checked == true)
            {
                //Extents pExt = m_pMapObj.nmMap.MaxExtents;
                //rectObj pExt = m_pMapObj.extent;

                MFEditor.Control.Extent pExt = m_pMapcontrol.Extents;

                if (pExt != null)
                {
                    textBoxMaxY.Text = pExt.Top.ToString();
                    textBoxMinY.Text = pExt.Bottom.ToString();
                    textBoxMaxX.Text = pExt.Right.ToString();
                    textBoxMinX.Text = pExt.Left.ToString();
                }

                textBoxMaxY.Enabled = false;
                textBoxMinY.Enabled = false;
                textBoxMaxX.Enabled = false;
                textBoxMinX.Enabled = false;
                
            }
            
        }

        private void radioButtonUser_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUser.Checked == true)
            {
                textBoxMaxY.Enabled = true;
                textBoxMinY.Enabled = true;
                textBoxMaxX.Enabled = true;
                textBoxMinX.Enabled = true;
            }
        }  

    }
}
