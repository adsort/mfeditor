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
    public partial class PointSymbolOptionsControl : SymbolOptionsControl
    {
        
        public PointSymbolOptionsControl()
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
                if (Symbol.size >=0)
                    numericUpDownSize.Value = (decimal)Symbol.size;
                if (Symbol.size >=0)
                    numericUpDownAngel.Value = (decimal)Symbol.angle;
                SymbolColor = Color.FromArgb(Symbol.color.red, Symbol.color.green,
                    Symbol.color.blue);
            }
        }
    
        private void numericUpDownSize_ValueChanged(object sender, EventArgs e)
        {
            if (IsInitialize) return;

            if (Symbol != null)
                Symbol.size = Convert.ToDouble(numericUpDownSize.Value);

            FireOnValueChanged();
        }

        private void numericUpDownAngel_ValueChanged(object sender, EventArgs e)
        {
            if (IsInitialize) return;

            if (Symbol != null)
                Symbol.angle = Convert.ToDouble(numericUpDownAngel.Value);

            FireOnValueChanged();
        }


       

       

    }
}
