﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;
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
        int countstate = 1;//ui state counter //1 means normal condition , 0 for inverted
        private void inv_Click(object sender, EventArgs e)
        {
            if (countstate == 1)
            {

                sin.Text = "sin⁻¹";
                cos.Text = "cos⁻¹";
                tan.Text = "tan⁻¹";
                ln.Text = "eˣ";
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


        //Codes for implemation of Dark Mode

        int darkmode = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (darkmode == 0)
            {
                this.BackColor = Color.Black;
                digit0.ForeColor = SystemColors.Control;
                digit1.ForeColor = SystemColors.Control;
                digit2.ForeColor = SystemColors.Control;
                digit3.ForeColor = SystemColors.Control;
                digit4.ForeColor = SystemColors.Control;
                digit5.ForeColor = SystemColors.Control;
                digit6.ForeColor = SystemColors.Control;
                digit7.ForeColor = SystemColors.Control;
                digit8.ForeColor = SystemColors.Control;
                digit9.ForeColor = SystemColors.Control;
                dot.ForeColor = SystemColors.Control;
                mainview.ForeColor = SystemColors.Control;
                mainview.BackColor = Color.Black;
                secondaryview.BackColor = Color.Black;



                darkmode = 1;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                digit0.ForeColor = Color.Black;
                digit1.ForeColor = Color.Black;
                digit2.ForeColor = Color.Black;
                digit3.ForeColor = Color.Black;
                digit4.ForeColor = Color.Black;
                digit5.ForeColor = Color.Black;
                digit6.ForeColor = Color.Black;
                digit7.ForeColor = Color.Black;
                digit8.ForeColor = Color.Black;
                digit9.ForeColor = Color.Black;
                mainview.ForeColor = Color.Black;
                mainview.BackColor = SystemColors.Control;
                secondaryview.BackColor = SystemColors.Control;

                darkmode = 0;

            }

        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please send us your Feedback at satyajit.edu@outlook.com", "Send Feedback");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Go to the https://github.com/SATYAJIT1910/AndroCalculator", "Help");
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
            digit0.ForeColor = Color.Black;
            digit1.ForeColor = Color.Black;
            digit2.ForeColor = Color.Black;
            digit3.ForeColor = Color.Black;
            digit4.ForeColor = Color.Black;
            digit5.ForeColor = Color.Black;
            digit6.ForeColor = Color.Black;
            digit7.ForeColor = Color.Black;
            digit8.ForeColor = Color.Black;
            digit9.ForeColor = Color.Black;
            mainview.ForeColor = Color.Black;
            mainview.BackColor = SystemColors.Control;
            secondaryview.BackColor = SystemColors.Control;
            lightToolStripMenuItem.Checked = true;
            darkToolStripMenuItem.Checked = false;


            darkmode = 0;

        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            digit0.ForeColor = SystemColors.Control;
            digit1.ForeColor = SystemColors.Control;
            digit2.ForeColor = SystemColors.Control;
            digit3.ForeColor = SystemColors.Control;
            digit4.ForeColor = SystemColors.Control;
            digit5.ForeColor = SystemColors.Control;
            digit6.ForeColor = SystemColors.Control;
            digit7.ForeColor = SystemColors.Control;
            digit8.ForeColor = SystemColors.Control;
            digit9.ForeColor = SystemColors.Control;
            dot.ForeColor = SystemColors.Control;
            mainview.ForeColor = SystemColors.Control;
            mainview.BackColor = Color.Black;
            secondaryview.BackColor = Color.Black;
            lightToolStripMenuItem.Checked = false;
            darkToolStripMenuItem.Checked = true;


            darkmode = 1;

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            //MessageBox.Show("Right click");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        //writing the backend codes
        string mainstring = "";

        private void digit1_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '1';
            secondaryview.Text = mainstring;
        }

        private void digit2_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '2';
            secondaryview.Text = mainstring;
        }

        private void digit3_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '3';
            secondaryview.Text = mainstring;
        }

        private void digit4_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '4';
            secondaryview.Text = mainstring;
        }

        private void digit5_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '5';
            secondaryview.Text = mainstring;
        }

        private void digit6_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '6';
            secondaryview.Text = mainstring;
        }

        private void digit7_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '7';
            secondaryview.Text = mainstring;
        }

        private void digit8_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '8';
            secondaryview.Text = mainstring;
        }

        private void digit9_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '9';
            secondaryview.Text = mainstring;
        }

        private void digit0_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '0';
            secondaryview.Text = mainstring;
        }

        private void plus_Click(object sender, EventArgs e)
        {


            mainstring = mainstring + '+';

            secondaryview.Text = mainstring;

        }

        private void minus_Click(object sender, EventArgs e)
        {



            mainstring = mainstring + '-';

            secondaryview.Text = mainstring;

        }

        private void multiply_Click(object sender, EventArgs e)
        {


            mainstring = mainstring + '*';

            secondaryview.Text = mainstring;

        }

        private void divide_Click(object sender, EventArgs e)
        {

            mainstring = mainstring + '/';

            secondaryview.Text = mainstring;
        }

        private void equal_Click(object sender, EventArgs e)
        {


            //testing capability
            // mainstring = "sin(45)+2";
            //string value = new DataTable().Compute(mainstring, null).ToString();//evalutes the result from string
            if (deg2.Text == "DEG")
            {

                mXparser.setDegreesMode();
                Expression eh = new Expression(mainstring);
                string value = eh.calculate().ToString();
                mainview.Text = Convert.ToString(value);
            }
            else
            {
                mXparser.setRadiansMode();
                Expression eh = new Expression(mainstring);
                string value = eh.calculate().ToString();
                mainview.Text = Convert.ToString(value);
            }





        }


        private void backspace_Click(object sender, EventArgs e)
        {

            if (mainview.Text == "NaN")
            {
                mainview.Text = "";
            }
            //code for backspace
            int textlength = secondaryview.Text.Length;
            if (textlength > 0)
            {
                secondaryview.Text = secondaryview.Text.Substring(0, textlength - 1);

            }
            secondaryview.Focus();
            secondaryview.SelectionStart = mainview.Text.Length;
            secondaryview.SelectionLength = 0;

            mainstring = secondaryview.Text;
        }
    


       

        private void options_Click(object sender, EventArgs e)
        {
            //code for contextmenu access by left click
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip1.Show(ptLowerLeft);
            ////
        }

        private void sin_Click(object sender, EventArgs e)
        {

            if (countstate == 1)
            {
                mainstring += "sin(";
            }
            else
            {
                mainstring += "asin(";
            }
            
            secondaryview.Text = mainstring;

        }
        

        private void closepar_Click(object sender, EventArgs e)
        {

            mainstring += ")";
            secondaryview.Text = mainstring;
        }

        private void cos_Click(object sender, EventArgs e)
        {
            if (countstate == 1)
            {
                mainstring += "cos(";
            }
            else
            {
                mainstring += "acos(";
            }

            secondaryview.Text = mainstring;

        }

        private void tan_Click(object sender, EventArgs e)
        {
            if (countstate == 1)
            {
                mainstring += "tan(";
            }
            else
            {
                mainstring += "atan(";
            }

            secondaryview.Text = mainstring;

        }

        private void factorial_Click(object sender, EventArgs e)
        {
            mainstring += "!";
            secondaryview.Text = mainstring;

        }

        private void dot_Click(object sender, EventArgs e)
        {
            mainstring += ".";
            secondaryview.Text = mainstring;
        }

        private void exp_Click(object sender, EventArgs e)
        {
            mainstring += "e";
            secondaryview.Text = mainstring;
        }

        private void pie_Click(object sender, EventArgs e)
        {
            mainstring += "pi";
            secondaryview.Text = mainstring;
        }

        private void root_Click(object sender, EventArgs e)
        {
            mainstring += "^";
            secondaryview.Text = mainstring;
        }

        private void squareroot_Click(object sender, EventArgs e)
        {
            if (countstate == 1)
            {

            mainstring += "sqrt(";
            }
            else
            {
                mainstring += "^2";
            }
            secondaryview.Text = mainstring;
        }

        private void log_Click(object sender, EventArgs e)
        {
            if (countstate == 1)
            {

            mainstring += "log10(";
            }
            else
            {
                mainstring += "10^";
            }
            secondaryview.Text = mainstring;
        }

        private void ln_Click(object sender, EventArgs e)
        {
            if (countstate == 1)
            {

            mainstring += "ln(";
            }
            else
            {
            mainstring += "e^";
            }
            secondaryview.Text = mainstring;
        }

        private void percentage_Click(object sender, EventArgs e)
        {
            mainstring += "%";
            secondaryview.Text = mainstring;
        }

        private void openpar_Click(object sender, EventArgs e)
        {
            mainstring += "(";
            secondaryview.Text = mainstring;
        }
    }
}
