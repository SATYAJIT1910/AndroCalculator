using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void deg1_Click(object sender, EventArgs e)
        {
            //change in the UI
            if (deg1.Text == "DEG")
            {
                deg1.Text = "RAD";
                deg2.Text = "DEG";
            }
            else
            {
                deg1.Text = "DEG";
                deg2.Text = "RAD";
            }
        }

        private void deg2_Click(object sender, EventArgs e)
        {
            //change in the UI
            if (deg2.Text == "DEG")
            {
                deg2.Text = "RAD";
                deg1.Text = "DEG";
            }
            else
            {
                deg2.Text = "DEG";
                deg1.Text = "RAD";
            }

        }
        int countstate = 0;//ui state counter
        private void inv_Click(object sender, EventArgs e)
        {
            if (countstate == 1)
            {

            sin.Text = "sin⁻¹";
            cos.Text = "cos⁻¹";
            tan.Text = "tan⁻¹";
            ln.Text = "e⁻ˣ";
            log.Text = "10ˣ";
            squareroot.Text = "x²";
                inv.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(233)))));
                countstate = 0;
            }
            else
            {
                sin.Text = "sin";
                cos.Text = "cos";
                tan.Text = "tan";
                ln.Text = "ln";
                log.Text = "log";
                squareroot.Text = "√";
                countstate = 1;
                inv.BackColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(115)))), ((int)(((byte)(233)))));

            }




        }

        //below code is from enable mouse drag on scrren for a borderless c# form 
        Point lastPoint;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}
