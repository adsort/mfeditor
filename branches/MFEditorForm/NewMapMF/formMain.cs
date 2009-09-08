using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MFEditorLib;

namespace MFEditor
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
            initProject();
        }

        private classBasic m_pMyBasic = new classBasic();
        private bool m_blnResize = false;

        private String m_strTempMapfile = "";
        private String m_strRootMapfile = "";
        private bool m_blnEditMap = false;
        


        //初始化工程文件
        private void initProject()
        {
            m_pMyBasic.DefaultDir = Application.StartupPath;
        }

        private void MenuItemFileLoadMapfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (mapView.Map != null)
                {                    
                    DialogResult Result = MessageBox.Show("需要保存当前的mapfile配置吗?",
                        "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    switch (Result)
                    {
                        case DialogResult.Yes:
                            if(SaveMapfile())
                                LoadMapfile();
                            break;
                        case DialogResult.Cancel:
                            break;
                        case DialogResult.No:
                            LoadMapfile();
                            break;
                    }
                }
                else
                {
                    this.SetStyle(ControlStyles.EnableNotifyMessage, true);
                    LoadMapfile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开mapfile文件异常：" + ex.Message, "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            mapView.currentTool = mcMapTools.mcTZoomIn;
        }

        //打开mapfile
        private bool LoadMapfile()
        {            
            OpenFileDialog pOpenNmp = new OpenFileDialog();
            pOpenNmp.Title = "打开mapfile";
            pOpenNmp.Multiselect = false;
            pOpenNmp.Filter = "mapfile 文件 (*.map)|*.map";

            if (Directory.Exists(m_pMyBasic.DefaultDir))
                pOpenNmp.InitialDirectory = m_pMyBasic.DefaultDir;


            if (pOpenNmp.ShowDialog() == DialogResult.Cancel)
                return false;
            if (pOpenNmp.FileName.Length == 0) return false;

            

            if (File.Exists(pOpenNmp.FileName))
            {
                m_pMyBasic.DefaultDir = Path.GetDirectoryName(pOpenNmp.FileName);
            }
            else
            {
                MessageBox.Show("工程文件[" + pOpenNmp.FileName + "]不存在!"
                    , "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            string strFilePath = pOpenNmp.FileName;

            //delete the old temp mapfile
            if(File.Exists(m_strTempMapfile))
            {
                File.Delete(m_strTempMapfile);
            }

            //generate a new tempmapfile path
            m_strTempMapfile = Path.GetDirectoryName(strFilePath) + "\\temp" + DateTime.Now.Hour.ToString()
                + DateTime.Now.Minute + DateTime.Now.Second + ".map";

            m_strRootMapfile = strFilePath;
            //copy a workversion to the exepath
            File.Copy(strFilePath, m_strTempMapfile);

            bool result = mapView.loadMapfile(m_strTempMapfile);

            if (result)
            {
                updataLegend();
            }

            return result;           
        }

        //新建mapfile
        private bool NewMapfile()
        {
            SaveFileDialog pOpenNmp = new SaveFileDialog();
            pOpenNmp.Title = "新建mapfile";            
            pOpenNmp.Filter = "mapfile 文件 (*.map)|*.map";
            pOpenNmp.OverwritePrompt = false;

            if (Directory.Exists(m_pMyBasic.DefaultDir))
                pOpenNmp.InitialDirectory = m_pMyBasic.DefaultDir;


            if (pOpenNmp.ShowDialog() == DialogResult.Cancel)
                return false;
            if (pOpenNmp.FileName.Length == 0) return false;



            if (File.Exists(pOpenNmp.FileName))
            {
                DialogResult myResult = MessageBox.Show("工程文件[" + pOpenNmp.FileName + "]已经存在，是否覆盖？"
                    , "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (DialogResult.Yes == myResult)
                {
                    File.Delete(pOpenNmp.FileName);
                }
                else 
                    return false;
                
                m_pMyBasic.DefaultDir = Path.GetDirectoryName(pOpenNmp.FileName);
            }
            

            string strFilePath = pOpenNmp.FileName;

            bool result = mapView.newMapfile(strFilePath);

            if (result)
                updataLegend();

            return result;
        }


        //保存mapfile
        private bool SaveMapfile()
        {
            //保存数据库
            SaveFileDialog cdlSave = new SaveFileDialog();
            cdlSave.Title = "保存mapfile";
            cdlSave.Filter = "mapfile 文件 (*.map)|*.map";

            if (Directory.Exists(m_pMyBasic.DefaultDir))
                cdlSave.InitialDirectory = m_pMyBasic.DefaultDir;

            if (cdlSave.ShowDialog() == DialogResult.Cancel)
                return false;
            if (cdlSave.FileName.Length == 0)
                return false;

            string strMapFile = cdlSave.FileName; ;

            if (File.Exists(strMapFile))
                File.Delete(strMapFile);

            mapView.saveMapfile(strMapFile);
            return true;
        }

        private void MenuItemFileCloseMapfile_Click(object sender, EventArgs e)
        {
            if (mapView.Map != null)
            {
                DialogResult Result = MessageBox.Show("需要保存当前的mapfile配置吗?",
                    "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                    SaveMapfile();
                else if (Result == DialogResult.Cancel)
                    return;
            }           

            mapView.closeMapfile();
            updataLegend();
        }

        private void MenuItemFileSaveMapfile_Click(object sender, EventArgs e)
        {
            //first save the edit to tempmapfile,
            //and then copy the tempmapfile to cover the basemapfile
            if(mapView.saveMapfile(""))
            {
                if (File.Exists(m_strRootMapfile))
                    File.Delete(m_strRootMapfile);

                File.Copy(m_strTempMapfile, m_strRootMapfile);
            }
        }

        private void MenuItemFileSaveAsMapfile_Click(object sender, EventArgs e)
        {
            if(mapView.Map != null)
                SaveMapfile();
            else
                MessageBox.Show("当前没有打开的mapfile！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MenuItemToolsZoomIn_Click(object sender, EventArgs e)
        {
            mapView.currentTool = mcMapTools.mcTZoomIn;
        }

        private void MenuItemToolsZoomOut_Click(object sender, EventArgs e)
        {
            mapView.currentTool = mcMapTools.mcTZoomOut;
        }

        private void MenuItemToolsZoomPan_Click(object sender, EventArgs e)
        {
            mapView.currentTool = mcMapTools.mcTZoomPan;
        }

        private void MenuItemToolsZoomFull_Click(object sender, EventArgs e)
        {
            mapView.zoomToFullExtents();
        }

        private void MenuItemToolsZoomPriv_Click(object sender, EventArgs e)
        {
            mapView.zoomToPrev();
        }

        private void MenuItemToolsZoomLast_Click(object sender, EventArgs e)
        {
            mapView.zoomToLast();
        }

        private void toolButtonZoomOut_Click(object sender, EventArgs e)
        {
            MenuItemToolsZoomOut_Click(sender, e);
        }

        private void toolButtonZoomPriv_Click(object sender, EventArgs e)
        {
            MenuItemToolsZoomPriv_Click(sender, e);
        }

        private void toolButtonZoomIn_Click(object sender, EventArgs e)
        {
            MenuItemToolsZoomIn_Click(sender, e);
        }

        private void toolButtonZoomPan_Click(object sender, EventArgs e)
        {
            MenuItemToolsZoomPan_Click(sender, e);
        }

        private void toolButtonFullExtent_Click(object sender, EventArgs e)
        {
            MenuItemToolsZoomFull_Click(sender, e);
        }

        private void toolButtonZoomLast_Click(object sender, EventArgs e)
        {
            MenuItemToolsZoomLast_Click(sender, e);
        }

        private void MenuItemFileNewMapfile_Click(object sender, EventArgs e)
        {
            bool bCreate = false;
            try
            {
                if (mapView.Map != null)
                {                    
                    DialogResult Result = MessageBox.Show("需要保存当前的mapfile配置吗?",
                        "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    switch (Result)
                    {
                        case DialogResult.Yes:
                            if(SaveMapfile())
                                bCreate = NewMapfile();
                            break;
                        case DialogResult.Cancel:
                            return;                         
                        case DialogResult.No:
                            bCreate = NewMapfile();
                            break;
                    }
                }
                else
                {
                    this.SetStyle(ControlStyles.EnableNotifyMessage, true);
                    bCreate = NewMapfile();
                }
                if (bCreate)
                    MenuItemMapProperty_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开mapfile文件异常：" + ex.Message, "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            mapView.currentTool = mcMapTools.mcTZoomIn;
            
        }

        private void toolButtonOpenMapfile_Click(object sender, EventArgs e)
        {
            MenuItemFileLoadMapfile_Click(sender, e);
        }

        private void toolButtonNewMapfile_Click(object sender, EventArgs e)
        {
            MenuItemFileNewMapfile_Click(sender, e);
        }

        private void MenuItemMapProperty_Click(object sender, EventArgs e)
        {
            //设置当前map的相关属性
            if (mapView.Map != null)
            {
                MapPropertys myProperty = mapView.mapProperty;
                formMapSet mySet = new formMapSet(myProperty);
                if (DialogResult.OK == mySet.ShowDialog())
                    mapView.mapProperty = classBasic.m_pMapProperty;
            }
            else
            {
                MessageBox.Show("当前没有打开的mapfile！","提示",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void toolButtonSaveMapfile_Click(object sender, EventArgs e)
        {
            MenuItemFileSaveMapfile_Click(sender, e);
        }

        private void MenuItemSetAddLayer_Click(object sender, EventArgs e)
        {
            //以前添加数据的方法
            //{
            //    McLayer newLayer = mapView.newLayer();
            //    string strShp = mapView.Map.get_ShapePath(true);

            //    if (newLayer == null)
            //    {
            //        MessageBox.Show("创建layer失败！", "提示",
            //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //    {
            //        formLayerSet myLayer = new formLayerSet(newLayer, strShp);
            //        if (DialogResult.Yes == myLayer.ShowDialog())
            //        {
            //            mapView.Refresh();
            //        }
            //    }

            //}

            OpenFileDialog pOpenNmp = new OpenFileDialog();
            pOpenNmp.Title = "Add Data";
            pOpenNmp.Multiselect = false;
            pOpenNmp.Filter = "Supported Formats|*.shp;*.tif;*.img;" +
                "|Shapefile (*.shp)|*.shp|TIFF (*.tif)|*.tif|IMAGE (*.img)|*.img";

            if (Directory.Exists(m_pMyBasic.DefaultDir))
                pOpenNmp.InitialDirectory = m_pMyBasic.DefaultDir;


            if (pOpenNmp.ShowDialog() == DialogResult.Cancel)
                return;
            if (pOpenNmp.FileName.Length == 0) return;



            if (File.Exists(pOpenNmp.FileName))
            {
                m_pMyBasic.DefaultDir = Path.GetDirectoryName(pOpenNmp.FileName);

                string strFilePath = pOpenNmp.FileName;

                McLayer pLayer = new McLayerClass();
                if (pLayer.Open(strFilePath))
                {
                    mapView.addLayer(pLayer);
                }
            }
            else
            {
                MessageBox.Show("data file[" + pOpenNmp.FileName + "]not exist!"
                    , "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);               
            }           
           
        }

        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            McLayer myLayer = mapView.newLayer();
            myLayer.Type = mcLayerType.mcLTpolygon;
           
        }

        //更新图例
        private void updataLegend()
        {
            tvLegend.Nodes.Clear();

            McMap myMap = mapView.Map;
            if (myMap == null) return;            

            //TreeNode mapsNode = new TreeNode();
            //mapsNode.Text = "Maps";
            //mapsNode.ImageIndex = -1;
            //mapsNode.SelectedImageIndex = -1;

            //tvLegend.Nodes.Add(mapsNode);

            TreeNode mapNode = new TreeNode();
            mapNode.Text = myMap.Name;
            mapNode.ImageIndex = 0;
            mapNode.SelectedImageIndex = 0;
            tvLegend.Nodes.Add(mapNode);

            TreeNode webNode = new TreeNode();
            webNode.Text = "Web";
            webNode.ImageIndex = 5;
            webNode.SelectedImageIndex = 5;
            mapNode.Nodes.Add(webNode);

            TreeNode layersNode = new TreeNode();
            layersNode.Text = "Layers";
            layersNode.ImageIndex = 6;
            layersNode.SelectedImageIndex = 6;
            mapNode.Nodes.Add(layersNode);


            int intLayer = myMap.LayerCount;
            for (int i = 0; i < intLayer; i++)
            {
                TreeNode layerNode = new TreeNode();
                layerNode.Text = myMap.get_LayerName(i);
                layerNode.ImageIndex = 1;
                layerNode.SelectedImageIndex = 1;
                layersNode.Nodes.Add(layerNode);
            }

            mapNode.ExpandAll();
            

        }

        //打开或者关闭传入的节点
        private void updataLegend(TreeNode inNode)
        {
            
            if (inNode.Nodes.Count == 0)
            {                
                if (inNode.ImageIndex == 1)
                {
                    McLayer myLayer = mapView.getLayerByName(inNode.Text);
                    if (myLayer == null) return;

                    int clsCount = myLayer.classCount;
                    for (int i = 0; i < clsCount; i++)
                    {
                        TreeNode clsNode = new TreeNode();
                        clsNode.Text = "Class" + "_" + i.ToString();
                        clsNode.ImageIndex = 2;
                        clsNode.SelectedImageIndex = 2;
                        inNode.Nodes.Add(clsNode);
                    }
                    inNode.Expand();
                }               
                if (inNode.ImageIndex == 2)
                {
                    McClass myClass = getMcClass(inNode);
                    if (myClass == null) return;

                    if (myClass.HasLabel)
                    {
                        TreeNode lblNode = new TreeNode();
                        lblNode.Text = "Label";
                        lblNode.ImageIndex = 3;
                        lblNode.SelectedImageIndex = 3;
                        inNode.Nodes.Add(lblNode);
                    }

                    int clsCount = myClass.StyleCount;
                    for (int i = 0; i < clsCount; i++)
                    {
                        TreeNode clsNode = new TreeNode();
                        clsNode.Text = "Style" + "_" + i.ToString();
                        clsNode.ImageIndex = 4;
                        clsNode.SelectedImageIndex = 4;
                        inNode.Nodes.Add(clsNode);
                    }
                    inNode.Expand();
                }
            }            
        }

        private void tvLegend_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectNode = tvLegend.SelectedNode;
            if (selectNode == null) return;
            //showProperty(selectNode);
           
        }

        private void tvLegend_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode selNode = tvLegend.GetNodeAt(e.X, e.Y);
            if (selNode == null) return;

            if (e.Button == MouseButtons.Right)
            {                
                Point showPoint = new Point(e.X, e.Y);
                tvLegend.SelectedNode = selNode;
              
                if (selNode.ImageIndex == 0)
                {
                    contextMenuLegend.Items.Clear();
                    //contextMenuLegend.Items.Add(ToolStripMenuItemNewLayer);
                    //contextMenuLegend.Items.Add(toolStripSeparator6);
                    contextMenuLegend.Items.Add(ToolStripMenuItemEditProp);
                    contextMenuLegend.Show(tvLegend,showPoint);

                }
                else if (selNode.ImageIndex == 1)
                {                   
                    contextMenuLegend.Items.Clear();
                    contextMenuLegend.Items.Add(ToolStripMenuItemNewClass);
                    contextMenuLegend.Items.Add(ToolStripMenuItemDel);                    
                    contextMenuLegend.Items.Add(ToolStripMenuItemEditLabel);
                    contextMenuLegend.Items.Add(ToolStripMenuItemDelLabel);
                    //contextMenuLegend.Items.Add(ToolStripMenuItemSymbol);
                    contextMenuLegend.Items.Add(ToolStripMenuItemMetadata);
                    contextMenuLegend.Items.Add(toolStripSeparator6);
                    contextMenuLegend.Items.Add(ToolStripMenuItemEditProp);
                    contextMenuLegend.Show(tvLegend, showPoint);
                }
                else if (selNode.ImageIndex == 2)
                {                     
                    contextMenuLegend.Items.Clear();
                    contextMenuLegend.Items.Add(ToolStripMenuItemNewLabel);
                    contextMenuLegend.Items.Add(ToolStripMenuItemNewStyle);
                    contextMenuLegend.Items.Add(toolStripSeparator6);
                    contextMenuLegend.Items.Add(ToolStripMenuItemEditProp);
                    contextMenuLegend.Show(tvLegend, showPoint);
                }
                else if (selNode.ImageIndex == 3)
                {                   
                    contextMenuLegend.Items.Clear();
                    contextMenuLegend.Items.Add(ToolStripMenuItemDel);
                    contextMenuLegend.Items.Add(toolStripSeparator6);
                    contextMenuLegend.Items.Add(ToolStripMenuItemEditProp);
                    contextMenuLegend.Show(tvLegend, showPoint);
                }
                else if (selNode.ImageIndex == 4)
                {                   
                    contextMenuLegend.Items.Clear();                   
                    contextMenuLegend.Items.Add(ToolStripMenuItemEditProp);
                    contextMenuLegend.Show(tvLegend, showPoint);
                }
                else if (selNode.ImageIndex == 5)
                {                   
                    contextMenuLegend.Items.Clear();
                    contextMenuLegend.Items.Add(ToolStripMenuItemMetadata);
                    contextMenuLegend.Show(tvLegend, showPoint);
                }   
            }
            else if (e.Button == MouseButtons.Left)
            {
                updataLegend(selNode);
 
            }
        }

        private void ToolStripMenuItemEditProp_Click(object sender, EventArgs e)
        {
            TreeNode selNode = tvLegend.SelectedNode;
            if (selNode == null) return;

            showProperty(selNode);            
        }

        private void showProperty(TreeNode inNode)
        {
            if (inNode == null) return;

            if (inNode.ImageIndex == 0)
            {
                //设置当前map的相关属性
                if (mapView.Map != null)
                {
                    MapPropertys myProperty = mapView.mapProperty;
                    formMapSet mySet = new formMapSet(myProperty);
                    if (DialogResult.OK == mySet.ShowDialog())
                        mapView.mapProperty = classBasic.m_pMapProperty;
                }
                else
                {
                    MessageBox.Show("当前没有打开的mapfile！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (inNode.ImageIndex == 1)
            {
                McLayer selLayer = mapView.getLayerByName(inNode.Text);
                if (selLayer == null)
                {
                    MessageBox.Show("mapfile中不存在图层：" + inNode.Text, "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    string strPath = mapView.Map.get_ShapePath(true);
                    formLayerSet myLayerset = new formLayerSet(selLayer, strPath);
                    myLayerset.ShowDialog();
                }  
            }
            else if (inNode.ImageIndex == 2)
            {
                //class
                McClass selClass = getMcClass(inNode);
                if (selClass == null) return;
                formClassSet myClassSet = new formClassSet(selClass);
                myClassSet.ShowDialog(); 
            }
            else if (inNode.ImageIndex == 3)
            {
                //Label
                McClass selClass = getMcClass(inNode);
                if (selClass == null) return;
                if (selClass.Label == null) return;

                McLayer selLayer = getMcLayer(inNode);
                formLabel myLabel = new formLabel(selClass.Label, selLayer);
                myLabel.ShowDialog();    

            }
            else if (inNode.ImageIndex == 4)
            {
                //style
                McClass selClass = getMcClass(inNode);
                if (selClass == null) return;
                formClassSet myClassSet = new formClassSet(selClass);
                myClassSet.ShowDialog();
            }
        }

        private void mapView_mcError(object sender, AxMFEditorLib._DMFEditorEvents_mcErrorEvent e)
        {
            formErr myErr = new formErr(e.errList);
            myErr.ShowDialog();
        }

        private void ToolStripMenuItemNewClass_Click(object sender, EventArgs e)
        {  
            TreeNode selNode = tvLegend.SelectedNode;
            if (selNode == null) return;
            if (selNode.ImageIndex != 1) return;

            McLayer selLayer = mapView.getLayerByName(selNode.Text);
            if (selLayer == null)
            {
                MessageBox.Show("mapfile中不存在图层：" + selNode.Text, "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                McClass newClass = selLayer.newClass();
                formClassSet myClassSet = new formClassSet(newClass);
                myClassSet.ShowDialog();
            }

        }

        private void ToolStripMenuItemNewLayer_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItemMetadata_Click(object sender, EventArgs e)
        {
            TreeNode inNode = tvLegend.SelectedNode;

            if(inNode == null)
            {
                MessageBox.Show("当前没有选中的节点！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (inNode.ImageIndex == 0)
            {
                //设置当前map的相关属性
                //if (mapView.Map != null)
                //{
                //    MapPropertys myProperty = mapView.mapProperty;
                //    formMapSet mySet = new formMapSet(myProperty);
                //    if (DialogResult.OK == mySet.ShowDialog())
                //        mapView.mapProperty = classBasic.m_pMapProperty;
                //}
                //else
                //{
                //    MessageBox.Show("当前没有打开的mapfile！", "提示",
                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
            else if (inNode.ImageIndex == 1)
            {
                McLayer selLayer = mapView.getLayerByName(inNode.Text);
                if (selLayer == null)
                {
                    MessageBox.Show("mapfile中不存在图层：" + inNode.Text, "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    string strPath = mapView.Map.get_ShapePath(true);
                    formMetadata myMeta = new formMetadata(selLayer);
                    myMeta.ShowDialog();
                }  
            }
            else if (inNode.ImageIndex == 5)
            {
                //web metadata    
                if (mapView.Map == null) return;
                formMetadata myMeta = new formMetadata(mapView.Map);
                myMeta.ShowDialog();

            }  

        }

        private void toolButtonRefresh_Click(object sender, EventArgs e)
        {
            
            //string strFilePath = mapView.mapProperty.mapfilePath;
            //bool result = mapView.loadMapfile(strFilePath);
            mapView.refreshMap(false);
            
        }

        private void mapView_ScaleChanged(object sender, AxMFEditorLib._DMFEditorEvents_ScaleChangedEvent e)
        {
            string strScale = e.heightScale.ToString();

            toolLabelScale.Text = 1 + ":" + strScale;
            //MessageBox.Show(e.heightScale.ToString() + "|" + e.widthScale.ToString());
        }

        private void mapView_MouseMoveEvent(object sender, AxMFEditorLib._DMFEditorEvents_MouseMoveEvent e)
        {
            toolStatusLabelPos.Text = "X:" + e.x.ToString() + "  Y:" + e.y.ToString();
        }

        private void formMain_ResizeEnd(object sender, EventArgs e)
        {
            m_blnResize = false;
            mapView.refreshMap(false);
        }

        private void formMain_Resize(object sender, EventArgs e)
        {
            if (m_blnResize == true) return;
            if ((this.WindowState == FormWindowState.Maximized) || (this.WindowState == FormWindowState.Normal))
            {
                mapView.refreshMap(false);
                //MessageBox.Show("formMain_Resize");
            }
                //mapView.refreshMap();
        }

        private void formMain_ResizeBegin(object sender, EventArgs e)
        {
            m_blnResize = true;
        }

        private void ToolStripMenuItemNewLabel_Click(object sender, EventArgs e)
        {            
            
            TreeNode inNode = tvLegend.SelectedNode;
            if (inNode.ImageIndex == 2)
            {
                McClass selClass = getMcClass(inNode);
                if (selClass == null) return;
                if (selClass.Label == null) return;

                McLayer selLayer = getMcLayer(inNode);
                formLabel myLabel = new formLabel(selClass.Label, selLayer);
                if (DialogResult.OK == myLabel.ShowDialog())
                    updataLegend();
            }
        }

        private McLayer getMcLayer(TreeNode inNode)
        {
            if (inNode == null) return null;

            string strLayerName = "";

            if (inNode.ImageIndex == 1)
            {
                strLayerName = inNode.Text;
            }
            else if (inNode.ImageIndex == 2)
            {
                strLayerName = inNode.Parent.Text;
            }
            else if (inNode.ImageIndex == 3)
            {
                strLayerName = inNode.Parent.Parent.Text;
            }
            else
                return null;            

            McLayer selLayer = mapView.getLayerByName(strLayerName);
            if (selLayer == null)
            {
                MessageBox.Show("mapfile中不存在图层：" + strLayerName, "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
                return selLayer;                    

            return null;
        }

        private McClass getMcClass(TreeNode inNode)
        {
            if (inNode == null) return null;

            string strText = "";
            string strLayerName = "";

            
            if (inNode.ImageIndex == 2)
            {
                
                strText = inNode.Text;
                strLayerName = inNode.Parent.Text;
            }
            else if (inNode.ImageIndex == 3)
            {
              
                strText = inNode.Parent.Text;
                strLayerName = inNode.Parent.Parent.Text;
            }
            else
                return null;
            string[] strTemp = strText.Split('_');
            string strIndex = "";
            if (strTemp.Length == 2)
            {
                strIndex = strTemp[1];

                try
                {
                    int iIndex = Convert.ToInt32(strIndex);                   

                    McLayer selLayer = mapView.getLayerByName(strLayerName);
                    if (selLayer == null)
                    {
                        MessageBox.Show("mapfile中不存在图层：" + strLayerName, "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        McClass selClass = selLayer.get_McClass(iIndex);
                        return selClass;                       
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("class标签错误！", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return null;
        }

        private void ToolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            TreeNode selNode = tvLegend.SelectedNode;
            if (selNode == null) return;

         
            //map
            if (selNode.ImageIndex == 0)
            {



            }
             
            else if (selNode.ImageIndex == 1)
            {   
                //layer
                if(mapView.removeLayerbyName(selNode.Text))
                {
                    selNode.Remove();
                }



            }
            else if (selNode.ImageIndex == 2)
            {
               

            }
            else if (selNode.ImageIndex == 3)
            {               
                McClass myClass = getMcClass(selNode);
                myClass.DeleteLabel();

            }
            else if (selNode.ImageIndex == 4)
            {               


            }

        }

        private void ToolStripMenuItemEditLabel_Click(object sender, EventArgs e)
        {
            //Label
            TreeNode inNode = tvLegend.SelectedNode;
            if (inNode.ImageIndex == 1)
            {                
                McLayer selLayer = getMcLayer(inNode);
                formLabel myLabel = new formLabel(selLayer);
                if (DialogResult.OK == myLabel.ShowDialog())
                {
                    mapView.refreshMap(false);
                    updataLegend();
                }
                    
            }
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            m_pMyBasic.ReadSetXML();

            //m_strTempMapfile = Application.StartupPath + "\\temp.map";
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_pMyBasic.SaveSetXML();

            //delete the wordcopy mapfile
            if (File.Exists(m_strTempMapfile))
                File.Delete(m_strTempMapfile);
        }

        private void MenuItemFileReload_Click(object sender, EventArgs e)
        {
            mapView.refreshMap(true);
            updataLegend();
        }

        private void ToolStripMenuItemDelLabel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("是否删除该图层的所有Label？", "提示",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                TreeNode inNode = tvLegend.SelectedNode;
                if (inNode.ImageIndex == 1)
                {
                    McLayer selLayer = getMcLayer(inNode);
                    selLayer.DeleteAllLabel();
                    mapView.refreshMap(false);
                    updataLegend();
                } 
            }
        }

        private void ToolStripMenuItemSymbol_Click(object sender, EventArgs e)
        {
            //symbol
            TreeNode inNode = tvLegend.SelectedNode;
            if (inNode.ImageIndex == 1)
            {
                McLayer selLayer = getMcLayer(inNode);
                formSymbolSet mySymbol = new formSymbolSet(selLayer);
                if (DialogResult.OK == mySymbol.ShowDialog())
                {
                    mapView.saveMapfile("");
                    mapView.refreshMap(true);
                    updataLegend();
                }

            }

        }        

        private void MenuItemHelpAbout_Click(object sender, EventArgs e)
        {
            FormAbout myAbout = new FormAbout();
            myAbout.ShowDialog();
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iIndex = tabControlMain.SelectedIndex;

            if (iIndex == 0)
            {
                //map tabpage
                if(m_blnEditMap)
                {
                    if(File.Exists(m_strTempMapfile))
                    {
                        File.Delete(m_strTempMapfile);
                    }

                    StreamWriter myWriter = new StreamWriter(m_strTempMapfile,true,Encoding.Default);
                    myWriter.Write(richTextBoxMapfile.Text);
                    myWriter.Flush();
                    myWriter.Close();
                    myWriter.Dispose();

                    mapView.refreshMap(true);
                }
            }
            else if (iIndex == 1)
            {
                if (m_strTempMapfile.Trim() == "") return;
                //mapfile tabpage
                if(mapView.saveMapfile(m_strTempMapfile))
                {
                    TextReader myReaser = new StreamReader(m_strTempMapfile,Encoding.Default);

                    richTextBoxMapfile.Text = myReaser.ReadToEnd();
                    m_blnEditMap = false;

                    myReaser.Close();
                    myReaser.Dispose();
                }               
                
            }
        }

        private void richTextBoxMapfile_TextChanged(object sender, EventArgs e)
        {
            m_blnEditMap = true;
        }

        private void MenuItemFileExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolButtonAddData_Click(object sender, EventArgs e)
        {
            OpenFileDialog pOpenNmp = new OpenFileDialog();
            pOpenNmp.Title = "Add Data";
            pOpenNmp.Multiselect = false;
            pOpenNmp.Filter = "Supported Formats|*.shp;*.tif;*.img;" +
                "|Shapefile (*.shp)|*.shp|TIFF (*.tif)|*.tif|IMAGE (*.img)|*.img";

            if (Directory.Exists(m_pMyBasic.DefaultDir))
                pOpenNmp.InitialDirectory = m_pMyBasic.DefaultDir;


            if (pOpenNmp.ShowDialog() == DialogResult.Cancel)
                return;
            if (pOpenNmp.FileName.Length == 0) return;



            if (File.Exists(pOpenNmp.FileName))
            {
                m_pMyBasic.DefaultDir = Path.GetDirectoryName(pOpenNmp.FileName);

                string strFilePath = pOpenNmp.FileName;

                McLayer pLayer = new McLayerClass();
                if (pLayer.Open(strFilePath))
                {
                    mapView.addLayer(pLayer);
                }
            }
            else
            {
                MessageBox.Show("data file[" + pOpenNmp.FileName + "]not exist!"
                    , "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }           
        }           
           

    }

   

}