using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MFEditorLib;

namespace MFEditor
{
    public partial class formMetadata : Form
    {
        private McLayer m_curLayer = null;
        private McMap m_curMap = null;
        private bool m_LayerMeta = false;
        private bool m_mapMeta = false;

        public formMetadata(McLayer inLayer)
        {
            InitializeComponent();
            m_curLayer = inLayer;
            m_LayerMeta = true;
        }

        public formMetadata(McMap inMap)
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
            string strList = "";
            if (m_LayerMeta)
                strList=m_curLayer.AllMetadatas;
            else if(m_mapMeta)
                strList = m_curMap.AllMetadatas;

            listBoxMeta.Items.Clear();
            if (strList.Length > 0)
            {
                string[] listMeta = strList.Split(',');

                for (int i = 0; i < listMeta.Length; i++)
                {
                    listBoxMeta.Items.Add(listMeta[i]);
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
                m_curLayer.set_Metadata(comboBoxName.Text.Trim(), textBoxValue.Text.Trim());
            else if (m_mapMeta)
                m_curMap.set_Metadata(comboBoxName.Text.Trim(), textBoxValue.Text.Trim());
            
            InitMetadata();
        }

        private void comboBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (comboBoxName.Text.Trim().Length == 0) return;

            if (e.KeyCode == Keys.Enter)
            {
                if (m_LayerMeta)
                    textBoxValue.Text = m_curLayer.get_Metadata(comboBoxName.Text.Trim());
                else if (m_mapMeta)
                    textBoxValue.Text = m_curMap.get_Metadata(comboBoxName.Text.Trim());                
            }
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxName.Text.Trim().Length == 0) return;

            if (m_LayerMeta)
                textBoxValue.Text = m_curLayer.get_Metadata(comboBoxName.Text.Trim());
            else if (m_mapMeta)
                textBoxValue.Text = m_curMap.get_Metadata(comboBoxName.Text.Trim());               
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxName.Text.Trim().Length == 0) return;
            if (textBoxValue.Text.Trim().Length == 0) return;

            //m_curLayer.set_Metadata(comboBoxName.Text.Trim(), textBoxValue.Text.Trim());

            if (m_LayerMeta)
                m_curLayer.set_Metadata(comboBoxName.Text.Trim(), textBoxValue.Text.Trim());
            else if (m_mapMeta)
                m_curMap.set_Metadata(comboBoxName.Text.Trim(), textBoxValue.Text.Trim());

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //if (comboBoxName.Text.Trim().Length == 0) return;
            //if (textBoxValue.Text.Trim().Length == 0) return;

            if (listBoxMeta.SelectedItem == null) return;

            if (m_LayerMeta)
                m_curLayer.DelMetadata(listBoxMeta.SelectedItem.ToString());
            else if (m_mapMeta)
                m_curMap.DelMetadata(listBoxMeta.SelectedItem.ToString());
            
            InitMetadata();
            comboBoxName.Text = "";
            textBoxValue.Text = "";
        }

        private void listBoxMeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            comboBoxName.Text = listBoxMeta.SelectedItem.ToString();

            if (m_LayerMeta)
                textBoxValue.Text = m_curLayer.get_Metadata(comboBoxName.Text.Trim());
            else if (m_mapMeta)
                textBoxValue.Text = m_curMap.get_Metadata(comboBoxName.Text.Trim());

            
        }
    }
}