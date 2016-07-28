namespace Mapping.View
{
    partial class ParticipleWaitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.Caption = new System.Windows.Forms.Label();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Total = new System.Windows.Forms.Label();
            this.Current = new System.Windows.Forms.Label();
            this.Succeed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Caption
            // 
            this.Caption.Location = new System.Drawing.Point(16, 26);
            this.Caption.Name = "Caption";
            this.Caption.Size = new System.Drawing.Size(67, 12);
            this.Caption.TabIndex = 3;
            this.Caption.Text = "Caption";
            this.Caption.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(104, 23);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.ShowTitle = true;
            this.progressBarControl1.Size = new System.Drawing.Size(141, 18);
            this.progressBarControl1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Total";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Current";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Succeed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Location = new System.Drawing.Point(104, 55);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(35, 12);
            this.Total.TabIndex = 3;
            this.Total.Text = "Total";
            // 
            // Current
            // 
            this.Current.AutoSize = true;
            this.Current.Location = new System.Drawing.Point(104, 84);
            this.Current.Name = "Current";
            this.Current.Size = new System.Drawing.Size(47, 12);
            this.Current.TabIndex = 3;
            this.Current.Text = "Current";
            // 
            // Succeed
            // 
            this.Succeed.AutoSize = true;
            this.Succeed.Location = new System.Drawing.Point(104, 113);
            this.Succeed.Name = "Succeed";
            this.Succeed.Size = new System.Drawing.Size(47, 12);
            this.Succeed.TabIndex = 3;
            this.Succeed.Text = "Succeed";
            // 
            // ParticipleWaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(266, 154);
            this.Controls.Add(this.Succeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Current);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Caption);
            this.Controls.Add(this.progressBarControl1);
            this.DoubleBuffered = true;
            this.Name = "ParticipleWaitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Caption;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.Label Current;
        private System.Windows.Forms.Label Succeed;
    }
}