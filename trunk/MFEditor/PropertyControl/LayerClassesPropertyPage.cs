using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
using OSGeo.MapServer;


using MFEditor.Utils;
using FusionMap.Geodatabase;
using FusionMap.DataSourcesFile;


namespace MFEditor.PropertyControl
{
    public partial class LayerClassesPropertyPage : UserControl, IPropertyPage
    {
        private IEnumerator m_pUniqueEnumerator = null;

        public LayerClassesPropertyPage()
        {
            InitializeComponent();
        }

        #region "Implement IPropertyPage"

        private layerObj m_pLayer = null;
        private layerObj m_pEditLayer = null;
        private symbolSetObj m_pSymbolSet = null;
        private mapObj m_pEditMap = null;
        private bool m_saveSymbolList = false;
        

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
            {
                m_pLayer = inObject as layerObj;
                m_pEditLayer = m_pLayer.clone();
                m_pEditMap = m_pLayer.map.clone();

                StringCollection pFields = Utils.Utility.GetFieldsOfLayer(m_pLayer);

                foreach(string fieldName in pFields)
                {
                    comboBoxClassItem.Items.Add(fieldName);
                    comboBoxLabelItem.Items.Add(fieldName);
                }
                
            }
        }

        #endregion


        /// <summary>
        /// initialize the information used for labelpage
        /// </summary>
        private void Initialize()
        {
            if (m_pEditLayer == null) return;

            int iClassIndex = -1;
            int iLabelIndex = -1;

            if ((m_pEditLayer.classitem != "") && (m_pEditLayer.classitem != null))
            {
                iClassIndex = comboBoxClassItem.FindStringExact(m_pEditLayer.classitem);
                if (iClassIndex == -1)
                {
                    Utility.PostWarning("classitem[" + m_pEditLayer.classitem + "] isn't exist!");
                }
            }

            if ((m_pEditLayer.labelitem != "") && (m_pEditLayer.labelitem != null))
            {
                iLabelIndex = comboBoxClassItem.FindStringExact(m_pEditLayer.labelitem);
                if (iLabelIndex == -1)
                {
                    Utility.PostWarning("classitem[" + m_pEditLayer.classitem + "] isn't exist!");
                }
            }

            comboBoxClassItem.SelectedIndex = iClassIndex;
            comboBoxLabelItem.SelectedIndex = iLabelIndex;
           
            GetClassOfLayer(m_pEditLayer);
        }

        /// <summary>
        /// save the current setting
        /// </summary>
        private void SaveEdit()
        {
            if (m_pEditLayer == null) return;            

            if (m_saveSymbolList)
            {
                for(int i=m_pLayer.map.getNumSymbols();i<m_pEditMap.getNumSymbols();i++)
                {
                    m_pLayer.map.symbolset.appendSymbol(m_pEditMap.symbolset.getSymbol(i));
                }
            }

            int iOriginCount = m_pLayer.numclasses;

            //insert the editlayer's class to origin layer
            for (int i = 0; i < m_pEditLayer.numclasses; i++)
            {
                m_pLayer.insertClass(m_pEditLayer.getClass(i).clone(), i);
            }

            //delete the origin layer's class
            for (int i = 0; i < iOriginCount; i++)
            {
                m_pLayer.removeClass(iOriginCount);
            }
            
        }


        /// <summary>
        /// get eachof the contents of classobj in the layerobj
        /// </summary>
        /// <param name="layer"></param>
        private void GetClassOfLayer(layerObj layer)
        {
            if (layer == null) return;

            int iCount = layer.numclasses;

            dataGridViewClass.AllowUserToAddRows = false;

            if (dataGridViewClass.Rows.Count > 0)
                dataGridViewClass.Rows.Clear();

            for (int i = 0; i < iCount; i++)
            {
                classObj pClass = layer.getClass(i);

                imageObj pSymbolImage = pClass.createLegendIcon(m_pLayer.map, m_pEditLayer,
                    90, 20);

                byte[] buffer = pSymbolImage.getBytes();
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ms.Write(buffer, 0, buffer.Length);                
                Image pBitMap = Image.FromStream(ms);
                ms.Dispose();
                pSymbolImage.Dispose();


                object[] pMetaRow = new object[4];
                pMetaRow[0] = pClass.name;
                pMetaRow[1] = pClass.getExpressionString();
                pMetaRow[2] = pBitMap;

                //indecate if there is a label obj
                if (pClass.label != null)
                    pMetaRow[3] = "YES";
                else
                    pMetaRow[3] = "NO";

                dataGridViewClass.Rows.Add(pMetaRow);

                pClass.Dispose();

            }
        }


        private void GetUniqueValueList()
        {

            //get all the unique value of the classitem           

            if ((m_pEditLayer.classitem == null) || (m_pEditLayer.classitem.Length == 0))
                return;

            //label
            string strDataPath = Utility.GetAbsolutePathOfData(m_pEditLayer);
            IWorkspaceFactory pWsf = new ShapefileWorkspaceFactory();
            IWorkspace pWs = pWsf.OpenFromFile(strDataPath, 0);
            if (pWs != null)
            {
                IFeatureWorkspace pFws = pWs as IFeatureWorkspace;

                string strDataName = System.IO.Path.GetFileNameWithoutExtension(strDataPath);

                IFeatureClass pFeatureClass = pFws.OpenFeatureClass(strDataName);
                if (pFeatureClass != null)
                {
                    ICursor pCursor = pFeatureClass.Search(null, false) as ICursor;

                    IDataStatistics pDataStatistics = new DataStatisticsClass();
                    pDataStatistics.Field = m_pEditLayer.classitem;
                    pDataStatistics.Cursor = pCursor;
                    m_pUniqueEnumerator = pDataStatistics.UniqueValues;
                    //pDataStatistics
                }
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //if (m_pUniqueEnumerator == null)
            //    GetUniqueValueList();
            NewClassForm pNewClass = new NewClassForm(m_pEditLayer, m_pUniqueEnumerator);
            if(pNewClass.ShowDialog() == DialogResult.OK)
                _IsPageDirty = true;
        }

        private void dataGridViewClass_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (m_pEditLayer == null) return;

            if(e.ColumnIndex == 2)
            {
                MFEditor.SymbolSelectorDialog pSelector =
                    new MFEditor.SymbolSelectorDialog(m_pEditMap, m_pEditLayer, m_pEditLayer.getClass(e.RowIndex));
                if (pSelector.ShowDialog() == DialogResult.OK)
                {
                    _IsPageDirty = true;
                    m_saveSymbolList = pSelector.SymbolListChanged;

                    imageObj pSymbolImage = m_pEditLayer.getClass(e.RowIndex).createLegendIcon(m_pEditMap, m_pEditLayer,
                    90, 20);

                    byte[] buffer = pSymbolImage.getBytes();
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    ms.Write(buffer, 0, buffer.Length);
                    dataGridViewClass.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Image.FromStream(ms);
                    ms.Dispose();
                    pSymbolImage.Dispose();
                }
            }
            else if (e.ColumnIndex == 3)
            {
                MessageBox.Show("label");
            }
        }

        private void buttonAddAll_Click(object sender, EventArgs e)
        {
            _IsPageDirty = true;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            _IsPageDirty = true;
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            _IsPageDirty = true;
        }

        /// <summary>
        /// click the label cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //3 is label column
            if(e.ColumnIndex == 3)
            {
                if (m_pEditLayer == null) return;

                classObj pClassObj = m_pEditLayer.getClass(e.RowIndex);
                LabelEditorDialog pDialog = new LabelEditorDialog(pClassObj,m_pEditMap);
                pDialog.ShowDialog();
            }
        }
    }
}
