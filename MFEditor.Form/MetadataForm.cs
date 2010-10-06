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
    public partial class MetadataForm : Form
    {
        private layerObj m_curLayer = null;
        private mapObj m_curMap = null;
        private bool m_LayerMeta = false;
        private bool m_mapMeta = false;

        public MetadataForm(layerObj inLayer)
        {
            InitializeComponent();
            m_curLayer = inLayer;
            m_LayerMeta = true;
        }

        public MetadataForm(mapObj inMap)
        {
            InitializeComponent();
            m_curMap = inMap;
            m_mapMeta = true;
        }    

        private void formMetadata_Load(object sender, EventArgs e)
        {
            if ((m_LayerMeta)&&(m_curLayer == null))
                return;

            if ((m_mapMeta) && (m_curMap == null))
                return;

            InitMetadata();
            comboBoxName.SelectedIndex = -1;
        }

        private void InitMetadata()
        {
            if (m_LayerMeta)
            {
                string strValue = m_curLayer.getFirstMetaDataKey();
                listBoxMeta.Items.Clear();
                while (strValue != null)
                {
                    listBoxMeta.Items.Add(strValue);
                    strValue = m_curLayer.getNextMetaDataKey(strValue);
                }     
            }
            else if (m_mapMeta)
            {
                string strValue = m_curMap.getFirstMetaDataKey();
                listBoxMeta.Items.Clear();
                while (strValue != null)
                {
                    listBoxMeta.Items.Add(strValue);
                    strValue = m_curMap.getNextMetaDataKey(strValue);
                }     
            }

               
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxName.Text.Trim().Length == 0) return;
            if (textBoxValue.Text.Trim().Length == 0)
            {
                MessageBox.Show("请设置属性值！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                textBoxValue.Focus();
                return;
            }

            if (m_LayerMeta)
                m_curLayer.setMetaData(comboBoxName.Text.Trim(), textBoxValue.Text.Trim());
            else if (m_mapMeta)
                m_curMap.setMetaData(comboBoxName.Text.Trim(), textBoxValue.Text.Trim());
            
            InitMetadata();
        }

        private void comboBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (comboBoxName.Text.Trim().Length == 0) return;

            if (e.KeyCode == Keys.Enter)
            {
                if (m_LayerMeta)
                    textBoxValue.Text = m_curLayer.getMetaData(comboBoxName.Text.Trim());
                else if (m_mapMeta)
                    textBoxValue.Text = m_curMap.getMetaData(comboBoxName.Text.Trim());                
            }
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxName.Text.Trim().Length == 0) return;

            if (m_LayerMeta)
                textBoxValue.Text = m_curLayer.getMetaData(comboBoxName.Text.Trim());
            else if (m_mapMeta)
                textBoxValue.Text = m_curMap.getMetaData(comboBoxName.Text.Trim());               
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxName.Text.Trim().Length == 0) return;
            if (textBoxValue.Text.Trim().Length == 0) return;

            if (m_LayerMeta)
                m_curLayer.setMetaData(comboBoxName.Text.Trim(), textBoxValue.Text.Trim());
            else if (m_mapMeta)
                m_curMap.setMetaData(comboBoxName.Text.Trim(), textBoxValue.Text.Trim());

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //if (comboBoxName.Text.Trim().Length == 0) return;
            //if (textBoxValue.Text.Trim().Length == 0) return;

            if (listBoxMeta.SelectedItem == null) return;

            if (m_LayerMeta)
                m_curLayer.removeMetaData(listBoxMeta.SelectedItem.ToString());
            else if (m_mapMeta)
                m_curMap.removeMetaData(listBoxMeta.SelectedItem.ToString());
            
            InitMetadata();
            comboBoxName.Text = "";
            textBoxValue.Text = "";
        }

        private void listBoxMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            comboBoxName.Text = listBoxMeta.SelectedItem.ToString();

            if (m_LayerMeta)
                textBoxValue.Text = m_curLayer.getMetaData(comboBoxName.Text.Trim());
            else if (m_mapMeta)
                textBoxValue.Text = m_curMap.getMetaData(comboBoxName.Text.Trim());

            
        }
    }
}