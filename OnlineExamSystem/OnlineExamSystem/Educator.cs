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
            topPanel.Controls.SetChildIndex(leftIconButton, 0);
            leftIconPanel.Left = -400;
            
        }

        private void Educator_Load(object sender, EventArgs e)
        {
            question.ShowInTaskbar = false;

        }

        private void questioncreateButton_Click_1(object sender, EventArgs e)
        {
            question.ShowDialog();
        }

        private void logoPicture_Click(object sender, EventArgs e)
        {

        }
        bool isLeftIconAnimated = false;
        bool isLeftPanelOpen = false;
        private async void leftIconButton_Click(object sender, EventArgs e)
        {
            if (isLeftIconAnimated)
                return;
            if (!isLeftPanelOpen)
            {
            
            isLeftIconAnimated = true;
            Point newLoc = new Point(116, 28);
            await leftIconPanel.MoveAnimation_Async(newLoc,ControlAnimations.MoveType.PositiveAccelerated,5);
            isLeftIconAnimated = false;
                isLeftPanelOpen = true;
            }
            else
            {
                isLeftIconAnimated = true;
                Point newLoc = new Point(-400, 28);
                await leftIconPanel.MoveAnimation_Async(newLoc, ControlAnimations.MoveType.PositiveAccelerated, 5);
                isLeftIconAnimated = false;
                isLeftPanelOpen = false;
            }


        }
    }
}
