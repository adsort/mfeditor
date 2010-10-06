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
using System.IO;
using System.Windows.Forms;

namespace MFEditor
{
    public partial class MFTextEditor : UserControl
    {

        private bool _IsDirty = false;//Indicates if the mapfile has been edited
        private string m_sMapfilePath = "";

        public MFTextEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Indicates if the mapfile has been edited
        /// </summary>
        public bool IsDirty
        {
            get { return _IsDirty; }
        } 
       
        /// <summary>
        /// show the mapfile according to the input filepath
        /// </summary>
        /// <param name="mapfilePath"></param>
        public void ShowMapfile(string mapfilePath)
        {
            if (System.IO.File.Exists(mapfilePath))
            {
                m_sMapfilePath = mapfilePath;

                TextReader myReaser = new StreamReader(mapfilePath, Encoding.Default);

                richTextBoxMapfile.Text = myReaser.ReadToEnd();

                myReaser.Close();
                myReaser.Dispose();
            }
            else
            {
                richTextBoxMapfile.Text = "";
            }

            _IsDirty = false;

        }

        /// <summary>
        /// save the current editing mapfile to disk
        /// </summary>
        /// <param name="mapfilePath"></param>
        public bool SaveMapfile()
        {
            if (m_sMapfilePath.Length == 0) return false;

            if (_IsDirty)
            {
                File.Delete(m_sMapfilePath);

                StreamWriter myWriter = new StreamWriter(m_sMapfilePath, true, Encoding.Default);
                myWriter.Write(richTextBoxMapfile.Text);
                myWriter.Flush();
                myWriter.Close();
                myWriter.Dispose();

                _IsDirty = false;
            }

            return true;

        }      

        private void richTextBoxMapfile_TextChanged(object sender, EventArgs e)
        {
            _IsDirty = true;
        }

        private void MFTextEditor_Load(object sender, EventArgs e)
        {
            _IsDirty = false;
        }

        
    }
}
