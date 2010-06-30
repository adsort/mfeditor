using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MFEditorUI
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            string strInfo ="This is a mapfile editor for MapServer.\r\n" + 
                "If you see any bug and if you have any suggenstion,"+ 
                "please mail to \r\n\r\n      wanliyun2009@gmail.com.\r\n\r\nThank you!" ;
            labelName.Text = "MFEditor Version 0.1.31";
            labelVersion.Text = strInfo;

            labelCopyRight.Text = "Copyright 2009.All rights reserved.";
        }
    }
}