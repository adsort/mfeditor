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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OSGeo.MapServer;

namespace MFEditorUI
{
    public partial class FormSymbolSet : Form
    {
        private layerObj m_curLayer = null;

        public FormSymbolSet(layerObj inLayer)
        {
            InitializeComponent();
            m_curLayer = inLayer;
        }

        private void formSymbolSet_Load(object sender, EventArgs e)
        {
            if (m_curLayer == null)
            {
                this.Close();
                return;
            }

            //labelLayerName.Text = m_curLayer.Name;
            //mcLayerType myType = m_curLayer.Type;
            ////labelLayerType.Text = myType.ToString();

            //comboBoxSymbol.Items.Clear();

            //if (myType == mcLayerType.mcLTpoint)
            //{
            //    comboBoxSymbol.Items.Add("省会");
            //    comboBoxSymbol.Items.Add("地级市");
            //    comboBoxSymbol.Items.Add("县");
            //    comboBoxSymbol.Items.Add("县级市");
            //    comboBoxSymbol.Items.Add("乡");
            //    comboBoxSymbol.Items.Add("镇");
            //    comboBoxSymbol.Items.Add("村");
            //    labelLayerType.Text = "Point";
            //}
            //else if (myType == mcLayerType.mcLTline)
            //{
            //    comboBoxSymbol.Items.Add("铁路");
            //    comboBoxSymbol.Items.Add("高速公路");
            //    comboBoxSymbol.Items.Add("国道");
            //    comboBoxSymbol.Items.Add("省道");
            //    comboBoxSymbol.Items.Add("省界");
            //    labelLayerType.Text = "Polyline";
            //}
            //else if (myType == mcLayerType.mcLTpolygon)
            //{
            //    labelLayerType.Text = "Polygon";
            //}
            //else
            //    labelLayerType.Text = "不支持该类型符号";


        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //if (comboBoxSymbol.SelectedIndex != -1)
            //{
            //    m_curLayer.Symbol = comboBoxSymbol.Text;
            //    this.DialogResult = DialogResult.OK;
            //}
        }
    }
}