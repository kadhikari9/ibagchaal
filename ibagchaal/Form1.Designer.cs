﻿namespace ibagchaal
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
            this.moveLabel = new System.Windows.Forms.Label();
            this.turnLabel = new System.Windows.Forms.Label();
            this.currentTurnLabel = new System.Windows.Forms.Label();
            this.currentMoveLabel = new System.Windows.Forms.Label();
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
            this.goatCapturedLabel.Location = new System.Drawing.Point(148, 44);
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
            // moveLabel
            // 
            this.moveLabel.AutoSize = true;
            this.moveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveLabel.Location = new System.Drawing.Point(17, 121);
            this.moveLabel.Name = "moveLabel";
            this.moveLabel.Size = new System.Drawing.Size(108, 20);
            this.moveLabel.TabIndex = 5;
            this.moveLabel.Text = "Current Move:";
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnLabel.Location = new System.Drawing.Point(17, 81);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(102, 20);
            this.turnLabel.TabIndex = 6;
            this.turnLabel.Text = "Current Turn:";
            this.turnLabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // currentTurnLabel
            // 
            this.currentTurnLabel.AutoSize = true;
            this.currentTurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTurnLabel.Location = new System.Drawing.Point(148, 81);
            this.currentTurnLabel.Name = "currentTurnLabel";
            this.currentTurnLabel.Size = new System.Drawing.Size(82, 20);
            this.currentTurnLabel.TabIndex = 7;
            this.currentTurnLabel.Text = "GOAT       ";
            // 
            // currentMoveLabel
            // 
            this.currentMoveLabel.AutoSize = true;
            this.currentMoveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentMoveLabel.Location = new System.Drawing.Point(148, 121);
            this.currentMoveLabel.Name = "currentMoveLabel";
            this.currentMoveLabel.Size = new System.Drawing.Size(89, 20);
            this.currentMoveLabel.TabIndex = 8;
            this.currentMoveLabel.Text = "                    ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1073, 549);
            this.Controls.Add(this.currentMoveLabel);
            this.Controls.Add(this.currentTurnLabel);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.moveLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.goatCapturedLabel);
            this.Controls.Add(this.goatLeftLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.winnerLabel);
            this.Name = "Form1";
            this.Text = "iBagChaal";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Label moveLabel;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label currentTurnLabel;
        private System.Windows.Forms.Label currentMoveLabel;


    }
}

