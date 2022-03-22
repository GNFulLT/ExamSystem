using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineExamSystem
{
    public partial class Educator : Form
    {
        QuestionForm question = new QuestionForm();

        public Educator()
        {
            InitializeComponent();
        }

        private void Educator_Load(object sender, EventArgs e)
        {
            question.ShowInTaskbar = false;

        }

        private void questioncreateButton_Click_1(object sender, EventArgs e)
        {
            question.ShowDialog();
        }
    }
}
