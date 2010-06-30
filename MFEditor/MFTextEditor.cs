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
