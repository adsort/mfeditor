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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OSGeo.MapServer;

namespace MFEditor
{
    public partial class FillSymbolOptionsControl : SymbolOptionsControl
    {
        public FillSymbolOptionsControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// initialise the options set using the current symbol
        /// </summary>
        protected override void InitializeOptions()
        {
            if (Symbol != null)
            {
                if (Symbol.size >= 0)
                    numericUpDownOutWidth.Value = (decimal)Symbol.outlinewidth;

                SymbolColor = Color.FromArgb(Symbol.color.red, Symbol.color.green,
                    Symbol.color.blue);

                colorButtonOutline.ButtonColor = Color.FromArgb(Symbol.outlinecolor.red, Symbol.outlinecolor.green,
                    Symbol.outlinecolor.blue);
            }
        }

        private void numericUpDownOutWidth_ValueChanged(object sender, EventArgs e)
        {
            if (IsInitialize) return;

            if (Symbol != null)
            {
                Symbol.outlinewidth = Convert.ToDouble(numericUpDownOutWidth.Value);
                Symbol.outlinecolor = new colorObj(colorButtonOutline.ButtonColor.R, 
                    colorButtonOutline.ButtonColor.G, colorButtonOutline.ButtonColor.B, 0);
            }

            FireOnValueChanged();
        }

        private void colorButtonOutline_Click(object sender, EventArgs e)
        {
            if (Symbol == null) return;

            IColorSelector selector = new ColorSelector();

            Color pColor =
                    Color.FromArgb(Symbol.outlinecolor.red, Symbol.outlinecolor.green, Symbol.outlinecolor.blue);

            selector.Color = pColor;
            selector.Location = base.PointToScreen(new Point(((ColorButton)sender).Left, ((ColorButton)sender).Bottom));
            if (selector.DoModal())
            {
                colorButtonOutline.ButtonColor = selector.Color;
                FireOnValueChanged();
            }
        }

        /// <summary>
        /// get the outlinecolor of the symbol of mapservertype
        /// </summary>
        public colorObj MsSymbolOutLineColor
        {
            get
            {
                return new colorObj(colorButtonOutline.ButtonColor.R,
                    colorButtonOutline.ButtonColor.G,
                    colorButtonOutline.ButtonColor.B, 
                    0);
            }
        }

        /// <summary>
        /// override the ForeOnValueChanged function
        /// because the outlinecolor must be reset before drawing
        /// </summary>
        protected override void FireOnValueChanged()
        {
            Symbol.outlinecolor = new colorObj(colorButtonOutline.ButtonColor.R,
                colorButtonOutline.ButtonColor.G, colorButtonOutline.ButtonColor.B, 0);
            base.FireOnValueChanged();
        }
    
    }
}
