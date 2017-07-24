namespace NT8_Monitor
{
    partial class NT8monitor
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
            this.lastUpdateLabel = new System.Windows.Forms.Label();
            this.lastUpdateOutputLabel = new System.Windows.Forms.Label();
            this.messageOutputLlabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.connectedOutputLabel = new System.Windows.Forms.Label();
            this.connectionLabel = new System.Windows.Forms.Label();
            this.onlineSinceOutput = new System.Windows.Forms.Label();
            this.onlineSinceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lastUpdateLabel
            // 
            this.lastUpdateLabel.AutoSize = true;
            this.lastUpdateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastUpdateLabel.Location = new System.Drawing.Point(125, 134);
            this.lastUpdateLabel.Name = "lastUpdateLabel";
            this.lastUpdateLabel.Size = new System.Drawing.Size(141, 29);
            this.lastUpdateLabel.TabIndex = 0;
            this.lastUpdateLabel.Text = "Last Update";
            // 
            // lastUpdateOutputLabel
            // 
            this.lastUpdateOutputLabel.AutoSize = true;
            this.lastUpdateOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastUpdateOutputLabel.Location = new System.Drawing.Point(324, 134);
            this.lastUpdateOutputLabel.Name = "lastUpdateOutputLabel";
            this.lastUpdateOutputLabel.Size = new System.Drawing.Size(218, 29);
            this.lastUpdateOutputLabel.TabIndex = 1;
            this.lastUpdateOutputLabel.Text = "12/10/2017 8:00PM";
            // 
            // messageOutputLlabel
            // 
            this.messageOutputLlabel.AutoSize = true;
            this.messageOutputLlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageOutputLlabel.Location = new System.Drawing.Point(324, 188);
            this.messageOutputLlabel.Name = "messageOutputLlabel";
            this.messageOutputLlabel.Size = new System.Drawing.Size(78, 29);
            this.messageOutputLlabel.TabIndex = 3;
            this.messageOutputLlabel.Text = "Trade";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.Location = new System.Drawing.Point(125, 188);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(112, 29);
            this.messageLabel.TabIndex = 2;
            this.messageLabel.Text = "Message";
            // 
            // connectedOutputLabel
            // 
            this.connectedOutputLabel.AutoSize = true;
            this.connectedOutputLabel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.connectedOutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectedOutputLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.connectedOutputLabel.Location = new System.Drawing.Point(324, 244);
            this.connectedOutputLabel.MinimumSize = new System.Drawing.Size(218, 30);
            this.connectedOutputLabel.Name = "connectedOutputLabel";
            this.connectedOutputLabel.Size = new System.Drawing.Size(218, 30);
            this.connectedOutputLabel.TabIndex = 5;
            this.connectedOutputLabel.Text = "Connected";
            this.connectedOutputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectionLabel.Location = new System.Drawing.Point(125, 244);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(135, 29);
            this.connectionLabel.TabIndex = 4;
            this.connectionLabel.Text = "Connection";
            // 
            // onlineSinceOutput
            // 
            this.onlineSinceOutput.AutoSize = true;
            this.onlineSinceOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlineSinceOutput.Location = new System.Drawing.Point(324, 305);
            this.onlineSinceOutput.Name = "onlineSinceOutput";
            this.onlineSinceOutput.Size = new System.Drawing.Size(218, 29);
            this.onlineSinceOutput.TabIndex = 7;
            this.onlineSinceOutput.Text = "12/10/2017 8:00PM";
            // 
            // onlineSinceLabel
            // 
            this.onlineSinceLabel.AutoSize = true;
            this.onlineSinceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlineSinceLabel.Location = new System.Drawing.Point(125, 305);
            this.onlineSinceLabel.Name = "onlineSinceLabel";
            this.onlineSinceLabel.Size = new System.Drawing.Size(151, 29);
            this.onlineSinceLabel.TabIndex = 6;
            this.onlineSinceLabel.Text = "Online Since";
            // 
            // NT8monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 481);
            this.Controls.Add(this.onlineSinceOutput);
            this.Controls.Add(this.onlineSinceLabel);
            this.Controls.Add(this.connectedOutputLabel);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.messageOutputLlabel);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.lastUpdateOutputLabel);
            this.Controls.Add(this.lastUpdateLabel);
            this.Name = "NT8monitor";
            this.Text = "NT8 Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lastUpdateLabel;
        private System.Windows.Forms.Label lastUpdateOutputLabel;
        private System.Windows.Forms.Label messageOutputLlabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Label connectedOutputLabel;
        private System.Windows.Forms.Label connectionLabel;
        private System.Windows.Forms.Label onlineSinceOutput;
        private System.Windows.Forms.Label onlineSinceLabel;
    }
}

