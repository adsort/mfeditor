using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OSGeo.MapServer;
using System.Configuration;

namespace MFEditor
{
    public partial class SymbolSelectorDialog : Form
    {
        private mapObj m_pDefaultMap = null;//map used for loading the symbollist
        private layerObj m_pCurrentLayer = null;
        private classObj m_pEditingClass = null;
        private classObj m_pCurrentClass = null;
        private int m_iClassIndex = 0;
        private SymbolOptionsControl m_pSymbolOptions = null;
        private MS_LAYER_TYPE m_LayerType = MS_LAYER_TYPE.MS_LAYER_POINT;
        private bool _SymbolListChanged = false;
        private mapObj _EditMap = null;//map use for tempedit.sometimes layer.map will be null
        //for example:use layer.clone()


        public SymbolSelectorDialog(layerObj layer)
        {
            InitializeComponent();
            if (layer != null)
            {
                m_pCurrentLayer = layer;
                m_pCurrentClass = layer.getClass(0);
                m_pEditingClass = m_pCurrentClass.clone();
                m_LayerType = layer.type;
            }
        }

        /// <summary>
        /// struction function
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="index">there are more than 1 classes in layerobj,
        /// use index to specify which class to use</param>
        public SymbolSelectorDialog(layerObj layer, classObj inClass)
            : this(layer)
        {

            m_pCurrentClass = inClass;
            m_pEditingClass = m_pCurrentClass.clone();
        }

        public SymbolSelectorDialog(mapObj map, layerObj layer, classObj inClass)
            : this(layer, inClass)
        {
            _EditMap = map;
        }


        ~SymbolSelectorDialog()
        {
            if (m_pDefaultMap != null)
                m_pDefaultMap.Dispose();

            if (m_pEditingClass != null)
                m_pEditingClass.Dispose();

            if (m_pSymbolOptions != null)
            {
                m_pSymbolOptions.Dispose();
            }
        }

        /// <summary>
        /// set the current map's symbolset
        /// </summary>
        /// <param name="map"></param>
        private void SetSymbolSet(mapObj map)
        {
            if (map == null) return;

            string strSymbolPath = System.Configuration.ConfigurationManager.AppSettings["symbolpath"];
            if (strSymbolPath.Length == 0)
                strSymbolPath = "symbols\\symbols.sym";

            strSymbolPath = Application.StartupPath + "\\" + strSymbolPath;

            string strFontSet = System.Configuration.ConfigurationManager.AppSettings["fontpath"];
            if (strFontSet.Length == 0)
                strFontSet = "data\\fonts\\fonts.list";

            strFontSet = Application.StartupPath + "\\" + strFontSet;

            try
            {                
                map.setSymbolSet(strSymbolPath);                
            }
            catch (Exception ex)
            {
                MFEditor.ErrorDialog myErr = new MFEditor.ErrorDialog(strSymbolPath + "\r\n" + ex.Message);
                myErr.ShowDialog();
                this.Close();
            }

            try
            {
                map.setFontSet(strFontSet);
            }
            catch (Exception ex)
            {
                MFEditor.ErrorDialog myErr = new MFEditor.ErrorDialog(strFontSet + "\r\n" + ex.Message);
                myErr.ShowDialog();
                this.Close();
            }

            

            
        }

        private void formSymbolSelector_Load(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            if (m_pCurrentLayer == null)
                this.Close();
            
            listViewSymbol.Items.Clear();
            imageListPreview.Images.Clear();

            //load the symbol.sym to default map
            if (m_pDefaultMap == null)
            {
                m_pDefaultMap = new mapObj("");
            }

            SetSymbolSet(m_pDefaultMap);


            LoadCurrentSymbol();

            if (m_pSymbolOptions == null)
            {
                if (m_LayerType == MS_LAYER_TYPE.MS_LAYER_POINT)
                {
                    m_pSymbolOptions = new PointSymbolOptionsControl();
                }
                else if (m_LayerType == MS_LAYER_TYPE.MS_LAYER_LINE)
                {
                    m_pSymbolOptions = new LineSymbolOptionsControl();
                }
                else if (m_LayerType == MS_LAYER_TYPE.MS_LAYER_POLYGON)
                {
                    m_pSymbolOptions = new FillSymbolOptionsControl();
                }
                else
                {
                    MessageBox.Show("不支持该类型的符号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                m_pSymbolOptions.OnValueChanged += new OnValueChangedEventHandler(SymbolOption_OnValueChanged);

            }

            m_pSymbolOptions.Symbol = m_pEditingClass.getStyle(0);
            groupBoxOption.Controls.Clear();
            m_pSymbolOptions.Location = new Point(10, 10);//the position in option groupbox

            m_pSymbolOptions.Height = groupBoxOption.Height - 20;
            groupBoxOption.Controls.Add((System.Windows.Forms.Control)m_pSymbolOptions);

            LoadSymbolFromLib();

            if (listViewSymbol.Items.Count > 0)
                listViewSymbol.Items[0].Selected = true;

        }

        /// <summary>
        /// callback functon used when the classobj's parameter is changed
        /// </summary>
        private void SymbolOption_OnValueChanged()
        {
            if (m_pDefaultMap == null) return;

            DrawSymbol2Preview();
        }

        /// <summary>
        /// draw the current classobj to previewbox
        /// </summary>
        private void DrawSymbol2Preview()
        {
            //the color must be reset with a new colorObj,otherwise is will draw with a black(0,0,0)
            //althouth the style.color's value is not black.
            //i don't know why?
            m_pEditingClass.getStyle(0).color = new colorObj(m_pSymbolOptions.SymbolColor.R
                , m_pSymbolOptions.SymbolColor.G, m_pSymbolOptions.SymbolColor.B, 0);           

            pictureBoxPreview.Image = 
                GetImageFromClass(m_pEditingClass, pictureBoxPreview.Width, pictureBoxPreview.Height);
        }

        /// <summary>
        /// get a csharp image from the ms classobj
        /// </summary>
        /// <param name="msClass"></param>
        /// <param name="imageWidth"></param>
        /// <param name="imageHeight"></param>
        /// <returns></returns>
        private Image GetImageFromClass(classObj msClass,int imageWidth,int imageHeight)
        {
            //return GetImageFromClass(m_pDefaultMap, msClass, imageWidth, imageHeight);

            if (msClass == null) return null;

            if (imageWidth < 8)
                imageWidth = 8;
            if (imageHeight < 8)
                imageHeight = 8;

            imageObj pSymbolImage;
            if(msClass.layer == null)
            {
                pSymbolImage = msClass.createLegendIcon(m_pDefaultMap, m_pCurrentLayer,
                    imageWidth, imageHeight);

            }
            else
            {
                pSymbolImage = msClass.createLegendIcon(msClass.layer.map, msClass.layer,
                    imageWidth, imageHeight);
            }

            byte[] buffer = pSymbolImage.getBytes();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ms.Write(buffer, 0, buffer.Length);
            Image pImage = Image.FromStream(ms);
            ms.Dispose();
            pSymbolImage.Dispose();

            return pImage;
        }    

        /// <summary>
        /// load the current classobj's preview image to listview
        /// </summary>
        private void LoadCurrentSymbol()
        {
            if (m_pCurrentLayer == null) return;

            Image pImage = GetImageFromClass(m_pCurrentLayer.getClass(m_iClassIndex), 48, 48);  
            imageListPreview.Images.Add(pImage);
            listViewSymbol.Items.Add("Default", imageListPreview.Images.Count - 1);

        }

        /// <summary>
        /// show all the predefined symbols
        /// </summary>
        private void LoadSymbolFromLib()
        {                     
            classObj pClass = new classObj(null);
            styleObj pStyle = new styleObj(pClass);            

            colorObj pColor = new colorObj(0,0,0,0);

            int iSymbolCount = m_pDefaultMap.getNumSymbols();

            symbolSetObj pSymSet = m_pDefaultMap.symbolset;

            for(int i=1;i < iSymbolCount;i++)
            {
                pStyle.symbol = i;
                pStyle.color = pColor;

                symbolObj pSymbol = pSymSet.getSymbol(i);               

                
                if (m_LayerType == MS_LAYER_TYPE.MS_LAYER_POINT)
                {
                    //type cartoline if only for line type
                    if (pSymbol.type == (int)MS_SYMBOL_TYPE.MS_SYMBOL_CARTOLINE)
                        continue;

                    pStyle.size = 10;
                    pStyle.angle = 0;
                }
                else if (m_LayerType == MS_LAYER_TYPE.MS_LAYER_LINE)
                {
                    pStyle.size = 6;
                    pStyle.width = 1;
                }
                else if (m_LayerType == MS_LAYER_TYPE.MS_LAYER_POLYGON)
                {
                    //type cartoline if only for line type
                    if (pSymbol.type == (int)MS_SYMBOL_TYPE.MS_SYMBOL_CARTOLINE)
                        continue;

                    pStyle.size = 8;
                    pStyle.outlinewidth = 1;
                    pStyle.outlinecolor = pColor;
                }

                imageListPreview.Images.Add(GetImageFromClass(pClass, 48, 48));

                listViewSymbol.Items.Add(pSymbol.name, imageListPreview.Images.Count - 1);
            }

            pStyle.Dispose();
            pClass.Dispose();
            pColor.Dispose();    
            
        }
       
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void listViewSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_pDefaultMap == null) return;
            if (listViewSymbol.SelectedIndices.Count == 0) return;

            //make sure there is only one style in class
            while (m_pEditingClass.numstyles > 1)
                m_pEditingClass.removeStyle(0);

            //index 0 is the orienge symbol
            if(listViewSymbol.SelectedIndices[0] == 0)
            {
                pictureBoxPreview.Image =
                    GetImageFromClass(m_pCurrentLayer.getClass(m_iClassIndex)
                    , pictureBoxPreview.Width, pictureBoxPreview.Height);
            }
            else
            {
                if (m_pEditingClass != null)
                    m_pEditingClass.Dispose();                

                m_pEditingClass = new classObj(null);
                styleObj pStyle = new styleObj(m_pEditingClass);
                pStyle.setSymbolByName(m_pDefaultMap, listViewSymbol.SelectedItems[0].Text);
                pStyle.color = new colorObj(0, 0, 0, 0);

                if (m_LayerType == MS_LAYER_TYPE.MS_LAYER_POINT)
                {
                    pStyle.size = 10;
                    pStyle.angle = 0;
                }
                else if (m_LayerType == MS_LAYER_TYPE.MS_LAYER_LINE)
                {
                    pStyle.size = 8;
                    pStyle.width = 1;
                }
                else if (m_LayerType == MS_LAYER_TYPE.MS_LAYER_POLYGON)
                {
                    pStyle.size = 8;
                    pStyle.outlinewidth = 1;
                    pStyle.outlinecolor = new colorObj(0, 0, 0, 0);
                }

                if (m_pSymbolOptions != null)
                    m_pSymbolOptions.Symbol = pStyle;

                DrawSymbol2Preview();  

            }
            
        }
        
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (listViewSymbol.SelectedIndices.Count == 0) return;

            if (m_pCurrentLayer != null)
            {
                //从class对象中获取一个styleObj对象  
                styleObj pStyle = m_pCurrentLayer.getClass(m_iClassIndex).getStyle(0);
                pStyle.color = m_pSymbolOptions.MsSymbolColor;
                 styleObj pSelectedStyle = m_pEditingClass.getStyle(0);
                    pStyle.color = pSelectedStyle.color;

                //index 0 is the origin symbol of the class
                if(listViewSymbol.SelectedIndices[0] > 0)                
                {
                    mapObj pMap = m_pCurrentLayer.map;
                    if (pMap == null)
                        pMap = _EditMap;

                    if (pMap != null)
                    {
                        if (pMap.symbolset == null)
                        {
                            SetSymbolSet(m_pDefaultMap);
                        }
                        else
                        {
                            symbolSetObj pSymbolset = pMap.symbolset;
                            bool blnFind = false;
                            for (int i = 0; i < pSymbolset.numsymbols; i++)
                            {
                                if (pSymbolset.getSymbol(0).name == pSelectedStyle.symbolname)
                                {
                                    blnFind = true;
                                    break;
                                }
                            }

                            if (blnFind == false)
                            {
                                symbolObj pSymbol = m_pDefaultMap.symbolset.getSymbolByName(pSelectedStyle.symbolname);
                                pMap.symbolset.appendSymbol(pSymbol);
                                _SymbolListChanged = true;

                                //check if the mapfile have the font that used in the symbol 
                                if (pSymbol.type == (int)MS_SYMBOL_TYPE.MS_SYMBOL_TRUETYPE)
                                {
                                    //hashTableObj pFontList = m_pCurrentLayer.map.fontset.fonts;
                                    //string strFont = pFontList.get(pSymbol.name,"");
                                    //if(strFont.Length == 0)
                                    //{
                                    //    string strFont1 = m_pDefaultMap.fontset.fonts.get(pSymbol.font,"");
                                    //    pFontList.set(pSymbol.name, strFont1);                                    
                                    //}                               

                                }
                            }
                        }

                        pStyle.setSymbolByName(pMap, pSelectedStyle.symbolname);

                    }
                    else
                    {
                        MessageBox.Show("当前图层不存在map对象，无法修改符号！","提示");
                        return;
                    }


                    
                }

                pStyle.size = pSelectedStyle.size;
                pStyle.width = pSelectedStyle.width;
                pStyle.angle = pSelectedStyle.angle;
                pStyle.outlinecolor = pSelectedStyle.outlinecolor;
                pStyle.outlinewidth = pSelectedStyle.outlinewidth;
                
            }

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 返回symbollist是否被修改
        /// </summary>
        public bool SymbolListChanged
        {
            get { return _SymbolListChanged; }
        }

        public mapObj EditMap
        {
            get { return _EditMap; }
        }

       
    }
}