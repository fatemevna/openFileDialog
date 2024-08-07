using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadingTextFiles
{
    public partial class Form1 : Form
    {
        int result;
        int operand1;
       int operand2;
        
        string firstLine,secondLine,thirdLine;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string pathToFile = "";//to save the location of the selected object
                                   // private void openToolStripMenuItem_Click(object sender, EventArgs e)
                                   //{
            //string text = "";
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(theDialog.FileName.ToString());
                pathToFile = theDialog.FileName;//doesn't need .tostring because .filename returns a string// saves the location of the selected object

            }

            if (File.Exists(pathToFile))// only executes if the file at pathtofile exists//you need to add the using System.IO reference at the top of te code to use this
            {


                //method1
                 firstLine = File.ReadAllLines(pathToFile).Skip(0).Take(1).First();//selects first line of the file
                 secondLine = File.ReadAllLines(pathToFile).Skip(1).Take(1).First();
                 thirdLine = File.ReadAllLines(pathToFile).Skip(2).Take(1).First();
                 operand1 = Int32.Parse(firstLine);
                 operand2 = Int32.Parse(secondLine);
                if (thirdLine == "+")
                {
                    result = operand1 + operand2;
                }
                else if (thirdLine == "-")
                {
                    result = operand1 - operand2;
                }
                else if (thirdLine == "*")
                {
                    result = operand1 * operand2;
                }
                else if (thirdLine == "/")
                {
                    result = operand1 / operand2;
                }

            }
            tbWrite.Text = firstLine+" "+secondLine+"\n" + operand1 + " " + thirdLine + " " + operand2 + " " + "=" + " " + result;
        }
    
    }
}
