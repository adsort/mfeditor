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
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MFEditor
{
    public class ColorSelector : IColorSelector
    {
        private Point m_Location;
        private Color m_pColor = new Color();


        public bool DoModal()
        {
            ColorDialog dialog;
            dialog = new ColorDialog();
            if(this.m_pColor != null)
                dialog.Color = this.m_pColor;
            //dialog.Color = 

            dialog.FullOpen = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {                
                this.m_pColor = dialog.Color;
                return true;
            }
            return false;
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public Color Color
        {
            get
            {
                return this.m_pColor;
            }
            set
            {
                this.m_pColor = value;
            }
        }

        public Point Location
        {
            get
            {
                return this.m_Location;
            }
            set
            {
                this.m_Location = value;
            }
        }       
    }
}

