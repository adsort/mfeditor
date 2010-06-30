using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OSGeo.MapServer;

namespace MFEditor.PropertyControl
{
    public partial class LayerBasicPropertyPage : UserControl, IPropertyPage
    {
        public LayerBasicPropertyPage()
        {
            InitializeComponent();
        }


        #region "Implement IPropertyPage"

        private layerObj m_pLayer = null;

        //if there is a change
        public bool _IsPageDirty = false;
        /// <summary>
        /// active the current page
        /// </summary>
        public void Activate()
        {
            if (m_pLayer == null) return;
            Initialize();
        }

        /// <summary>
        /// apply the current setting
        /// </summary>
        public void Apply()
        {
            if (m_pLayer == null) return;

            SaveEdit();
        }

        /// <summary>
        /// destory the current page
        /// </summary>
        public void Deactivate()
        {
        }

        /// <summary>
        /// return if there is any change of current object
        /// </summary>
        public bool IsPageDirty
        {
            get { return _IsPageDirty; }
        }


        /// <summary>
        /// set the object of the page
        /// </summary>
        /// <param name="inObject"></param>
        public void SetObjects(object inObject)
        {
            if (inObject is layerObj)
                m_pLayer = inObject as layerObj;
        }

        #endregion


        private void Initialize()
        {
            if (m_pLayer == null) return;
            textName.Text = m_pLayer.name;
            textGroup.Text = m_pLayer.group;


            textMinScale.Text = m_pLayer.minscaledenom.ToString();
            textMaxScale.Text = m_pLayer.maxscaledenom.ToString();

            if ((textMinScale.Text == "-1") && (textMaxScale.Text == "-1"))
            {
                radioButtonClearScale.Checked = true;
                radioButtonClearScale_CheckedChanged(null, null);
            }
            else
                radioButtonSetScale.Checked = true;

            int intUnits = Convert.ToInt32(m_pLayer.units);
            if ((intUnits > 0) && (intUnits < comboUnits.Items.Count))
                comboUnits.SelectedIndex = intUnits;      
        }

        private void SaveEdit()
        {
            if (m_pLayer == null) return;

            if (checkInput())
            {
                if (textName.Text.Trim().Length == 0)
                    m_pLayer.name = null;
                else
                    m_pLayer.name = textName.Text;

                if (textGroup.Text.Trim().Length == 0)
                    m_pLayer.group = null;
                else
                    m_pLayer.group = textGroup.Text;


                m_pLayer.minscaledenom = Convert.ToDouble(textMinScale.Text);
                m_pLayer.maxscaledenom = Convert.ToDouble(textMaxScale.Text);

                m_pLayer.units = comboUnits.SelectedIndex;
            }

            

        }

        private bool checkInput()
        {
            //检查用户输入数据是否合法
            if (textName.Text.Trim().Length <= 0)
            {
                MFEditor.Utils.Utility.PostMessage("Name属性不可以为空！");
                textName.Focus();
                return false;
            }


            if (checkScale(textMinScale) == false) return false;
            if (checkScale(textMaxScale) == false) return false;


            if (comboUnits.SelectedIndex == -1)
            {
                MFEditor.Utils.Utility.PostMessage("Units没有设置！");
                return false;
            }

            return true;
        }

        private bool checkScale(TextBox inTextbox)
        {
            try
            {
                int inValue = Convert.ToInt32(inTextbox.Text);

                if (inValue < -1)
                {
                    MFEditor.Utils.Utility.PostMessage("Size的值不合法！");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MFEditor.Utils.Utility.PostMessage("Size的设置不合法:" + ex.Message);
                inTextbox.Focus();
                return false;
            }
        }

        private void radioButtonClearScale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonClearScale.Checked)
            {
                textMinScale.Text = "-1";
                textMinScale.Enabled = false;

                textMaxScale.Text = "-1";
                textMaxScale.Enabled = false;
            }

            _IsPageDirty = true;
        }

        private void radioButtonSetScale_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSetScale.Checked)
            {
                textMinScale.Enabled = true;
                textMaxScale.Enabled = true;
            }

            _IsPageDirty = true;
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            _IsPageDirty = true;
        }

        private void textGroup_TextChanged(object sender, EventArgs e)
        {
            _IsPageDirty = true;
        }

        private void comboUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            _IsPageDirty = true;
        }

        private void textMinScale_TextChanged(object sender, EventArgs e)
        {
            _IsPageDirty = true;
        }

        private void textMaxScale_TextChanged(object sender, EventArgs e)
        {
            _IsPageDirty = true;
        }
    }
}
