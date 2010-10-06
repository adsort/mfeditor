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

namespace MFEditor.PropertyControl
{
    public interface IPropertyPage
    {
        /// <summary>
        /// ancivate the current page
        /// </summary>
        void Activate();

        /// <summary>
        /// apply the current setting 
        /// </summary>
        void Apply();

        /// <summary>
        /// destory the current page
        /// </summary>
        void Deactivate();

        /// <summary>
        /// return if there is any change of current object
        /// </summary>
        bool IsPageDirty { get;}

        /// <summary>
        /// show tha page
        /// </summary>
        void Show();

        /// <summary>
        /// hide the page
        /// </summary>
        void Hide();

        /// <summary>
        /// set the object of the page
        /// </summary>
        /// <param name="inObject"></param>
        void SetObjects(object inObject);

        /// <summary>
        /// get the width of the page
        /// </summary>
        int Width { get;}

        /// <summary>
        /// get the height of the page
        /// </summary>
        int Height { get;}
    }
}
