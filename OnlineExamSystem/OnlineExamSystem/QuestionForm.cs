using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace OnlineExamSystem
{
    public partial class QuestionForm : Form
    {
        confirmMessagebox confirmMessage = new confirmMessagebox();

        public QuestionForm()
        {
            /*Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-uk");
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-uk");*/
            InitializeComponent();
        }

        private void addpictureBtn_Click_1(object sender, EventArgs e)
        {
            questionPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            fileshow.ShowDialog();
            questionPicture.ImageLocation = fileshow.FileName;
        }

        private void confirmquestionBtn_Click(object sender, EventArgs e)
        {
            bool flag = false;

            foreach (Control item in this.Controls)
            {
                if (item is Guna.UI2.WinForms.Guna2GroupBox)
                {
                    foreach (var textboxItem in item.Controls)
                    {

                        if (textboxItem is Guna.UI2.WinForms.Guna2TextBox)
                        {
                            Guna.UI2.WinForms.Guna2TextBox gunaTxt = textboxItem as Guna.UI2.WinForms.Guna2TextBox;
                            if (gunaTxt.Text == "")
                            {
                                flag = true;
                                //break;
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                    }
                }

                /*else if (item is Guna.UI2.WinForms.Guna2ComboBox)
                 {
                     Guna.UI2.WinForms.Guna2ComboBox gunaTxt = item as Guna.UI2.WinForms.Guna2ComboBox;
                     if (item.Text == "")
                     {
                         flag = true;
                         //break;
                     }
                     else
                     {
                         flag = false;
                     }
                 }*/

                else if (item is Guna.UI2.WinForms.Guna2TextBox)
                {
                    Guna.UI2.WinForms.Guna2TextBox gunaTxt = item as Guna.UI2.WinForms.Guna2TextBox;
                    if (gunaTxt.Text == "")
                    {
                        flag = true;
                        //break;
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }

            if (flag == true)
            {
                //lblMessage.Text = ""; eksik veri girildiginde caliscak
            }
            else
            {
                confirmMessage.ShowDialog();
            }
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            confirmMessage.ShowInTaskbar = false;
        }
    }
}
