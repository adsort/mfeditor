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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OSGeo.MapServer;

namespace MFEditorUI
{
    public partial class FormClassSet : Form
    {
        private classObj m_pMcClass = null;
        public FormClassSet(classObj inClass)
        {
            InitializeComponent();

            m_pMcClass = inClass;
        }

        private void formClassSet_Load(object sender, EventArgs e)
        {
            if (m_pMcClass == null)
            {
                this.Close();
            }

            textName.Text = m_pMcClass.name;
            textExpression.Text = m_pMcClass.getExpressionString();

            textMinScale.Text = m_pMcClass.minscaledenom.ToString();
            textMaxScale.Text = m_pMcClass.maxscaledenom.ToString();

            textText.Text = m_pMcClass.getTextString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_pMcClass.name = textName.Text;
            m_pMcClass.setExpression(textExpression.Text);

            //textMinScale.Text = m_pMcClass.MinScale.ToString();
            //textMaxScale.Text = m_pMcClass.MaxScale.ToString();

            //m_pMcClass.Text = textText.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}