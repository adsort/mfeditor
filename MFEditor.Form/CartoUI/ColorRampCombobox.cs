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
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MFEditorUI.CartoUI
{
    public partial class ColorRampCombobox : System.Windows.Forms.ComboBox
    {
        public ColorRampCombobox()
        {
            InitializeComponent();
        }

        public ColorRampCombobox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
           // Size imageSize = e.DrawFocusRectangle();
            //Font fn = null;
            if (e.Index >= 0)
            {
                //fn = (Font)fontArray[0];
                //string s = "";
                //string s = (string)comboBox1.Items[e.Index];
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))
                {
                    //画条目背景 
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), r);
                    //绘制图像 
                    //imageList1.Draw(e.Graphics, r.Left, r.Top, e.Index);
                    //显示字符串 
                   // e.Graphics.DrawString(s, fn, new SolidBrush(Color.Black), r.Left + imageSize.Width, r.Top);
                    //显示取得焦点时的虚线框 
                    e.DrawFocusRectangle();
                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), r);
                    //imageList1.Draw(e.Graphics, r.Left, r.Top, e.Index);
                    //e.Graphics.DrawString(s, fn, new SolidBrush(Color.Black), r.Left + imageSize.Width, r.Top);
                    e.DrawFocusRectangle();
                }
            } 

            //base.OnDrawItem(e);
        }
    }
}
