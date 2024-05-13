namespace Calculator
{
    partial class PrimeChecker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrimeChecker));
            this.NumberBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckButton = new System.Windows.Forms.Button();
            this.ResultBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NumberBox
            // 
            resources.ApplyResources(this.NumberBox, "NumberBox");
            this.NumberBox.Name = "NumberBox";
            this.NumberBox.Click += new System.EventHandler(this.NumberBox_Click);
            this.NumberBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberBox_KeyPress);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Name = "label1";
            // 
            // CheckButton
            // 
            resources.ApplyResources(this.CheckButton, "CheckButton");
            this.CheckButton.BackColor = System.Drawing.Color.Orange;
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.UseVisualStyleBackColor = false;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // ResultBox
            // 
            resources.ApplyResources(this.ResultBox, "ResultBox");
            this.ResultBox.ForeColor = System.Drawing.Color.DarkRed;
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.ReadOnly = true;
            // 
            // PrimeChecker
            // 
            this.AcceptButton = this.CheckButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumberBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrimeChecker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NumberBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.TextBox ResultBox;
    }
}
