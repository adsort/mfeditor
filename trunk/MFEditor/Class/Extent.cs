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

namespace MFEditor.Control
{ 
    public class Extent
    {
        private double m_MinX = 0;
        private double m_MaxX = 0;
        private double m_MinY = 0;
        private double m_MaxY = 0;   
    
        public Extent()
        {

        }

        public Extent( double left, double right, double bottom, double top)
        {
            m_MinX = left;
            m_MaxX = right;
            m_MinY = bottom;
            m_MaxY = top;
        }


        public double Left
        {
            get { return m_MinX; }
            set
            {
                m_MinX = value;
            }
        }

        public double Right
        {
            get { return m_MaxX; }
            set
            {
                m_MaxX = value;
            }
        }

        public double Bottom
        {
            get { return m_MinY; }
            set
            {
                m_MinY = value;
            }
        }

        public double Top
        {
            get { return m_MaxY; }
            set
            {
                m_MaxY = value;
            }
        }
    }
}