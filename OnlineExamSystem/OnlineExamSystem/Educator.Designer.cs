
namespace OnlineExamSystem
{
    partial class Educator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Educator));
            this.topPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.namesurnameLabel = new System.Windows.Forms.Label();
            this.shadowpanelLogo = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.logoPicture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.minimizeBtn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.exitBtn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.middlePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.shadowpanelBottom = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.shadowpanelTop = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.bottomPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.questioncreateButton = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.specialquestioncreateButton = new Guna.UI2.WinForms.Guna2GradientCircleButton();
            this.topPanel.SuspendLayout();
            this.shadowpanelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.middlePanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.namesurnameLabel);
            this.topPanel.Controls.Add(this.shadowpanelLogo);
            this.topPanel.Controls.Add(this.minimizeBtn);
            this.topPanel.Controls.Add(this.exitBtn);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1280, 130);
            this.topPanel.TabIndex = 0;
            // 
            // namesurnameLabel
            // 
            this.namesurnameLabel.AutoSize = true;
            this.namesurnameLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.namesurnameLabel.Location = new System.Drawing.Point(177, 54);
            this.namesurnameLabel.Name = "namesurnameLabel";
            this.namesurnameLabel.Size = new System.Drawing.Size(122, 19);
            this.namesurnameLabel.TabIndex = 3;
            this.namesurnameLabel.Text = "name surname ";
            // 
            // shadowpanelLogo
            // 
            this.shadowpanelLogo.BackColor = System.Drawing.Color.Transparent;
            this.shadowpanelLogo.Controls.Add(this.logoPicture);
            this.shadowpanelLogo.FillColor = System.Drawing.Color.Transparent;
            this.shadowpanelLogo.Location = new System.Drawing.Point(27, 9);
            this.shadowpanelLogo.Name = "shadowpanelLogo";
            this.shadowpanelLogo.Radius = 30;
            this.shadowpanelLogo.ShadowColor = System.Drawing.Color.BlueViolet;
            this.shadowpanelLogo.Size = new System.Drawing.Size(127, 112);
            this.shadowpanelLogo.TabIndex = 2;
            // 
            // logoPicture
            // 
            this.logoPicture.Image = global::OnlineExamSystem.Properties.Resources.LogoIcon;
            this.logoPicture.ImageRotate = 0F;
            this.logoPicture.Location = new System.Drawing.Point(18, -3);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.logoPicture.Size = new System.Drawing.Size(100, 112);
            this.logoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPicture.TabIndex = 0;
            this.logoPicture.TabStop = false;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeBtn.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.minimizeBtn.FillColor = System.Drawing.Color.Transparent;
            this.minimizeBtn.IconColor = System.Drawing.Color.BlueViolet;
            this.minimizeBtn.Location = new System.Drawing.Point(1219, 0);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.PressedColor = System.Drawing.Color.BlueViolet;
            this.minimizeBtn.Size = new System.Drawing.Size(30, 30);
            this.minimizeBtn.TabIndex = 1;
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.FillColor = System.Drawing.Color.Transparent;
            this.exitBtn.IconColor = System.Drawing.Color.BlueViolet;
            this.exitBtn.Location = new System.Drawing.Point(1250, -1);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.PressedColor = System.Drawing.Color.BlueViolet;
            this.exitBtn.Size = new System.Drawing.Size(30, 30);
            this.exitBtn.TabIndex = 1;
            // 
            // middlePanel
            // 
            this.middlePanel.BackColor = System.Drawing.Color.Transparent;
            this.middlePanel.Controls.Add(this.shadowpanelBottom);
            this.middlePanel.Controls.Add(this.shadowpanelTop);
            this.middlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.middlePanel.Location = new System.Drawing.Point(0, 130);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Size = new System.Drawing.Size(1280, 417);
            this.middlePanel.TabIndex = 1;
            // 
            // shadowpanelBottom
            // 
            this.shadowpanelBottom.BackColor = System.Drawing.Color.Transparent;
            this.shadowpanelBottom.FillColor = System.Drawing.Color.Transparent;
            this.shadowpanelBottom.Location = new System.Drawing.Point(256, 403);
            this.shadowpanelBottom.Name = "shadowpanelBottom";
            this.shadowpanelBottom.ShadowColor = System.Drawing.Color.SteelBlue;
            this.shadowpanelBottom.Size = new System.Drawing.Size(800, 5);
            this.shadowpanelBottom.TabIndex = 2;
            // 
            // shadowpanelTop
            // 
            this.shadowpanelTop.BackColor = System.Drawing.Color.Transparent;
            this.shadowpanelTop.FillColor = System.Drawing.Color.Transparent;
            this.shadowpanelTop.Location = new System.Drawing.Point(256, 9);
            this.shadowpanelTop.Name = "shadowpanelTop";
            this.shadowpanelTop.ShadowColor = System.Drawing.Color.SteelBlue;
            this.shadowpanelTop.Size = new System.Drawing.Size(800, 5);
            this.shadowpanelTop.TabIndex = 1;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.guna2Button2);
            this.bottomPanel.Controls.Add(this.guna2Button1);
            this.bottomPanel.Controls.Add(this.questioncreateButton);
            this.bottomPanel.Controls.Add(this.specialquestioncreateButton);
            this.bottomPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomPanel.Location = new System.Drawing.Point(0, 547);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1280, 134);
            this.bottomPanel.TabIndex = 2;
            // 
            // guna2Button2
            // 
            this.guna2Button2.AutoRoundedCorners = true;
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button2.BorderRadius = 21;
            this.guna2Button2.BorderThickness = 2;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guna2Button2.ForeColor = System.Drawing.Color.SteelBlue;
            this.guna2Button2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button2.HoverState.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guna2Button2.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.ImageSize = new System.Drawing.Size(24, 24);
            this.guna2Button2.Location = new System.Drawing.Point(305, 40);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.PressedDepth = 45;
            this.guna2Button2.ShadowDecoration.BorderRadius = 26;
            this.guna2Button2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button2.ShadowDecoration.Depth = 45;
            this.guna2Button2.ShadowDecoration.Enabled = true;
            this.guna2Button2.Size = new System.Drawing.Size(233, 45);
            this.guna2Button2.TabIndex = 5;
            this.guna2Button2.Text = "Create Custom Exam";
            this.guna2Button2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2Button1
            // 
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 21;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Arial", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageSize = new System.Drawing.Size(24, 24);
            this.guna2Button1.Location = new System.Drawing.Point(89, 40);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.PressedDepth = 45;
            this.guna2Button1.ShadowDecoration.BorderRadius = 26;
            this.guna2Button1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2Button1.ShadowDecoration.Depth = 45;
            this.guna2Button1.ShadowDecoration.Enabled = true;
            this.guna2Button1.Size = new System.Drawing.Size(195, 45);
            this.guna2Button1.TabIndex = 5;
            this.guna2Button1.Text = "Create Question";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // questioncreateButton
            // 
            this.questioncreateButton.Animated = true;
            this.questioncreateButton.BackColor = System.Drawing.Color.Transparent;
            this.questioncreateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.questioncreateButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.questioncreateButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.questioncreateButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.questioncreateButton.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.questioncreateButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.questioncreateButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.questioncreateButton.Font = new System.Drawing.Font("Arial", 7.8F);
            this.questioncreateButton.ForeColor = System.Drawing.Color.White;
            this.questioncreateButton.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.questioncreateButton.HoverState.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.questioncreateButton.HoverState.FillColor = System.Drawing.Color.White;
            this.questioncreateButton.HoverState.FillColor2 = System.Drawing.Color.White;
            this.questioncreateButton.HoverState.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.questioncreateButton.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.questioncreateButton.Location = new System.Drawing.Point(573, 20);
            this.questioncreateButton.Name = "questioncreateButton";
            this.questioncreateButton.PressedDepth = 45;
            this.questioncreateButton.ShadowDecoration.BorderRadius = 26;
            this.questioncreateButton.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.questioncreateButton.ShadowDecoration.Enabled = true;
            this.questioncreateButton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.questioncreateButton.Size = new System.Drawing.Size(75, 65);
            this.questioncreateButton.TabIndex = 4;
            this.questioncreateButton.UseTransparentBackground = true;
            this.questioncreateButton.Click += new System.EventHandler(this.questioncreateButton_Click_1);
            // 
            // specialquestioncreateButton
            // 
            this.specialquestioncreateButton.Animated = true;
            this.specialquestioncreateButton.BackColor = System.Drawing.Color.Transparent;
            this.specialquestioncreateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.specialquestioncreateButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.specialquestioncreateButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.specialquestioncreateButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.specialquestioncreateButton.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.specialquestioncreateButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.specialquestioncreateButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.specialquestioncreateButton.Font = new System.Drawing.Font("Arial", 7.8F);
            this.specialquestioncreateButton.ForeColor = System.Drawing.Color.White;
            this.specialquestioncreateButton.Location = new System.Drawing.Point(700, 20);
            this.specialquestioncreateButton.Name = "specialquestioncreateButton";
            this.specialquestioncreateButton.PressedDepth = 45;
            this.specialquestioncreateButton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.specialquestioncreateButton.Size = new System.Drawing.Size(75, 65);
            this.specialquestioncreateButton.TabIndex = 4;
            this.specialquestioncreateButton.UseTransparentBackground = true;
            // 
            // Educator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1280, 680);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.middlePanel);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Educator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Educator";
            this.Load += new System.EventHandler(this.Educator_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.shadowpanelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.middlePanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel topPanel;
        private Guna.UI2.WinForms.Guna2CirclePictureBox logoPicture;
        private Guna.UI2.WinForms.Guna2ControlBox minimizeBtn;
        private Guna.UI2.WinForms.Guna2ControlBox exitBtn;
        private Guna.UI2.WinForms.Guna2Panel middlePanel;
        private Guna.UI2.WinForms.Guna2ShadowPanel shadowpanelLogo;
        private Guna.UI2.WinForms.Guna2ShadowPanel shadowpanelBottom;
        private Guna.UI2.WinForms.Guna2ShadowPanel shadowpanelTop;
        private Guna.UI2.WinForms.Guna2Panel bottomPanel;
        private System.Windows.Forms.Label namesurnameLabel;
        private Guna.UI2.WinForms.Guna2GradientCircleButton specialquestioncreateButton;
        private Guna.UI2.WinForms.Guna2GradientCircleButton questioncreateButton;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}