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

namespace MFEditor
{
    public partial class LineSymbolOptionsControl : SymbolOptionsControl
    {
        public LineSymbolOptionsControl()
        {
            InitializeComponent();
        }

        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            if (IsInitialize) return;

            if (Symbol != null)
            {
                Symbol.width = Convert.ToDouble(numericUpDownWidth.Value);
            }

            base.FireOnValueChanged();
        }


        /// <summary>
        /// initialise the options set using the current symbol
        /// </summary>
        protected override void InitializeOptions()
        {
            if (Symbol != null)
            {
                if (Symbol.width < -1)
                    Symbol.width = -1;
                if (Symbol.size < -1)
                    Symbol.size = -1;

                numericUpDownWidth.Value = (decimal)Symbol.width;
                numericUpDownSize.Value = (decimal)Symbol.size;
                SymbolColor = Color.FromArgb(Symbol.color.red, Symbol.color.green,
                    Symbol.color.blue);
            }
        }

        private void numericUpDownSize_ValueChanged(object sender, EventArgs e)
        {
            if (IsInitialize) return;

            if (Symbol != null)
            {
                Symbol.size = Convert.ToDouble(numericUpDownSize.Value);
            }

            base.FireOnValueChanged();
        }
    }
}
