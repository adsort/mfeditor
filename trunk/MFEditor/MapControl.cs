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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using OSGeo.MapServer;
using MFEditor.Utils;

using FusionMap.Carto;
using FusionMap.Geodatabase;
using FusionMap.DataSourcesFile;
using FusionMap.DataSourceExtension;
using FusionMap.Geometries;

namespace MFEditor.Control
{
    
    public partial class MapControl : UserControl
    {
        #region "Event Delegate"

        ///<summary>
        ///ScaleChanged Event
        ///</summary>
        [Category("MFEditor Event")]
        public delegate void ScaleChangedEventHandler(object sender, ScaleEventArgs e);
        public event ScaleChangedEventHandler ScaleChanged;
      
        ///<summary>
        ///MapServerError Event
        ///</summary>
        [Category("MFEditor Event")]
        public delegate void ErrorOccuredEventHandler(object sender, MSErrorEventArgs e);
        public event ErrorOccuredEventHandler ErrorOccured;

        ///<summary>
        ///OnLayerChanged Event
        ///</summary>
        [Category("MFEditor Event")]
        public delegate void OnLayerChangedEventHandler(object sender, LayerChangedEventArgs e);
        public event OnLayerChangedEventHandler OnLayerChanged;

        ///<summary>
        ///OnMapReplaced Event
        ///</summary>
        [Category("MFEditor Event")]
        public delegate void OnMapReplacedEventHandler(object sender, EventArgs e);
        public event OnMapReplacedEventHandler OnMapReplaced;

        ///<summary>
        ///OnExtentChanged Event
        ///</summary>
        [Category("MFEditor Event")]
        public delegate void OnExtentChangedEventHandler(object sender, ExtentChangedEventArgs e);
        public event OnExtentChangedEventHandler OnExtentChanged;

        ///<summary>
        ///OnLayerStateChanged Event
        ///</summary>
        [Category("MFEditor Event")]
        public delegate void OnLayerStateChangedEventHandler(object sender, LayerStateChangedEventArgs e);
        public event OnLayerStateChangedEventHandler OnLayerStateChanged;

        ////reload the OnMouseMove method
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //   if(m_inversePixelPerProjectionX*m_inversePixelPerProjectionY != 0)
        //    {
        //        //CPoint newPoint;
        //        //newPoint.x = m_Curextents.left + point.x * m_inversePixelPerProjectionX;
        //        //newPoint.y = m_Curextents.bottom + point.y * m_inversePixelPerProjectionY;
        //        base.OnMouseMove(e);
        //    }
        //    else      	
        //        base.OnMouseMove(e);
        //}

        #endregion


        private const int MAXLAYERCOUNT = 256;

        /// <summary>
        /// Map tools enumeration
        /// </summary>
        public enum Tools
        {
            /// <summary>
            /// Pan
            /// </summary>
            Pan,
            /// <summary>
            /// Zoom in
            /// </summary>
            ZoomIn,
            /// <summary>
            /// Zoom out
            /// </summary>
            ZoomOut,
            /// <summary>
            /// Query tool
            /// </summary>
            Query,
            /// <summary>
            /// No active tool
            /// </summary>
            None
        }

        //the current activated tool
        private Tools m_pActivetool;

        //used for drawing the zoom box
        private Rubberband m_RubberBand = null;

        private string _TempMapfilePath = "";//the path of the temp mapfile        
        private string _MapfilePath = "";//the filepath of working mapfile        


        private mapObj _Map = null;

        #region "variable for mapfile parameter"

        //the Extent Information of the mapfile
        double m_MapMinx = 0;
        double m_MapMiny = 0;
        double m_MapMaxx = 0;
        double m_MapMaxy = 0;

        //the size of the mapfile
        int m_MapWidth = 256;
        int m_MapHeight = 256;

        //the output image format of the map
        //mcOutImageFormat m_outImgFormat;

        #endregion

        
        #region "variable for pan "
        private bool m_blnOnPan = false;//indicate the current action is pan or not
        private Point m_bitbltClickDown;
        private Point m_bitbltClickMove;
        #endregion

        //current visible extents;
        private Extent m_Curextents = new Extent();
        //private Extent m_pResizeExtent;

        //current Window Properties
        private int m_viewWidth = 0;
        private int m_viewHeight = 0;

        private int m_lngMaxHistory = 50;//记录最多的历史视图的数量
        private Extent[] m_prevExtents = new Extent[50];//记录前视图
        private Extent[] m_lastExtents = new Extent[50];//记录后视图的范围

        //CursorModesHelpers
        private Point m_clickDown;
        private Point m_clickMove;

        //Projection Variables
        double m_pixelPerProjectionX = 0;
        double m_pixelPerProjectionY = 0;
        double m_inversePixelPerProjectionX = 0;
        double m_inversePixelPerProjectionY = 0;

        //计算比例尺的地图单位
        double[] inchesPerUnit = new double[6];

        //private Stack<Extent> m_pStackPrev;
        //private Stack<Extent> m_pStackLast;

        private ArrayList m_pAryPrevExt = new ArrayList();
        private ArrayList m_pAryLastExt = new ArrayList();

        //wanliyun:2009.05.07
        //record the layer visible and status of the map
        private int[] m_iLayerVisible = new int[MAXLAYERCOUNT];
        private int[] m_iLayerStatus = new int[MAXLAYERCOUNT];

        /// <summary>
        /// the construct function
        /// </summary>
        public MapControl()
        {
            InitializeComponent();

            inchesPerUnit[0] = 1;
            inchesPerUnit[1] = 12;
            inchesPerUnit[2] = 63360.0;
            inchesPerUnit[3] = 39.3701;
            inchesPerUnit[4] = 39370.1;
            inchesPerUnit[5] = 4374754;

            m_viewWidth = this.Width;
            m_viewHeight = this.Height;

            this.BorderStyle = BorderStyle.FixedSingle;

            m_pActivetool = Tools.None;
            //base.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MapImage_Wheel);        
            //this.Cursor = new Cursor(GetType(), "zoomin.cur");

            if (this.BackgroundImage != null)
            {
                this.BackgroundImage.Dispose();
                this.BackgroundImage = null;
            }

            for(int i=0;i<MAXLAYERCOUNT;i++)
            {
                m_iLayerVisible[i] = 0;
                m_iLayerStatus[i] = 0;
            }

            //Bitmap image1 = new Bitmap("c:\\temp.jpg", true);
            //this.BackgroundImage = Bitmap.FromFile("c:\\temp.jpg");
            //image1.Dispose();

        }

        /****************************Start Method**********************************/

        #region "public method"

        #region "function for mapfile"

        /// <summary>
        /// create a copy of the origin mapfile
        /// </summary>
        /// <param name="originPath"></param>
        /// <returns></returns>
        public bool CreateTempMapfile(string originPath)
        {
            try
            {
                //use the temp.map name for all the maps
                string strTempPath = Utility.GetTempPath(originPath);

                File.Delete(strTempPath);

                //copy a workversion to the exepath
                File.Copy(originPath, strTempPath);

                _TempMapfilePath = strTempPath;

                return true;
            }
            catch
            { }

            return false;
        }
                     
        /// <summary>
        /// load mapfile
        /// </summary>
        /// <param name="filePath">the mapfile path to open</param>
        /// <returns>true:open successful false:open failed</returns>
        public bool loadMapfile(string filePath)
        {
            //if there is already a mapobj，distroy it.
            if (_Map != null)
                closeMapfile();

            if (filePath.Length > 1024)
            {
                if (ErrorOccured != null)
                    ErrorOccured(null, new MSErrorEventArgs("mapfile path is too long\n"));
                return false;
            }

            if (filePath.Length <= 0)
            {
                if (ErrorOccured != null)
                    ErrorOccured(null, new MSErrorEventArgs("mapfile path is null\n"));
                return false;
            }

            if (_Map != null)
                closeMapfile();            

            _MapfilePath = filePath;           

            if (!CreateTempMapfile(_MapfilePath))
            {
                if (ErrorOccured != null)
                    ErrorOccured(null, new MSErrorEventArgs("create tempfile failure!\n"));
                return false;
            }

            try
            {
                _Map = new mapObj(filePath);
            }
            catch (Exception ex)
            {
                if (ErrorOccured != null)
                    ErrorOccured(null, new MSErrorEventArgs("open mapfile failed:" + ex.Message));
                return false;
            }            

            rectObj mapRect = _Map.extent;

            m_MapMinx = mapRect.minx;
            m_MapMiny = mapRect.miny;
            m_MapMaxx = mapRect.maxx;
            m_MapMaxy = mapRect.maxy;

            m_MapWidth = _Map.width;
            m_MapHeight = _Map.height;

           
            //m_outImgFormat = GetoutputImageFormat();

            //set the output image size，according to the size of mapcontrol
            _Map.width = this.Width;
            _Map.height = this.Height;

            //_Map.imagecolor.red

            RecordLayersState();
            //get the background color of mapfile
            //m_BackColor = RGB(_Map.imagecolor.red,_Map.imagecolor.green,_Map.imagecolor.blue);		

            refreshMap(false);

            //wanliyun:2009.05.07
            //fire the mapreplaced event
            if (this.OnMapReplaced != null)
                OnMapReplaced(null, new EventArgs());


            return true;
        }

        /// <summary>
        ///create a new mapfile
        /// </summary>
        public bool newMapfile()
        {
            if(_Map != null)
		        closeMapfile();              

            _MapfilePath = "";
            _TempMapfilePath = "";
            

            _Map = new mapObj("");

            if (_Map == null)
                return false;
            else
            {
                _Map.extent.maxx = 100;
                _Map.extent.maxy = 100;
                _Map.extent.minx = -100;
                _Map.extent.miny = -100;

                _Map.name = "NewMap";

                m_MapWidth = _Map.width;
                m_MapHeight = _Map.height;

                //int result = _Map.save(filePath);

                //loadMapfile(filePath);

                //wanliyun:2009.05.07
                //fire the mapreplaced event
                if (this.OnMapReplaced != null)
                    OnMapReplaced(null, new EventArgs());

                RecordLayersState();

                return true;
            }	           
        }

        /// <summary>
        /// save the current map to temp mapfile
        /// </summary>
        /// <param name="filePath">save the mapfile to originally path</param>
        /// <param name="saveSymbollist">indicate save the symbollist or not</param>
        /// <returns>true or false</returns>
        public bool SaveTempMapfile(bool saveSymbollist)
        {
            return SaveMapfile(_TempMapfilePath, saveSymbollist);
        }

        /// <summary>
        /// save the current map to mapfile
        /// </summary>
        /// <param name="filePath">save the mapfile to originally path</param>
        /// <param name="saveSymbollist">indicate save the symbollist or not</param>
        /// <returns>true or false</returns>
        public bool SaveMapfile(string filePath,bool saveSymbollist)
        {
            if(_Map == null) return false;

            string sMapfilePath = filePath;

            if (sMapfilePath.Length > 1024)
            {
                if (ErrorOccured != null)
                    ErrorOccured(null, new MSErrorEventArgs("The path of mapfile is too long!\n"));
                return false;
            }

            if (sMapfilePath.Length <= 0)
            {
                if (ErrorOccured != null)
                    ErrorOccured(null, new MSErrorEventArgs("Please set the path to save the mapfile!\n"));
                return false;
            }

            //reset the extents of mapobj to originally
            _Map.extent.maxx = m_MapMaxx;
            _Map.extent.minx = m_MapMinx;
            _Map.extent.maxy = m_MapMaxy;
            _Map.extent.miny = m_MapMiny;

            _Map.width = m_MapWidth;
            _Map.height = m_MapHeight;

            File.Delete(filePath);

            //SetoutputImageFormat(m_outImgFormat);
            int result = _Map.save(filePath);

            if ((saveSymbollist)&&(_Map.symbolset.filename != null))
            {
                _Map.symbolset.save(_Map.symbolset.filename);
            }

            //reset the extents of mapobj to current extents
            _Map.extent.maxx = m_Curextents.Right;
            _Map.extent.minx = m_Curextents.Left;
            _Map.extent.maxy = m_Curextents.Top;
            _Map.extent.miny = m_Curextents.Bottom;

            //reset the size of the mapobj to current size
            _Map.width = m_viewWidth;
            _Map.height = m_viewHeight;

            return true;
        }

       
        /// <summary>
        /// close the current mapfile
        /// </summary>
        /// <returns></returns>
        public bool closeMapfile()
        {
            if (_Map != null)
            {
                _Map.Dispose();
                _Map = null;
            }

            m_MapMinx = 0.0;
            m_MapMiny = 0.0;
            m_MapMaxx = 0.0;
            m_MapMaxy = 0.0;

            m_MapWidth = 256;
            m_MapHeight = 256;

            //记录当前打开的map文件的路径
            _MapfilePath = "";
            _TempMapfilePath = "";

            //m_outImgFormat = mcIFUNKNOWN;
            m_blnOnPan = false;

            //清空前后视图记录
            m_pAryPrevExt.Clear();//记录前视图
            m_pAryLastExt.Clear();//记录后视图的范围

            m_pixelPerProjectionX = 0;
            m_pixelPerProjectionY = 0;
            m_inversePixelPerProjectionX = 0;
            m_inversePixelPerProjectionY = 0;

            ClearLayerState();

            if (ScaleChanged != null)
                ScaleChanged(null, new ScaleEventArgs(1));

            //InvalidateControl();

            refreshMap(false);

            //wanliyun:2009.05.07
            //fire the mapreplaced event
            if (this.OnMapReplaced != null)
                OnMapReplaced(null,new EventArgs());

            return true;
        }
        #endregion

        //地理坐标屏幕坐标转换
        public void toMapPoint(int pixelX, int pixelY,out double geoX,out double geoY)
        {           
            geoX = m_Curextents.Left + pixelX * m_inversePixelPerProjectionX;
            geoY = m_Curextents.Bottom + pixelY * m_inversePixelPerProjectionY;
        }

        //添加一个新图层到mapfile
        public bool addLayer(string dataPath)
        {
            if (_Map == null)
            {
                if (ErrorOccured != null)
                    ErrorOccured(null, new MSErrorEventArgs("没有打开mapfile"));

                return false;
            }

            layerObj pLayer = new layerObj(_Map);
            pLayer.status = 1;            
           

            string strName = Path.GetFileNameWithoutExtension(dataPath);
            pLayer.name = strName;
            pLayer.group = strName;

            string strExt = Path.GetExtension(dataPath).ToLower();
            //wanliyun:2009.05.06
            //add the mapinfo tab format support
            if ((strExt == ".shp") || (strExt == ".tab"))
            {
                IFeatureClass pFc = null;

                if (strExt == ".shp")
                {
                    IWorkspaceFactory pWsf = new ShapefileWorkspaceFactory();
                    IFeatureWorkspace pFws = pWsf.OpenFromFile(dataPath, 0) as IFeatureWorkspace;
                    pFc = pFws.OpenFeatureClass(strName);
        
                    pLayer.connectiontype = MS_CONNECTION_TYPE.MS_SHAPEFILE;
                    pLayer.data = dataPath;
                }
                else if (strExt == ".tab")
                {
                    IWorkspaceFactory pWsf = new OgrWorkspaceFactory();
                    IFeatureWorkspace pFws = pWsf.OpenFromFile(dataPath, 0) as IFeatureWorkspace;

                    pFc = pFws.OpenFeatureClass(strName);

                    pLayer.connectiontype = MS_CONNECTION_TYPE.MS_OGR;
                    pLayer.connection = dataPath;
                }

                IEnvelope pEnvelope = ((IGeoDataset)pFc).Extent;

                if (_Map.numlayers == 1)
                {
                    _Map.extent.minx = pEnvelope.XMin;
                    _Map.extent.miny = pEnvelope.YMin;
                    _Map.extent.maxx = pEnvelope.XMax;
                    _Map.extent.maxy = pEnvelope.YMax;
                }
                else
                {
                    //if the layer extents lager than the map extents
                    //reset the map extents
                    if (pEnvelope.XMin < _Map.extent.minx)
                        _Map.extent.minx = pEnvelope.XMin;
                    if (pEnvelope.YMin < _Map.extent.miny)
                        _Map.extent.miny = pEnvelope.YMin;
                    if (pEnvelope.XMax > _Map.extent.maxx)
                        _Map.extent.maxx = pEnvelope.XMax;
                    if (pEnvelope.YMax > _Map.extent.maxy)
                        _Map.extent.maxy = pEnvelope.YMax;

                }

                //rerecord the max extents
                m_MapMinx = _Map.extent.minx;
                m_MapMiny = _Map.extent.miny;
                m_MapMaxx = _Map.extent.maxx;
                m_MapMaxy = _Map.extent.maxy;

                classObj myClass = new classObj(pLayer);
                myClass.name = "random";

                styleObj myStyle = new styleObj(myClass);
                Color pRandomColor = GetRandomColor();
                myStyle.color.red = pRandomColor.R;
                myStyle.color.green = pRandomColor.G;
                myStyle.color.blue = pRandomColor.B;
                
                myStyle.opacity = 0;

                fmapGeometryType pGeomType = pFc.ShapeType;

                

                if ((pGeomType == fmapGeometryType.Point) ||
                    (pGeomType == fmapGeometryType.Point25D) ||
                    (pGeomType == fmapGeometryType.MultiPoint) ||
                    (pGeomType == fmapGeometryType.MultiPoint25D))
                {
                    pLayer.type = MS_LAYER_TYPE.MS_LAYER_POINT;
                }
                else if ((pGeomType == fmapGeometryType.LineString) ||
                        (pGeomType == fmapGeometryType.LineString) ||
                        (pGeomType == fmapGeometryType.MultiLineString) ||
                        (pGeomType == fmapGeometryType.MultiLineString25D))
                {
                    pLayer.type = MS_LAYER_TYPE.MS_LAYER_LINE;
                }
                else if ((pGeomType == fmapGeometryType.Polygon) ||
                        (pGeomType == fmapGeometryType.Polygon25D) ||
                        (pGeomType == fmapGeometryType.MultiPolygon) ||
                        (pGeomType == fmapGeometryType.MultiPolygon25D))
                {
                    pRandomColor = GetRandomColor();
                    myStyle.outlinecolor.red = pRandomColor.R;
                    myStyle.outlinecolor.green = pRandomColor.G;
                    myStyle.outlinecolor.blue = pRandomColor.B;

                    pLayer.type = MS_LAYER_TYPE.MS_LAYER_POLYGON;
                }
                else
                {
                    pLayer.type = MS_LAYER_TYPE.MS_LAYER_POLYGON;
                }

                if (pFc != null)
                    pFc.Dispose();
            }           
            else if ((strExt == ".tif") || (strExt == ".img"))
            {
                pLayer.data = dataPath;
                pLayer.connectiontype = MS_CONNECTION_TYPE.MS_RASTER;
                pLayer.type = MS_LAYER_TYPE.MS_LAYER_RASTER;
            }
            else
                return false;

            

            if (OnLayerChanged != null)
                OnLayerChanged(null, new LayerChangedEventArgs(pLayer.index,strName, true));

      

            RecordLayersState();
            //Console.WriteLine(_Map.numlayers.ToString());

            return true;
        }

        //remove a layer from mapfile according to the layername
        public bool removeLayer(string layerName)
        {
            bool blnResult = false;
            int iCount = _Map.numlayers;
            for(int i=0;i< iCount;i++)
            {
                if (_Map.getLayer(i).name == layerName)
                {
                    blnResult = true;
                    removeLayer(i);
                    break;

                }
            }

            return blnResult;
        }

        //remove a layer from mapfile accroeding to the layerindex
        public bool removeLayer(int index)
        {
            if((index >= 0)&&(index<_Map.numlayers))
            {
                layerObj delLayer = _Map.removeLayer(index);
                string strName = delLayer.name;
                delLayer.Dispose();
                RecordLayersState();
                this.refreshMap(false);

                if (OnLayerChanged != null)
                    OnLayerChanged(null, new LayerChangedEventArgs(-1,strName, false));
                return true;
            }
            else
                return false;
            
        }


        #region "范围函数"

        //全图工具
        public void zoomToFullExtents()
        {
            zoomToExtents(m_MapMinx, m_MapMaxx, m_MapMiny, m_MapMaxy);
        }

        //前视图工具
        public int zoomToPrev()
        {

            int iItemCount = m_pAryPrevExt.Count;
            if (iItemCount > 0)
            {
                Extent pTempExtent = (Extent)m_pAryPrevExt[iItemCount - 1];               
                m_pAryLastExt.Add(m_Curextents);
                CalculateVisibleExtents(pTempExtent, false, false);
                m_pAryPrevExt.RemoveAt(iItemCount - 1); 
                refreshMap(false);	    
            }

            return m_pAryPrevExt.Count;
        }

        //后视图工具
        public int zoomToLast()
        {
            int iItemCount = m_pAryLastExt.Count;

            if (iItemCount > 0)
            {
                Extent pTempExtent = (Extent)m_pAryLastExt[iItemCount - 1];               
                m_pAryPrevExt.Add(m_Curextents);
                if (m_pAryPrevExt.Count > m_lngMaxHistory)
                {
                    m_pAryPrevExt.RemoveAt(m_pAryPrevExt.Count - 1);
                }
                CalculateVisibleExtents(pTempExtent, false, false);
                m_pAryLastExt.RemoveAt(iItemCount - 1);
                refreshMap(false);	 
            }

            return m_pAryLastExt.Count;
        }

        public void zoomToExtents(double xMin, double xMax, double yMin, double yMax)
        {    	

	        Extent inExtent = new Extent(xMin,xMax,yMin,yMax);
	        CalculateVisibleExtents(inExtent,true,true);
            refreshMap(false);	        
        }

        public void zoomIn()
        {
	        double halfW = Math.Abs(m_Curextents.Right - m_Curextents.Left)/4;
            double halfH = Math.Abs(m_Curextents.Top - m_Curextents.Bottom) / 4;

	        Extent zoomGeoExt = new Extent(m_Curextents.Left + halfW,m_Curextents.Right - halfW,
		        m_Curextents.Bottom + halfH,m_Curextents.Top - halfH);

            CalculateVisibleExtents(zoomGeoExt, true, true);
            refreshMap(false);
        }

        public void zoomOut()
        {

            double halfW = Math.Abs(m_Curextents.Right - m_Curextents.Left) / 4;
            double halfH = Math.Abs(m_Curextents.Top - m_Curextents.Bottom) / 4;

            Extent zoomGeoExt = new Extent(m_Curextents.Left - halfW, m_Curextents.Right + halfW,
                m_Curextents.Bottom - halfH, m_Curextents.Top + halfH);
            CalculateVisibleExtents(zoomGeoExt, true, true);
            refreshMap(false);	
        }

        public void zoomToScale(double dblScale)
        {
            // get center
            double xCenter = (m_Curextents.Right + m_Curextents.Left) / 2;
            double yCenter = (m_Curextents.Top + m_Curextents.Bottom) / 2;
            // get extent
            int intMapUnit = (int)_Map.units;
            double geoWidth = dblScale * m_viewWidth / (_Map.resolution * inchesPerUnit[intMapUnit]);
            double geoHeight = dblScale * m_viewHeight / (_Map.resolution * inchesPerUnit[intMapUnit]);
            // zoomToExtents
            zoomToExtents(xCenter - geoWidth / 2, xCenter + geoWidth / 2, yCenter - geoHeight / 2, yCenter + geoHeight / 2);
        }


        #endregion

      
        /// <summary>
        /// refresh the map,can reread the origin mapfile
        /// </summary>
        /// <param name="reload"></param>
        public void refreshMap(bool reload)
        {
            if (_Map == null)
            {
                if (this.BackgroundImage != null)
                    this.BackgroundImage = null;
                return;
            }
            
            if (reload)
            {                
                if (_Map != null)
                    _Map.Dispose();

                try
                {

                    //_TempMapfilePath = CreateTempMapfile(_MapfilePath);

                    _Map = new mapObj(_TempMapfilePath);
                    _Map.setSize(m_viewWidth, m_viewHeight);
                    _Map.extent.minx = m_Curextents.Left;
                    _Map.extent.maxx = m_Curextents.Right;
                    _Map.extent.miny = m_Curextents.Bottom;
                    _Map.extent.maxy = m_Curextents.Top;

                    drawImg2Mapcontrol();

                    //fire the mapreplaced event
                    if (this.OnMapReplaced != null)
                        OnMapReplaced(null, new EventArgs());
                }
                catch (Exception ex)
                {
                    if (ErrorOccured != null)
                        ErrorOccured(null, new MSErrorEventArgs(ex.Message));
                    closeMapfile();
                }                
            }
            else
            {
                try
                {
                    _Map.setSize(m_viewWidth, m_viewHeight);

                    drawImg2Mapcontrol();

                    calculateNewScale();
                 
                    m_Curextents = new Extent(_Map.extent.minx, _Map.extent.maxx, _Map.extent.miny, _Map.extent.maxy);


                    {
                        double geoWidth = Math.Abs(m_Curextents.Right - m_Curextents.Left);
                        double geoHeight = Math.Abs(m_Curextents.Top - m_Curextents.Bottom);

                        if (geoWidth == 0)
                        {
                            m_pixelPerProjectionX = 0;
                            m_inversePixelPerProjectionX = 0;
                        }
                        else
                        {
                            m_pixelPerProjectionX = m_viewWidth / geoWidth;
                            m_inversePixelPerProjectionX = 1.0 / m_pixelPerProjectionX;
                        }

                        if (geoHeight == 0)
                        {
                            m_pixelPerProjectionY = 0;
                            m_inversePixelPerProjectionY = 0;
                        }
                        else
                        {
                            m_pixelPerProjectionY = m_viewHeight / geoHeight;
                            m_inversePixelPerProjectionY = 1.0 / m_pixelPerProjectionY;
                        }
                    }

                    ChecktLayerState();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message,"提示");
                }

            }


        }

        //获取图层
        public layerObj getLayerByName(string layername)
        {
            if (_Map == null) return null;
            if (layername.Length == 0) return null;

            return _Map.getLayerByName(layername);
        }


        #endregion

        /****************************End Method**********************************/

        /****************************Start public properties**********************************/

        #region "Properties"
        public Tools ActiveTool
        {
            get { return m_pActivetool; }
            set
            {
                bool fireevent = (value != m_pActivetool);
                m_pActivetool = value;
                this.Cursor = GetCurrentCursor();                
                //if (fireevent)
                //    if (ActiveToolChanged != null)
                //        ActiveToolChanged(value);
            }
        }

        /// <summary>
        /// the control's current cursor
        /// </summary>
        /// <returns></returns>
        private Cursor GetCurrentCursor()
        {
            Cursor pCursor = Cursors.Default;

            string strPath = Application.StartupPath + "\\Resource\\";

            if (m_pActivetool == Tools.ZoomIn)
                pCursor = new Cursor(strPath + "zoomin.cur");
            else if (m_pActivetool == Tools.ZoomOut)
                pCursor = new Cursor(strPath + "zoomout.cur");
            else if (m_pActivetool == Tools.Pan)
                pCursor = new Cursor(strPath + "zoompan.cur");

            return pCursor;
        }

        /// <summary>
        /// the current mapfile's mapobj
        /// </summary>
        public mapObj Map
        {
            get { return _Map; }
            set
            {
                _Map = value;
                if (_Map != null)
                    this.Refresh();
            }
        }

        /// <summary>
        /// the current extent of the map
        /// </summary>
        public Extent Extents
        {
            get { return new Extent(m_MapMinx, m_MapMaxx, m_MapMiny, m_MapMaxy); }
            set
            {
                m_MapMinx = value.Left;
                m_MapMiny = value.Bottom;
                m_MapMaxx = value.Right;
                m_MapMaxy = value.Top;
                if (value != null)
                    this.Refresh();
            }
        }

        /// <summary>
        /// the filepath of working mapfile
        /// </summary>
        public string MapfilePath
        {
            get { return _MapfilePath; }
        }


        /// <summary>
        /// the path of the temp mapfile
        /// </summary>
        public string TempMapfilePath
        {
            get { return _TempMapfilePath; }
        }

        #endregion


        /****************************End public properties**********************************/



        /**************************Start private method***************************/

        #region "私有方法"

        public Color GetRandomColor()
        {
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            //  对于C#的随机数，没什么好说的
            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);

            //  为了在白色背景上显示，尽量生成深色
            int int_Red = RandomNum_First.Next(256);
            int int_Green = RandomNum_Sencond.Next(256);
            int int_Blue = (int_Red + int_Green > 400) ? 0 : 400 - int_Red - int_Green;
            int_Blue = (int_Blue > 255) ? 255 : int_Blue;

            return Color.FromArgb(int_Red, int_Green, int_Blue);
        }


        private void CalculateVisibleExtents( Extent e, bool LogPrev,bool OnResize)
        {
	        if(_Map == null) return;

	        if( LogPrev == true )
	        {
		        LogPrevExtent();
	        }	

	        //判断当前传入的范围是否大于地图的可见范围
	        //如果大于可见范围，调整到可见范围大小

            e.Left = e.Left < m_MapMinx ? m_MapMinx : e.Left;
            e.Right = e.Right > m_MapMaxx ? m_MapMaxx : e.Right;
            e.Bottom = e.Bottom < m_MapMiny ? m_MapMiny : e.Bottom;
            e.Top = e.Top > m_MapMaxy ? m_MapMaxy : e.Top;

	        //判断传入的范围与当前的显示区域范围比率是否一致
	        //如果不一致，修改范围	

	        double viewWidth = m_viewWidth;
	        double viewHeight = m_viewHeight;

	        double geoxMin = e.Left>=e.Right?e.Right:e.Left;
            double geoxMax = e.Left >= e.Right ? e.Left : e.Right;
            double geoyMin = e.Bottom >= e.Top ? e.Top : e.Bottom;
            double geoyMax = e.Bottom >= e.Top ? e.Bottom : e.Top;


	        double geoWidth = Math.Abs(geoxMax -  geoxMin);
            double geoHeight = Math.Abs(geoyMax - geoyMin);

	        if((viewWidth <=0)||(viewHeight <= 0)||(geoWidth <=0)||(geoHeight<=0))
	        {
		        m_Curextents = new Extent();
		        return;
	        }

	        double xAdjust = 0;
	        double yAdjust = 0;

	        if((viewWidth/viewHeight)>(geoWidth/geoHeight))
	        {
		        xAdjust = ((viewWidth/viewHeight)*geoHeight - geoWidth)/2;		
	        }
	        else
	        {
		        yAdjust = (geoWidth*viewHeight/viewWidth - geoHeight)/2;
	        }

	        //drawmap的时候会改变extent的范围。
	        //需要在这里还原
	        _Map.extent.maxx = geoxMax + xAdjust;
            _Map.extent.minx = geoxMin - xAdjust;
            _Map.extent.miny = geoyMin - yAdjust;
            _Map.extent.maxy = geoyMax + yAdjust;

            if (OnExtentChanged != null)
                OnExtentChanged(null, null);

	        //m_Curextents.left = geoxMin - xAdjust;
	        //m_Curextents.right = geoxMax + xAdjust;
	        //m_Curextents.top = geoyMin - yAdjust;
	        //m_Curextents.bottom = geoyMax +  yAdjust;		
        }

        private void LogPrevExtent()
        {
            m_pAryLastExt.Clear();
            m_pAryPrevExt.Add(m_Curextents);
            if (m_pAryPrevExt.Count > m_lngMaxHistory)
            {
                m_pAryPrevExt.RemoveAt(m_pAryPrevExt.Count - 1);
                //m_pStackPrev.Dequeue();
            }

        //    private ArrayList m_pAryPrevExt = new ArrayList();
        //private ArrayList m_pAryLastExt = new ArrayList();

           
                       
            //m_pStackLast.Clear();
            //m_pStackPrev.Push(m_Curextents);  
            //C#中暂时没有找到stack中移除底层要素的方法
            //if (m_pStackPrev.Count > m_lngMaxHistory)
            //    m_pStackPrev.Dequeue();
        }

        private Extent pixcelToGeo(Rectangle pixExtent)
        {
        	
	        //重新计算可见范围
	        //根据传入的extent的最长边来调整extent的大小，使其和现实区域范围大小一致
	        //传入的中心点
	        double pCenterX = (pixExtent.Right + pixExtent.Left)/2;
	        double pCenterY = (pixExtent.Top + pixExtent.Bottom)/2;	

	        //求出地理坐标长宽
	        double geoWidth = Math.Abs(m_Curextents.Right - m_Curextents.Left);
            double geoHeight = Math.Abs(m_Curextents.Top - m_Curextents.Bottom);	

	        double viewWidth = m_viewWidth;
	        double viewHeight = m_viewHeight;

            Extent newExt = new Extent();

	        if((viewWidth <=0)||(viewHeight <= 0)||(geoWidth <=0)||(geoHeight<=0))
                return newExt;

            newExt.Left = m_Curextents.Left + (pixExtent.Left / viewWidth) * geoWidth;
            newExt.Right = m_Curextents.Left + (pixExtent.Right / viewWidth) * geoWidth;
            newExt.Bottom = m_Curextents.Bottom + (1 - pixExtent.Bottom / viewHeight) * geoHeight;
            newExt.Top = m_Curextents.Bottom + (1 - pixExtent.Top / viewHeight) * geoHeight;
        	
	        return newExt;

        }

        #endregion

        /**************************End 私有方法***************************/


        #region "事件"

        private void msView_MouseDown(object sender, MouseEventArgs e)
        {

            m_clickDown.X = e.X;
            m_clickDown.Y = e.Y;

            if(e.Button == MouseButtons.Left)
            {
                if(m_pActivetool == Tools.Pan)
                {
                    m_blnOnPan = true;
                    m_bitbltClickDown.X = e.X;
                    m_bitbltClickDown.Y = e.Y;

                    if (pictureBoxPan.BackgroundImage != null)
                    {
                        pictureBoxPan.BackgroundImage.Dispose();
                        pictureBoxPan.BackgroundImage = null;
                    }

                    if (this.BackgroundImage != null)
                    {
                        Bitmap pNewImage = new Bitmap(this.BackgroundImage);
                        pictureBoxPan.BackgroundImage = pNewImage;
                        this.BackgroundImage.Dispose();
                        this.BackgroundImage = null;
                    }
                 
                    pictureBoxPan.Left = 0;
                    pictureBoxPan.Top = 0;

                    pictureBoxPan.Width = this.Width;
                    pictureBoxPan.Height = this.Height;

                    pictureBoxPan.Visible = true;

                    this.Capture = true;
                }
                else if (m_pActivetool == Tools.ZoomIn)
                {
                    this.m_RubberBand = new Rubberband(this, new Point(e.X, e.Y));

                }
                else if (m_pActivetool == Tools.ZoomOut)
                {
                    this.m_RubberBand = new Rubberband(this, new Point(e.X, e.Y));

                }

            }

            //if (_Map != null)
            //{
            //    if (e.Button == MouseButtons.Left) //dragging
            //        mousedrag = e.Location;
            //    if (MouseDown != null)
            //        MouseDown(this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y)), e);
            //}
        }

        private void msView_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (m_RubberBand != null)
            {
                if (_Map != null)
                {
                    Rectangle myRect = m_RubberBand.Bounds();

                    bool selected = true;

                    if (myRect.Width < 10 && myRect.Height < 10)
                        selected = false;

                    if (m_pActivetool == Tools.ZoomIn)
                    {
                        if (selected)
                        {
                            Extent zoomGeoExt = pixcelToGeo(myRect);
                            zoomToExtents(zoomGeoExt.Left, zoomGeoExt.Right, zoomGeoExt.Bottom, zoomGeoExt.Top);
                        }
                        else
                        {
                            //默认为放大一倍
                            zoomIn();
                        }

                    }
                    else if (m_pActivetool == Tools.ZoomOut)
                    {
                        if (selected)
                        {
                            double rectW = myRect.Width;
                            double rectH = myRect.Height;
                            //缩小地图，计算选择框和当前视图的比率，取最小比率
                            double dFactor = ((rectW / m_viewWidth) > (rectH / m_viewHeight)) ? (rectW / m_viewWidth) : (rectH / m_viewHeight);
                            dFactor = 1 / dFactor;

                            double pCenterX = (myRect.Right + myRect.Left) / 2;
                            double pCenterY = (myRect.Top + myRect.Bottom) / 2;

                            double dNewW = (m_viewWidth * dFactor) / 2;
                            double dNewH = (m_viewHeight * dFactor) / 2;

                            Rectangle newRect = Rectangle.FromLTRB((int)(pCenterX - dNewW), (int)(pCenterY + dNewH),
                                (int)(pCenterX + dNewW), (int)(pCenterY - dNewH));

                            Extent zoomGeoExt = pixcelToGeo(newRect);
                            zoomToExtents(zoomGeoExt.Left, zoomGeoExt.Right, zoomGeoExt.Bottom, zoomGeoExt.Top);
                        }
                        else
                        {
                            //默认为放大一倍
                            zoomOut();
                        }
                    }
                }

                m_RubberBand.End();
                m_RubberBand = null;
            }
            else if (m_pActivetool == Tools.Pan)
            {
                if (_Map == null) return;
                if (m_blnOnPan)
                {
                    m_blnOnPan = false;

                    //this is the only mode we care about for this event
                    m_bitbltClickDown.X = 0;
                    m_bitbltClickMove.Y = 0;

                    //m_pResizeExtent = m_Curextents;
                    double xAmount = (pictureBoxPan.Left) * m_inversePixelPerProjectionX;
                    double yAmount = (pictureBoxPan.Top) * m_inversePixelPerProjectionY;

                    _Map.extent.maxx -= xAmount;
                    _Map.extent.minx -= xAmount;
                    _Map.extent.miny += yAmount;
                    _Map.extent.maxy += yAmount;

                    LogPrevExtent();
                    refreshMap(false);

                    pictureBoxPan.Visible = false;
                    if (pictureBoxPan.BackgroundImage != null)
                    {
                        pictureBoxPan.BackgroundImage.Dispose();
                        pictureBoxPan.BackgroundImage = null;
                    }

                    this.Capture = false;
                    this.Refresh();
                }
                
            }
            //if (_Map != null)
            //{

            //    if (MouseUp != null)
            //        MouseUp(this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y)), e);

            //    if (e.Button == MouseButtons.Left)
            //    {
            //        if (this.ActiveTool == Tools.ZoomOut)
            //        {
            //            double scale = 0.5;
            //            if (!mousedragging)
            //            {
            //                _Map.Center = this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y));
            //                if (MapCenterChanged != null)
            //                    MapCenterChanged(_Map.Center);
            //            }
            //            else
            //            {
            //                if (e.Y - mousedrag.Y < 0) //Zoom out
            //                    scale = (float)Math.Pow(1 / (float)(mousedrag.Y - e.Y), 0.5);
            //                else //Zoom in
            //                    scale = 1 + (e.Y - mousedrag.Y) * 0.1;
            //            }
            //            _Map.Zoom *= 1 / scale;
            //            if (MapZoomChanged != null)
            //                MapZoomChanged(_Map.Zoom);
            //            Refresh();
            //        }
            //        else if (this.ActiveTool == Tools.ZoomIn)
            //        {
            //            double scale = 2;
            //            if (!mousedragging)
            //            {
            //                _Map.Center = this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y));
            //                if (MapCenterChanged != null)
            //                    MapCenterChanged(_Map.Center);
            //            }
            //            else
            //            {
            //                if (e.Y - mousedrag.Y < 0) //Zoom out
            //                    scale = (float)Math.Pow(1 / (float)(mousedrag.Y - e.Y), 0.5);
            //                else //Zoom in
            //                    scale = 1 + (e.Y - mousedrag.Y) * 0.1;
            //            }
            //            _Map.Zoom *= 1 / scale;
            //            if (MapZoomChanged != null)
            //                MapZoomChanged(_Map.Zoom);
            //            Refresh();
            //        }
            //        else if (this.ActiveTool == Tools.Pan)
            //        {
            //            if (mousedragging)
            //            {
            //                System.Drawing.Point pnt = new System.Drawing.Point(this.Width / 2 + (mousedrag.X - e.Location.X), this.Height / 2 + (mousedrag.Y - e.Location.Y));
            //                _Map.Center = this._Map.ImageToWorld(pnt);
            //                if (MapCenterChanged != null)
            //                    MapCenterChanged(_Map.Center);
            //            }
            //            else
            //            {
            //                _Map.Center = this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y));
            //                if (MapCenterChanged != null)
            //                    MapCenterChanged(_Map.Center);
            //            }
            //            Refresh();
            //        }
            //        else if (this.ActiveTool == Tools.Query)
            //        {
            //            if (_Map.Layers.Count > _queryLayerIndex && _queryLayerIndex > -1)
            //            {
            //                if (_Map.Layers[_queryLayerIndex].GetType() == typeof(SharpMap.Layers.VectorLayer))
            //                {
            //                    SharpMap.Layers.VectorLayer layer = _Map.Layers[_queryLayerIndex] as SharpMap.Layers.VectorLayer;
            //                    SharpMap.Geometries.BoundingBox bbox = this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y)).GetBoundingBox().Grow(_Map.PixelSize * 5);
            //                    SharpMap.Data.FeatureDataSet ds = new SharpMap.Data.FeatureDataSet();
            //                    layer.DataSource.Open();
            //                    layer.DataSource.ExecuteIntersectionQuery(bbox, ds);
            //                    layer.DataSource.Close();
            //                    if (ds.Tables.Count > 0)
            //                        if (MapQueried != null) MapQueried(ds.Tables[0]);
            //                        else
            //                            if (MapQueried != null) MapQueried(new SharpMap.Data.FeatureDataTable());
            //                }
            //            }
            //            else
            //                MessageBox.Show("No active layer to query");
            //        }
            //    }
            //    if (mousedragImg != null)
            //    {
            //        mousedragImg.Dispose();
            //        mousedragImg = null;
            //    }
            //    mousedragging = false;
        }

        private void msView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                m_clickMove.X = e.X;
                m_clickMove.Y = e.Y;

                if (m_pActivetool == Tools.Pan)
                {
                    //double xAmount = (m_clickDown.X - m_clickMove.X) * m_inversePixelPerProjectionX;
                    //double yAmount = (m_clickMove.Y - m_clickDown.Y) * m_inversePixelPerProjectionY;

                    //m_Curextents.left += xAmount;
                    //m_Curextents.right += xAmount;
                    //m_Curextents.bottom += yAmount;
                    //m_Curextents.top += yAmount;

                    m_clickDown = m_clickMove;

                    //根据鼠标的偏移位置移动底图
                    int iMovex = m_clickMove.X - m_bitbltClickDown.X;
                    int iMovey = m_clickMove.Y - m_bitbltClickDown.Y;

                    pictureBoxPan.Left = iMovex;
                    pictureBoxPan.Top = iMovey;                    

                }
                else if (m_pActivetool == Tools.ZoomIn)
                {
                    if (m_RubberBand != null)
                        m_RubberBand.ResizeTo(new Point(e.X, e.Y));

                }
                else if (m_pActivetool == Tools.ZoomOut)
                {
                    if (m_RubberBand != null)
                        m_RubberBand.ResizeTo(new Point(e.X, e.Y));
                }                
            }




            //if (_Map != null)
            //{

            //    SharpMap.Geometries.Point p = this._Map.ImageToWorld(new System.Drawing.Point(e.X, e.Y));

            //    if (MouseMove != null)
            //        MouseMove(p, e);

            //    if (Image != null && e.Location != mousedrag && !mousedragging && e.Button == MouseButtons.Left)
            //    {
            //        mousedragImg = this.Image.Clone() as Image;
            //        mousedragging = true;
            //    }

            //    if (mousedragging)
            //    {
            //        if (MouseDrag != null)
            //            MouseDrag(p, e);

            //        if (this.ActiveTool == Tools.Pan)
            //        {
            //            System.Drawing.Image img = new System.Drawing.Bitmap(this.Size.Width, this.Size.Height);
            //            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img);
            //            g.Clear(Color.Transparent);
            //            g.DrawImageUnscaled(mousedragImg, new System.Drawing.Point(e.Location.X - mousedrag.X, e.Location.Y - mousedrag.Y));
            //            g.Dispose();
            //            this.Image = img;
            //        }
            //        else if (this.ActiveTool == Tools.ZoomIn || this.ActiveTool == Tools.ZoomOut)
            //        {
            //            System.Drawing.Image img = new System.Drawing.Bitmap(this.Size.Width, this.Size.Height);
            //            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img);
            //            g.Clear(Color.Transparent);
            //            float scale = 0;
            //            if (e.Y - mousedrag.Y < 0) //Zoom out
            //                scale = (float)Math.Pow(1 / (float)(mousedrag.Y - e.Y), 0.5);
            //            else //Zoom in
            //                scale = 1 + (e.Y - mousedrag.Y) * 0.1f;
            //            RectangleF rect = new RectangleF(0, 0, this.Width, this.Height);
            //            if (_Map.Zoom / scale < _Map.MinimumZoom)
            //                scale = (float)Math.Round(_Map.Zoom / _Map.MinimumZoom, 4);
            //            rect.Width *= scale;
            //            rect.Height *= scale;
            //            rect.Offset(this.Width / 2 - rect.Width / 2, this.Height / 2 - rect.Height / 2);
            //            g.DrawImage(mousedragImg, rect);
            //            g.Dispose();
            //            this.Image = img;
            //            if (MapZooming != null)
            //                MapZooming(scale);
            //        }
            //    }
            //}
        }

        #endregion

        private void msView_Resize(object sender, EventArgs e)
        {
            m_viewWidth = this.Width;
            m_viewHeight = this.Height;
        }

        private void calculateNewScale()
        {
	        if(_Map == null) return;

	        double scaleW = 0;
	        double scaleH = 0;

	        double geoWidth = Math.Abs(_Map.extent.maxx - _Map.extent.minx);
            double geoHeight = Math.Abs(_Map.extent.maxy - _Map.extent.miny);

            int intMapUnit = (int)_Map.units;

            scaleW = geoWidth * (_Map.resolution * inchesPerUnit[intMapUnit]) / m_viewWidth;
            scaleH = geoHeight * (_Map.resolution * inchesPerUnit[intMapUnit]) / m_viewHeight;

            double dblScale = scaleW;

            // sw 2009-04-01 the real scale is the bigger,so the scaledenom is the smaller.
            //if (dblScale < scaleH)
            if (dblScale > scaleH)
                dblScale = scaleH;
            if (ScaleChanged != null)
                ScaleChanged(null, new ScaleEventArgs(dblScale));
        }

        private void RecordLayersState()
        {
            //record the state of layers in the map
            //visiabe&status            
            if (_Map == null) return;

            int iLayerCount = _Map.numlayers;
            if (iLayerCount > MAXLAYERCOUNT)
                iLayerCount = MAXLAYERCOUNT;

            for(int i=0;i<iLayerCount;i++)
            {
                layerObj pLayer = _Map.getLayer(i);
                if (pLayer == null)
                    continue;
                m_iLayerVisible[i] = pLayer.isVisible();
                m_iLayerStatus[i] = pLayer.status;

                pLayer.Dispose();               
            }

            
        }

        private void ChecktLayerState()
        {
            //compare the layer state with the last record
            //visiabe&status
            if (_Map == null) return;

            int iLayerCount = _Map.numlayers;
            if (iLayerCount > MAXLAYERCOUNT)
                iLayerCount = MAXLAYERCOUNT;

            for (int i = 0; i < iLayerCount; i++)
            {
                layerObj pLayer = _Map.getLayer(i);
                if (pLayer == null)
                    continue;
                if((m_iLayerVisible[i] != pLayer.isVisible())
                    &&(m_iLayerStatus[i] != pLayer.status))
                {
                    m_iLayerVisible[i] = pLayer.isVisible();
                    m_iLayerVisible[i] = pLayer.status;
                    bool blnVisible = Convert.ToBoolean(m_iLayerVisible[i]);
                    bool blnStatus = Convert.ToBoolean(m_iLayerStatus[i]);
                    if (OnLayerStateChanged != null)
                        OnLayerStateChanged(null, new LayerStateChangedEventArgs
                            (blnVisible, blnStatus,pLayer.name));
                }              

                pLayer.Dispose();
            }
        }

        //clear the information of the mapcontrol
        //used when the map is replaced or closed
        private void ClearLayerState()
        {
            for(int i=0;i<MAXLAYERCOUNT;i++)
            {
                m_iLayerVisible[i] = 0;
                m_iLayerStatus[i] = 0;
            }
        }

        //draw the mapserver imageobj to picturebox
        private void drawImg2Mapcontrol()
        {
            if (this.BackgroundImage != null)
            {
                this.BackgroundImage.Dispose();
                this.BackgroundImage = null;
            }

            imageObj img = _Map.draw();
            byte[] buffer = img.getBytes();
            MemoryStream ms = new MemoryStream();
            ms.Write(buffer, 0, buffer.Length);
            this.BackgroundImage = Image.FromStream(ms);
            ms.Dispose();
            img.Dispose();
        }       
    }
}
