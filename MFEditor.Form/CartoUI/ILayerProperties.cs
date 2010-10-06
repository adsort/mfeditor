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
using System.Text;
using OSGeo.MapServer;

namespace MFEditorUI.CartoUI
{
    interface ILayerProperties
    {
        /// <summary>
        /// the layerobj used of the page
        /// </summary>
        layerObj Layer { set;}        

        /// <summary>
        /// activate the page
        /// </summary>
        void Activate();


        /// <summary>
        /// deactivate the page
        /// </summary>
        void Deactivate();       

        /// <summary>
        /// refresh the page
        /// </summary>
        void RefreshPage();
        
        /// <summary>
        /// apply the change to the layerobj
        /// </summary>
        void Apply();

        /// <summary>
        /// get the if the layerobj is changed
        /// </summary>
        bool IsDirty { get;}
        
    }
}
