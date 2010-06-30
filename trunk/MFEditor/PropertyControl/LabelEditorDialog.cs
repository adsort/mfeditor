using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OSGeo.MapServer;
using MFEditor.Utils;

namespace MFEditor.PropertyControl
{
    public partial class LabelEditorDialog : Form
    {
        private labelObj m_pLabel = null;
        private mapObj m_pMap = null;
        private classObj m_pClass = null;

        public LabelEditorDialog(classObj inClass, mapObj map)
            : this(inClass)
        {
            m_pMap = map;            

            if(m_pMap != null)
            {
                //add all the font int fontlist to the combox
                hashTableObj pFontList = m_pMap.fontset.fonts;
                string value = pFontList.nextKey(null);
                while(value != null)
                {
                    comboBoxFont.Items.Add(value);
                    value = pFontList.nextKey(value);
                }

            }
        }

        public LabelEditorDialog(classObj inClass)
        {
            InitializeComponent();
            m_pLabel = inClass.label;
            m_pClass = inClass;
        }

        /// <summary>
        /// show the labelobj's value
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        private bool InitializeLabel(labelObj label)
        {
            if (label == null) return false;

            try
            {
                //read the angle info of the label
                if (label.autoangle != 0)
                    comboBoxAngle.Text = "auto";
                else if (label.autofollow != 0)
                    comboBoxAngle.Text = "follow";
                else
                    comboBoxAngle.Text = label.angle.ToString();


                //color info
                ButtonColor.ButtonColor =
                    Color.FromArgb(label.color.red, label.color.green, label.color.blue);


                //size info
                if (label.size == -1)
                    checkBoxShowLabel.Checked = false;
                else
                    checkBoxShowLabel.Checked = true;

                numericUpDownSize.Value = (decimal)label.size;

                //max and min size
                numericUpDownMaxSize.Value = (decimal)label.maxsize;
                numericUpDownMinSize.Value = (decimal)label.minsize;

                //position
                string strPosition = ((MS_POSITIONS_ENUM)label.position).ToString();
                if (strPosition.Length > 0)
                {
                    string[] strValues = strPosition.Split('_');
                    if (strValues.Length == 2)
                        comboBoxPosition.SelectedIndex = comboBoxPosition.FindString(strValues[1]);
                }

                //mindistance
                numericUpDownMinDist.Value = (decimal)label.mindistance;

                //antialias
                comboBoxAntiAlias.SelectedIndex = label.antialias;

                //partials
                comboBoxPartials.SelectedIndex = label.partials;


                //encoding
                textBoxEncoding.Text = label.encoding;

                //font
                if (label.font != null)
                {
                    comboBoxFont.SelectedIndex = comboBoxFont.FindString(label.font);
                }

                //font type
                if (label.type == MS_FONT_TYPE.MS_BITMAP)
                    comboBoxType.SelectedIndex = 0;
                else if (label.type == MS_FONT_TYPE.MS_TRUETYPE)
                    comboBoxType.SelectedIndex = 1;


                //align
                string sAlign = ((MS_ALIGN_VALUE)label.align).ToString();
                string[] sAligns = sAlign.Split('_');
                if (sAligns.Length == 3)
                {
                    comboBoxAlign.SelectedIndex = comboBoxAlign.FindString(sAligns[2]);
                }

                //wrap
                textBoxWarp.Text = label.wrap.ToString();

                //maxlength
                numericUpDownMaxLength.Value = (decimal)label.maxlength;


                //force
                comboBoxForce.SelectedIndex = label.force;

                //priority
                comboBoxPriority.SelectedIndex = label.priority - 1;

                //minfeaturesize
                if (label.autominfeaturesize != 0)
                {
                    comboBoxMinFeatureSize.SelectedIndex = 0;
                }
                else
                    comboBoxMinFeatureSize.Text = label.minfeaturesize.ToString();

                //buffer
                numericUpDownBuffer.Value = (decimal)label.buffer;

                //shadow color 
                if ((label.shadowcolor.red == -1) || (label.shadowcolor.green == -1) ||
                    (label.shadowcolor.blue == -1))
                {
                    ButtonShadowColor.ButtonColor = Color.Transparent;
                }
                else
                {
                    ButtonShadowColor.ButtonColor =
        Color.FromArgb(label.shadowcolor.red, label.shadowcolor.green, label.shadowcolor.blue);

                }

                //shadow size
                numericUpDownShadowSizeX.Value = (decimal)label.shadowsizex;
                numericUpDownShadowSizeY.Value = (decimal)label.shadowsizey;

                //outline color 
                if ((label.outlinecolor.red == -1) || (label.outlinecolor.green == -1) ||
                    (label.outlinecolor.blue == -1))
                {
                    ButtonOutLineColor.ButtonColor = Color.Transparent;
                }
                else
                {
                    ButtonOutLineColor.ButtonColor =
        Color.FromArgb(label.outlinecolor.red, label.outlinecolor.green, label.outlinecolor.blue);

                }

                //outline width
                numericUpDownOutlineWidth.Value = (decimal)label.outlinewidth;


                //backgorundcolor color 
                if ((label.backgroundcolor.red == -1) || (label.backgroundcolor.green == -1) ||
                    (label.backgroundcolor.blue == -1))
                {
                    ButtonBGColor.ButtonColor = Color.Transparent;
                }
                else
                {
                    ButtonBGColor.ButtonColor =
        Color.FromArgb(label.backgroundcolor.red, label.backgroundcolor.green, label.backgroundcolor.blue);

                }

                //backgorundshadowcolor color 
                if ((label.backgroundshadowcolor.red == -1) || (label.backgroundshadowcolor.green == -1) ||
                    (label.backgroundshadowcolor.blue == -1))
                {
                    ButtonBGSColor.ButtonColor = Color.Transparent;
                }
                else
                {
                    ButtonBGSColor.ButtonColor =
        Color.FromArgb(label.backgroundshadowcolor.red, label.backgroundshadowcolor.green, label.backgroundshadowcolor.blue);

                }


                //backgroundshadowsize 
                numericUpDownBGSSizeX.Value = (decimal)label.backgroundshadowsizex;
                numericUpDownBGSSizeY.Value = (decimal)label.backgroundshadowsizey;


            }
            catch(Exception ex)
            {
                Utility.PostWarning(ex.Message);
            }         

            return true;


        }

        private void LabelEditorDialog_Load(object sender, EventArgs e)
        {            
            InitializeLabel(m_pLabel);                
        }



        private void ButtonColor_Click(object sender, EventArgs e)
        {
            IColorSelector selector = new ColorSelector();
            selector.Color = ((ColorButton)sender).ButtonColor;
            selector.Location = base.PointToScreen(new Point(((ColorButton)sender).Left, ((ColorButton)sender).Bottom));
            if (selector.DoModal())
            {
                ((ColorButton)sender).ButtonColor = selector.Color;                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (m_pLabel == null) return;
            if (!CheckValue()) return;

            if (checkBoxShowLabel.Checked == false)
            {
                m_pClass.label.size = -1;
            }
            else
            {
                try
                {
                    //set the angle info of the label
                    if (comboBoxAngle.Text == "auto")
                    {
                        m_pLabel.autoangle = 1;
                        m_pLabel.autofollow = 0;
                        m_pLabel.angle = -1;
                    }
                    else if (comboBoxAngle.Text == "follow")
                    {
                        m_pLabel.autoangle = 0;
                        m_pLabel.autofollow = 1;
                        m_pLabel.angle = -1;
                    }
                    else
                    {
                        m_pLabel.angle = double.Parse(comboBoxAngle.Text);
                    }


                    //        //color info
                    //        ButtonColor.ButtonColor =
                    //            Color.FromArgb(label.color.red, label.color.green, label.color.blue);


                    //        //size info
                    //        numericUpDownSize.Value = (decimal)label.size;

                    //        //max and min size
                    //        numericUpDownMaxSize.Value = (decimal)label.maxsize;
                    //        numericUpDownMinSize.Value = (decimal)label.minsize;

                    //        //position
                    //        string strPosition = ((MS_POSITIONS_ENUM)label.position).ToString();
                    //        if (strPosition.Length > 0)
                    //        {
                    //            string[] strValues = strPosition.Split('_');
                    //            if (strValues.Length == 2)
                    //                comboBoxPosition.SelectedIndex = comboBoxPosition.FindString(strValues[1]);
                    //        }

                    //        //mindistance
                    //        numericUpDownMinDist.Value = (decimal)label.mindistance;

                    //        //antialias
                    //        comboBoxAntiAlias.SelectedIndex = label.antialias;

                    //        //partials
                    //        comboBoxPartials.SelectedIndex = label.partials;


                    //        //encoding
                    //        textBoxEncoding.Text = label.encoding;

                    //        //font
                    //        if (label.font != null)
                    //        {
                    //            comboBoxFont.SelectedIndex = comboBoxFont.FindString(label.font);
                    //        }

                    //        //font type
                    //        if (label.type == MS_FONT_TYPE.MS_BITMAP)
                    //            comboBoxType.SelectedIndex = 0;
                    //        else if (label.type == MS_FONT_TYPE.MS_TRUETYPE)
                    //            comboBoxType.SelectedIndex = 1;


                    //        //align
                    //        string sAlign = ((MS_ALIGN_VALUE)label.align).ToString();
                    //        string[] sAligns = sAlign.Split('_');
                    //        if (sAligns.Length == 3)
                    //        {
                    //            comboBoxAlign.SelectedIndex = comboBoxAlign.FindString(sAligns[2]);
                    //        }

                    //        //wrap
                    //        textBoxWarp.Text = label.wrap.ToString();

                    //        //maxlength
                    //        numericUpDownMaxLength.Value = (decimal)label.maxlength;


                    //        //force
                    //        comboBoxForce.SelectedIndex = label.force;

                    //        //priority
                    //        comboBoxPriority.SelectedIndex = label.priority - 1;

                    //        //minfeaturesize
                    //        if (label.autominfeaturesize != 0)
                    //        {
                    //            comboBoxMinFeatureSize.SelectedIndex = 0;
                    //        }
                    //        else
                    //            comboBoxMinFeatureSize.Text = label.minfeaturesize.ToString();

                    //        //buffer
                    //        numericUpDownBuffer.Value = (decimal)label.buffer;

                    //        //shadow color 
                    //        if ((label.shadowcolor.red == -1) || (label.shadowcolor.green == -1) ||
                    //            (label.shadowcolor.blue == -1))
                    //        {
                    //            ButtonShadowColor.ButtonColor = Color.Transparent;
                    //        }
                    //        else
                    //        {
                    //            ButtonShadowColor.ButtonColor =
                    //Color.FromArgb(label.shadowcolor.red, label.shadowcolor.green, label.shadowcolor.blue);

                    //        }

                    //        //shadow size
                    //        numericUpDownShadowSizeX.Value = (decimal)label.shadowsizex;
                    //        numericUpDownShadowSizeY.Value = (decimal)label.shadowsizey;

                    //        //outline color 
                    //        if ((label.outlinecolor.red == -1) || (label.outlinecolor.green == -1) ||
                    //            (label.outlinecolor.blue == -1))
                    //        {
                    //            ButtonOutLineColor.ButtonColor = Color.Transparent;
                    //        }
                    //        else
                    //        {
                    //            ButtonOutLineColor.ButtonColor =
                    //Color.FromArgb(label.outlinecolor.red, label.outlinecolor.green, label.outlinecolor.blue);

                    //        }

                    //        //outline width
                    //        numericUpDownOutlineWidth.Value = (decimal)label.outlinewidth;


                    //        //backgorundcolor color 
                    //        if ((label.backgroundcolor.red == -1) || (label.backgroundcolor.green == -1) ||
                    //            (label.backgroundcolor.blue == -1))
                    //        {
                    //            ButtonBGColor.ButtonColor = Color.Transparent;
                    //        }
                    //        else
                    //        {
                    //            ButtonBGColor.ButtonColor =
                    //Color.FromArgb(label.backgroundcolor.red, label.backgroundcolor.green, label.backgroundcolor.blue);

                    //        }

                    //        //backgorundshadowcolor color 
                    //        if ((label.backgroundshadowcolor.red == -1) || (label.backgroundshadowcolor.green == -1) ||
                    //            (label.backgroundshadowcolor.blue == -1))
                    //        {
                    //            ButtonBGSColor.ButtonColor = Color.Transparent;
                    //        }
                    //        else
                    //        {
                    //            ButtonBGSColor.ButtonColor =
                    //Color.FromArgb(label.backgroundshadowcolor.red, label.backgroundshadowcolor.green, label.backgroundshadowcolor.blue);

                    //        }


                    //        //backgroundshadowsize 
                    //        numericUpDownBGSSizeX.Value = (decimal)label.backgroundshadowsizex;
                    //        numericUpDownBGSSizeY.Value = (decimal)label.backgroundshadowsizey;


                }
                catch (Exception ex)
                {
                    Utility.PostWarning(ex.Message);
                }
            }
        }

        /// <summary>
        /// check if the input value is valid
        /// </summary>
        /// <returns></returns>
        private bool CheckValue()
        {
            try
            {
                //set the angle info of the label
                if ((comboBoxAngle.Text != "auto")&&(comboBoxAngle.Text != "follow"))
                {
                    try
                    {
                        double dTemp = double.Parse(comboBoxAngle.Text);
                    }
                    catch
                    {
                        Utility.PostWarning("Angle value is invalid!");
                        comboBoxAngle.Focus();
                        return false;
                    }
                }

                //check the size value
                if((checkBoxShowLabel.Checked)&&((int)numericUpDownSize.Value == -1))
                {
                    Utility.PostWarning("Size must bigger than -1!");
                    numericUpDownSize.Focus();
                    return false;
                }               


        //        //max and min size
        //        numericUpDownMaxSize.Value = (decimal)label.maxsize;
        //        numericUpDownMinSize.Value = (decimal)label.minsize;

        //        //position
        //        string strPosition = ((MS_POSITIONS_ENUM)label.position).ToString();
        //        if (strPosition.Length > 0)
        //        {
        //            string[] strValues = strPosition.Split('_');
        //            if (strValues.Length == 2)
        //                comboBoxPosition.SelectedIndex = comboBoxPosition.FindString(strValues[1]);
        //        }

        //        //mindistance
        //        numericUpDownMinDist.Value = (decimal)label.mindistance;

        //        //antialias
        //        comboBoxAntiAlias.SelectedIndex = label.antialias;

        //        //partials
        //        comboBoxPartials.SelectedIndex = label.partials;


        //        //encoding
        //        textBoxEncoding.Text = label.encoding;

        //        //font
        //        if (label.font != null)
        //        {
        //            comboBoxFont.SelectedIndex = comboBoxFont.FindString(label.font);
        //        }

        //        //font type
        //        if (label.type == MS_FONT_TYPE.MS_BITMAP)
        //            comboBoxType.SelectedIndex = 0;
        //        else if (label.type == MS_FONT_TYPE.MS_TRUETYPE)
        //            comboBoxType.SelectedIndex = 1;


        //        //align
        //        string sAlign = ((MS_ALIGN_VALUE)label.align).ToString();
        //        string[] sAligns = sAlign.Split('_');
        //        if (sAligns.Length == 3)
        //        {
        //            comboBoxAlign.SelectedIndex = comboBoxAlign.FindString(sAligns[2]);
        //        }

        //        //wrap
        //        textBoxWarp.Text = label.wrap.ToString();

        //        //maxlength
        //        numericUpDownMaxLength.Value = (decimal)label.maxlength;


        //        //force
        //        comboBoxForce.SelectedIndex = label.force;

        //        //priority
        //        comboBoxPriority.SelectedIndex = label.priority - 1;

        //        //minfeaturesize
        //        if (label.autominfeaturesize != 0)
        //        {
        //            comboBoxMinFeatureSize.SelectedIndex = 0;
        //        }
        //        else
        //            comboBoxMinFeatureSize.Text = label.minfeaturesize.ToString();

        //        //buffer
        //        numericUpDownBuffer.Value = (decimal)label.buffer;

        //        //shadow color 
        //        if ((label.shadowcolor.red == -1) || (label.shadowcolor.green == -1) ||
        //            (label.shadowcolor.blue == -1))
        //        {
        //            ButtonShadowColor.ButtonColor = Color.Transparent;
        //        }
        //        else
        //        {
        //            ButtonShadowColor.ButtonColor =
        //Color.FromArgb(label.shadowcolor.red, label.shadowcolor.green, label.shadowcolor.blue);

        //        }

        //        //shadow size
        //        numericUpDownShadowSizeX.Value = (decimal)label.shadowsizex;
        //        numericUpDownShadowSizeY.Value = (decimal)label.shadowsizey;

        //        //outline color 
        //        if ((label.outlinecolor.red == -1) || (label.outlinecolor.green == -1) ||
        //            (label.outlinecolor.blue == -1))
        //        {
        //            ButtonOutLineColor.ButtonColor = Color.Transparent;
        //        }
        //        else
        //        {
        //            ButtonOutLineColor.ButtonColor =
        //Color.FromArgb(label.outlinecolor.red, label.outlinecolor.green, label.outlinecolor.blue);

        //        }

        //        //outline width
        //        numericUpDownOutlineWidth.Value = (decimal)label.outlinewidth;


        //        //backgorundcolor color 
        //        if ((label.backgroundcolor.red == -1) || (label.backgroundcolor.green == -1) ||
        //            (label.backgroundcolor.blue == -1))
        //        {
        //            ButtonBGColor.ButtonColor = Color.Transparent;
        //        }
        //        else
        //        {
        //            ButtonBGColor.ButtonColor =
        //Color.FromArgb(label.backgroundcolor.red, label.backgroundcolor.green, label.backgroundcolor.blue);

        //        }

        //        //backgorundshadowcolor color 
        //        if ((label.backgroundshadowcolor.red == -1) || (label.backgroundshadowcolor.green == -1) ||
        //            (label.backgroundshadowcolor.blue == -1))
        //        {
        //            ButtonBGSColor.ButtonColor = Color.Transparent;
        //        }
        //        else
        //        {
        //            ButtonBGSColor.ButtonColor =
        //Color.FromArgb(label.backgroundshadowcolor.red, label.backgroundshadowcolor.green, label.backgroundshadowcolor.blue);

        //        }


        //        //backgroundshadowsize 
        //        numericUpDownBGSSizeX.Value = (decimal)label.backgroundshadowsizex;
        //        numericUpDownBGSSizeY.Value = (decimal)label.backgroundshadowsizey;


            }
            catch (Exception ex)
            {
                Utility.PostWarning(ex.Message);
            }

            return true;


        }

    }
}