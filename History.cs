using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AndroCalculator
{
    public partial class History : Form
    {

        public History()
        {
            InitializeComponent();
        }
        //ENABLES THE MOUSE DRAG FOR BORDERLESS FORMS .
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

        //THIS CODES FETCHES THE DARKMODE STATUS FROM THE FORM1

        int form1darkmode = Calculator.darkmode;
        string historystr = "";

        public void Readhist()
        {

            string file = @"/config/history.txt";
            if (File.Exists(file))
            {

                string str = File.ReadAllText(file);
                historystr = str;
            }




        }

        //THIS CODE CLEARS THE HISTORY
        public void clearhist()
        {
            string file = @"/config/history.txt";
            string text1 = "";

            File.WriteAllText(file, text1);
        }


        string temp = "";


        //THIS CODES LOADS FROM THE HISTORY FROM THE FILE AND SHOW IT 
        private void Form2_Shown(object sender, EventArgs e)
        {

            if (form1darkmode == 1)
            {
                this.BackColor = Color.Black;
                listBox1.BackColor = Color.Black;
                listBox1.ForeColor = SystemColors.Control;
            }
            //BREAKS THE STRING INTO THE SUBSTRING AND ADD IT TO THE LISTBOX
            for (int i = 0; i < historystr.Length; i++)
            {
                if (historystr[i] != '\n')
                {
                    temp += historystr[i];
                }
                else
                {
                    listBox1.Items.Add(temp);

                    temp = "";

                }
            }








        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            historystr = "";
            Calculator.hist = "";
            clearhist();

        }

        private void options_fr2_Click(object sender, EventArgs e)
        {
            //ACCESS THE CONTEXT MENU BY LEFT CLICK
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip1.Show(ptLowerLeft);
            ////
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Readhist(); //READS THE HISTORY ON THE FORM LOAD .
        }
    }
}
