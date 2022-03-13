using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineExamSystem
{
    public partial class TabuES : Form
    {
        Dictionary<string,LanguageString> languageStrings;

        private readonly Size BOX_SIZE = new Size(250, 45);

        public static PrivateFontCollection pfc = new PrivateFontCollection();

        //Login Screen
        AnimatedTextBox usernameBoxLogin;
        AnimatedTextBox passBoxLogin;
        Label forgotPassLabel;
        Label registerLabelLogin;

        //Error Labels
        Label emptyUsernameLabelLogin;
        Label emptyPassLabelLogin;
        Label badPassLabelLogin;
        Label registeredLabelLogin;
        Label badEmailLabelRegister;
        Label emptyInfoLabelRegister;  
        Label alreadyUserLabelRegister;
        Label alreadyEmailLabelRegister;
        Label selectedErrorLabel;

        Timer errorLabelTimer = new Timer();


        //Register Screen
        AnimatedTextBox emailBoxRegister;
        AnimatedTextBox usernameBoxRegister;
        AnimatedTextBox nameBoxRegister;
        AnimatedTextBox pass1BoxRegister;
        Label backLabelRegister;

        //Forgot Pass Screen
        AnimatedTextBox emailBoxForgot;
        Label backLabelEmail;

        Control selectedGroupBox;

        public TabuES()
        {
            InitializeComponent();
            CheckStartablity();
            languageStrings = new Dictionary<string, LanguageString>();
            //Initializes
            loginGroupBox.Controls.Add(pictureBox2);
            loginGroupBox.Controls.Add(logoPicture);
            registerGroupBox.Visible = false;
            forgotGroupBox.Visible = false;

            forgotGroupBox.Location = loginGroupBox.Location;
            registerGroupBox.Location = loginGroupBox.Location;

            selectedGroupBox = loginGroupBox;

            forgotPictureDown.Controls.Add(forgotPassButton);

            OkeyButton.Click += LoginButton_Click;

            errorLabelTimer.Interval = 2000;
            errorLabelTimer.Tick += UsernameEmptyErrorLogin_Tick;

            InitializeFonts();

            InitializeStrings();
            InitializeTextBoxes();
            InitializeGroupBoxes();
            SetStrings();

            selectedErrorLabel = emptyUsernameLabelLogin;

            guna2DragControl1.RemoveDrag(loginGroupBox);
            guna2DragControl1.SetDrag(logoPicture);
            guna2DragControl1.SetDrag(pictureBox5);
            guna2DragControl1.SetDrag(pictureBox7);


        }
        private static void InitializeFonts()
        {
            int fontLength = Properties.Resources.loginScreenFont.Length;
            byte[] fontdata = Properties.Resources.loginScreenFont;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);

            //
            int fontLength2 = Properties.Resources.loginScreenFont2.Length;
            byte[] fontdata2 = Properties.Resources.loginScreenFont2;
            System.IntPtr data2 = Marshal.AllocCoTaskMem(fontLength2);
            Marshal.Copy(fontdata2, 0, data2, fontLength2);
            pfc.AddMemoryFont(data2, fontLength2);

            int fontLength3 = Properties.Resources.loginScreenFont3.Length;
            byte[] fontdata3 = Properties.Resources.loginScreenFont3;
            System.IntPtr data3 = Marshal.AllocCoTaskMem(fontLength3);
            Marshal.Copy(fontdata3, 0, data3, fontLength3);
            pfc.AddMemoryFont(data3, fontLength3);
        }

        private void InitializeGroupBoxes()
        { 
            //Login Group Box
            loginGroupBox.Controls.Add(usernameBoxLogin);
            loginGroupBox.Controls.SetChildIndex(usernameBoxLogin, 0);
            loginGroupBox.Controls.Add(passBoxLogin);
            loginGroupBox.Controls.SetChildIndex(passBoxLogin, 0);
            forgotPassLabel = new Label();
            forgotPassLabel.Text = "";
            forgotPassLabel.Top = 150;
            forgotPassLabel.BackColor = Color.Transparent;
            forgotPassLabel.Left = OkeyButton.Location.X+78;
            forgotPassLabel.AutoSize = true;
            forgotPassLabel.Cursor = Cursors.Hand;
            forgotPassLabel.UseCompatibleTextRendering = true;
            forgotPassLabel.ForeColor = Color.SteelBlue;
            forgotPassLabel.Font = new Font(pfc.Families[2], 10,FontStyle.Regular);
            forgotPassLabel.Click += ForgotPassLabel_Click;
            pictureBox2.Controls.Add(forgotPassLabel);

            registerLabelLogin = new Label();
            registerLabelLogin.Text = "";
            registerLabelLogin.Top = 150;
            registerLabelLogin.BackColor = Color.Transparent;
            registerLabelLogin.Left = OkeyButton.Location.X + 10;
            registerLabelLogin.AutoSize = true;
            registerLabelLogin.Cursor = Cursors.Hand;
            registerLabelLogin.UseCompatibleTextRendering = true;
            registerLabelLogin.ForeColor = Color.SteelBlue;
            registerLabelLogin.Font = new Font(pfc.Families[2], 10, FontStyle.Regular);
            registerLabelLogin.Click += RegisterLabel_Click;
            pictureBox2.Controls.Add(registerLabelLogin);

            badPassLabelLogin = new Label();
            emptyPassLabelLogin = new Label();
            emptyUsernameLabelLogin = new Label();
            registeredLabelLogin = new Label();

            emptyPassLabelLogin.AutoSize = true;
            badPassLabelLogin.AutoSize = true;
            emptyUsernameLabelLogin.AutoSize = true;
            registeredLabelLogin.AutoSize = true;

            emptyPassLabelLogin.Visible = false;
            badPassLabelLogin.Visible = false;
            emptyUsernameLabelLogin.Visible = false;
            registeredLabelLogin.Visible = false;

            emptyPassLabelLogin.Left = 80;
            emptyPassLabelLogin.Top = 70;
            badPassLabelLogin.Location = emptyPassLabelLogin.Location;
            emptyUsernameLabelLogin.Location = emptyPassLabelLogin.Location;
            registeredLabelLogin.Location = emptyPassLabelLogin.Location;

            pictureBox2.Controls.Add(registeredLabelLogin);
            pictureBox2.Controls.Add(emptyPassLabelLogin);
            pictureBox2.Controls.Add(badPassLabelLogin);
            pictureBox2.Controls.Add(emptyUsernameLabelLogin);

            //Register Group Box
            registerGroupBox.Controls.Add(nameBoxRegister);    
            registerGroupBox.Controls.Add(emailBoxRegister);
            registerGroupBox.Controls.Add(usernameBoxRegister);
            registerGroupBox.Controls.Add(pass1BoxRegister);
            registerGroupBox.Controls.SetChildIndex(pass1BoxRegister, 0);
            registerDownPicture.Controls.Add(registerButton);
            registerButton.Top = 45;
            registerButton.Left =110;
            registerButton.Click += RegisterButton_Click;
            registerDownPicture.Controls.SetChildIndex(registerButton,0);


            emptyInfoLabelRegister = new Label();           
            alreadyUserLabelRegister = new Label();
            alreadyEmailLabelRegister = new Label();
            badEmailLabelRegister = new Label();

            badEmailLabelRegister.AutoSize = true;
            emptyInfoLabelRegister.AutoSize = true;
            alreadyUserLabelRegister.AutoSize = true;
            alreadyEmailLabelRegister.AutoSize = true;

            emptyInfoLabelRegister.Visible = false;
            alreadyUserLabelRegister.Visible = false;
            alreadyEmailLabelRegister.Visible = false;
            badEmailLabelRegister.Visible = false;

            emptyInfoLabelRegister.Top = 20;    
            emptyInfoLabelRegister.Left = 75;
            alreadyUserLabelRegister.Location = emptyInfoLabelRegister.Location;
            alreadyEmailLabelRegister.Location = emptyInfoLabelRegister.Location;
            badEmailLabelRegister.Location = emptyInfoLabelRegister.Location;

            registerDownPicture.Controls.Add(emptyInfoLabelRegister);
            registerDownPicture.Controls.Add(alreadyUserLabelRegister);
            registerDownPicture.Controls.Add(alreadyEmailLabelRegister);
            registerDownPicture.Controls.Add(badEmailLabelRegister);

            registerDownPicture.Controls.SetChildIndex(emptyInfoLabelRegister, 0);


            backLabelRegister = new Label();
            backLabelRegister.Click += BackLabel_Click;
            backLabelRegister.Text = "";
            backLabelRegister.Top = 95;
            backLabelRegister.BackColor = Color.Transparent;
            backLabelRegister.Left = registerButton.Location.X + 78;
            backLabelRegister.AutoSize = true;
            backLabelRegister.Cursor = Cursors.Hand;
            backLabelRegister.UseCompatibleTextRendering = true;
            backLabelRegister.ForeColor = Color.SteelBlue;
            backLabelRegister.Font = new Font(pfc.Families[2], 10, FontStyle.Regular);
            registerDownPicture.Controls.Add(backLabelRegister);
            registerDownPicture.Controls.SetChildIndex(backLabelRegister, 0);


            //Forgot Screen
            forgotGroupBox.Controls.Add(emailBoxForgot);
            backLabelEmail = new Label();
            backLabelEmail.Text = "";
            backLabelEmail.Top = 15;
            backLabelEmail.BackColor = Color.Transparent;
            backLabelEmail.Left = 275;
            backLabelEmail.AutoSize = true;
            backLabelEmail.Cursor = Cursors.Hand;
            backLabelEmail.UseCompatibleTextRendering = true;
            backLabelEmail.ForeColor = Color.SteelBlue;
            backLabelEmail.Font = new Font(pfc.Families[2], 10, FontStyle.Regular);
            backLabelEmail.Click += BackLabel_Click;
            forgotPictureDown.Controls.Add(backLabelEmail);
            forgotPassButton.Top = 0;
        }

        private void InitializeTextBoxes()
        {
            Font textBoxFont = new Font(pfc.Families[1],8);
            //AA
            usernameBoxLogin = new AnimatedTextBox("",BOX_SIZE);
            usernameBoxLogin.Location = new Point(76, 208);
            usernameBoxLogin.SetFont(textBoxFont);

            passBoxLogin = new AnimatedTextBox("",BOX_SIZE);
            passBoxLogin.Location = new Point(76, 283);
            passBoxLogin.SetFont(textBoxFont);
            passBoxLogin.PasswordChar = '*';

            //Name Box
            nameBoxRegister = new AnimatedTextBox("", BOX_SIZE);
            nameBoxRegister.Location = new Point(76, 208);
            nameBoxRegister.SetFont(textBoxFont);

            //Email Box
            emailBoxRegister = new AnimatedTextBox("", BOX_SIZE);
            emailBoxRegister.Location = new Point(76, 258);
            emailBoxRegister.SetFont(textBoxFont);
            //UserNAME BOX
            usernameBoxRegister = new AnimatedTextBox("", BOX_SIZE);
            usernameBoxRegister.Location = new Point(76, 308);
            usernameBoxRegister.SetFont(textBoxFont);


            //Password BOX
            pass1BoxRegister = new AnimatedTextBox("", BOX_SIZE);
            pass1BoxRegister.Location = new Point(76, 358);
            pass1BoxRegister.SetFont(textBoxFont);
            pass1BoxRegister.PasswordChar = '*';

            //Forgot Email Box
            emailBoxForgot = new AnimatedTextBox("", BOX_SIZE);
            emailBoxForgot.Location = new Point(76, 208);
            emailBoxForgot.SetFont(textBoxFont);


        }

        private void SetStrings()
        {
            LanguageString loginS;
            languageStrings.TryGetValue("usernameBoxLoginString", out loginS);
            usernameBoxLogin.SetLabelText(loginS.GetString(Globals.MySettings.LanguageOption));
            usernameBoxRegister.SetLabelText(loginS.GetString(Globals.MySettings.LanguageOption));


            LanguageString passS;
            languageStrings.TryGetValue("passBoxLoginString", out passS);
            passBoxLogin.SetLabelText(passS.GetString(Globals.MySettings.LanguageOption));
            pass1BoxRegister.SetLabelText(passS.GetString(Globals.MySettings.LanguageOption));


            LanguageString forgotPassLabelS;
            languageStrings.TryGetValue("forgotPassLabelString", out forgotPassLabelS);
            forgotPassLabel.Text = forgotPassLabelS.GetString(Globals.MySettings.LanguageOption);

            LanguageString nameBoxRegisterS;
            languageStrings.TryGetValue("nameBoxRegisterString", out nameBoxRegisterS);
            nameBoxRegister.SetLabelText(nameBoxRegisterS.GetString(Globals.MySettings.LanguageOption));

            LanguageString emailBoxRegisterS;
            languageStrings.TryGetValue("emailBoxRegisterString", out emailBoxRegisterS);
            emailBoxRegister.SetLabelText(emailBoxRegisterS.GetString(Globals.MySettings.LanguageOption));
            emailBoxForgot.SetLabelText(emailBoxRegisterS.GetString(Globals.MySettings.LanguageOption));


            LanguageString s;
            languageStrings.TryGetValue("loginButtonString", out s);
            OkeyButton.Text = s.GetString(Globals.MySettings.LanguageOption);
            
           
            LanguageString registerButtonS;
            languageStrings.TryGetValue("registerButtonString", out registerButtonS);
            registerButton.Text = registerButtonS.GetString(Globals.MySettings.LanguageOption);
            registerLabelLogin.Text = registerButtonS.GetString(Globals.MySettings.LanguageOption);

            LanguageString backLabelS;
            languageStrings.TryGetValue("backLabelRegisterString", out backLabelS);
            backLabelRegister.Text = backLabelS.GetString(Globals.MySettings.LanguageOption);
            backLabelEmail.Text = backLabelS.GetString(Globals.MySettings.LanguageOption);

            LanguageString forgotPassButtonS;
            languageStrings.TryGetValue("forgotPassButtonString", out forgotPassButtonS);
            forgotPassButton.Text = forgotPassButtonS.GetString(Globals.MySettings.LanguageOption);

            LanguageString emptyUsernameLabelLoginS;
            languageStrings.TryGetValue("emptyUsernameLabelLoginString", out emptyUsernameLabelLoginS);
            emptyUsernameLabelLogin.Text = emptyUsernameLabelLoginS.GetString(Globals.MySettings.LanguageOption);
            emptyUsernameLabelLogin.ForeColor = Color.Red;

            LanguageString emptyPassLabelLoginS;
            languageStrings.TryGetValue("emptyPassLabelLoginString", out emptyPassLabelLoginS);
            emptyPassLabelLogin.Text = emptyPassLabelLoginS.GetString(Globals.MySettings.LanguageOption);
            emptyPassLabelLogin.ForeColor = Color.Red;

            LanguageString badPassLabelLoginS;
            languageStrings.TryGetValue("badPasswordLabelLoginString", out badPassLabelLoginS);
            badPassLabelLogin.Text = badPassLabelLoginS.GetString(Globals.MySettings.LanguageOption);
            badPassLabelLogin.ForeColor = Color.Red;

            //Empty Info Label
            LanguageString emptyInfoLabelRegisterS;
            languageStrings.TryGetValue("emptyInfoLabelRegisterString", out emptyInfoLabelRegisterS);
            emptyInfoLabelRegister.Text = emptyInfoLabelRegisterS.GetString(Globals.MySettings.LanguageOption);
            emptyInfoLabelRegister.ForeColor = Color.Red;

            //Registered Label
            LanguageString registeredLabelLoginS;
            languageStrings.TryGetValue("registeredLabelLoginString", out registeredLabelLoginS);
            registeredLabelLogin.Text = registeredLabelLoginS.GetString(Globals.MySettings.LanguageOption);
            registeredLabelLogin.ForeColor = Color.Green;

            //Already registered label
            LanguageString alreadyUserLabelRegisterS;
            languageStrings.TryGetValue("alreadyUserLabelRegisterString", out alreadyUserLabelRegisterS);
            alreadyUserLabelRegister.Text = alreadyUserLabelRegisterS.GetString(Globals.MySettings.LanguageOption);
            alreadyUserLabelRegister.ForeColor = Color.Red;
            //AlreadyEmail
            
            LanguageString alreadyEmailLabelRegisterS;
            languageStrings.TryGetValue("alreadyEmailLabelRegisterString", out alreadyEmailLabelRegisterS);
            alreadyEmailLabelRegister.Text = alreadyEmailLabelRegisterS.GetString(Globals.MySettings.LanguageOption);
            alreadyEmailLabelRegister.ForeColor = Color.Red;

            LanguageString badEmailLabelRegisterS;
            languageStrings.TryGetValue("badEmailLabelRegisterString", out badEmailLabelRegisterS);
            badEmailLabelRegister.Text = badEmailLabelRegisterS.GetString(Globals.MySettings.LanguageOption);
            badEmailLabelRegister.ForeColor = Color.Red;
        }

        private void InitializeStrings()
        {
            //Login Button
            LanguageString loginButtonString = new LanguageString();
            loginButtonString.AddString("Giriş Yap",AppSettings.Language.Turkish);
            loginButtonString.AddString("Login", AppSettings.Language.English);
            languageStrings.Add("loginButtonString",loginButtonString);

            //Register Button
            LanguageString registerButtonString = new LanguageString();
            registerButtonString.AddString("Kayıt Ol",AppSettings.Language.Turkish);
            registerButtonString.AddString("Register", AppSettings.Language.English);
            languageStrings.Add("registerButtonString",registerButtonString);

            //Login UsernameBox
            LanguageString usernameBoxLoginString = new LanguageString();
            usernameBoxLoginString.AddString("Kullanıcı Adı",AppSettings.Language.Turkish);
            usernameBoxLoginString.AddString("Username", AppSettings.Language.English);
            languageStrings.Add("usernameBoxLoginString", usernameBoxLoginString);

            //Login passBox
            LanguageString passBoxLoginString = new LanguageString();
            passBoxLoginString.AddString("Şifre", AppSettings.Language.Turkish);
            passBoxLoginString.AddString("Password", AppSettings.Language.English);
            languageStrings.Add("passBoxLoginString", passBoxLoginString);

            //Forgot Pass Label
            LanguageString forgotPassLabelString = new LanguageString();
            forgotPassLabelString.AddString("Şifremi Unuttum",AppSettings.Language.Turkish);
            forgotPassLabelString.AddString("Forgot Password", AppSettings.Language.English);
            languageStrings.Add("forgotPassLabelString", forgotPassLabelString);

            //Name Surname Box
            LanguageString nameBoxRegisterString = new LanguageString();
            nameBoxRegisterString.AddString("İsim Soyisim", AppSettings.Language.Turkish);
            nameBoxRegisterString.AddString("Name/Surname", AppSettings.Language.English);
            languageStrings.Add("nameBoxRegisterString", nameBoxRegisterString);

            //Email
            LanguageString emailBoxRegisterString = new LanguageString();
            emailBoxRegisterString.AddString("Email", AppSettings.Language.Turkish);
            emailBoxRegisterString.AddString("Email", AppSettings.Language.English);
            languageStrings.Add("emailBoxRegisterString", emailBoxRegisterString);

            //Back Label Register
            LanguageString backLabelRegisterString = new LanguageString();
            backLabelRegisterString.AddString("Geri", AppSettings.Language.Turkish);
            backLabelRegisterString.AddString("Back", AppSettings.Language.English);
            languageStrings.Add("backLabelRegisterString", backLabelRegisterString);

            //Forgot Password Button
            LanguageString forgotPassButtonString = new LanguageString();
            forgotPassButtonString.AddString("Şifremi yolla", AppSettings.Language.Turkish);
            forgotPassButtonString.AddString("Send Password", AppSettings.Language.English);
            languageStrings.Add("forgotPassButtonString", forgotPassButtonString);

            //Login Empty Username
            LanguageString emptyUsernameLabelLoginString = new LanguageString();
            emptyUsernameLabelLoginString.AddString("Kullanıcı adı boş bırakılamaz!", AppSettings.Language.Turkish);
            emptyUsernameLabelLoginString.AddString("Username cannot be empty!", AppSettings.Language.English);
            languageStrings.Add("emptyUsernameLabelLoginString", emptyUsernameLabelLoginString);

            //Login Empty Password
            LanguageString emptyPassLabelLoginString = new LanguageString();
            emptyPassLabelLoginString.AddString("Şifre boş bırakılamaz!", AppSettings.Language.Turkish);
            emptyPassLabelLoginString.AddString("Password cannot be empty!", AppSettings.Language.English);
            languageStrings.Add("emptyPassLabelLoginString", emptyPassLabelLoginString);

            //Login Bad Password
            LanguageString badPasswordLabelLoginString = new LanguageString();
            badPasswordLabelLoginString.AddString("Kullanıcı adı veya şifre yanlış!", AppSettings.Language.Turkish);
            badPasswordLabelLoginString.AddString("Username or password is incorrect!", AppSettings.Language.English);
            languageStrings.Add("badPasswordLabelLoginString", badPasswordLabelLoginString);

            //Register Empty Info
            LanguageString emptyInfoLabelRegisterString = new LanguageString();
            emptyInfoLabelRegisterString.AddString("Herhangi bir kutucuk boş bırakılamaz!", AppSettings.Language.Turkish);
            emptyInfoLabelRegisterString.AddString("Any box cannot be empty!", AppSettings.Language.English);
            languageStrings.Add("emptyInfoLabelRegisterString", emptyInfoLabelRegisterString);

            //Registered Label
            LanguageString registeredLabelLoginString = new LanguageString();
            registeredLabelLoginString.AddString("Başarıyla kayıt olundu!", AppSettings.Language.Turkish);
            registeredLabelLoginString.AddString("You have successfully registered!", AppSettings.Language.English);
            languageStrings.Add("registeredLabelLoginString", registeredLabelLoginString);

            //Already Register label
            LanguageString alreadyUserLabelRegisterString = new LanguageString();
            alreadyUserLabelRegisterString.AddString("Bu kullanıcı adı ile zaten hesap var!", AppSettings.Language.Turkish);
            alreadyUserLabelRegisterString.AddString("This username is already in use!", AppSettings.Language.English);
            languageStrings.Add("alreadyUserLabelRegisterString", alreadyUserLabelRegisterString);

            LanguageString alreadyEmailLabelRegisterString = new LanguageString();
            alreadyEmailLabelRegisterString.AddString("Bu email ile zaten hesap var!", AppSettings.Language.Turkish);
            alreadyEmailLabelRegisterString.AddString("This email is already in use!", AppSettings.Language.English);
            languageStrings.Add("alreadyEmailLabelRegisterString", alreadyEmailLabelRegisterString);

            LanguageString badEmailLabelRegisterString = new LanguageString();
            badEmailLabelRegisterString.AddString("Geçersiz email!", AppSettings.Language.Turkish);
            badEmailLabelRegisterString.AddString("Invalid email address!", AppSettings.Language.English);
            languageStrings.Add("badEmailLabelRegisterString", badEmailLabelRegisterString);

        }

        private void CheckStartablity()
        {
            if (!Globals.MySettings.IsJsonExisted())
            {
                Globals.MySettings.CreateJsonFile();
            }
            else
            {
                Globals.MySettings.GetSettings();
            }
        }
      
      
        private void SetErrorLabel(Label l)
        {
            errorLabelTimer.Stop();
            selectedErrorLabel.Visible = false;
            selectedErrorLabel = l;
            selectedErrorLabel.Visible = true;
            errorLabelTimer.Start();

        }

        private void ResetRegisterTextBoxes()
        {
            if (registerGroupBox.Visible == false)
                return;
            emailBoxRegister.Text = "";
            usernameBoxRegister.Text = "";
            nameBoxRegister.Text = "";
            pass1BoxRegister.Text = "";

            emailBoxRegister.LabelToCenter();
            usernameBoxRegister.LabelToCenter();
            nameBoxRegister.LabelToCenter();
            pass1BoxRegister.LabelToCenter();

        }
        private void ResetForgotTextBoxes()
        {
            if (forgotGroupBox.Visible == false)
                return;
            emailBoxForgot.Text = "";
            emailBoxForgot.LabelToCenter();
        }

        // Form Events -------------------------------------------------------------------------------------------------
        
        private void UsernameEmptyErrorLogin_Tick(object sender,EventArgs e)
        {
            selectedErrorLabel.Visible = false;
            errorLabelTimer.Stop();

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globals.MySettings.SetJsonFile();
        }

        private void loginGroupBox_Enter(object sender, EventArgs e)
        {

        }
        private void ForgotPassLabel_Click(object sender,EventArgs e)
        {
            selectedGroupBox.Visible = false;
            selectedGroupBox = forgotGroupBox;
            selectedGroupBox.Visible = true;
        }
        private void RegisterLabel_Click(object sender,EventArgs e)
        {
            selectedGroupBox.Visible = false;
            selectedGroupBox = registerGroupBox;
            selectedGroupBox.Visible = true;
        }
        private void BackLabel_Click(object sender,EventArgs e)
        {
            ResetRegisterTextBoxes();
            ResetForgotTextBoxes();
            selectedGroupBox.Visible = false;
            selectedGroupBox = loginGroupBox;
            selectedGroupBox.Visible = true;
            
        }
        
        private async void RegisterButton_Click(object sender,EventArgs e)
        {         
            if(usernameBoxRegister.Text == string.Empty || emailBoxRegister.Text == string.Empty || nameBoxRegister.Text == string.Empty
                || pass1BoxRegister.Text == string.Empty)
            {
                SetErrorLabel(emptyInfoLabelRegister);
                return;
            }
            if (!Globals.EmailHandle.EmailVerify(emailBoxRegister.Text))
            {
                SetErrorLabel(badEmailLabelRegister);
                return;
            }
             string[] Infos = nameBoxRegister.Text.Split(' ');
            if(Infos.Length == 1)
            {
                SetErrorLabel(emptyInfoLabelRegister);
                return;
            }

            //Register  İşlemleri
            User user = new User();
            user.Username = usernameBoxRegister.Text;
            user.Email = emailBoxRegister.Text;
            user.SetPassword(pass1BoxRegister.Text);
            user.Surname = Infos[Infos.Length-1].ToUpperFirstLetter();
            string name = "";
            for(int i = 1; 0 < Infos.Length-1;i++)
            {
                if (i == Infos.Length - 1)
                {
                    name += Infos[i].ToUpperFirstLetter();
                }
                else
                {
                    name += Infos[i].ToUpperFirstLetter() + " ";
                }
            }
            user.Name = name;

            List<User> user2 = await Globals.database.GetUser(user.Username);
            List<User> user3 = await Globals.database.GetUserWithEmail(user.Email);
            if(user2.Count != 0)
            {
                SetErrorLabel(alreadyUserLabelRegister);
                return;
            }
            if(user3.Count != 0)
            {
                SetErrorLabel(alreadyEmailLabelRegister);
                return;
            }
            Globals.database.InsertUser(user);
            BackLabel_Click(null,null);
            SetErrorLabel(registeredLabelLogin);
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {

            if (usernameBoxLogin.Text == string.Empty)
            {
                SetErrorLabel(emptyUsernameLabelLogin);
                return;
            }
            else if (passBoxLogin.Text == string.Empty)
            {
                SetErrorLabel(emptyPassLabelLogin);


                return;
            }
            string username = usernameBoxLogin.Text;
            string password = passBoxLogin.Text;

            List<User> user = await Globals.database.GetUser(username);
            //User Not Found
            if (user.Count == 0)
            {
                SetErrorLabel(badPassLabelLogin);
            }
             //User Found 
            else
            {
                User myUser = user[0];
                if(myUser.Password != password)
                {
                    SetErrorLabel(badPassLabelLogin);

                }
                else
                {
                    ///LOGİN İŞLEMLERİ ŞİFRESİ DOĞRUYMUŞ
                    ///
                }
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          

        }
    }
}
