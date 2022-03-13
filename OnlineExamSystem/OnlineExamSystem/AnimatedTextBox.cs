using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace OnlineExamSystem
{
    internal class AnimatedTextBox : Guna2TextBox
    {

        public Label placeHolder = new Label();
        //Hover Animate
        Timer hoverTimer = new Timer();
        bool isHoverAnimationDoing = false;
        Color hoverColor;
        int hoverColorDepth;

        //Mouse Leave
        Timer leaveTimer = new Timer();
        bool isLeaveAnimationDoing = false;

        Color leaveColor;

        //Focus Animate
        Timer focusTimer = new Timer();
        bool isFocusAnimationDoing = false;
        float focusFontSize = 8f;
        readonly Point LABEL_LOC = new Point(0, 0);

        float widthRatio;
        float heightRatio;
        float fontRatio;
        int moveDepth = 10;
        //It will be provide that be able to move with floating numbers 
        float label_locX_float;
        float label_locY_float;
        //LostFocus Animate
        Timer lostFocusTimer = new Timer();
        bool isLostFocusAnimationDoing = false;
        float targetSize;
        Point targetPosition;

       
        internal AnimatedTextBox(string s,Size boxSize)
        {
            this.ForeColor = Color.Black;
            this.Size = boxSize;
            this.TextChanged += TextBoxTextChanged;
            this.targetSize = placeHolder.Font.Size;
            placeHolder.ForeColor = Color.Purple;
            leaveColor = placeHolder.ForeColor;


            placeHolder.Font = new Font("Arial", 8, FontStyle.Regular);  
            placeHolder.Text = s;
            placeHolder.FontChanged += LabeFontChanged;
            float maxWidth = 0;
            using(Graphics g = CreateGraphics())
            {
                var size = g.MeasureString(placeHolder.Text,placeHolder.Font);
                maxWidth = size.Width;
            }
            placeHolder.BackColor = Color.Transparent;
            placeHolder.Width = Convert.ToInt32(maxWidth);
            placeHolder.Top = ((this.Size.Height - placeHolder.Size.Height))/2 ;
            placeHolder.Left = (this.Size.Width - Convert.ToInt32(maxWidth))/2 ;      
            placeHolder.Height = placeHolder.Font.Height;

            this.Controls.Add(placeHolder);

            this.Controls.SetChildIndex(placeHolder, 0);

            
            //Hover Animate
            hoverColorDepth = 40;
            placeHolder.MouseHover += MouseHoverAnimation;
            this.MouseHover += MouseHoverAnimation;

       
            hoverTimer.Interval = 1;
            hoverTimer.Tick += HoverAnimationTick;

            //Leave Animate
            this.MouseLeave += MouseLeaveAnimation;
            leaveTimer.Interval = 1;           
            leaveTimer.Tick += LeaveAnimationTick;

            //Focus Animate
            this.Enter += ClickAnimation;
            focusTimer.Interval = moveDepth;
            focusTimer.Tick += ClickAnimationTick;

            //LostFocus Animate
            this.Leave += LostFocusAnimation;
            lostFocusTimer.Interval = moveDepth;
            lostFocusTimer.Tick += LostFocusAnimationTick;
        }


        internal void SetLabelText(string s)
        {
            placeHolder.Text = s;
            float maxWidth;
            using (Graphics g = CreateGraphics())
            {
                var size = g.MeasureString(placeHolder.Text, placeHolder.Font);
                maxWidth = size.Width;
            }
            placeHolder.Width = Convert.ToInt32(maxWidth);
            placeHolder.Left -= placeHolder.Width / 2 ;
            ReDrawLabel();
            

        }

        private Color GetNewColor(bool b = true)
        {       float total = placeHolder.ForeColor.R + placeHolder.ForeColor.G + placeHolder.ForeColor.B;
                float rRatio = placeHolder.ForeColor.R / total;
                float gRatio = placeHolder.ForeColor.G / total;
                float bRatio = placeHolder.ForeColor.B / total;
            if (b)
            {
              

                int colorR = placeHolder.ForeColor.R + Convert.ToInt32((hoverColorDepth/12 * rRatio));
                if (colorR < hoverColor.R)
                {
                    colorR = hoverColor.R;
                }
                int colorG = placeHolder.ForeColor.G + Convert.ToInt32((hoverColorDepth/12 * gRatio));
                if (colorG < hoverColor.G)
                {
                    colorG = hoverColor.G;
                }
                int colorB = placeHolder.ForeColor.B + Convert.ToInt32((hoverColorDepth / 12 * bRatio));
                if (colorB < hoverColor.B)
                {
                    colorB = hoverColor.B;
                }
                return  Color.FromArgb(colorR, colorG, colorB);
            }
            else
            {
                int colorR = placeHolder.ForeColor.R - Convert.ToInt32((hoverColorDepth * rRatio));
                if (colorR > leaveColor.R)
                {
                    colorR = leaveColor.R;
                }
                int colorG = placeHolder.ForeColor.G - Convert.ToInt32((hoverColorDepth * gRatio));
                if (colorG > leaveColor.G)
                {
                    colorG = hoverColor.G;
                }
                int colorB = placeHolder.ForeColor.B - Convert.ToInt32((hoverColorDepth * bRatio));
                if (colorB < hoverColor.B)
                {
                    colorB = leaveColor.B;
                }
                return Color.FromArgb(colorR, colorG, colorB);
            }
        }





        private void TextBoxTextChanged(object sender,EventArgs e)
        {
            Guna2TextBox textbox = sender as Guna2TextBox;
            if(textbox.Text != string.Empty)
            {
                isLostFocusAnimationDoing = true;
            }
            else
            {
                isLostFocusAnimationDoing = false;

            }
        }
        // Animations

        private void ClickAnimationTick(object sender,EventArgs e)
        {
           
            label_locX_float -= widthRatio;
            label_locY_float -= heightRatio;
            int label_locX = Convert.ToInt32(label_locX_float);
            if (label_locX < 0)
            {
                label_locX = 0;
                label_locX_float = 0;
            }
            int label_locY = Convert.ToInt32(label_locY_float);
            if (label_locY < 0)
            {
                label_locY = 0;
                label_locY_float = 0;
            }
            Point newLoc = new Point(label_locX,label_locY);
            float fontSize = placeHolder.Font.Size - fontRatio;
            if (fontSize < focusFontSize)
                fontSize = focusFontSize;
            Font newFont = new Font("Arial",fontSize,FontStyle.Regular);
            if(!newLoc.Equals(LABEL_LOC))
            {
                placeHolder.Location = newLoc;
                placeHolder.Font = newFont;
            }
            else
            {
                isLostFocusAnimationDoing = false;
                focusTimer.Stop();
                placeHolder.Location = new Point(0,0);
                ReDrawLabel();
            }
        }
        private float GetEBOB(float first,float second)
        {
            float total = 0;
            if(first > second)
            {
                for(int i = 1; i < first; i++)
                {
                    if (first % i == 0 && second % i == 0) total = i;
                }
            }
            else if(first < second)
            {
                for(int i = 1; i < second; i++)
                {
                    if (first % i == 0 && second % i == 0) total = i;

                }
            }
            else
            {
                return first;
            }
            return total;
        }
        private void ClickAnimation(object sender,EventArgs e)
        {
            if (isFocusAnimationDoing)
                return;
            float widthDif = (placeHolder.Location.X - LABEL_LOC.X);
            float heightDif = (placeHolder.Location.Y - LABEL_LOC.Y);
            float fontDif = placeHolder.Font.Size - focusFontSize;
            float ebob = GetEBOB(widthDif, heightDif);
            fontRatio = (fontDif / ebob)/moveDepth;
            widthRatio = (widthDif / ebob)/moveDepth;
            heightRatio = ((heightDif / ebob))/moveDepth;
            label_locX_float = placeHolder.Location.X;
            label_locY_float = placeHolder.Location.Y;

            targetPosition = placeHolder.Location;
            targetSize = placeHolder.Font.Size;

            isLostFocusAnimationDoing = false;
            lostFocusTimer.Stop();  
            isFocusAnimationDoing = true;
            focusTimer.Start();
        }


        public void SetFont(Font font)
        {
            placeHolder.Font = font;
            ReDrawLabel();
        }


        private void LostFocusAnimationTick(object sender,EventArgs e)
        {
            label_locX_float += widthRatio;
            label_locY_float += heightRatio;
            int label_locX = Convert.ToInt32(label_locX_float);
            if (label_locX > targetPosition.X)
            {
                label_locX = targetPosition.X;
                label_locX_float = targetPosition.X;
            }
            int label_locY = Convert.ToInt32(label_locY_float);
            if (label_locY > targetPosition.Y)
            {
                label_locY = targetPosition.Y;
                label_locY_float = targetPosition.Y;
            }

            Point newLoc = new Point(label_locX, label_locY);
            float fontSize = placeHolder.Font.Size + fontRatio;
            if (fontSize > targetSize)
                fontSize = targetSize;

            Font newFont = new Font("Arial", fontSize, FontStyle.Regular);

            if (!newLoc.Equals(targetPosition))
            {
                placeHolder.Location = newLoc;
                placeHolder.Font = newFont;
            }
            else
            {
                isFocusAnimationDoing = false;
                lostFocusTimer.Stop();
                placeHolder.Location = targetPosition;
                placeHolder.Font = new Font(placeHolder.Font.FontFamily, targetSize, FontStyle.Regular);
                ReDrawLabel();
            }

        }

        public void LabelToCenter()
        {
            LostFocusAnimation(null, null);
        }
        private void LostFocusAnimation(object sender,EventArgs e)
        {
            if (isLostFocusAnimationDoing)
                return;   
            isFocusAnimationDoing = false;
            focusTimer.Stop(); 
            isFocusAnimationDoing = true;
            lostFocusTimer.Start();
        }

        private void HoverAnimationTick(object sender,EventArgs e)
        {
            if (placeHolder.ForeColor != hoverColor)
            {
                Console.WriteLine($"Old color : {placeHolder.ForeColor}");

                placeHolder.ForeColor = GetNewColor(false);
                Console.WriteLine($"New color : {placeHolder.ForeColor}");

            }
            else
            {
                Console.WriteLine("Finished");
                isLeaveAnimationDoing = false;
                hoverTimer.Stop();
            }
        }
        private void LeaveAnimationTick(object sender, EventArgs e)
        {
            if(placeHolder.ForeColor != leaveColor)
            {
                int colorR = placeHolder.ForeColor.R + (hoverColorDepth / 12);
                if (colorR > leaveColor.R)
                {
                    colorR = leaveColor.R;
                }
                int colorG = placeHolder.ForeColor.G + (hoverColorDepth / 12);
                if (colorG > leaveColor.G)
                {
                    colorG = leaveColor.G;
                }
                int colorB = placeHolder.ForeColor.B + (hoverColorDepth / 12);
                if (colorB > leaveColor.B)
                {
                    colorB = leaveColor.B;
                }
                placeHolder.ForeColor = Color.FromArgb(colorR, colorG, colorB);
            }
            else
            {
                Console.WriteLine("Finished Leave");
                isHoverAnimationDoing = false;
                leaveTimer.Stop();
            }
           

        }




        protected void MouseHoverAnimation(object sender,EventArgs e)
        {
            if (isHoverAnimationDoing)
                return;

            int colorR = placeHolder.ForeColor.R - hoverColorDepth;
            if(colorR < 0)
            {
                colorR = 0;
            }
            int colorG = placeHolder.ForeColor.G - hoverColorDepth;
            if(colorG < 0)
            {
                colorG = 0;
            }
            int colorB = placeHolder.ForeColor.B - hoverColorDepth;
            if(colorB < 0)
            {
                colorB = 0;
            }
            hoverColor = Color.FromArgb(colorR, colorG, colorB);
            isHoverAnimationDoing = true;
            isLeaveAnimationDoing = false; 
            leaveTimer.Stop();
             
            hoverTimer.Start();
        }

        protected void MouseLeaveAnimation(object sender, EventArgs e)
        {
            if (isLeaveAnimationDoing)
                return;
            
            isHoverAnimationDoing = false;
            isLeaveAnimationDoing = true;
            hoverTimer.Stop();
            leaveTimer.Start();

        }
        private float ReDrawLabel()
        {
            Console.WriteLine($"First MaxWidth {placeHolder.Width}");
            float maxWidth;
            using (Graphics g = CreateGraphics())
            {
                var size = g.MeasureString(placeHolder.Text, placeHolder.Font);
                maxWidth = size.Width;
            }
            placeHolder.Height = placeHolder.Font.Height;
            Console.WriteLine($"Second MaxWidth {placeHolder.Width}");

            return maxWidth;
        }

        private void LabeFontChanged(object sender,EventArgs e)
        {

            float maxWidth = ReDrawLabel();
        }


    }
}
