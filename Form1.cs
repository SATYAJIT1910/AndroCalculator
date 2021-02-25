using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;
using System.IO;
namespace AndroCalculator
{
    public partial class Form1 : Form
    {
        public static int darkmode = 0;
        public static string hist = "";

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
            Writecon(darkmode);

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
            Writecon(darkmode);

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
            mainview.Text = mainstring;
        }

        private void digit2_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '2';
            mainview.Text = mainstring;
        }

        private void digit3_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '3';
            mainview.Text = mainstring;
        }

        private void digit4_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '4';
            mainview.Text = mainstring;
        }

        private void digit5_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '5';
            mainview.Text = mainstring;
        }

        private void digit6_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '6';
            mainview.Text = mainstring;
        }

        private void digit7_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '7';
            mainview.Text = mainstring;
        }

        private void digit8_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '8';
            mainview.Text = mainstring;
        }

        private void digit9_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '9';
            mainview.Text = mainstring;
        }

        private void digit0_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '0';
            mainview.Text = mainstring;
        }

        private void plus_Click(object sender, EventArgs e)
        {


            mainstring = mainstring + '+';

            mainview.Text = mainstring;

        }

        private void minus_Click(object sender, EventArgs e)
        {



            mainstring = mainstring + '-';

            mainview.Text = mainstring;

        }

        private void multiply_Click(object sender, EventArgs e)
        {


            mainstring = mainstring + '*';

            mainview.Text = mainstring;

        }

        private void divide_Click(object sender, EventArgs e)
        {

            mainstring = mainstring + '/';

            mainview.Text = mainstring;
        }

        private void equal_Click(object sender, EventArgs e)
        {


          
            string value;
            if (deg2.Text == "DEG")
            {

                mXparser.setDegreesMode();
                Expression eh = new Expression(mainstring);
                value = eh.calculate().ToString();
                mainview.Text = Convert.ToString(value);
            }
            else
            {
                mXparser.setRadiansMode();
                Expression eh = new Expression(mainstring);
                value = eh.calculate().ToString();
                mainview.Text = Convert.ToString(value);
            }




            //storing the history

            // hist = value + " = " + mainstring + '\n';
            if (value != "NaN")
            {
            hist = mainstring + "=" + value + '\n';
            Writehist();
            hist = "";

            }



            //
            secondaryview.Text = "";






        }



        private void backspace_Click(object sender, EventArgs e)
        {

           // if (secondaryview.Text == "NaN")
          //  {
           //     mainview.Text = "";
          //  }
            //code for backspace
            int textlength = mainview.Text.Length;
            if (textlength > 0)
            {
                mainview.Text = mainview.Text.Substring(0, textlength - 1);

            }
            //secondaryview.Focus();
            secondaryview.SelectionStart = mainview.Text.Length;
            secondaryview.SelectionLength = 0;

            mainstring = mainview.Text;
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

            mainview.Text = mainstring;

        }


        private void closepar_Click(object sender, EventArgs e)
        {

            mainstring += ")";
            mainview.Text = mainstring;
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

            mainview.Text = mainstring;

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

            mainview.Text = mainstring;

        }

        private void factorial_Click(object sender, EventArgs e)
        {
            mainstring += "!";
            mainview.Text = mainstring;

        }

        private void dot_Click(object sender, EventArgs e)
        {
            mainstring += ".";
            mainview.Text = mainstring;
        }

        private void exp_Click(object sender, EventArgs e)
        {
            mainstring += "e";
            mainview.Text = mainstring;
        }

        private void pie_Click(object sender, EventArgs e)
        {
            mainstring += "pi";
            mainview.Text = mainstring;
        }

        private void root_Click(object sender, EventArgs e)
        {
            mainstring += "^";
            mainview.Text = mainstring;
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
            mainview.Text = mainstring;
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
            mainview.Text = mainstring;
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
            mainview.Text = mainstring;
        }

        private void percentage_Click(object sender, EventArgs e)
        {
            mainstring += "%";
            mainview.Text = mainstring;
        }

        private void openpar_Click(object sender, EventArgs e)
        {
            mainstring += "(";
            mainview.Text = mainstring;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // MessageBox.Show(e.KeyCode.ToString());


            if(e.KeyCode==Keys.Add || e.Shift && e.KeyCode == Keys.Oemplus)
            { 
                plus.PerformClick();
            }
            else if (e.KeyCode == Keys.Subtract || e.Shift && e.KeyCode == Keys.OemMinus)
            {
                minus.PerformClick();
            }
            else if (e.KeyCode == Keys.Multiply || e.Shift && e.KeyCode == Keys.D8)
            {
                multiply.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.D9)
            {
                openpar.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.D0)
            {
                closepar.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.OemCloseBrackets)
            {
                closepar.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.D1)
            {
                factorial.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.D6)
            {
                root.PerformClick();
            }
            else if (e.Shift && e.KeyCode == Keys.D5)
            {
                percentage.PerformClick();
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.I)
            {
                inv.PerformClick();
                
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.R)
            {
                deg1.PerformClick();

            }
            else if (e.Shift && e.KeyCode == Keys.D5)
            {
                percentage.PerformClick();
            }
            else if(e.KeyCode==Keys.Divide ||e.KeyCode==Keys.OemQuestion)
            {
                divide.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
            {
                digit0.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
            {
                digit1.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
            {
                digit2.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
            {
                digit3.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
            {
                digit4.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
            {
                digit5.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6)
            {
                digit6.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7)
            {
                digit7.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8)
            {
                digit8.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
            {
                digit9.PerformClick();
            }
            else if (e.KeyCode == Keys.Back)
            {
                backspace.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
            {
                digit9.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
            {
                digit9.PerformClick();
            }
            else if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
            {
                digit9.PerformClick();
            }
            else if (e.KeyCode == Keys.OemPeriod||e.KeyCode==Keys.Decimal)
            {
                dot.PerformClick();
            }
            else if (e.KeyCode==Keys.Space)
           {
                //MessageBox.Show(e.KeyCode.ToString());
                //SendKeys.Send('{ENTER}');
                equal.PerformClick();
            }


           


        }




        //this code is to fix the bug with the enter key not working in previous version

        private void Form1_Activated(object sender, EventArgs e)
        {
           // secondaryview.Focus();
        }

        
        //history section

        //this code is to openup the history form
        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new Form2();
            myForm.Show();
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
          //  if (e.KeyCode==Keys.Enter)
          //  {
         //   equal.Focus();

           // }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //equal.Focus();
           // secondaryview.Focus();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mainview.Text !="")
            {

                string value;
            if (deg2.Text == "DEG")
            {
                mXparser.setDegreesMode();
                Expression eh = new Expression(mainstring);
                value = eh.calculate().ToString();
                secondaryview.Text = Convert.ToString(value);
            }
            else
            {
                mXparser.setRadiansMode();
                Expression eh = new Expression(mainstring);
                value = eh.calculate().ToString();
                secondaryview.Text = Convert.ToString(value);
            }
            }
            else
            {
                secondaryview.Text = "";
            }




        }

        //app configuration storing theme data
        public int Readcon()
        {
            int result=0;
        string file = @"/config/theme.txt";
            if (File.Exists(file))
            {
               
                string str = File.ReadAllText(file);
                result = System.Convert.ToInt32(str);
            }


            return result;

        }

        public void Writecon(int val)
        {
            string file = @"/config/theme.txt";
            string text1;
            if (val == 0)
            {

            text1 = "0";
            }
            else
            {
            text1 = "1";
            }

            File.WriteAllText(file, text1);
        }
        // app configuration for storing the history data .


        public void Writehist()
        {
            string file = @"/config/history.txt";
            string text1=hist;

            File.AppendAllText(file, text1);
        }
        ///



        private void Form1_Load(object sender, EventArgs e)
        {
            int mode = Readcon();
            if (mode == 1)
            {
                darkToolStripMenuItem.PerformClick();
           }
            else
            {
                lightToolStripMenuItem.PerformClick();
                
            }

            //Readhist(); //it reads the older history .

        }
    }




}
