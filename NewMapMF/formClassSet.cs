using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MFEditorLib;

namespace MFEditor
{
    public partial class formClassSet : Form
    {
        private McClass m_pMcClass = null;
        public formClassSet(McClass inClass)
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

            textName.Text = m_pMcClass.Name;
            textExpression.Text = m_pMcClass.Expression;

            textMinScale.Text = m_pMcClass.MinScale.ToString();
            textMaxScale.Text = m_pMcClass.MaxScale.ToString();

            textText.Text = m_pMcClass.Text;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_pMcClass.Name = textName.Text;
            m_pMcClass.Expression = textExpression.Text;

            //textMinScale.Text = m_pMcClass.MinScale.ToString();
            //textMaxScale.Text = m_pMcClass.MaxScale.ToString();

            //m_pMcClass.Text = textText.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}