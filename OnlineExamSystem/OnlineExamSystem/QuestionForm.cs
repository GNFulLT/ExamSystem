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
using Guna.UI2.WinForms;

namespace OnlineExamSystem
{
    public partial class QuestionForm : Form
    {
        confirmMessagebox confirmMessage = new confirmMessagebox();

        public QuestionForm()
        {
            InitializeComponent();
            questionPicture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void addpictureBtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select an image for question";
            DialogResult res = dialog.ShowDialog(this);
            if (res != DialogResult.OK)
                return;
            questionPicture.ImageLocation = dialog.FileName;
            
            
        }

        private void confirmquestionBtn_Click(object sender, EventArgs e)
        {
            if (CheckEmptyBoxes())
            {

            }
            else
            {

            }
        }

        private void QuestionForm_Load(object sender, EventArgs e)
        {
            confirmMessage.ShowInTaskbar = false;
        }
        private bool CheckEmptyBoxes()
        {
            throw new NoNullAllowedException();
        }

        private void wronganswer1Txt_TextChanged(object sender, EventArgs e)
        {
            Guna2TextBox a = sender as Guna2TextBox;
            
        }
    }
}
