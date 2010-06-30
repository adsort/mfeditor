namespace MFEditorUI
{
    partial class FormClassSet
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClassSet));
            this.textExpression = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textMaxScale = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textMinScale = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textExpression
            // 
            resources.ApplyResources(this.textExpression, "textExpression");
            this.textExpression.Name = "textExpression";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textName
            // 
            resources.ApplyResources(this.textName, "textName");
            this.textName.Name = "textName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // textMaxScale
            // 
            resources.ApplyResources(this.textMaxScale, "textMaxScale");
            this.textMaxScale.Name = "textMaxScale";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // textMinScale
            // 
            resources.ApplyResources(this.textMinScale, "textMinScale");
            this.textMinScale.Name = "textMinScale";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // textText
            // 
            resources.ApplyResources(this.textText, "textText");
            this.textText.Name = "textText";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label17
            // 
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // FormClassSet
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textMaxScale);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textMinScale);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textExpression);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormClassSet";
            this.Load += new System.EventHandler(this.formClassSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textExpression;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textMaxScale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textMinScale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label17;
    }
}