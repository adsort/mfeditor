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
