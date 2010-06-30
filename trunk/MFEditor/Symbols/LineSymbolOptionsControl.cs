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
