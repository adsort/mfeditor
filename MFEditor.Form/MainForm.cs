// Copyright 2008, 2010 - http://code.google.com/p/mfeditor/
//
// Author:   WanliYun 
// Email:    wanliyun2009@gmail.com
// QQ Group: 81979380
// Blog:     http://blog.csdn.net/wanliyun2009
//
//
// This file is part of MFEditor.
// MFEditor is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// MFEditor is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with MFEditor; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MFEditor.Control;
using MFEditor.Utils;
using MFEditor.PropertyControl;
using OSGeo.MapServer;

//multi-language support
using System.Globalization;
using System.Threading;




namespace MFEditorUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //English support
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US"); 
            InitializeComponent();            
        }

        private classBasic m_pMyBasic = new classBasic();
        private bool m_blnResize = false;

        private int m_sSelectedClassIndex = -1;//the index of the current selected class
        private bool m_saveSymbolList = false;

        private layerObj m_pSelectedLayer = null;//the current selected layer
        private classObj m_pSelectedClass = null;//the current selected class

        //the selected element type in the legendcontrol.
        private LegendControlItem m_pCurrentElement = LegendControlItem.None;        


        private void MenuItemFileLoadMapfile_Click(object sender, EventArgs e)
        {            
            try
            {
                if (mapControl1.Map != null)
                {
                    DialogResult Result = Utility.PostQuestion("Do you want to save the current mapfile?");
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
                Utility.PostMessage("Open mapfile error:" + ex.Message);
            }


            mapControl1.ActiveTool = MapControl.Tools.ZoomIn;
        }

        //open mapfile
        private bool LoadMapfile()
        {            
            OpenFileDialog pOpenNmp = new OpenFileDialog();
            pOpenNmp.Title = "open mapfile";
            pOpenNmp.Multiselect = false;
            pOpenNmp.Filter = "mapfile(*.map)|*.map";

            if (Directory.Exists(m_pMyBasic.DefaultMapPath))
                pOpenNmp.InitialDirectory = m_pMyBasic.DefaultMapPath;


            if (pOpenNmp.ShowDialog() == DialogResult.Cancel)
                return false;
            if (pOpenNmp.FileName.Length == 0) return false;

            

            if (File.Exists(pOpenNmp.FileName))
            {
                m_pMyBasic.DefaultMapPath = Path.GetDirectoryName(pOpenNmp.FileName);
            }
            else
            {
                Utility.PostMessage("The file [" + pOpenNmp.FileName + "]is not exist!");
                return false;
            }

            string strFilePath = pOpenNmp.FileName;

           

            return mapControl1.loadMapfile(strFilePath);                 
        }

        //create a new mapfile,the default path is under the startup path of the application 
        private bool NewMapfile()
        {
            return mapControl1.newMapfile(); 
        }

        ///<summary>
        ///save the current mapfile
        ///</summary>
        private bool SaveMapfile()
        {
            SaveFileDialog cdlSave = new SaveFileDialog();
            //cdlSave.CheckFileExists = false;
            cdlSave.Title = "Save mapfile";
            cdlSave.Filter = "mapfile(*.map)|*.map";

            if (Directory.Exists(m_pMyBasic.DefaultMapPath))
                cdlSave.InitialDirectory = m_pMyBasic.DefaultMapPath;

            if (cdlSave.ShowDialog() == DialogResult.Cancel)
                return false;
            if (cdlSave.FileName.Length == 0)
                return false;

            string strMapFile = cdlSave.FileName;

            if (strMapFile == Utility.GetTempPath(strMapFile))
            {
                Utility.PostMessage("[temp.map] is system name!");
                return false;
            }


            if (File.Exists(strMapFile))
                File.Delete(strMapFile);           

            return mapControl1.SaveMapfile(strMapFile,m_saveSymbolList);
        }

        private void MenuItemFileCloseMapfile_Click(object sender, EventArgs e)
        {
            if (mapControl1.Map != null)
            {
                DialogResult Result = Utility.PostQuestion("Do you want to save the current mapfile?");
                
                if (Result == DialogResult.Yes)
                    SaveMapfile();
                else if (Result == DialogResult.Cancel)
                    return;
            }           

            mapControl1.closeMapfile();
        }

        private void MenuItemFileSaveMapfile_Click(object sender, EventArgs e)
        {
            if (mapControl1.MapfilePath == "")
            {
                MenuItemFileSaveAsMapfile_Click(sender, e);
            }
            else
            {                
                mapControl1.SaveMapfile(mapControl1.MapfilePath, m_saveSymbolList);                
            }           

        }

        private void MenuItemFileSaveAsMapfile_Click(object sender, EventArgs e)
        {
            if (mapControl1.Map != null)
                SaveMapfile();
            else
                Utility.PostMessage("There is no opened mapfile£°");
        }

        private void MenuItemToolsZoomIn_Click(object sender, EventArgs e)
        {
            mapControl1.ActiveTool = MapControl.Tools.ZoomIn;
            
        }

        private void MenuItemToolsZoomOut_Click(object sender, EventArgs e)
        {
            mapControl1.ActiveTool = MapControl.Tools.ZoomOut;
        }

        private void MenuItemToolsZoomPan_Click(object sender, EventArgs e)
        {
            mapControl1.ActiveTool = MapControl.Tools.Pan;
        }


        private void MenuItemToolsZoomFull_Click(object sender, EventArgs e)
        {
            mapControl1.zoomToFullExtents();            
        }

        private void MenuItemToolsZoomPriv_Click(object sender, EventArgs e)
        {
            mapControl1.zoomToPrev();
        }

        private void MenuItemToolsZoomLast_Click(object sender, EventArgs e)
        {
            mapControl1.zoomToLast();
        }        

        private void MenuItemFileNewMapfile_Click(object sender, EventArgs e)
        {
            bool bCreate = false;
            try
            {
                if (mapControl1.Map != null)
                {
                    DialogResult Result = Utility.PostQuestion("Do you want to save the current mapfile?");
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
                Utility.PostMessage("Create mapfile error:" + ex.Message);
            }

            mapControl1.ActiveTool = MapControl.Tools.ZoomIn;
            
        }
        
        private void MenuItemMapProperty_Click(object sender, EventArgs e)
        {
            //set the property of the current map
            //if (mapControl1.Map != null)
            //{
            //    MapPropertys myProperty = mapControl1.mapProperty;
            //    FormMapSet mySet = new FormMapSet(myProperty);
            //    if (DialogResult.OK == mySet.ShowDialog())
            //        mapControl1.mapProperty = classBasic.m_pMapProperty;
            //}
            //else
            //{
            //    Utility.PostMessage("There is no opened mapfile!");
            //}
        }   
      

        private void ≤‚ ‘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //layerObj pLayer = mapControl1.Map.getLayer(0);
            //string strTemp = pLayer.getProcessing(0);
            //Console.WriteLine(strTemp);

            //string ddd = pLayer.getProcessingKey("BANDS");
            ////pLayer.setProcessing("BANDS = 1,2,3");

            //pLayer.setProcessingKey("BANDS", "1,2,3");
            //strTemp = pLayer.getProcessing(0);


            //Console.WriteLine(ddd);

            //McLayer myLayer = mapControl1.newLayer();
            //myLayer.Type = mcLayerType.mcLTpolygon;

            //layerObj pLayer = mapControl1.Map.getLayer(0);
            //labelObj pLable = pLayer.getClass(0).label;
            //pLable.type = MS_FONT_TYPE.MS_TRUETYPE;
            //pLable.align = 0;
            //pLable.size = 10;

         

            hashTableObj pFontList = mapControl1.Map.fontset.fonts;
            string value = pFontList.nextKey(null);
            while (value != null)
            {
                string ddd = (value);
                value = pFontList.nextKey(value);
            }


            //string strTemp = pLayer.getProcessing(0);
            //Console.WriteLine(strTemp);
           
        }    

        private void ToolStripMenuItemEditProp_Click(object sender, EventArgs e)
        {         
            showProperty(m_pCurrentElement);
        }

        private void showProperty(LegendControlItem selElement)
        {
            if (selElement ==  LegendControlItem.None) return;

            if (selElement == LegendControlItem.Map)
            {
                //set the property of the current map
                if (mapControl1.Map != null)
                {
                    //FormMapSet mySet = new FormMapSet(mapControl1.Map);
                    FormMapSet mySet = new FormMapSet(mapControl1);
                    if (DialogResult.OK == mySet.ShowDialog())
                    {
                        //mapControl1.mapProperty = classBasic.m_pMapProperty;
                        mapControl1.refreshMap(false);
                        
                    }
                }
                else
                {
                    Utility.PostMessage("There is no opened mapfile!");
                }
            }
            else if (selElement == LegendControlItem.Layer)
            {
                if (m_pSelectedLayer == null) return;
                layerObj selLayer = m_pSelectedLayer;
                if (selLayer == null)
                {
                    Utility.PostMessage("There is no selected layer!");
                }
                else
                {
                    LayerPropertiesDialog myLayerset = new LayerPropertiesDialog(selLayer);
                    if(myLayerset.ShowDialog() == DialogResult.OK)
                    {
                        mapControl1.refreshMap(false);
                        legendControl1.RefreshLegend();
                    }
                }
            }
            else if (selElement == LegendControlItem.Class)
            {
                //class
                if (m_pSelectedClass == null) return;
                layerObj selLayer = m_pSelectedClass.layer;
                if (selLayer == null)
                {
                    Utility.PostMessage("There is no layerobj in selected class!");
                }
                else
                {
                    FormClassSet myClassSet = new FormClassSet(m_pSelectedClass);
                    myClassSet.ShowDialog();
                }                
            }
            else if (selElement == LegendControlItem.Label)
            {
                ////Label
                //if (m_sSelectedLayerName == "") return;
                //if (m_sSelectedClassIndex == -1) return;
                //layerObj selLayer = mapControl1.getLayerByName(m_sSelectedLayerName);
                //if (selLayer == null)
                //{
                //    Utility.PostMessage("There is no such layer [" + m_sSelectedLayerName + "] in the mapfile!");
                //}
                //else
                //{
                //    classObj selClass = selLayer.getClass(m_sSelectedClassIndex);
                //    if (selClass == null) return;
                //    if (selClass.label == null) return;
                //    LabelEditorDialog myLabel = new LabelEditorDialog(selClass);
                //    myLabel.ShowDialog();
                //}  
            }
            //else if (inNode.ImageIndex == 4)
            //{
            //    //style
            //    McClass selClass = getMcClass(inNode);
            //    if (selClass == null) return;
            //    formClassSet myClassSet = new formClassSet(selClass);
            //    myClassSet.ShowDialog();
            //}
        }

       

        private void ToolStripMenuItemNewClass_Click(object sender, EventArgs e)
        {
            //TreeNode selNode = tvLegend.SelectedNode;
            //if (selNode == null) return;
            //if (selNode.ImageIndex != 1) return;

            //layerObj selLayer = mapControl1.getLayerByName(selNode.Text);
            //if (selLayer == null)
            //{
            //    Utility.PostMessage("There is no such layer [" + m_sSelectedLayerName + "] in the mapfile!");
            //}
            //else
            //{
            //    McClass newClass = selLayer.newClass();
            //    formClassSet myClassSet = new formClassSet(newClass);
            //    myClassSet.ShowDialog();
            //}

        }

        private void ToolStripMenuItemMetadata_Click(object sender, EventArgs e)
        {
            if (m_pCurrentElement == LegendControlItem.None)
            {
                Utility.PostMessage("There is no selected node!");
            }

            if (m_pCurrentElement == LegendControlItem.Map)
            {
                //set the property of the current map
                if (mapControl1.Map != null)
                {
                    FormMapSet mySet = new FormMapSet(mapControl1.Map);
                    if (DialogResult.OK == mySet.ShowDialog())
                    {
                    }
                        //mapControl1.mapProperty = classBasic.m_pMapProperty;                       
                }
                else
                {
                    Utility.PostMessage("There is no opened mapfile!");
                }
            }
            else if (m_pCurrentElement == LegendControlItem.Layer)
            {                
                if (m_pSelectedLayer == null)
                {
                    Utility.PostMessage("There is no selected layer!");
                }
                else
                {
                    string strPath = mapControl1.Map.shapepath;
                    MetadataForm myMeta = new MetadataForm(m_pSelectedLayer);
                    myMeta.ShowDialog();
                }
            }
            else if (m_pCurrentElement == LegendControlItem.Web)
            {
                ////web metadata    
                //if (mapControl1.Map == null) return;
                //formMetadata myMeta = new formMetadata(mapControl1.Map);
                //myMeta.ShowDialog();
            }  

        }

        private void toolButtonRefresh_Click(object sender, EventArgs e)
        {           
            //re-read the mapfile
            if (Utility.PostQuestion("This operation will lost the current editing,continue?")
                    == DialogResult.Yes)
            {
                if(mapControl1.CreateTempMapfile(mapControl1.MapfilePath))
                {
                    mapControl1.refreshMap(true);
                }
            }
            
        }

        private void formMain_ResizeEnd(object sender, EventArgs e)
        {
            m_blnResize = false;
            mapControl1.refreshMap(false);
        }

        private void formMain_Resize(object sender, EventArgs e)
        {
            if (m_blnResize == true) return;
            if ((this.WindowState == FormWindowState.Maximized) || (this.WindowState == FormWindowState.Normal))
            {
                mapControl1.refreshMap(false);
                //MessageBox.Show("formMain_Resize");
            }
                //mapControl1.refreshMap();
        }

        private void formMain_ResizeBegin(object sender, EventArgs e)
        {
            m_blnResize = true;
        }

        private void ToolStripMenuItemNewLabel_Click(object sender, EventArgs e)
        {            
            
            //TreeNode inNode = tvLegend.SelectedNode;
            //if (inNode.ImageIndex == 2)
            //{
            //    McClass selClass = getMcClass(inNode);
            //    if (selClass == null) return;
            //    if (selClass.Label == null) return;

            //    layerObj selLayer = getMcLayer(inNode);
                //formLabel myLabel = new formLabel(selClass.Label, selLayer);
                //if (DialogResult.OK == myLabel.ShowDialog())
                //    updataLegend();
            //}
        }

        private layerObj getMcLayer(TreeNode inNode)
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

            layerObj selLayer = mapControl1.getLayerByName(strLayerName);
            if (selLayer == null)
            {
                Utility.PostMessage("There is no such layer [" + strLayerName + "] in the mapfile!");

            }
            else
                return selLayer;                    

            return null;
        }

        /// <summary>
        /// remove the selected layer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemDel_Click(object sender, EventArgs e)
        {
            if (m_pSelectedLayer == null) return;
            if(m_pCurrentElement == LegendControlItem.Layer)
            {
                mapControl1.removeLayer(m_pSelectedLayer.name);
            }
            
            //else if (selNode.ImageIndex == 2)
            //{
               

            //}
            //else if (selNode.ImageIndex == 3)
            //{               
            //    //McClass myClass = getMcClass(selNode);
            //    //myClass.DeleteLabel();

            //}
            //else if (selNode.ImageIndex == 4)
            //{               


            //}

        }

        private void ToolStripMenuItemEditLabel_Click(object sender, EventArgs e)
        {
            ////Label
            //TreeNode inNode = tvLegend.SelectedNode;
            //if (inNode.ImageIndex == 1)
            //{                
            //    layerObj selLayer = getMcLayer(inNode);
            //    formLabel myLabel = new formLabel(selLayer);
            //    if (DialogResult.OK == myLabel.ShowDialog())
            //    {
            //        mapControl1.refreshMap(false);
            //        legendControl1.RefreshLegend();
            //    }
                    
            //}
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            m_pMyBasic.ReadSetXML();
            legendControl1.SetBuddyControl(this.mapControl1);

            this.Text = "MFEditor for MapServer" + mapscript.MS_VERSION;

            //m_strTempMapfile = Application.StartupPath + "\\temp.map";
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_pMyBasic.SaveSetXML();

            if (File.Exists(mapControl1.TempMapfilePath))
                File.Delete(mapControl1.TempMapfilePath);
        }

        private void MenuItemFileReload_Click(object sender, EventArgs e)
        {
            mapControl1.refreshMap(true);
            legendControl1.RefreshLegend();
        }

        private void ToolStripMenuItemDelLabel_Click(object sender, EventArgs e)
        {
            DialogResult pResult = Utility.PostQuestion("Do you want to delete all the labels in the layer?");
            if (DialogResult.Yes == pResult)
            {
                //TreeNode inNode = tvLegend.SelectedNode;
                //if (inNode.ImageIndex == 1)
                //{
                //    layerObj selLayer = getMcLayer(inNode);
                //    selLayer.DeleteAllLabel();
                //    mapControl1.refreshMap(false);
                //    updataLegend();
                //} 
            }
        }

        private void ToolStripMenuItemSymbol_Click(object sender, EventArgs e)
        {
            ////symbol
            //TreeNode inNode = tvLegend.SelectedNode;
            //if (inNode.ImageIndex == 1)
            //{
            //    layerObj selLayer = getMcLayer(inNode);
            //    formSymbolSet mySymbol = new formSymbolSet(selLayer);
            //    if (DialogResult.OK == mySymbol.ShowDialog())
            //    {
            //        mapControl1.saveMapfile("");
            //        mapControl1.refreshMap(true);
            //        legendControl1.RefreshLegend();
            //    }

            //}

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
                if (mfTextEditor1.IsDirty)
                {
                    if (mfTextEditor1.SaveMapfile())
                    {
                        mapControl1.refreshMap(true);
                    }
                }
                
            }
            else if (iIndex == 1)
            {                
                //mapfile tabpage
                if (mapControl1.SaveTempMapfile(m_saveSymbolList))
                {
                    mfTextEditor1.ShowMapfile(mapControl1.TempMapfilePath);
                }
                else
                {
                    mfTextEditor1.ShowMapfile("");
                }
                
            }
        }       

        private void MenuItemFileExist_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolButtonAddData_Click(object sender, EventArgs e)
        {
            if(mapControl1.Map == null)
            {
                Utility.PostMessage("There is no opened mapfile!");
                return;
            }
            OpenFileDialog pOpenNmp = new OpenFileDialog();
            pOpenNmp.Title = "Add Data";
            pOpenNmp.Multiselect = false;
            pOpenNmp.Filter = "Supported Formats|*.shp;*.tab;*.tif;*.img;" +
                "|Shapefile (*.shp)|*.shp|mapinfo (*.tab)|*.shp|TIFF (*.tif)|*.tif|IMAGE (*.img)|*.img";

            if (Directory.Exists(m_pMyBasic.DefaultDataPath))
                pOpenNmp.InitialDirectory = m_pMyBasic.DefaultDataPath;


            if (pOpenNmp.ShowDialog() == DialogResult.Cancel)
                return;
            if (pOpenNmp.FileName.Length == 0) return;

            if (File.Exists(pOpenNmp.FileName))
            {
                m_pMyBasic.DefaultDataPath = Path.GetDirectoryName(pOpenNmp.FileName);

                string strFilePath = pOpenNmp.FileName;

                mapControl1.addLayer(strFilePath);

                mapControl1.refreshMap(false);
          
                

            }
            else
            {
                MessageBox.Show("data file[" + pOpenNmp.FileName + "]not exist!"
                    , "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }           
        }

        private void mapControl1_ScaleChanged(object sender, ScaleEventArgs e)
        {
            //update the legend control
            //legendControl1.RefreshLegend(false);
            string strScale = e.Scale.ToString();
            //remove the number after the dot of double data
            string[] strTemp = strScale.Split('.');
            if (strTemp.Length > 1)
                toolLabelScale.Text = 1 + ":" + strTemp[0];
            else
                toolLabelScale.Text = 1 + ":" + strScale;
        }

        private void mapControl1_ErrorOccured(object sender, MSErrorEventArgs e)
        {
            MFEditor.ErrorDialog myErr = new MFEditor.ErrorDialog(e.ErrorInfo);
            myErr.ShowDialog();
        }

        private void mapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            double dblGeoX, dblGeoY;
            mapControl1.toMapPoint(e.X, e.Y, out dblGeoX, out dblGeoY);
            toolStatusLabelPos.Text = "X:" + dblGeoX.ToString() + "  Y:" + dblGeoY.ToString();
        }        
       

        private void toolLabelScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] temp = toolLabelScale.Text.Split(':');
            //double dblScale = double.Parse(temp[1]);
            double dblScale = (temp.Length > 1) ? double.Parse(temp[1]) : double.Parse(temp[0]);
            mapControl1.zoomToScale(dblScale);
        }

        private void toolLabelScale_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string[] temp = toolLabelScale.Text.Split(':');
                double dblScale = (temp.Length > 1) ? double.Parse(temp[1]) : double.Parse(temp[0]);
                mapControl1.zoomToScale(dblScale);
            }
        }

        private void MenuItemToolboxPreKamap_Click(object sender, EventArgs e)
        {
            mapObj pMap = mapControl1.Map;
            if((pMap != null)&&(pMap.numlayers > 0))
            {
                formPrecacheKamap pPreKamap = new formPrecacheKamap(mapControl1);
                pPreKamap.ShowDialog();
            }
            else
            {
                MessageBox.Show("The current map is null£°", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            
        }      

        private void legendControl1_LayerVisibleChanged(object sender, VisibleEventArgs e)
        {
            this.mapControl1.refreshMap(false);
        }

        private void ToolStripMenuItemScaleMax_Click(object sender, EventArgs e)
        {           

            if (m_pSelectedLayer == null) return;

            string strScale = toolLabelScale.Text;
            string[] aryScale = strScale.Split(':');
            if(aryScale.Length == 2)
            {
                try
                {
                    double dblScale = Convert.ToDouble(aryScale[1]);
                    m_pSelectedLayer.maxscaledenom = dblScale;
                }
                catch{}
            }           
        }

        private void ToolStripMenuItemScaleMin_Click(object sender, EventArgs e)
        {            

            if (m_pSelectedLayer == null) return;

            string strScale = toolLabelScale.Text;
            string[] aryScale = strScale.Split(':');
            if (aryScale.Length == 2)
            {
                try
                {
                    double dblScale = Convert.ToDouble(aryScale[1]);
                    m_pSelectedLayer.minscaledenom = dblScale;
                }
                catch { }
            }               
        }

        private void ToolStripMenuItemScaleClear_Click(object sender, EventArgs e)
        {  
            if (m_pSelectedLayer == null) return;
            m_pSelectedLayer.minscaledenom = -1;
            m_pSelectedLayer.maxscaledenom = -1;               
        }
       

        private void ToolStripMenuItemZoom2Layer_Click(object sender, EventArgs e)
        {
            if (m_pCurrentElement == LegendControlItem.Layer)
            {
                if (m_pSelectedLayer == null) return;

                //set the layer extents
                rectObj pRect = m_pSelectedLayer.getExtent();                
                mapControl1.zoomToExtents(pRect.minx, pRect.maxx, pRect.miny, pRect.maxy);

                pRect.Dispose();               
            }
        }

        private void mapControl1_OnMapReplaced(object sender, EventArgs e)
        {
            tabControlMain_SelectedIndexChanged(sender, e);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\Work\gmap\htdocs\gmap75.map";
            mapObj pMap = new mapObj(filePath);

            string filePath1 = @"D:\Work\gmap\htdocs\gmapnew.map";

            pMap.save(filePath1);
        }

        private void MenuItemHelpWeb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://code.google.com/p/mfeditor/");
        }

        private void legendControl1_MouseDown(object sender, MouseEventArgs e)
        {
            LegendControlItem itemType = LegendControlItem.None;
            object pMsObject = null;
            legendControl1.HitTest(e.X, e.Y, ref itemType, ref pMsObject);

            if (pMsObject == null) return;

            m_pCurrentElement = itemType;

            if (e.Button == MouseButtons.Left)
            {
                if (itemType == LegendControlItem.Class)
                {
                    classObj pClass = pMsObject as classObj;
                    MFEditor.SymbolSelectorDialog pSelector = new MFEditor.SymbolSelectorDialog(pClass.layer, pClass);
                    if (pSelector.ShowDialog() == DialogResult.OK)
                    {
                        m_saveSymbolList = pSelector.SymbolListChanged;
                        mapControl1.refreshMap(false);
                        //updata the legend
                        legendControl1.RefreshLegend();
                    }
                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                
                if(itemType == LegendControlItem.Map)
                {
                    contextMenuLegend.Items.Clear();
                    contextMenuLegend.Items.Add(ToolStripMenuItemNewLayer);
                    contextMenuLegend.Items.Add(toolStripSeparator6);
                    contextMenuLegend.Items.Add(ToolStripMenuItemEditProp);
                    contextMenuLegend.Show(legendControl1, new Point(e.X, e.Y));

                    m_pSelectedLayer = null;
                    m_pSelectedClass = null;
                }
                else if (itemType == LegendControlItem.Layer)
                {                   
                    contextMenuLegend.Items.Clear();
                    contextMenuLegend.Items.Add(ToolStripMenuItemDel);
                    contextMenuLegend.Items.Add(toolStripSeparator12);
                    contextMenuLegend.Items.Add(ToolStripMenuItemZoom2Layer);
                    contextMenuLegend.Items.Add(ToolStripMenuItemScale);
                    contextMenuLegend.Items.Add(toolStripSeparator13);
                    contextMenuLegend.Items.Add(ToolStripMenuItemNewClass);
                    contextMenuLegend.Items.Add(ToolStripMenuItemEditLabel);
                    contextMenuLegend.Items.Add(ToolStripMenuItemDelLabel);
                    //contextMenuLegend.Items.Add(ToolStripMenuItemSymbol);
                    contextMenuLegend.Items.Add(ToolStripMenuItemMetadata);
                    contextMenuLegend.Items.Add(toolStripSeparator6);
                    contextMenuLegend.Items.Add(ToolStripMenuItemEditProp);
                    contextMenuLegend.Show(legendControl1, new Point(e.X, e.Y));

                    m_pSelectedLayer = pMsObject as layerObj;
                    m_pSelectedClass = null;
                }
                else if (itemType == LegendControlItem.Class)
                {
                    //occured when the Class node is selected
                    contextMenuLegend.Items.Clear();
                    contextMenuLegend.Items.Add(ToolStripMenuItemNewLabel);
                    contextMenuLegend.Items.Add(ToolStripMenuItemNewStyle);
                    contextMenuLegend.Items.Add(toolStripSeparator6);
                    contextMenuLegend.Items.Add(ToolStripMenuItemEditProp);
                    contextMenuLegend.Show(legendControl1, new Point(e.X, e.Y));
                }
                else if (itemType == LegendControlItem.Web)
                {
                    //occured when the Web node is selected
                    contextMenuLegend.Items.Clear();
                    contextMenuLegend.Items.Add(ToolStripMenuItemMetadata);
                    contextMenuLegend.Show(legendControl1, new Point(e.X, e.Y));
                }
            }
        }        

    }

   

}