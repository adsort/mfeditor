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
    public partial  class SymbolOptionsControl : UserControl
    {
        private styleObj _Symbol = null;
        private Color _SymbolColor = Color.Black;
        public event OnValueChangedEventHandler OnValueChanged;
        private bool _IsInitialize = false;


        public SymbolOptionsControl()
        {
            InitializeComponent();
        }

        private void colorButton1_Click(object sender, EventArgs e)
        {
            if (_Symbol == null) return;

            IColorSelector selector = new ColorSelector();

            Color pColor =
                    Color.FromArgb(_Symbol.color.red, _Symbol.color.green, _Symbol.color.blue);

            selector.Color = pColor;
            selector.Location = base.PointToScreen(new Point(((ColorButton)sender).Left, ((ColorButton)sender).Bottom));
            if (selector.DoModal())
            {

                ((ColorButton)sender).ButtonColor = selector.Color;

                //this._Symbol.color = new colorObj(selector.Color.R, selector.Color.G, selector.Color.B, 0);

                _SymbolColor = selector.Color;
                //the follow code does not work out too well.
                //the color value is changed here,but when create preview image
                //is still use the old color

                //this._Symbol.color.red = selector.Color.R;
                //this._Symbol.color.green = selector.Color.G;
                //this._Symbol.color.blue = selector.Color.B;

                FireOnValueChanged();
            }
        }

        /// <summary>
        /// get the color of the symbol
        /// </summary>
        public Color SymbolColor
        {
            get
            {
                return _SymbolColor;
            }
            set
            {
                _SymbolColor = value;
                colorButton1.ButtonColor = value;
            }
        }

        /// <summary>
        /// get the color of the symbol of mstype
        /// </summary>
        public colorObj MsSymbolColor
        {
            get
            {
                return new colorObj(_SymbolColor.R,_SymbolColor.G,_SymbolColor.B,0);
            }            
        }

        /// <summary>
        /// the default symbol
        /// </summary>
        public styleObj Symbol
        {
            get
            {
                return this._Symbol;
            }
            set
            {
                this._Symbol = value;
                _IsInitialize = true;
                InitializeOptions();
                _IsInitialize = false;

            }
        }

        /// <summary>
        /// return if the current process is initialize
        /// </summary>
        protected bool IsInitialize
        {
            get { return _IsInitialize; }
        }

        /// <summary>
        /// initialise the options set using the current symbol
        /// </summary>
        protected virtual void InitializeOptions()
        {

        }


        /// <summary>
        /// ´¥·¢ÊÂ¼þ
        /// </summary>
        protected virtual void FireOnValueChanged()
        {
            if (this.OnValueChanged != null)
            {
                this.OnValueChanged();
            }
        }
        

    }
}
