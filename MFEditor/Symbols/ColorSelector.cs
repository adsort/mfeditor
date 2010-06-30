
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

