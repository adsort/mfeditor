using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MFEditorLib;

namespace MFEditor
{
    public partial class formMapSet : Form
    {
        private MapPropertys m_mapPropertys = null;
        private string m_strMapPath = "";  


        public formMapSet()
        {
            InitializeComponent();
        }

        public formMapSet(MapPropertys inMapPropertys)
        {
            InitializeComponent();   
            m_mapPropertys = inMapPropertys;           
        }

        private void formMapSet_Load(object sender, EventArgs e)
        {
            if (m_mapPropertys != null)
            {
                textName.Text = m_mapPropertys.Name;

                if (m_mapPropertys.Status == mcStatus.mc_ON)
                    comboStatus.SelectedIndex = 0;
                else
                    comboStatus.SelectedIndex = 1;

                textExtMinX.Text = m_mapPropertys.Extent.minX.ToString();
                textExtMinY.Text = m_mapPropertys.Extent.minY.ToString();
                textExtMaxX.Text = m_mapPropertys.Extent.maxX.ToString();
                textExtMaxY.Text = m_mapPropertys.Extent.maxY.ToString();

                textSizeW.Text = m_mapPropertys.Size.Width.ToString();
                textSizeH.Text = m_mapPropertys.Size.Height.ToString();

                textShpPath.Text = m_mapPropertys.ShapePath;
                //textSymSet.Text = m_mapPropertys.
                textFontSet.Text = m_mapPropertys.FontSet;

                int intImgType = Convert.ToInt16(m_mapPropertys.ImageType);
                if ((intImgType > 0) && (intImgType < comboImgType.Items.Count))
                    comboImgType.SelectedIndex = intImgType - 1;
                else
                    comboImgType.SelectedIndex = comboImgType.Items.Count - 1;

                buttonImgColor.BackColor = ColorTranslator.FromOle((int)m_mapPropertys.ImageColor);

                int intUnits = Convert.ToInt16(m_mapPropertys.Units);
                if ((intUnits > 0) && (intUnits < comboUnits.Items.Count))
                    comboUnits.SelectedIndex = intUnits - 1;

            }
            else
                m_mapPropertys = new MapPropertys();
        }

        private void formMapSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_mapPropertys != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_mapPropertys);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                MapPropertys myProperty = new MapPropertys();
                myProperty.Name = textName.Text.Trim();
                if (comboStatus.SelectedIndex == 0)
                    myProperty.Status = mcStatus.mc_ON;
                else
                    myProperty.Status = mcStatus.mc_OFF;

                mcExtent myExtent = new mcExtent();
                myExtent.maxX = Convert.ToDouble(textExtMaxX.Text);
                myExtent.maxY = Convert.ToDouble(textExtMaxY.Text);
                myExtent.minX = Convert.ToDouble(textExtMinX.Text);
                myExtent.minY = Convert.ToDouble(textExtMinY.Text);

                myProperty.Extent = myExtent;

                mcSize mySize = new mcSize();
                mySize.Width = Convert.ToInt32(textSizeW.Text);
                mySize.Height = Convert.ToInt32(textSizeH.Text);

                myProperty.Size = mySize;
             

                myProperty.ShapePath = textShpPath.Text;

                myProperty.FontSet = textFontSet.Text;

                myProperty.ImageType = (mcOutImageFormat)(comboImgType.SelectedIndex + 1);

                myProperty.ImageColor = (uint)ColorTranslator.ToOle(buttonImgColor.BackColor);

                myProperty.Units = (mcUnits)(comboUnits.SelectedIndex + 1);


                classBasic.m_pMapProperty = myProperty;
                

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

            double dblMinx = 0;
            double dblMaxx = 0;
            double dblMiny = 0;
            double dblMaxy = 0;

            if (checkExtent(textExtMinX, out dblMinx) == false)
                return false;
            if (checkExtent(textExtMaxX, out dblMaxx) == false)
                return false;
            if (checkExtent(textExtMinY, out dblMiny) == false)
                return false;
            if (checkExtent(textExtMaxY, out dblMaxy) == false)
                return false;       


            if ((dblMaxy <= dblMiny)||(dblMaxx <= dblMinx))
            {
                warningMessage("Extent的设置不合法！");              
                return false;
            }

            if (checkSize(textSizeW) == false)
                return false;
            if (checkSize(textSizeH) == false)
                return false;

            m_strMapPath = m_mapPropertys.mapfilePath;

            if (textShpPath.Text.Trim().Length == 0)
            {
                //warningMessage("shapePath未设置！");
                //return false;
            }
            else
            {
                //string strSHPpath = Path.GetDirectoryName(m_strMapPath) + "\\" + textShpPath.Text;
                //string strSHPpath = textShpPath.Text;
                //if (!Directory.Exists(strSHPpath))
                //{
                //    strSHPpath = Path.GetDirectoryName(m_strMapPath) + "\\" + textShpPath.Text;
                //    if (!Directory.Exists(strSHPpath))
                //    {
                //        warningMessage("shapePath文件夹路径不存在！");
                //        return false;
                //    }
                //}
            }

            string strFontPath = textFontSet.Text;
            if (strFontPath.Trim().Length == 0)
            {
                warningMessage("FontSet路径未设置！");
                return false;
            }
            else
            {
                if (!File.Exists(strFontPath))
                {
                    string strFullPath = Path.GetFullPath(strFontPath);
                    if (!File.Exists(strFullPath))
                    {
                        warningMessage("FontSet文件不存在！");
                        return false;
                    }
                }
            }

            if (comboImgType.SelectedIndex == -1)
            {
                warningMessage("ImageType没有设置！");
                return false;
            }

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

        private bool checkExtent(TextBox inTextbox,out double inValue)
        {
            try
            {
                inValue = Convert.ToDouble(inTextbox.Text);
                return true;
            }
            catch (Exception ex)
            {
                inValue = 0;
                warningMessage("Extent的设置不合法！");
                inTextbox.Focus();
                return false;
            }
        }

        private bool checkSize(TextBox inTextbox)
        {
            try
            {
                int inValue = Convert.ToInt32(inTextbox.Text);

                if ((inValue <= 0) && (inValue >= 2000))
                {
                    warningMessage("Size的值应该在1-2000之间！");
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            m_mapPropertys = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonImgColor_Click(object sender, EventArgs e)
        {
            ColorDialog myColor = new ColorDialog();
            if (myColor.ShowDialog() == DialogResult.OK)
            {
                buttonImgColor.BackColor = myColor.Color;
            }
        }

        private void buttonShpPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog myDialog = new FolderBrowserDialog();
            if (DialogResult.OK == myDialog.ShowDialog())
            {
                string strPath = myDialog.SelectedPath;

                textShpPath.Text = strPath;
            }
        }

        private void buttonFontSet_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenNmp = new OpenFileDialog();
            pOpenNmp.Title = "打开fontset";
            pOpenNmp.Multiselect = false;
            pOpenNmp.Filter = "fontset 文件 (*.list)|*.list";


            if (pOpenNmp.ShowDialog() == DialogResult.OK)
            {              
                textFontSet.Text = pOpenNmp.FileName;
            }
        }
    }
}