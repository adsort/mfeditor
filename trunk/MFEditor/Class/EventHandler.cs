// Copyright 2008, 2009 - WanliYun (http://code.google.com/p/mfeditor/)
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
using System.Text;
using System.Drawing;

namespace MFEditor.Control
{
    #region "LegendControl "
    public class SelectedEventArgs : EventArgs
    {
        public int _Index;
        public string _Name;
        public System.Windows.Forms.MouseButtons _Button;
        public readonly int _X;
        public readonly int _Y;

        public int Index
        {
            get { return _Index; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public System.Windows.Forms.MouseButtons Button
        {
            get { return _Button; }
        }

        public int X
        {
            get { return _X; }
        }

        public int Y
        {
            get { return _Y; }
        }

        public SelectedEventArgs(System.Windows.Forms.MouseButtons button,int x,int y,int index,string name)
        {
            this._Index = index;
            this._Name = name;
            this._Button = button;
            this._X = x;
            this._Y = y;
        }

        //public SelectedEventArgs(System.Windows.Forms.MouseButtons button, int x, int y)
        //{            
        //    this.Button = button;
        //    this.X = x;
        //    this.Y = y;
        //}
    }

    public class VisibleEventArgs : EventArgs
    {
        public int _Index;
        public readonly string _LayerName;
        public readonly bool _Visible;

        public int Index
        {
            get { return _Index; }
        }

        public string LayerName
        {
            get { return _LayerName; }
        }

        public bool Visible
        {
            get { return _Visible; }
        }

        public VisibleEventArgs(int index, string layername,bool visible)
        {
            this._Index = index;
            this._LayerName = layername;
            this._Visible = visible;
       }      
    }

    #endregion

    #region "MapControl "
    public class ScaleEventArgs : EventArgs
    {

        private double _Scale = 0;

        public double Scale
        {
            get { return _Scale; }
        }

        public ScaleEventArgs(double newScale)
        {
            this._Scale = newScale;   
        }
    }

    public class MSErrorEventArgs : EventArgs
    {

        private string _ErrorInfo = "";

        public string ErrorInfo
        {
            get { return _ErrorInfo; }
        }


        public MSErrorEventArgs(string newError)
        {
            this._ErrorInfo = newError;
        }
    }

    public class LayerChangedEventArgs : EventArgs
    {
        private int _LayerIndex = -1;
        private string _LayerName = "";
        private bool _IsAddLayer = false;

        public int LayerIndex
        {
            get { return _LayerIndex; }
        }

        public string LayerName
        {
            get { return _LayerName; }
        }

        public bool IsAddLayer
        {
            get { return _IsAddLayer; }
        }

        public LayerChangedEventArgs(int layerindex,string layername,bool addlayer)
        {
            //li:2009.07.05
            //add Layerindex parameter£¬there will be sth wrong 
            //use the layername parameter to getlayer when more than 
            //one layer with the same name.
            this._LayerIndex = layerindex;
            this._LayerName = layername;
            this._IsAddLayer = addlayer;
        }
    }


    public class ExtentChangedEventArgs : EventArgs
    {

        private bool _SizeChanged = false;
        private readonly FusionMap.Geometries.IEnvelope _newExtent = null;

        public bool SizeChanged
        {
            get { return _SizeChanged; }
        }

        public FusionMap.Geometries.IEnvelope newExtent
        {
            get { return _newExtent; }
        }



        public ExtentChangedEventArgs(bool sizechange)
        {
            this._SizeChanged = sizechange;
        }
    }

    public class LayerStateChangedEventArgs : EventArgs
    {

        private bool _Visible = false;
        private bool _Status = false;
        private int _Index = -1;
        private string _LayerName = "";

        public bool Visible
        {
            get { return _Visible; }          
        }

        public bool Status
        {
            get { return _Status; }
        }

        public int Index
        {
            get { return _Index; }
        }

        public string LayerName
        {
            get { return _LayerName; }
        }


        public LayerStateChangedEventArgs(bool visible,bool status, int index, string layername)
        {
            this._Visible = visible;
            this._Status = status;
            this._Index = index;
            this._LayerName = layername;
        }

        public LayerStateChangedEventArgs(bool visible,bool status, string layername)
        {
            this._Visible = visible;
            this._Status = status;
            this._LayerName = layername;
        }  
    }

    #endregion
}