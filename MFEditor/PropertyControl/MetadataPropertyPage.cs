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
using System.Windows.Forms;

using OSGeo.MapServer;

using MFEditor.Utils;


namespace MFEditor.PropertyControl
{
    public partial class MetadataPropertyPage : UserControl, IPropertyPage
    {
        public MetadataPropertyPage()
        {
            InitializeComponent();
        }

        private bool m_blnMetaInit = false;


        #region "Implement IPropertyPage"

        private layerObj m_pLayer = null;

        //if there is a change
        public bool _IsPageDirty = false;
        /// <summary>
        /// active the current page
        /// </summary>
        public void Activate()
        {
            if (m_pLayer == null) return;
            Initialize();
        }

        /// <summary>
        /// apply the current setting
        /// </summary>
        public void Apply()
        {
            if (m_pLayer == null) return;

            SaveEdit();
        }

        /// <summary>
        /// destory the current page
        /// </summary>
        public void Deactivate()
        {
        }

        /// <summary>
        /// return if there is any change of current object
        /// </summary>
        public bool IsPageDirty
        {
            get { return _IsPageDirty; }
        }


        /// <summary>
        /// set the object of the page
        /// </summary>
        /// <param name="inObject"></param>
        public void SetObjects(object inObject)
        {
            if (inObject is layerObj)
                m_pLayer = inObject as layerObj;
        }

        #endregion

        /// <summary>
        /// show the layer's metadata 
        /// </summary>
        private void Initialize()
        {
            if (m_pLayer == null) return;

            m_blnMetaInit = true;
            string strMetaName = m_pLayer.getFirstMetaDataKey();

            while ((strMetaName != null) && (!String.IsNullOrEmpty(strMetaName)))
            {
                string strMetaValue = m_pLayer.metadata.get(strMetaName, "");
                string[] pMetaRow = new string[2];
                pMetaRow[0] = strMetaName;
                pMetaRow[1] = strMetaValue;

                dataGridViewMeta.Rows.Add(pMetaRow);

                strMetaName = m_pLayer.getNextMetaDataKey(strMetaName);
            }
        }

        /// <summary>
        /// save the current setting
        /// </summary>
        private void SaveEdit()
        {
            if (m_pLayer == null) return;

            if (m_blnMetaInit == false) return;
            //there is always a static rows
            int iCount = dataGridViewMeta.Rows.Count - 1;

            m_pLayer.metadata.clear();

            for (int i = 0; i < iCount; i++)
            {
                object objValue = null;
                objValue = dataGridViewMeta.Rows[i].Cells[0].Value;
                if (objValue == null) continue;

                string strName = objValue.ToString();

                objValue = dataGridViewMeta.Rows[i].Cells[1].Value;
                string strValue = "";
                if (objValue != null)
                    strValue = objValue.ToString();

                m_pLayer.metadata.set(strName, strValue);
            }
        }

        private void dataGridViewMeta_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //draw the index of the metadata
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGridViewMeta.RowHeadersWidth - 4,
                e.RowBounds.Height);


            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridViewMeta.RowHeadersDefaultCellStyle.Font, rectangle,
                dataGridViewMeta.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void dataGridViewMeta_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //-1 means is the index column
            if ((e.Button == MouseButtons.Right) && (e.ColumnIndex == -1))
            {
                //Console.WriteLine(e..X + "|" + e.Location.Y);
                //dataGridViewMeta.sele
                dataGridViewMeta.ClearSelection();
                dataGridViewMeta.Rows[e.RowIndex].Selected = true;

                contextMenuStripMeta.Show(MousePosition.X, MousePosition.Y);
            }

            //dataGridViewMeta.

            //dataGridViewMeta.SelectedRows[0];
        }

        private void ToolStripMenuItemMetaDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == Utility.PostQuestion("您确认要删除选中项吗？"))
            {
                if (dataGridViewMeta.SelectedRows.Count == 0) return;
                if (dataGridViewMeta.SelectedRows[0].Index < dataGridViewMeta.Rows.Count - 1)
                    dataGridViewMeta.Rows.RemoveAt(dataGridViewMeta.SelectedRows[0].Index);
            }
        }      
    }
}
