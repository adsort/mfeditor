using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MFEditor
{
    public partial class formErr : Form
    {
        private string m_strErrs = "";
        public formErr(string strErrs)
        {
            InitializeComponent();
            m_strErrs = strErrs;
        }

        private void formErr_Load(object sender, EventArgs e)
        {
            labelErr.Text = m_strErrs;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}