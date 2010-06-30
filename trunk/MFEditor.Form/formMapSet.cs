using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OSGeo.MapServer;
using MFEditor.Control;
using MFEditor.Utils;

namespace MFEditorUI
{
    public partial class FormMapSet : Form
    {
        private MapControl m_control = null;
        private mapObj m_mapPropertys = null;
        //private string m_strMapPath = "";  


        public FormMapSet()
        {
            InitializeComponent();
        }

        public FormMapSet(mapObj inMapPropertys)
        {
            InitializeComponent();
            m_mapPropertys = inMapPropertys;
        }

        public FormMapSet(MapControl inMapCtl)
        {
            InitializeComponent();
            m_control = inMapCtl;
            m_mapPropertys = m_control.Map;
        }

        private void formMapSet_Load(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            if (m_mapPropertys != null)
            {
                textName.Text = m_mapPropertys.name;

                if (m_mapPropertys.status == 1)
                    comboStatus.SelectedIndex = 0;
                else
                    comboStatus.SelectedIndex = 1;

                textExtMinX.Text = m_mapPropertys.extent.minx.ToString();
                textExtMinY.Text = m_mapPropertys.extent.miny.ToString();
                textExtMaxX.Text = m_mapPropertys.extent.maxx.ToString();
                textExtMaxY.Text = m_mapPropertys.extent.maxx.ToString();

                textSizeW.Text = m_mapPropertys.width.ToString();
                textSizeH.Text = m_mapPropertys.height.ToString();

                //if the shapepath exist,combine the shapepath and data
                if (Path.IsPathRooted(m_mapPropertys.shapepath))
                    textShpPath.Text = m_mapPropertys.shapepath;
                else
                    textShpPath.Text = Utility.GetAbsolutePath(m_mapPropertys.mappath, m_mapPropertys.shapepath);

                //if the fontset exist,get the absolute path
                if (Path.IsPathRooted(m_mapPropertys.fontset.filename))
                    textFontSet.Text = m_mapPropertys.fontset.filename;
                else
                    textFontSet.Text = Utility.GetAbsolutePath(m_mapPropertys.mappath, m_mapPropertys.fontset.filename);

                int iFormatIndex = -1;
                string strCurFormat = m_mapPropertys.outputformat.name;
                outputFormatObj[] outputList = m_mapPropertys.outputformatlist;
                comboImgType.Items.Clear();
                int intIndex = 0;
                foreach(outputFormatObj formatObj in outputList)
                {
                    if(strCurFormat == formatObj.name)
                        iFormatIndex = intIndex;
                    comboImgType.Items.Add(formatObj.name);
                    intIndex++;
                    
                }

                if (comboImgType.Items.Count > 0)
                    comboImgType.SelectedIndex = iFormatIndex;

                colorObj pcurObj = m_mapPropertys.imagecolor;
                buttonImgColor.BackColor = Color.FromArgb(pcurObj.red, pcurObj.green, pcurObj.blue);              
            

                int intUnits = Convert.ToInt16(m_mapPropertys.units);
                if ((intUnits > 0) && (intUnits < comboUnits.Items.Count))
                    comboUnits.SelectedIndex = intUnits;

                textSRID.Text = m_mapPropertys.getProjection();
                textResolution.Text = m_mapPropertys.resolution.ToString();

            }
            else
                this.Close();
        }      

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (checkInput())
            {
                m_mapPropertys.name = textName.Text.Trim();
                if (comboStatus.SelectedIndex == 0)
                    m_mapPropertys.status = 1;
                else
                    m_mapPropertys.status = 0;

                m_mapPropertys.width = Convert.ToInt32(textSizeW.Text);
                m_mapPropertys.height = Convert.ToInt32(textSizeH.Text);

               //get the relative path of the shapepath
                m_mapPropertys.shapepath = Utility.GetRelativePath(m_mapPropertys.mappath, textShpPath.Text);

                //myProperty.FontSet = textFontSet.Text;


                if (comboImgType.SelectedItem.ToString() != m_mapPropertys.outputformat.name)
                {
                    m_mapPropertys.setOutputFormat
                        (m_mapPropertys.getOutputFormatByName(comboImgType.SelectedItem.ToString()));
                }

                m_mapPropertys.imagecolor.red = buttonImgColor.BackColor.R;
                m_mapPropertys.imagecolor.green = buttonImgColor.BackColor.G;
                m_mapPropertys.imagecolor.blue = buttonImgColor.BackColor.B;

                m_mapPropertys.units = (MS_UNITS)comboUnits.SelectedIndex;

                // 
                m_mapPropertys.resolution = Convert.ToDouble(textResolution.Text);
                if (m_mapPropertys.getProjection() == "" || textSRID.Text == m_mapPropertys.getProjection())
                {
                    m_mapPropertys.extent.maxx = Convert.ToDouble(textExtMaxX.Text);
                    m_mapPropertys.extent.maxy = Convert.ToDouble(textExtMaxY.Text);
                    m_mapPropertys.extent.minx = Convert.ToDouble(textExtMinX.Text);
                    m_mapPropertys.extent.miny = Convert.ToDouble(textExtMinY.Text);
                    if(textSRID.Text != "")
                    {
                        try
                        {
                            m_mapPropertys.setProjection(textSRID.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("设置投影异常：" + ex.Message, "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    try
                    {
                        rectObj rect = m_mapPropertys.extent;
                        projectionObj proIn = new projectionObj(m_mapPropertys.getProjection());
                        projectionObj proOut = new projectionObj(textSRID.Text);
                        rect.project(proIn, proOut);
                        m_control.Extents = new Extent(rect.minx, rect.maxx, rect.miny, rect.maxy);
                        //m_control.refreshMap(false);
                        m_mapPropertys.setProjection(textSRID.Text);
                        if (proOut.getUnits() != -1)
                        {
                            m_mapPropertys.units = (MS_UNITS)proOut.getUnits();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("设置投影异常：" + ex.Message, "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                 }

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

            //m_strMapPath = m_mapPropertys.mapfilePath;

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
            catch
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
            catch
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