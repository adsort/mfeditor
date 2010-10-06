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
using System.Collections;

using OSGeo.MapServer;

namespace MFEditor.PropertyControl
{
    public partial class NewClassForm : Form
    {
        private layerObj m_pCurrentLayer = null;
        private classObj m_pCurrentClass = null;
        private IEnumerator m_pUniqueValues = null;
        public NewClassForm(layerObj layer,IEnumerator uniqueEnum)
        {
            InitializeComponent();
            m_pCurrentLayer = layer;
            m_pUniqueValues = uniqueEnum;
        }

        public NewClassForm(classObj msClass, IEnumerator uniqueEnum)
        {
            InitializeComponent();
            m_pCurrentClass = msClass;
            m_pUniqueValues = uniqueEnum;
        }

        private void FormNewClass_Load(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.None;

            if ((m_pCurrentLayer == null) && (m_pCurrentClass == null))
                this.Dispose();

            if(m_pCurrentClass != null)
            {
                textBoxClassName.Text = m_pCurrentClass.name;
                textBoxGroup.Text = m_pCurrentClass.group;
                textBoxExpression.Text = m_pCurrentClass.getExpressionString();
            }

            //if(m_pUniqueValues != null)
            //{
            //    m_pUniqueValues.Reset();
            //    while (m_pUniqueValues.MoveNext()) 
            //    {
            //        object myObject = m_pUniqueValues.Current;
            //        listBoxValues.Items.Add(myObject);                    
            //    }

            //}
        }       

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if(m_pCurrentLayer != null)
            {
                classObj pClass = new classObj(m_pCurrentLayer);
                if (textBoxClassName.Text.Trim().Length > 0)
                    pClass.name = textBoxClassName.Text;

                if (textBoxGroup.Text.Trim().Length > 0)
                    pClass.group = textBoxGroup.Text;

                if (textBoxExpression.Text.Trim().Length > 0)
                    pClass.setExpression(textBoxExpression.Text);
            }
            else if (m_pCurrentClass != null)
            {
                if (textBoxClassName.Text.Trim().Length > 0)
                    m_pCurrentClass.name = textBoxClassName.Text;
                else
                    m_pCurrentClass.name = null;

                if (textBoxGroup.Text.Trim().Length > 0)
                    m_pCurrentClass.group = textBoxGroup.Text;
                else
                    m_pCurrentClass.group = null;

                if (textBoxExpression.Text.Trim().Length > 0)
                    m_pCurrentClass.setExpression(textBoxExpression.Text);
                else
                    m_pCurrentClass.setExpression(null);
            }

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// check if the input classobj has a style parameter
        /// a class must have a style item
        /// </summary>
        /// <param name="inClass"></param>
        private void CheckClass(classObj inClass)
        {
            if (inClass == null) return;

            if(inClass.numstyles == 0)
            {
                //stle
            }

        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {

        }

       
    }
}