// Copyright 2008, 2009 - WanliYun (http://code.google.com/p/mfeditor/)
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
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MFEditor.Control
{
    class Rubberband
    {
        protected System.Windows.Forms.Control parent;
        protected Rectangle rect = Rectangle.Empty;

        public Rubberband(System.Windows.Forms.Control theParent, Point theStartingPoint)
        {
            parent = theParent;
            parent.Capture = true;
            Cursor.Clip = parent.RectangleToScreen(parent.ClientRectangle);
            rect = new Rectangle(theStartingPoint.X, theStartingPoint.Y, 0, 0);
        }

        public void End()
        {
            Cursor.Clip = Rectangle.Empty;
            parent.Capture = false;

            //erase the rubberband   
            Draw();
            rect = Rectangle.Empty;
        }

        public void ResizeTo(Point thePoint)
        {
            //erase the old rubberband   
            Draw();

            //get the new size of the rubberband   
            rect.Width = thePoint.X - rect.Left;
            rect.Height = thePoint.Y - rect.Top;

            //draw the new rubberband   
            Draw();
        }

        public Rectangle Bounds()
        {
            //   return   a   normalized   rectangle,   i.e.   a   rect   
            //   where   (left   <=   right)   and   (top   <=   bottom)   
            if ((rect.Left > rect.Right) || (rect.Top > rect.Bottom))
            {
                int left = Math.Min(rect.Left, rect.Right);
                int right = Math.Max(rect.Left, rect.Right);
                int top = Math.Min(rect.Top, rect.Bottom);
                int bottom = Math.Max(rect.Top, rect.Bottom);
                return Rectangle.FromLTRB(left, top, right, bottom);
            }
            return rect;
        }

        //Reversible drawing method   
        //Calling theis method the first time draws the rubberband.   
        //Calling it a second time with the same rect erases the rubberband   
        protected void Draw()
        {
            Rectangle r = parent.RectangleToScreen(rect);
            ControlPaint.DrawReversibleFrame(r, Color.White, FrameStyle.Dashed);
        }   

    }
}
