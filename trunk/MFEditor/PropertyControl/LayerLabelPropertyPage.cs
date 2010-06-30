using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OSGeo.MapServer;

using MFEditor.Utils;
using FusionMap.Geodatabase;
using FusionMap.DataSourcesFile;


namespace MFEditor.PropertyControl
{
    public partial class LayerLabelPropertyPage : UserControl, IPropertyPage
    {
        public LayerLabelPropertyPage()
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

            //load the label size parameter
            //[integer]|[tiny|small|medium|large|giant]|[attribute]
            comboBoxLabelSize.Items.Add("integer");
            comboBoxLabelSize.Items.Add("attribute");

            //load the label angle parameter
            //double|auto|follow|attribute
            comboBoxLabelAngel.Items.Add("double");
            comboBoxLabelAngel.Items.Add("auto");
            comboBoxLabelAngel.Items.Add("follow");
            comboBoxLabelAngel.Items.Add("attribute");



            //read the layer's fields list
            if (comboBoxLabelItem.Items.Count == 0)
            {
                AddClassExpression();

                //get the current labelitem
                string strLabelItem = m_pLayer.labelitem;
                if ((strLabelItem != null) && (strLabelItem.Length > 0))
                {
                    int iIndex = comboBoxLabelItem.FindStringExact(strLabelItem);
                    if ((iIndex >= 0) && (iIndex < comboBoxLabelItem.Items.Count))
                    {
                        comboBoxLabelItem.SelectedIndex = iIndex;

                        //check the label if on or off
                        //assume if the labelitem is setting then the label is open
                    }
                }

                //check the label method
                bool blnLabelAllFeature = false;
                int iClassCount = m_pLayer.numclasses;
                for (int i = 0; i < iClassCount; i++)
                {
                    classObj pClass = m_pLayer.getClass(i);
                    string strExpression = pClass.getExpressionString();
                    if ((strExpression != null) && (strExpression.Length > 0))
                    {
                        comboBoxLabelExpression.Items.Add(strExpression);
                    }
                    else
                    {
                        //if there is a class with no expression and it's labelobj is not null
                        //then the label all feature is true
                        if (pClass.label != null)
                            blnLabelAllFeature = true;
                    }
                }

                if (blnLabelAllFeature)
                    comboBoxLabelMethod.SelectedIndex = 0;
                else
                    comboBoxLabelMethod.SelectedIndex = 1;
            }
        }

        private void SaveEdit()
        {
            if (m_pLayer == null) return;

            if (comboBoxLabelItem.Text.Trim().Length == 0)
                m_pLayer.labelitem = null;
            else
                m_pLayer.labelitem = comboBoxLabelItem.Text;
        }

        private void comboBoxLabelMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLabelMethod.SelectedIndex == 0)
                groupBoxClassSet.Visible = false;
            else
                groupBoxClassSet.Visible = true;
        }

        private void comboBoxLabelExpression_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLabelExpression.SelectedIndex == -1) return;
            string strExpression = comboBoxLabelExpression.SelectedItem.ToString();

            //bool blnLabelAllFeature = false;
            //int iClassCount = m_currentLayer.numclasses;
            //for (int i = 0; i < iClassCount; i++)
            //{
            //    classObj pClass = m_currentLayer.getClass(i);
            //    string strExpression = pClass.getExpressionString();
            //    if ((strExpression != null) && (strExpression.Length > 0))
            //    {
            //        comboBoxLabelExpression.Items.Add(strExpression);
            //    }
            //    else
            //    {
            //        //if there is a class with no expression and it's labelobj is not null
            //        //then the label all feature is true
            //        if (pClass.label != null)
            //            blnLabelAllFeature = true;
            //    }
            //}
        }


        /// <summary>
        /// add the class expression to the comboBoxLabelExpression
        /// </summary>
        private void AddClassExpression()
        {
            //read the layer's fields list
            comboBoxLabelItem.Items.Clear();

            //used for cancel the labelitem
            comboBoxLabelItem.Items.Add("");
            //label
            string strDataPath = Utility.GetAbsolutePathOfData(m_pLayer);
            IWorkspaceFactory pWsf = new ShapefileWorkspaceFactory();
            IWorkspace pWs = pWsf.OpenFromFile(strDataPath, 0);
            if (pWs != null)
            {
                IFeatureWorkspace pFws = pWs as IFeatureWorkspace;

                string strDataName = System.IO.Path.GetFileNameWithoutExtension(strDataPath);

                IFeatureClass pFeatureClass = pFws.OpenFeatureClass(strDataName);
                if (pFeatureClass != null)
                {
                    IFields pFields = pFeatureClass.Fields;
                    int iCount = pFields.FiledCount;
                    for (int i = 0; i < iCount; i++)
                    {
                        string strName = pFields.GetField(i).Name;
                        comboBoxLabelItem.Items.Add(strName);
                        comboBoxItemAngle.Items.Add(strName);
                        comboBoxItemSize.Items.Add(strName);
                    }
                }
            }
        }
    }
}
