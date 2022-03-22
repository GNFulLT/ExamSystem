
namespace OnlineExamSystem
{
   /* [Localizable(true)]*/

    partial class QuestionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionForm));
            this.questionTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.fileshow = new System.Windows.Forms.OpenFileDialog();
            this.addpictureBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.confirmquestionBtn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.wronganswerGruopbox = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblanswer4 = new System.Windows.Forms.Label();
            this.lblanswer3 = new System.Windows.Forms.Label();
            this.lblanswer2 = new System.Windows.Forms.Label();
            this.lblanswer1 = new System.Windows.Forms.Label();
            this.wronganswer4Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.wronganswer1Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.wronganswer3Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.wronganswer2Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.correctanswerGruopbox = new Guna.UI2.WinForms.Guna2GroupBox();
            this.lblanswer5 = new System.Windows.Forms.Label();
            this.answerTxt = new Guna.UI2.WinForms.Guna2TextBox();
            this.lessondetailCmb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.exitBtn = new Guna.UI2.WinForms.Guna2ControlBox();
            this.unitdetailCmb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.subjectdetailCmb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.questionPicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.wronganswerGruopbox.SuspendLayout();
            this.correctanswerGruopbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // questionTxt
            // 
            resources.ApplyResources(this.questionTxt, "questionTxt");
            this.questionTxt.BorderRadius = 10;
            this.questionTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.questionTxt.DefaultText = "";
            this.questionTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.questionTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.questionTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.questionTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.questionTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.questionTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.questionTxt.Multiline = true;
            this.questionTxt.Name = "questionTxt";
            this.questionTxt.PasswordChar = '\0';
            this.questionTxt.PlaceholderText = "";
            this.questionTxt.SelectedText = "";
            // 
            // fileshow
            // 
            this.fileshow.FileName = "fileshow";
            resources.ApplyResources(this.fileshow, "fileshow");
            // 
            // addpictureBtn
            // 
            resources.ApplyResources(this.addpictureBtn, "addpictureBtn");
            this.addpictureBtn.Animated = true;
            this.addpictureBtn.BackColor = System.Drawing.Color.Transparent;
            this.addpictureBtn.BorderRadius = 20;
            this.addpictureBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addpictureBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addpictureBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addpictureBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addpictureBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addpictureBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addpictureBtn.FillColor = System.Drawing.Color.SteelBlue;
            this.addpictureBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.addpictureBtn.ForeColor = System.Drawing.Color.White;
            this.addpictureBtn.Name = "addpictureBtn";
            this.addpictureBtn.UseTransparentBackground = true;
            this.addpictureBtn.Click += new System.EventHandler(this.addpictureBtn_Click_1);
            // 
            // confirmquestionBtn
            // 
            resources.ApplyResources(this.confirmquestionBtn, "confirmquestionBtn");
            this.confirmquestionBtn.Animated = true;
            this.confirmquestionBtn.BackColor = System.Drawing.Color.Transparent;
            this.confirmquestionBtn.BorderRadius = 20;
            this.confirmquestionBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmquestionBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.confirmquestionBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.confirmquestionBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.confirmquestionBtn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.confirmquestionBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.confirmquestionBtn.FillColor = System.Drawing.Color.SteelBlue;
            this.confirmquestionBtn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(153)))), ((int)(((byte)(174)))));
            this.confirmquestionBtn.ForeColor = System.Drawing.Color.White;
            this.confirmquestionBtn.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.confirmquestionBtn.Name = "confirmquestionBtn";
            this.confirmquestionBtn.UseTransparentBackground = true;
            this.confirmquestionBtn.Click += new System.EventHandler(this.confirmquestionBtn_Click);
            // 
            // wronganswerGruopbox
            // 
            resources.ApplyResources(this.wronganswerGruopbox, "wronganswerGruopbox");
            this.wronganswerGruopbox.BorderRadius = 10;
            this.wronganswerGruopbox.Controls.Add(this.lblanswer4);
            this.wronganswerGruopbox.Controls.Add(this.lblanswer3);
            this.wronganswerGruopbox.Controls.Add(this.lblanswer2);
            this.wronganswerGruopbox.Controls.Add(this.lblanswer1);
            this.wronganswerGruopbox.Controls.Add(this.wronganswer4Txt);
            this.wronganswerGruopbox.Controls.Add(this.wronganswer1Txt);
            this.wronganswerGruopbox.Controls.Add(this.wronganswer3Txt);
            this.wronganswerGruopbox.Controls.Add(this.wronganswer2Txt);
            this.wronganswerGruopbox.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.wronganswerGruopbox.FillColor = System.Drawing.Color.WhiteSmoke;
            this.wronganswerGruopbox.ForeColor = System.Drawing.Color.White;
            this.wronganswerGruopbox.Name = "wronganswerGruopbox";
            // 
            // lblanswer4
            // 
            resources.ApplyResources(this.lblanswer4, "lblanswer4");
            this.lblanswer4.BackColor = System.Drawing.Color.Transparent;
            this.lblanswer4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.lblanswer4.Name = "lblanswer4";
            // 
            // lblanswer3
            // 
            resources.ApplyResources(this.lblanswer3, "lblanswer3");
            this.lblanswer3.BackColor = System.Drawing.Color.Transparent;
            this.lblanswer3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.lblanswer3.Name = "lblanswer3";
            // 
            // lblanswer2
            // 
            resources.ApplyResources(this.lblanswer2, "lblanswer2");
            this.lblanswer2.BackColor = System.Drawing.Color.Transparent;
            this.lblanswer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.lblanswer2.Name = "lblanswer2";
            // 
            // lblanswer1
            // 
            resources.ApplyResources(this.lblanswer1, "lblanswer1");
            this.lblanswer1.BackColor = System.Drawing.Color.Transparent;
            this.lblanswer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.lblanswer1.Name = "lblanswer1";
            // 
            // wronganswer4Txt
            // 
            resources.ApplyResources(this.wronganswer4Txt, "wronganswer4Txt");
            this.wronganswer4Txt.Animated = true;
            this.wronganswer4Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.wronganswer4Txt.DefaultText = "";
            this.wronganswer4Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.wronganswer4Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.wronganswer4Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wronganswer4Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wronganswer4Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wronganswer4Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wronganswer4Txt.Multiline = true;
            this.wronganswer4Txt.Name = "wronganswer4Txt";
            this.wronganswer4Txt.PasswordChar = '\0';
            this.wronganswer4Txt.PlaceholderText = "";
            this.wronganswer4Txt.SelectedText = "";
            // 
            // wronganswer1Txt
            // 
            resources.ApplyResources(this.wronganswer1Txt, "wronganswer1Txt");
            this.wronganswer1Txt.Animated = true;
            this.wronganswer1Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.wronganswer1Txt.DefaultText = "";
            this.wronganswer1Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.wronganswer1Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.wronganswer1Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wronganswer1Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wronganswer1Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wronganswer1Txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.wronganswer1Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wronganswer1Txt.Multiline = true;
            this.wronganswer1Txt.Name = "wronganswer1Txt";
            this.wronganswer1Txt.PasswordChar = '\0';
            this.wronganswer1Txt.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.wronganswer1Txt.PlaceholderText = "";
            this.wronganswer1Txt.SelectedText = "";
            // 
            // wronganswer3Txt
            // 
            resources.ApplyResources(this.wronganswer3Txt, "wronganswer3Txt");
            this.wronganswer3Txt.Animated = true;
            this.wronganswer3Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.wronganswer3Txt.DefaultText = "";
            this.wronganswer3Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.wronganswer3Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.wronganswer3Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wronganswer3Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wronganswer3Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wronganswer3Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wronganswer3Txt.Multiline = true;
            this.wronganswer3Txt.Name = "wronganswer3Txt";
            this.wronganswer3Txt.PasswordChar = '\0';
            this.wronganswer3Txt.PlaceholderText = "";
            this.wronganswer3Txt.SelectedText = "";
            // 
            // wronganswer2Txt
            // 
            resources.ApplyResources(this.wronganswer2Txt, "wronganswer2Txt");
            this.wronganswer2Txt.Animated = true;
            this.wronganswer2Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.wronganswer2Txt.DefaultText = "";
            this.wronganswer2Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.wronganswer2Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.wronganswer2Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wronganswer2Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.wronganswer2Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wronganswer2Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.wronganswer2Txt.Multiline = true;
            this.wronganswer2Txt.Name = "wronganswer2Txt";
            this.wronganswer2Txt.PasswordChar = '\0';
            this.wronganswer2Txt.PlaceholderText = "";
            this.wronganswer2Txt.SelectedText = "";
            // 
            // correctanswerGruopbox
            // 
            resources.ApplyResources(this.correctanswerGruopbox, "correctanswerGruopbox");
            this.correctanswerGruopbox.BorderRadius = 10;
            this.correctanswerGruopbox.Controls.Add(this.lblanswer5);
            this.correctanswerGruopbox.Controls.Add(this.answerTxt);
            this.correctanswerGruopbox.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.correctanswerGruopbox.FillColor = System.Drawing.Color.WhiteSmoke;
            this.correctanswerGruopbox.ForeColor = System.Drawing.Color.White;
            this.correctanswerGruopbox.Name = "correctanswerGruopbox";
            // 
            // lblanswer5
            // 
            resources.ApplyResources(this.lblanswer5, "lblanswer5");
            this.lblanswer5.BackColor = System.Drawing.Color.Transparent;
            this.lblanswer5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.lblanswer5.Name = "lblanswer5";
            // 
            // answerTxt
            // 
            resources.ApplyResources(this.answerTxt, "answerTxt");
            this.answerTxt.Animated = true;
            this.answerTxt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.answerTxt.DefaultText = "";
            this.answerTxt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.answerTxt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.answerTxt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.answerTxt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.answerTxt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.answerTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.answerTxt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.answerTxt.Multiline = true;
            this.answerTxt.Name = "answerTxt";
            this.answerTxt.PasswordChar = '\0';
            this.answerTxt.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.answerTxt.PlaceholderText = "";
            this.answerTxt.SelectedText = "";
            // 
            // lessondetailCmb
            // 
            resources.ApplyResources(this.lessondetailCmb, "lessondetailCmb");
            this.lessondetailCmb.BackColor = System.Drawing.Color.Transparent;
            this.lessondetailCmb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lessondetailCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lessondetailCmb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lessondetailCmb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.lessondetailCmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.lessondetailCmb.Name = "lessondetailCmb";
            // 
            // exitBtn
            // 
            resources.ApplyResources(this.exitBtn, "exitBtn");
            this.exitBtn.FillColor = System.Drawing.Color.Transparent;
            this.exitBtn.IconColor = System.Drawing.Color.BlueViolet;
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.PressedColor = System.Drawing.Color.BlueViolet;
            // 
            // unitdetailCmb
            // 
            resources.ApplyResources(this.unitdetailCmb, "unitdetailCmb");
            this.unitdetailCmb.BackColor = System.Drawing.Color.Transparent;
            this.unitdetailCmb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.unitdetailCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitdetailCmb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.unitdetailCmb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.unitdetailCmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.unitdetailCmb.Name = "unitdetailCmb";
            // 
            // subjectdetailCmb
            // 
            resources.ApplyResources(this.subjectdetailCmb, "subjectdetailCmb");
            this.subjectdetailCmb.BackColor = System.Drawing.Color.Transparent;
            this.subjectdetailCmb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.subjectdetailCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectdetailCmb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.subjectdetailCmb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.subjectdetailCmb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.subjectdetailCmb.Name = "subjectdetailCmb";
            // 
            // questionPicture
            // 
            resources.ApplyResources(this.questionPicture, "questionPicture");
            this.questionPicture.BackColor = System.Drawing.Color.White;
            this.questionPicture.ImageRotate = 0F;
            this.questionPicture.Name = "questionPicture";
            this.questionPicture.TabStop = false;
            // 
            // lblMessage
            // 
            resources.ApplyResources(this.lblMessage, "lblMessage");
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(88)))), ((int)(((byte)(89)))));
            this.lblMessage.Name = "lblMessage";
            // 
            // QuestionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.subjectdetailCmb);
            this.Controls.Add(this.unitdetailCmb);
            this.Controls.Add(this.lessondetailCmb);
            this.Controls.Add(this.correctanswerGruopbox);
            this.Controls.Add(this.wronganswerGruopbox);
            this.Controls.Add(this.confirmquestionBtn);
            this.Controls.Add(this.addpictureBtn);
            this.Controls.Add(this.questionTxt);
            this.Controls.Add(this.questionPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuestionForm";
            this.wronganswerGruopbox.ResumeLayout(false);
            this.wronganswerGruopbox.PerformLayout();
            this.correctanswerGruopbox.ResumeLayout(false);
            this.correctanswerGruopbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2PictureBox questionPicture;
        private Guna.UI2.WinForms.Guna2TextBox questionTxt;
        private System.Windows.Forms.OpenFileDialog fileshow;
        private Guna.UI2.WinForms.Guna2GradientButton addpictureBtn;
        private Guna.UI2.WinForms.Guna2GradientButton confirmquestionBtn;
        private Guna.UI2.WinForms.Guna2GroupBox wronganswerGruopbox;
        private Guna.UI2.WinForms.Guna2TextBox wronganswer4Txt;
        private Guna.UI2.WinForms.Guna2TextBox wronganswer1Txt;
        private Guna.UI2.WinForms.Guna2TextBox wronganswer3Txt;
        private Guna.UI2.WinForms.Guna2TextBox wronganswer2Txt;
        private System.Windows.Forms.Label lblanswer4;
        private System.Windows.Forms.Label lblanswer3;
        private System.Windows.Forms.Label lblanswer2;
        private System.Windows.Forms.Label lblanswer1;
        private Guna.UI2.WinForms.Guna2GroupBox correctanswerGruopbox;
        private System.Windows.Forms.Label lblanswer5;
        private Guna.UI2.WinForms.Guna2TextBox answerTxt;
        private Guna.UI2.WinForms.Guna2ComboBox lessondetailCmb;
        private Guna.UI2.WinForms.Guna2ControlBox exitBtn;
        private Guna.UI2.WinForms.Guna2ComboBox unitdetailCmb;
        private Guna.UI2.WinForms.Guna2ComboBox subjectdetailCmb;
        private System.Windows.Forms.Label lblMessage;
    }
}