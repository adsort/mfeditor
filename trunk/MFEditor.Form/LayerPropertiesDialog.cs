using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using System.Collections;

using OSGeo.MapServer;

using MFEditor.Utils;
using MFEditor.PropertyControl;

namespace MFEditorUI
{
    public partial class LayerPropertiesDialog : Form
    {
        private layerObj m_currentLayer = null;

        public LayerPropertiesDialog()
        {
            InitializeComponent();
        }

        public LayerPropertiesDialog(layerObj inLayer)
        {
            InitializeComponent();
            m_currentLayer = inLayer;           
        }   
        private void formLayerSet_Load(object sender, EventArgs e)
        {
            if (m_currentLayer == null)
            {                
                Utility.PostMessage("layerobj is null!");
                this.Close();
            }


            
            tabControl1_SelectedIndexChanged(null, null);           

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            
            if (tabPageMeta.Controls.Count > 0)
            {
                IPropertyPage pProperty = tabPageMeta.Controls[0] as IPropertyPage;
                if (pProperty.IsPageDirty)
                    pProperty.Apply();               

            }
            if (tabPageBasic.Controls.Count > 0)
            {
                IPropertyPage pProperty = tabPageBasic.Controls[0] as IPropertyPage;
                if (pProperty.IsPageDirty)
                    pProperty.Apply();   

            }
            if (tabPageData.Controls.Count > 0)
            {
                IPropertyPage pProperty = tabPageData.Controls[0] as IPropertyPage;
                if (pProperty.IsPageDirty)
                    pProperty.Apply();   

            }
            if (tabPageClass.Controls.Count > 0)
            {
                IPropertyPage pProperty = tabPageClass.Controls[0] as IPropertyPage;
                if (pProperty.IsPageDirty)
                    pProperty.Apply();   

            }
            if (tabPageLabel.Controls.Count > 0)
            {
                IPropertyPage pProperty = tabPageLabel.Controls[0] as IPropertyPage;
                if (pProperty.IsPageDirty)
                    pProperty.Apply();   

            }
   
        

            this.DialogResult = DialogResult.OK;           
        }       
       

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(m_currentLayer==null) return;

            string strCurTab = tabControl1.SelectedTab.Text;

            switch (strCurTab)
            {
                case "Metadata":
                    if (tabPageMeta.Controls.Count == 0)
                    {
                        IPropertyPage pProperty = new MetadataPropertyPage();
                        pProperty.SetObjects(m_currentLayer);
                        pProperty.Activate();
                        tabPageMeta.Controls.Add(pProperty as Control);

                    }
                    break;
                case "Basic":
                    if (tabPageBasic.Controls.Count == 0)
                    {
                        IPropertyPage pProperty = new LayerBasicPropertyPage();
                        pProperty.SetObjects(m_currentLayer);
                        pProperty.Activate();
                        tabPageBasic.Controls.Add(pProperty as Control);

                    }
                    break;
                case "Data":
                    if (tabPageData.Controls.Count == 0)
                    {
                        IPropertyPage pProperty = new LayerDataPropertyPage();
                        pProperty.SetObjects(m_currentLayer);
                        pProperty.Activate();
                        tabPageData.Controls.Add(pProperty as Control);

                    }
                    break;
                case "Class":
                    if (tabPageClass.Controls.Count == 0)
                    {
                        IPropertyPage pProperty = new LayerClassesPropertyPage();
                        pProperty.SetObjects(m_currentLayer);
                        pProperty.Activate();
                        tabPageClass.Controls.Add(pProperty as Control);

                    }
                    break;
                case "Label":
                    if (tabPageLabel.Controls.Count == 0)
                    {
                        IPropertyPage pProperty = new LayerLabelPropertyPage();
                        pProperty.SetObjects(m_currentLayer);
                        pProperty.Activate();
                        tabPageLabel.Controls.Add(pProperty as Control);

                    }
                    break;
            }          
            
        }
        

        private void buttonAdvantage_Click(object sender, EventArgs e)
        {
            //启动一个包含Layer全部参数设置的窗口，给高级用户使用
            
            if(Utility.PostQuestion("是否保留当前修改？") == DialogResult.Yes)
            {

            }
        }
    }
}