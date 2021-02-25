using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
        public void clearhist()
        {
            string file = @"/config/history.txt";
            string text1 = "";

            File.WriteAllText(file, text1);
        }


        string temp="";
        private void Form2_Shown(object sender, EventArgs e)
        {
            
            if (form1darkmode == 1)
            {
                this.BackColor = Color.Black;
                listBox1.BackColor = Color.Black;
                listBox1.ForeColor = SystemColors.Control;
            }

            for(int i = 0; i < historystr.Length; i++)
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            historystr = "";
            Form1.hist = "";
            clearhist();
            
        }

        private void options_fr2_Click(object sender, EventArgs e)
        {
            //code for contextmenu access by left click
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            contextMenuStrip1.Show(ptLowerLeft);
            ////
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Readhist();
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            
        }
    }
}
