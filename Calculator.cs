using org.mariuszgromada.math.mxparser; //IMPORTS MXPARSER PACKAGE
using System;
using System.Drawing;
using System.IO; //REQUIRED FOR FILE IMPORT , EXPORT
using System.Windows.Forms;
namespace AndroCalculator
{
    public partial class Calculator : Form
    {
        public static int darkmode = 0; // 0-> LIGHT MODE , 1-> DARK MODE | IT IS A PUBLIC STATIC INT SO THAT IT CAN BE ACCESSED FROM THE FORM2(HISTORY)
        public static string hist = ""; //STORES THE HISTORY INTO STRING .

        public Calculator()
        {
            InitializeComponent();

        }

        private void deg1_Click(object sender, EventArgs e)
        {
            //IT CHANGES THE TEXT ON THE DEGREE AND RADIAN SWITCHING BUTTON
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
            equal.Focus();
        }

        private void deg2_Click(object sender, EventArgs e)
        {
            //IT CHANGES THE TEXT ON THE DEGREE AND RADIAN SWITCHING BUTTON
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
            equal.Focus();

        }
        int countstate = 1;//1-> NORMAL , 0-> INVERTED OPERATIONS MODE 
        private void inv_Click(object sender, EventArgs e)
        {
            if (countstate == 1)
            {
                //CHANGES THE BUTTON TEXT IF INVERT OPERATION SELECTED .
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



            equal.Focus();
        }











        //BELLOW CODES HELPS TO ENABLE THE MOUSE DRAG ON THE FORM , IF THE FORM IS IN BORDERLESS CONDITION .
        //THIS CODES ARE MOSTLY NOT REQUIRED IF THE FORM HAS BORDER ENABLED .
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

        //BELOW CODES ARE FOR SHOWING MESSAGEBOXES ON CLICK EVENT IN CONTEXT MENU


        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please send us your Feedback at satyajit.edu@outlook.com", "Send Feedback");
            equal.Focus();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Go to the https://github.com/SATYAJIT1910/AndroCalculator", "Help");
            equal.Focus();
        }
        //BELOW CODES ARE FOR CHANGING THE COLORS OF THE FORM ELEMENTS BASED ON THE THEME SELECTED .

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
            Writecon(darkmode); //THIS CODE WRITES THE VALUE OF DARKMODE ON/OFF TO A FILE IN C:\CONFIG OF USER , SO THAT THE NEXT TIME THE PROGRAM OPENS IT CAN KNOW LAST TIME SELECTED THEME .
            equal.Focus();
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
            Writecon(darkmode); //WRITES THE VALUE OF THEMEMODE TO C:\CONFIG
            equal.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close(); //IT CLOSED THE APPLICATION ON EXIT CLICK
        }

        //BELOW CODES ARE FOR MAINLY BACKEND PROCESSING .
        /* ON EACH BUTTON CLICK THE BUTTON SPECIFIC VALUE ADDED TO A STRING NAMED "mainstring"
         * AFTER THAT WHEN THE USER CLICK ON THE EQUAL SIGN , IT CALCULATES THE MATHMATICAL VALUE OF THE STRING USING THE MXPARSER PACKAGE .
         * 
         * 
         * EQUAL.FOCUS() ADDED TO THE EVERY BUTTON CLICK TO SOLVE THE ISSUE OF ENTER BUTTON , GETTING DEFOCUS AND NOT PERFORMING THE EQUAL OPERATION .
         * 
         */
        string mainstring = ""; //THIS STRING STORES THE USER INPUT

        private void digit1_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '1';
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void digit2_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '2';
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void digit3_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '3';
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void digit4_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '4';
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void digit5_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '5';
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void digit6_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '6';
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void digit7_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '7';
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void digit8_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '8';
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void digit9_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '9';
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void digit0_Click(object sender, EventArgs e)
        {
            mainstring = mainstring + '0';
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void plus_Click(object sender, EventArgs e)
        {


            mainstring = mainstring + '+';

            mainview.Text = mainstring;
            equal.Focus();

        }

        private void minus_Click(object sender, EventArgs e)
        {



            mainstring = mainstring + '-';

            mainview.Text = mainstring;
            equal.Focus();
        }

        private void multiply_Click(object sender, EventArgs e)
        {


            mainstring = mainstring + '*';

            mainview.Text = mainstring;
            equal.Focus();
        }

        private void divide_Click(object sender, EventArgs e)
        {

            mainstring = mainstring + '/';

            mainview.Text = mainstring;
            equal.Focus();
        }

        private void equal_Click(object sender, EventArgs e)
        {



            string value;
            if (deg2.Text == "DEG")
            {

                mXparser.setDegreesMode(); //IT SETS THE MXPARSER TO DO DEGREE OPERATIONS
                Expression eh = new Expression(mainstring); //MXPARSER CODE
                value = eh.calculate().ToString(); //MXPARSER CODE
                mainview.Text = Convert.ToString(value);
            }
            else
            {
                mXparser.setRadiansMode(); //IT SETS THE MXPARSER TO DO RADIAN OPERATIONS
                Expression eh = new Expression(mainstring); //MXPARSER CODE
                value = eh.calculate().ToString(); //MXPARSER CODE
                mainview.Text = Convert.ToString(value);
            }




            //BELOW CODES USED FOR STORING THE HISTORY

            if (value != "NaN") //SKIPS THE RESULT WITH NaN value 
            {
                hist = mainstring + "=" + value + '\n'; //MAKES THE STRING FOR HISTORY .
                Writehist(); //WRITES THE STRING TO THE C:\CONFIG\ FOLDER.
                hist = ""; //CLEAR THE HISTORY STRING.

            }



            //
            secondaryview.Text = ""; //CLEARS THE SECONDARY CLICK
            backspace.Text = "C"; //CHNAGES THE BACKSPACE TEXT TO PERFORM CLEAR ALL OPERATION


            mainstring = value;
            equal.Focus();




        }



        private void backspace_Click(object sender, EventArgs e)
        {

            if (backspace.Text != "C")
            {
                //CODE FOR BACKSPACE
                int textlength = mainview.Text.Length;
                if (textlength > 0)
                {
                    mainview.Text = mainview.Text.Substring(0, textlength - 1);

                }
                secondaryview.SelectionStart = mainview.Text.Length;
                secondaryview.SelectionLength = 0;

                mainstring = mainview.Text;
            }
            else
            {
                mainstring = "";
                mainview.Text = "";
                secondaryview.Text = "";
                backspace.Text = "⌫";

            }
            equal.Focus();
        }





        private void options_Click(object sender, EventArgs e)
        {
            //THIS CODE HELPS TO ACCESS THE CONTEXT MENU USING LEFT CLICK .
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip1.Show(ptLowerLeft);
            ////
            ///
            equal.Focus();
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
            equal.Focus();

        }


        private void closepar_Click(object sender, EventArgs e)
        {

            mainstring += ")";
            mainview.Text = mainstring;
            equal.Focus();
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
            equal.Focus();

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
            equal.Focus();

        }

        private void factorial_Click(object sender, EventArgs e)
        {
            mainstring += "!";
            mainview.Text = mainstring;
            equal.Focus();

        }

        private void dot_Click(object sender, EventArgs e)
        {
            mainstring += ".";
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void exp_Click(object sender, EventArgs e)
        {
            mainstring += "e";
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void pie_Click(object sender, EventArgs e)
        {
            mainstring += "pi";
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void root_Click(object sender, EventArgs e)
        {
            mainstring += "^";
            mainview.Text = mainstring;
            equal.Focus();
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
            equal.Focus();
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
            equal.Focus();
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
            equal.Focus();
        }

        private void percentage_Click(object sender, EventArgs e)
        {
            mainstring += "%";
            mainview.Text = mainstring;
            equal.Focus();
        }

        private void openpar_Click(object sender, EventArgs e)
        {
            mainstring += "(";
            mainview.Text = mainstring;
            equal.Focus();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // MessageBox.Show(e.KeyCode.ToString()); -> THIS CODE USED TO CHECK/TEST THE KEYCODE OF SPECIFIC KEY


            //BELOW CODES ARE USED TO ENABLE THE KEYBROAD INPUT

            if (e.KeyCode == Keys.Add || e.Shift && e.KeyCode == Keys.Oemplus)
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
            else if (e.Control && e.Shift && e.KeyCode == Keys.I) //THIS CODE IS FOR CREATING SHORTCUT CTRL+SHIFT+I ->INVERSE OPERATION
            {
                inv.PerformClick();

            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.R) //THIS CODE IS FOR CREATING SHORTCUT CTRL+SHIFT+R ->DEG/RAD OPERATION
            {
                deg1.PerformClick();

            }
            else if (e.Shift && e.KeyCode == Keys.D5)
            {
                percentage.PerformClick();
            }
            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemQuestion)
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
            else if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
            {
                dot.PerformClick();
            }
            else if (e.KeyCode == Keys.Space)
            {
                equal.PerformClick();
            }





        }





        //BELOW CODES OPEN UP THE HISTORY FORM .
        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new History();
            myForm.Show();
            equal.Focus();
        }

        //THIS CODE IS USED FOR CONTINUOUS EVALUTION OF THE RESULT .

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (mainview.Text != "")
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
            equal.Focus();



        }

        //THIS FUNCTION READS THE THEME VALUE .
        public int Readcon()
        {
            int result = 0;
            string file = @"/config/theme.txt";
            if (File.Exists(file))
            {

                string str = File.ReadAllText(file);
                result = System.Convert.ToInt32(str);
            }


            return result;

        }
        //THIS CODE WRITES THE THEME VALUE
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
        // THIS CODE WRITES THE HISTORY DATA


        public void Writehist()
        {
            string file = @"/config/history.txt";
            string text1 = hist;

            File.AppendAllText(file, text1);
        }


        //THIS CODES USED TO FETCH THE THEME STATUS ON FORM LOAD .
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


        }
    }




}
