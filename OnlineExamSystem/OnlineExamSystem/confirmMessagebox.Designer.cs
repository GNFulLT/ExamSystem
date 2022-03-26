
namespace OnlineExamSystem
{
    partial class confirmMessagebox
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
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.messageLbl = new System.Windows.Forms.Label();
            this.exitBtn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.messagePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.approveBtn = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.messagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.messageLbl);
            this.panelTop.Controls.Add(this.exitBtn);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(650, 60);
            this.panelTop.TabIndex = 0;
            // 
            // messageLbl
            // 
            this.messageLbl.AutoSize = true;
            this.messageLbl.Font = new System.Drawing.Font("Arial", 10F);
            this.messageLbl.ForeColor = System.Drawing.Color.White;
            this.messageLbl.Location = new System.Drawing.Point(13, 22);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(136, 19);
            this.messageLbl.TabIndex = 1;
            this.messageLbl.Text = "Confirm Question";
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.exitBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.IconColor = System.Drawing.Color.White;
            this.exitBtn.Location = new System.Drawing.Point(612, 1);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(37, 32);
            this.exitBtn.TabIndex = 0;
            // 
            // messagePanel
            // 
            this.messagePanel.BackColor = System.Drawing.Color.White;
            this.messagePanel.Controls.Add(this.guna2PictureBox1);
            this.messagePanel.Controls.Add(this.approveBtn);
            this.messagePanel.Controls.Add(this.label1);
            this.messagePanel.Location = new System.Drawing.Point(3, 60);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(645, 148);
            this.messagePanel.TabIndex = 1;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::OnlineExamSystem.Properties.Resources.questionIcon;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(29, 30);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(68, 74);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 4;
            this.guna2PictureBox1.TabStop = false;
            // 
            // approveBtn
            // 
            this.approveBtn.Animated = true;
            this.approveBtn.BackColor = System.Drawing.Color.Transparent;
            this.approveBtn.BorderRadius = 15;
            this.approveBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.approveBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.approveBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.approveBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.approveBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(190)))), ((int)(((byte)(130)))));
            this.approveBtn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.approveBtn.ForeColor = System.Drawing.Color.White;
            this.approveBtn.Location = new System.Drawing.Point(238, 77);
            this.approveBtn.Name = "approveBtn";
            this.approveBtn.Size = new System.Drawing.Size(167, 40);
            this.approveBtn.TabIndex = 0;
            this.approveBtn.Text = "Approve";
            this.approveBtn.UseTransparentBackground = true;
            this.approveBtn.Click += new System.EventHandler(this.approveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(132, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Do you approve the problem being added to the system?";
            // 
            // confirmMessagebox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(650, 210);
            this.Controls.Add(this.messagePanel);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "confirmMessagebox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "confirmMessagebox";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.messagePanel.ResumeLayout(false);
            this.messagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2Panel messagePanel;
        private Guna.UI2.WinForms.Guna2ControlBox exitBtn;
        private System.Windows.Forms.Label messageLbl;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button approveBtn;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}