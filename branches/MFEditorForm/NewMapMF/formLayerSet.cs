using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MFEditorLib;
using System.IO;

namespace MFEditor
{
    public partial class formLayerSet : Form
    {
        private McLayer m_currentLayer = null;
        private string m_strShapePath = "";

        public formLayerSet()
        {
            InitializeComponent();
        }

        public formLayerSet(McLayer inLayer,string shpPath)
        {
            InitializeComponent();
            m_currentLayer = inLayer;
            m_strShapePath = shpPath;
        }   

        private void formLayerSet_Load(object sender, EventArgs e)
        {
            if (m_currentLayer == null)
            {
                MessageBox.Show("Layer对象为空！","提示",
                    MessageBoxButtons.OK,MessageBoxIcon.Stop);
                this.Close();
            }

            if (m_strShapePath.Length <=0)
            {
                MessageBox.Show("缺乏shapePath参数！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }


            textName.Text = m_currentLayer.Name;
            textGroup.Text = m_currentLayer.Group;

            if (m_currentLayer.Status == mcStatus.mc_ON)
                comboStatus.SelectedIndex = 0;
            else
                comboStatus.SelectedIndex = 1;

            textData.Text = m_currentLayer.Data;

            int iType = Convert.ToInt32(m_currentLayer.Type);
            if (iType > 5)
                comboBoxDataType.SelectedIndex = -1;
            else
                comboBoxDataType.SelectedIndex = iType - 1;

            int iConnType = Convert.ToInt32(m_currentLayer.ConnectionType);
            if (iConnType > comboBoxConnType.Items.Count-1)
                comboBoxConnType.SelectedIndex = -1;
            else
                comboBoxConnType.SelectedIndex = iConnType;

            textConnection.Text = m_currentLayer.Connection;

            textLabelItem.Text = m_currentLayer.LabelItem;
            textClassItem.Text = m_currentLayer.ClassItem;

            textMinScale.Text = m_currentLayer.MinScale.ToString();
            textMaxScale.Text = m_currentLayer.MaxScale.ToString();

            int intUnits = Convert.ToInt32(m_currentLayer.Units);

            if (intUnits > 6)
                comboUnits.SelectedIndex = -1;
            else
                comboUnits.SelectedIndex = intUnits - 1;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                m_currentLayer.Name = textName.Text;
                m_currentLayer.Group = textGroup.Text;

                if (comboStatus.SelectedIndex == 0)
                    m_currentLayer.Status = mcStatus.mc_ON;
                else
                    m_currentLayer.Status = mcStatus.mc_OFF;


                m_currentLayer.Data = textData.Text;
                m_currentLayer.Type = (mcLayerType)comboBoxDataType.SelectedIndex + 1;

                m_currentLayer.ConnectionType = (mcConnectionType)comboBoxConnType.SelectedIndex;
                m_currentLayer.Connection = textConnection.Text;

                m_currentLayer.ClassItem = textClassItem.Text;
                m_currentLayer.LabelItem = textLabelItem.Text;

                m_currentLayer.MinScale = Convert.ToDouble(textMinScale.Text);
                m_currentLayer.MaxScale = Convert.ToDouble(textMaxScale.Text);

                m_currentLayer.Units = (mcUnits)(comboUnits.SelectedIndex + 1);

                this.DialogResult = DialogResult.OK;

            }
        }

        private bool checkInput()
        {
            //检查用户输入数据是否合法
            if (textName.Text.Trim().Length <= 0)
            {
                warningMessage("Name属性不可以为空！");
                textName.Focus();
                return false;
            }  

            if (textData.Text.Trim().Length == 0)
            {
                warningMessage("dataname未设置！");
                return false;
            }
            else
            {
                string strSHPpath = Path.Combine(m_strShapePath, textData.Text);                
                if (!(File.Exists(strSHPpath + ".shp")||File.Exists(strSHPpath + ".tif")||File.Exists(strSHPpath + ".img")))
                {
                    warningMessage("数据文件不存在，请重新设置data！");
                    return false;
                }
            }

            if (comboBoxDataType.SelectedIndex == -1)
            {
                warningMessage("DataType没有设置！");
                return false;
            }

            if (comboBoxConnType.SelectedIndex == -1)
            {
                warningMessage("ConnectionType没有设置！");
                return false;
            }

            if (checkScale(textMinScale) == false) return false;
            if (checkScale(textMaxScale) == false) return false;


            if (comboUnits.SelectedIndex == -1)
            {
                warningMessage("Units没有设置！");
                return false;
            }

            return true;

        }

        private void warningMessage(string strValue)
        {
            MessageBox.Show(strValue, "提示", MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
        }

        private bool checkScale(TextBox inTextbox)
        {
            try
            {
                int inValue = Convert.ToInt32(inTextbox.Text);

                if (inValue < -1)
                {
                    warningMessage("Size的值不合法！");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                warningMessage("Size的设置不合法！");
                inTextbox.Focus();
                return false;
            }
        }

        private void buttonShpPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenNmp = new OpenFileDialog();
            pOpenNmp.Title = "打开fontset";
            pOpenNmp.Multiselect = false;
            pOpenNmp.InitialDirectory = m_strShapePath;
            pOpenNmp.Filter = "All Formats|*.shp;*.tif;*.img|Shapefile(*.shp)|*.shp|Image(*.img)|*.img|Tiff(*.tif)|*.tif";

            if (pOpenNmp.ShowDialog() == DialogResult.OK)
            {
                string strFullPath = pOpenNmp.FileName;
                textData.Text = Path.GetFileNameWithoutExtension(strFullPath);
            }
        }

    }
}