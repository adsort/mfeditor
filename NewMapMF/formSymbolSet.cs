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
    public partial class formSymbolSet : Form
    {
        private McLayer m_curLayer = null;

        public formSymbolSet(McLayer inLayer)
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

            labelLayerName.Text = m_curLayer.Name;
            mcLayerType myType = m_curLayer.Type;
            //labelLayerType.Text = myType.ToString();

            comboBoxSymbol.Items.Clear();

            if (myType == mcLayerType.mcLTpoint)
            {
                comboBoxSymbol.Items.Add("省会");
                comboBoxSymbol.Items.Add("地级市");
                comboBoxSymbol.Items.Add("县");
                comboBoxSymbol.Items.Add("县级市");
                comboBoxSymbol.Items.Add("乡");
                comboBoxSymbol.Items.Add("镇");
                comboBoxSymbol.Items.Add("村");
                labelLayerType.Text = "Point";
            }
            else if (myType == mcLayerType.mcLTline)
            {
                comboBoxSymbol.Items.Add("铁路");
                comboBoxSymbol.Items.Add("高速公路");
                comboBoxSymbol.Items.Add("国道");
                comboBoxSymbol.Items.Add("省道");
                comboBoxSymbol.Items.Add("省界");
                labelLayerType.Text = "Polyline";
            }
            else if (myType == mcLayerType.mcLTpolygon)
            {
                labelLayerType.Text = "Polygon";
            }
            else
                labelLayerType.Text = "不支持该类型符号";


        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxSymbol.SelectedIndex != -1)
            {
                m_curLayer.Symbol = comboBoxSymbol.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}