using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT5
{
    public partial class MainForm : Form
    {
        List<circle> circleArr = new List<circle>();

        public MainForm()
        {
            InitializeComponent();
        }

        // Anti flickering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;
                return handleParam;
            }
        }
        private void Draw(circle Circle)
        {
            Graphics draw = contentPanel.CreateGraphics();
            Pen blackPen = new Pen(Circle.borderColor, 4);
            draw.SmoothingMode = SmoothingMode.AntiAlias;
            draw.DrawEllipse(blackPen, Circle.x - Circle.radius / 2, Circle.y - Circle.radius / 2, Circle.radius, Circle.radius);
        }

        private void animationActivate_Click(object sender, EventArgs e)
        {
            if (animationActivate.ForeColor != Color.Red)
            {
                animationActivate.ForeColor = Color.Red;
                animationActivate.Text = "STOP";
                timer.Start();
            }
            else
            {
                animationActivate.ForeColor = Color.Black;
                animationActivate.Text = "ACTIVATE";
                timer.Stop();
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            foreach (circle Circle in circleArr)
            {
                Circle.y += 5;
                if (Circle.y >= contentPanel.Height)
                    Circle.y = 0;
            }
            Refresh();
        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {
            foreach (circle Circle in circleArr)
            {
                Draw(Circle);
            }
        }
        private void contentPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();
            int x = e.X;
            int y = e.Y;
            circle c = new circle(x, y, Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
            Draw(c);
            circleArr.Add(c);
        } 
    }
}