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
