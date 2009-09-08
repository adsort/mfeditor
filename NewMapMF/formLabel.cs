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
    public partial class formLabel : Form
    {
        private IMcLabel m_curLabel = null;
        private IMcLayer m_curLayer = null;
        private bool m_blnLayerLabel = true;
        

        public formLabel(IMcLabel inLabel,McLayer inLayer)
        {
            InitializeComponent();
            m_curLabel = inLabel;
            m_curLayer = inLayer;
        }

        public formLabel(IMcLayer inLayer)
        {
            InitializeComponent();
            m_curLayer = inLayer;
            m_blnLayerLabel = true;
        }

        private void formLabel_Load(object sender, EventArgs e)
        {
            if (m_curLayer == null)
            {
                this.Close();
                return;
            }

            string strFields = m_curLayer.FieldNames;
            string[] strFieldsList = strFields.Split(',');

            foreach (string strName in strFieldsList)
            {
                comboBoxLabelItem.Items.Add(strName);
            }

            //comboBoxFontType.SelectedIndex = 0;
            comboBoxLabelItem.Text = m_curLayer.LabelItem;

            if (m_blnLayerLabel)
            {
                ILayerLabel inLabel = m_curLayer.Label;
                if (inLabel == null)
                {
                    this.Close();
                    return;
                }
                comboBoxFont.Text = inLabel.Font;
                numericUpDownSize.Value = inLabel.Size;
                //comboBoxEncoding.Text = inLabel.Encoding;
                buttonColor.BackColor = ColorTranslator.FromOle((int)inLabel.Color);

                int intPos = Convert.ToInt32(inLabel.Position);

                if (intPos > 10)
                    comboBoxPostion.SelectedIndex = -1;
                else
                    comboBoxPostion.SelectedIndex = intPos;

                numericUpDownBuffer.Value = inLabel.Buffer;

                if (inLabel.Antialias == mcStatus.mc_ON)
                    comboBoxAntialias.SelectedIndex = 0;
                else
                    comboBoxAntialias.SelectedIndex = 1;

                if (inLabel.Force == mcStatus.mc_ON)
                    comboBoxForce.SelectedIndex = 0;
                else
                    comboBoxForce.SelectedIndex = 1;
                
            }
            else
            {
                if (m_curLabel == null)
                {
                    this.Close();
                    return;
                }  

                comboBoxFont.Text = m_curLabel.Font;

                numericUpDownSize.Value = m_curLabel.Size;

                //comboBoxEncoding.Text = m_curLabel.Encoding;

                buttonColor.BackColor = ColorTranslator.FromOle((int)m_curLabel.Color);


                int intPos = Convert.ToInt32(m_curLabel.Position);

                if (intPos > 10)
                    comboBoxPostion.SelectedIndex = -1;
                else
                    comboBoxPostion.SelectedIndex = intPos;

                numericUpDownBuffer.Value = m_curLabel.Buffer;

                if (m_curLabel.Antialias == mcStatus.mc_ON)
                    comboBoxAntialias.SelectedIndex = 0;
                else
                    comboBoxAntialias.SelectedIndex = 1;

                if (m_curLabel.Force == mcStatus.mc_ON)
                    comboBoxForce.SelectedIndex = 0;
                else
                    comboBoxForce.SelectedIndex = 1;
            }

            if (comboBoxFont.SelectedIndex == -1)
                comboBoxFont.SelectedIndex = 0;

            if (Convert.ToInt32(numericUpDownSize.Value) <= 0)
            {
                numericUpDownSize.Value = 10;
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (checkValue())
            {
                if (m_blnLayerLabel)
                {
                    LayerLabel myLayerLabel = new LayerLabelClass();
                    m_curLayer.LabelItem = comboBoxLabelItem.Text;
                    myLayerLabel.Type = mcFonttype.mcFtruetype;
                    myLayerLabel.Font = comboBoxFont.Text;
                    //myLayerLabel.Angle = 0;
                    myLayerLabel.Size = Convert.ToInt32(numericUpDownSize.Value);
                    myLayerLabel.Encoding = "GBK";
                    //myLayerLabel.AutoAngle = mcStatus.mc_ON;


                    myLayerLabel.Color = (uint)ColorTranslator.ToOle(buttonColor.BackColor);

                    myLayerLabel.Position = (mcPosition)comboBoxPostion.SelectedIndex;

                    myLayerLabel.Buffer = Convert.ToInt32(numericUpDownBuffer.Value);

                    if (comboBoxAntialias.SelectedIndex == 0)
                        myLayerLabel.Antialias = mcStatus.mc_ON;
                    else
                        myLayerLabel.Antialias = mcStatus.mc_OFF;

                    if (comboBoxForce.SelectedIndex == 0)
                        myLayerLabel.Force = mcStatus.mc_ON;
                    else
                        myLayerLabel.Force = mcStatus.mc_OFF;

                    m_curLayer.Label = myLayerLabel;
                }
                else
                {
                    m_curLayer.LabelItem = comboBoxLabelItem.Text;
                    m_curLabel.Type = mcFonttype.mcFtruetype;
                    m_curLabel.Font = comboBoxFont.Text;
                    m_curLabel.Angle = 0;
                    m_curLabel.Size = Convert.ToInt32(numericUpDownSize.Value);
                    m_curLabel.Encoding = "GBK";
                    m_curLabel.AutoAngle = mcStatus.mc_ON;


                    m_curLabel.Color = (uint)ColorTranslator.ToOle(buttonColor.BackColor);

                    m_curLabel.Position = (mcPosition)comboBoxPostion.SelectedIndex;

                    m_curLabel.Buffer = Convert.ToInt32(numericUpDownBuffer.Value);

                    if (comboBoxAntialias.SelectedIndex == 0)
                        m_curLabel.Antialias = mcStatus.mc_ON;
                    else
                        m_curLabel.Antialias = mcStatus.mc_OFF;

                    if (comboBoxForce.SelectedIndex == 0)
                        m_curLabel.Force = mcStatus.mc_ON;
                    else
                        m_curLabel.Force = mcStatus.mc_OFF;
                    
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private bool checkValue()
        {
            //检查设置的输入值是否合法
            if (comboBoxLabelItem.Text.Trim().Length <= 0)
            {
                MessageBox.Show("LabelItem属性必须设置！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                comboBoxLabelItem.Focus();
                return false;
            }


            //if (comboBoxFontType.SelectedIndex != 0)
            //{
            //    MessageBox.Show("FontType目前只支持TrueType！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    comboBoxFontType.Focus();
            //    return false;
            //}

            if (Convert.ToInt32(numericUpDownSize.Value) <= 0)
            {
                MessageBox.Show("Font字体大小不合法！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDownSize.Focus();
                return false;
            }

            return true;
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog myColor = new ColorDialog();
            if (myColor.ShowDialog() == DialogResult.OK)
            {
                buttonColor.BackColor = myColor.Color;
            }
        }

       

       

    }
}