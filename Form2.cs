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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //below code is from enable mouse drag on scrren for a borderless c# form 
        Point lastPoint;

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        //this codes is for sync the darkmode status from the form1

        int form1darkmode = Form1.darkmode;
        private void Form2_Shown(object sender, EventArgs e)
        {
            if (form1darkmode == 1)
            {
                this.BackColor = Color.Black;
            }

        }
    }
}
