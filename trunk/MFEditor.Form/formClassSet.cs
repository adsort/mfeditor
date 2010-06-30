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