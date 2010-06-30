// Copyright 2008, 2009 - http://code.google.com/p/mfeditor/
//
// Author:   WanliYun 
// Email:    wanliyun2009@gmail.com
// QQ Group: 81979380
// Homepage: http://code.google.com/p/mfeditor/
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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using OSGeo.MapServer;

namespace MFEditor.Control
{
    public enum LegendControlItem
    {
        Map,
        Layer,
        Class,
        Style,
        Label,
        Web,
        None
    }

    public partial class LegendControl : UserControl
    {
        public LegendControl()
        {
            InitializeComponent();
            m_iSymImageCount = imageListLeg.Images.Count;
        }

       

        #region "the imageindex of the legendcontrol"
        private const int IMAGEINDEX_MAP = 0;
        //private const int IMAGEINDEX_LAYER = 1; 
        private const int IMAGEINDEX_CLASS = 2;
        private const int IMAGEINDEX_LABEL = 3;
        private const int IMAGEINDEX_STYLE = 4;
        private const int IMAGEINDEX_WEB = 5;
        private const int IMAGEINDEX_LAYERS = 6;
        private const int IMAGEINDEX_LAYER_ON = 7;
        private const int IMAGEINDEX_LAYER_OFF = 8;
        private const int IMAGEINDEX_LAYER_LOCK = 9;
        #endregion

        #region "the nodename of the legendcontrol"
        private const string NODE_WEB = "Web";
        private const string NODE_LAYERS = "Layers";
     
        #endregion

        private mapObj m_pMap = null;
        private MapControl m_pMapControl = null;

        //record the system image count in the imagelist
        //used for clear the layer symbol image
        private int m_iSymImageCount = 0;


        #region "Event Delegate"       

        
        //LayerVisibleChanged Event
        [Category("LegendControl Event")]
        public delegate void LayerVisibleChangedEventHandler(object sender, VisibleEventArgs e);
        public event LayerVisibleChangedEventHandler LayerVisibleChanged;           

        #endregion


        //设置legend的关联控件
        public void SetBuddyControl(MapControl mapcontrol)
        {
            m_pMapControl = mapcontrol;
            
            if (m_pMapControl != null)
                m_pMap = m_pMapControl.Map;

            m_pMapControl.OnLayerChanged +=new MapControl.OnLayerChangedEventHandler(DoOnLayerChanged);
            m_pMapControl.OnMapReplaced +=new MapControl.OnMapReplacedEventHandler(DoOnMapReplaced);
        }
        //更新图例
        public void RefreshLegend(bool reload)
        {
            if (reload)
                RefreshLegend();
            else
                resetLegend();
            
        }
        public void RefreshLegend()
        {
            treeViewLegend.Nodes.Clear();

            if(imageListLeg.Images.Count > m_iSymImageCount)
            {
                int iCount = imageListLeg.Images.Count;
                for (int i = m_iSymImageCount; i < iCount; i++)
                {
                    imageListLeg.Images.RemoveAt(m_iSymImageCount);
                }
            }

            if (m_pMap == null) return;

            //TreeNode mapsNode = new TreeNode();
            //mapsNode.Text = "Maps";
            //mapsNode.ImageIndex = -1;
            //mapsNode.SelectedImageIndex = -1;

            //treeViewLegend.Nodes.Add(mapsNode);
            
            TreeNode mapNode = new TreeNode();
            mapNode.Text = m_pMap.name;
            mapNode.ImageIndex = IMAGEINDEX_MAP;
            mapNode.SelectedImageIndex = IMAGEINDEX_MAP;
            treeViewLegend.Nodes.Add(mapNode);

            TreeNode webNode = new TreeNode();
            webNode.Text = NODE_WEB;
            webNode.ImageIndex = IMAGEINDEX_WEB;
            webNode.SelectedImageIndex = IMAGEINDEX_WEB;
            mapNode.Nodes.Add(webNode);

            TreeNode layersNode = new TreeNode();
            layersNode.Name = NODE_LAYERS;
            layersNode.Text = NODE_LAYERS;
            layersNode.ImageIndex = IMAGEINDEX_LAYERS;
            layersNode.SelectedImageIndex = IMAGEINDEX_LAYERS;
            mapNode.Nodes.Add(layersNode);

            int intLayer = m_pMap.numlayers; ;
            for (int i = 0; i < intLayer; i++)
            {
                layerObj pLayer = m_pMap.getLayer(i);
                AddLayerNode(pLayer, layersNode);
                pLayer.Dispose();
            }

            mapNode.ExpandAll();
        }

        private void AddLayerNode(layerObj layer, TreeNode layersnode,int index)
        {
            if ((layer == null) || (layersnode == null)) return;

            TreeNode layerNode = new TreeNode();
            layerNode.Text = layer.name;

            if (layer.status == 0)
            {
                layerNode.ImageIndex = IMAGEINDEX_LAYER_OFF;
                layerNode.SelectedImageIndex = IMAGEINDEX_LAYER_OFF;
            }
            else
            {
                if (layer.isVisible() != 0)
                {
                    layerNode.ImageIndex = IMAGEINDEX_LAYER_ON;
                    layerNode.SelectedImageIndex = IMAGEINDEX_LAYER_ON;
                }
                else
                {
                    layerNode.ImageIndex = IMAGEINDEX_LAYER_LOCK;
                    layerNode.SelectedImageIndex = IMAGEINDEX_LAYER_LOCK;
                }
            }

            if ((index > 0) && (index < layersnode.Nodes.Count - 1))
                layersnode.Nodes.Insert(index, layerNode);
            else
                layersnode.Nodes.Add(layerNode);

            AddLayerClassNode(layer, layerNode);
        }

        private void AddLayerNode(layerObj layer, TreeNode layersnode)
        {
            AddLayerNode(layer, layersnode, layersnode.Nodes.Count - 1);
        }


        private void AddLayerClassNode(layerObj layer, TreeNode layernode)
        {
            if ((layer == null) || (layernode == null)) return;
            int iClassCount = layer.numclasses;
            for (int i = 0; i < iClassCount; i++)
            {
                classObj pClass = layer.getClass(i);
                imageObj pSymbolImage = pClass.createLegendIcon(m_pMap, layer, 16, 16);            

                byte[] buffer = pSymbolImage.getBytes();
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                ms.Write(buffer, 0, buffer.Length);
                imageListLeg.Images.Add(Image.FromStream(ms));
                ms.Dispose();
                pSymbolImage.Dispose();

                int iIndex = imageListLeg.Images.Count - 1;

                TreeNode subNode2 = new TreeNode("", iIndex, iIndex);
                layernode.Nodes.Add(subNode2);
            }
        }

      

        //打开或者关闭传入的节点
        private void updateLegend(TreeNode inNode)
        {
            if (m_pMap == null) return;

            if (inNode.Nodes.Count == 0)
            {
                if (inNode.ImageIndex == IMAGEINDEX_LAYER_ON)
                {
                    layerObj pLayer = m_pMap.getLayer(inNode.Index);
                    if (pLayer == null) return;

                    int clsCount = pLayer.numclasses;
                    for (int i = 0; i < clsCount; i++)
                    {
                        TreeNode clsNode = new TreeNode();                       
                        clsNode.Text = "Class" + "_" + i.ToString();
                        clsNode.ImageIndex = IMAGEINDEX_CLASS;
                        clsNode.SelectedImageIndex = IMAGEINDEX_CLASS;
                        inNode.Nodes.Add(clsNode);
                    }
                    inNode.Expand();
                }
                if (inNode.ImageIndex == IMAGEINDEX_CLASS)
                {
                    classObj myClass = getMcClass(inNode);
                    if (myClass == null) return;

                    if (myClass.label != null)
                    {
                        TreeNode lblNode = new TreeNode();
                        lblNode.Text = "Label";
                        lblNode.ImageIndex = IMAGEINDEX_LABEL;
                        lblNode.SelectedImageIndex = IMAGEINDEX_LABEL;
                        inNode.Nodes.Add(lblNode);
                    }

                    int clsCount = myClass.numstyles;
                    for (int i = 0; i < clsCount; i++)
                    {
                        TreeNode clsNode = new TreeNode();
                        clsNode.Text = "Style" + "_" + i.ToString();
                        clsNode.ImageIndex = IMAGEINDEX_STYLE;
                        clsNode.SelectedImageIndex = IMAGEINDEX_STYLE;
                        inNode.Nodes.Add(clsNode);
                    }
                    inNode.Expand();
                }
            }            
        }

        //更新legend控件的checkbox状态
        private void resetLegend()
        {
            if (m_pMap == null) return;

            //find the layers node
            //the key is the name of the node
            TreeNode[] pLayersNodes = treeViewLegend.Nodes[0].Nodes.Find(NODE_LAYERS, false);

            if (pLayersNodes.Length <= 0) return;

            TreeNodeCollection pLayerNodes = pLayersNodes[0].Nodes;

            if (pLayerNodes == null) return;

            int iCount = pLayerNodes.Count;
            for(int i=0;i<iCount;i++)
            {                
                TreeNode layerNode = pLayerNodes[i];
                layerObj pLayer = m_pMap.getLayer(i);  

                if (pLayer == null)
                {
                    //wanliyun:2009.05.05
                    //if the layer is not exist,remote node from the list
                    pLayerNodes.Remove(layerNode);
                    iCount--;
                    i--;
                }
                else
                {
                    //Console.WriteLine(pLayer.name);
                    if (pLayer.status == 0)
                    {
                        layerNode.ImageIndex = IMAGEINDEX_LAYER_OFF;
                        layerNode.SelectedImageIndex = IMAGEINDEX_LAYER_OFF;
                    }
                    else
                    {
                        if (pLayer.isVisible() != 0)
                        {
                            layerNode.ImageIndex = IMAGEINDEX_LAYER_ON;
                            layerNode.SelectedImageIndex = IMAGEINDEX_LAYER_ON;
                        }
                        else
                        {
                            layerNode.ImageIndex = IMAGEINDEX_LAYER_LOCK;
                            layerNode.SelectedImageIndex = IMAGEINDEX_LAYER_LOCK;
                        }
                    }
                    pLayer.Dispose();
                }
                
            }            
        }

        private classObj getMcClass(TreeNode inNode)
        {
            if (inNode == null) return null;

            string strText = "";
            int iLayerIndex = -1;
            string strLayerName = "";


            if (inNode.ImageIndex == IMAGEINDEX_CLASS)
            {
                strText = inNode.Text;
                iLayerIndex = inNode.Parent.Index;
                strLayerName = inNode.Parent.Text;
            }
            else if (inNode.ImageIndex == IMAGEINDEX_LABEL)
            {

                strText = inNode.Parent.Text;
                iLayerIndex = inNode.Parent.Parent.Index;
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

                    layerObj selLayer = m_pMap.getLayer(iLayerIndex);
                    if (selLayer == null)
                    {
                        MessageBox.Show("mapfile中不存在图层：" + strLayerName, "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        return selLayer.getClass(iIndex);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("class标签错误！" + ex.Message , "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return null;
        }

        /// <summary>
        /// get the selected item in the position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="itemType"></param>
        /// <param name="msObject"></param>
        public void HitTest(int x, int y, ref LegendControlItem itemType, ref object msObject)
        {
            TreeNode selNode = treeViewLegend.GetNodeAt(x, y);
            if (selNode == null) return;

            Point showPoint = new Point(x, y);        
            
            treeViewLegend.SelectedNode = selNode;        
        
            //the preview image's index range
            if(selNode.ImageIndex >= m_iSymImageCount)
            {
                itemType = LegendControlItem.Class;
                msObject = m_pMap.getLayer(selNode.Parent.Index).getClass(selNode.Index);
            }
            else
            {
                switch (selNode.ImageIndex)
                {
                    case IMAGEINDEX_MAP:
                        itemType = LegendControlItem.Map;
                        msObject = m_pMap;
                        break;
                    //case IMAGEINDEX_LAYER:
                    case IMAGEINDEX_LAYER_ON:
                    case IMAGEINDEX_LAYER_OFF:
                    case IMAGEINDEX_LAYER_LOCK:
                        itemType = LegendControlItem.Layer;
                        msObject = m_pMap.getLayer(selNode.Index);
                        break;
                    case IMAGEINDEX_CLASS:
                        //itemType = LegendControlItem.Class;
                        //msObject = m_pMap.getLayer(selNode.Parent.Index).getClass(selNode.Index);
                        break;
                    case IMAGEINDEX_LABEL:
                        //itemType = LegendControlItem.Label;
                        //msObject = m_pMap.getLayer(selNode.Parent.Index).getClass(selNode.Index).label;
                        break;
                    case IMAGEINDEX_STYLE:
                        break;
                    case IMAGEINDEX_WEB:
                        itemType = LegendControlItem.Web;
                        msObject = m_pMap.web;
                        break;
                    default:
                        break;
                } 
            }          
           
        }


      

        private void LegendControl_Resize(object sender, EventArgs e)
        {

        }

        private void treeViewLegend_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode selNode = treeViewLegend.GetNodeAt(e.X, e.Y);
            if (selNode == null) return;

            Point showPoint = new Point(e.X, e.Y);

            if (e.Button == MouseButtons.Left)
            {
                if((selNode.ImageIndex == IMAGEINDEX_LAYER_ON)
                    ||(selNode.ImageIndex == IMAGEINDEX_LAYER_OFF))
                {
                                       
                    Rectangle nodeRect = selNode.Bounds;
                    nodeRect.X -= 16;
                    nodeRect.Width = 16;

                    //check if the mouse is within the picture
                    if (nodeRect.Contains(showPoint))
                    {
                        if (selNode.ImageIndex == IMAGEINDEX_LAYER_ON)
                        {
                            //li:get the nodeindex in the parentnode as the 
                            //layerindex in the map
                            int iIndex = selNode.Index;
                            layerObj pLayer = m_pMap.getLayer(iIndex);
                            if (pLayer == null) return;

                            pLayer.status = 0;

                            selNode.ImageIndex = IMAGEINDEX_LAYER_OFF;
                            selNode.SelectedImageIndex = IMAGEINDEX_LAYER_OFF;
                            if (LayerVisibleChanged != null)
                                LayerVisibleChanged(sender, new VisibleEventArgs(selNode.Index, selNode.Text, false));

                            pLayer.Dispose();


                        }
                        else if (selNode.ImageIndex == IMAGEINDEX_LAYER_OFF)
                        {
                            //li:get the nodeindex in the parentnode as the 
                            //layerindex in the map
                            layerObj pLayer = m_pMap.getLayer(selNode.Index);
                            if (pLayer == null) return;

                            pLayer.status = 1;

                            if (pLayer.isVisible() != 0)
                            {
                                selNode.ImageIndex = IMAGEINDEX_LAYER_ON;
                                selNode.SelectedImageIndex = IMAGEINDEX_LAYER_ON;
                                if (LayerVisibleChanged != null)
                                    LayerVisibleChanged(sender, new VisibleEventArgs(selNode.Index, selNode.Text, true));
                            }
                            else
                            {
                                selNode.ImageIndex = IMAGEINDEX_LAYER_LOCK;
                                selNode.SelectedImageIndex = IMAGEINDEX_LAYER_LOCK;
                            }

                            pLayer.Dispose();
                        }
                    }
                    else
                        updateLegend(selNode);
                }                
            }

            this.OnMouseDown(e);
        }


        #region "Function for the mapcontrol event"

        private void DoOnLayerStateChanged(object sender, LayerStateChangedEventArgs e)
        {
            //find the layers node
            //the key is the name of the node
            TreeNode[] pLayersNodes = treeViewLegend.Nodes[0].Nodes.Find(NODE_LAYERS, false);
            if (pLayersNodes.Length <= 0) return;

            TreeNodeCollection pLayerNodes = pLayersNodes[0].Nodes;
            if (pLayerNodes == null) return;

            if ((e.Index != -1) && (pLayersNodes.Length > e.Index))
            {

                if(e.Visible)
                {
                    pLayersNodes[e.Index].ImageIndex = IMAGEINDEX_LAYER_ON;
                    pLayersNodes[e.Index].SelectedImageIndex = IMAGEINDEX_LAYER_ON;
                }
                else
                {
                    pLayersNodes[e.Index].ImageIndex = IMAGEINDEX_LAYER_OFF;
                    pLayersNodes[e.Index].SelectedImageIndex = IMAGEINDEX_LAYER_OFF;
                }
            }
            else
            {
                if (e.LayerName.Length == 0) return;
                for(int i=0;i<pLayersNodes.Length;i++)
                {
                    if(pLayersNodes[i].Text == e.LayerName)
                    {
                        if (e.Visible)
                        {
                            pLayersNodes[i].ImageIndex = IMAGEINDEX_LAYER_ON;
                            pLayersNodes[i].SelectedImageIndex = IMAGEINDEX_LAYER_ON;
                        }
                        else
                        {
                            pLayersNodes[i].ImageIndex = IMAGEINDEX_LAYER_OFF;
                            pLayersNodes[i].SelectedImageIndex = IMAGEINDEX_LAYER_OFF;
                        }
                    }
                }
            }
        } 

        //when map was replaced,refresh the legend
        private void DoOnMapReplaced(object sender, EventArgs e)
        {
            m_pMap = m_pMapControl.Map;
            this.RefreshLegend();
        }

        private void DoOnLayerChanged(object sender, LayerChangedEventArgs e)
        {
            if (m_pMap == null) return;            
            string strLayerName = e.LayerName;

            //find the layers node
            //the key is the name of the node
            TreeNode[] pLayersNodes = treeViewLegend.Nodes[0].Nodes.Find(NODE_LAYERS, false);
            if (pLayersNodes.Length <= 0) return;

            if (e.IsAddLayer)
            {
                if (e.LayerIndex < 0) return;

                //layer added                
                //add a layernode to the treeview  
                //is the node should be inserted into the fitstnode?
                layerObj pLayer = m_pMap.getLayer(e.LayerIndex);
                if (pLayer != null)
                    AddLayerNode(pLayer, pLayersNodes[0], e.LayerIndex);
                pLayer.Dispose();

            }
            else
            {
                //is remove layer                

                TreeNodeCollection pLayerNodes = pLayersNodes[0].Nodes;
                if (pLayerNodes == null) return;

                //layer removed                
                //remove the layernode in the treeview                  
                int iCount = pLayerNodes.Count;
                for (int i = 0; i < iCount; i++)
                {
                    if (pLayerNodes[i].Text == strLayerName)
                    {
                        pLayerNodes.Remove(pLayerNodes[i]);
                        break;
                    }
                }
            }
        }

        
        #endregion
    }
}
