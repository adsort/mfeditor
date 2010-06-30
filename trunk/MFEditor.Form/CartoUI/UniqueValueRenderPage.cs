using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using OSGeo.MapServer;

namespace MFEditorUI.CartoUI
{
    public partial class UniqueValueRenderPage : UserControl
    {
        private layerObj m_pLayer = null;

        public UniqueValueRenderPage(layerObj layer)
        {
            InitializeComponent();
            m_pLayer = layer;
        }

        private void UniqueValueRenderPage_Load(object sender, EventArgs e)
        {

        }
    }
}
