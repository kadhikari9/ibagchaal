namespace ibagchaal
{
    partial class Form1
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
            this.winnerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.goatLeftLabel = new System.Windows.Forms.Label();
            this.goatCapturedLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // winnerLabel
            // 
            this.winnerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.winnerLabel.AutoSize = true;
            this.winnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnerLabel.ForeColor = System.Drawing.Color.Red;
            this.winnerLabel.Location = new System.Drawing.Point(632, 27);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(0, 37);
            this.winnerLabel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Goats Left To Position:";
            // 
            // goatLeftLabel
            // 
            this.goatLeftLabel.AutoSize = true;
            this.goatLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goatLeftLabel.Location = new System.Drawing.Point(179, 9);
            this.goatLeftLabel.Name = "goatLeftLabel";
            this.goatLeftLabel.Size = new System.Drawing.Size(51, 20);
            this.goatLeftLabel.TabIndex = 2;
            this.goatLeftLabel.Text = "label2";
            // 
            // goatCapturedLabel
            // 
            this.goatCapturedLabel.AutoSize = true;
            this.goatCapturedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goatCapturedLabel.Location = new System.Drawing.Point(179, 44);
            this.goatCapturedLabel.Name = "goatCapturedLabel";
            this.goatCapturedLabel.Size = new System.Drawing.Size(51, 20);
            this.goatCapturedLabel.TabIndex = 3;
            this.goatCapturedLabel.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Goats Captured:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1073, 549);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.goatCapturedLabel);
            this.Controls.Add(this.goatLeftLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.winnerLabel);
            this.Name = "Form1";
            this.Text = "iBagChaal";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label winnerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label goatLeftLabel;
        private System.Windows.Forms.Label goatCapturedLabel;
        private System.Windows.Forms.Label label2;


    }
}

