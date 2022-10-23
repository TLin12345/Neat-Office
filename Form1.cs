using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

namespace NeatOffice
{
    public partial class Form1 : Form
    {
        object dateAndTime = DateTime.Now;
        private GraphAlgorithms g;
        public Form1()
        {
            InitializeComponent();
            g = new GraphAlgorithms(pBar, pLabel, statusStrip2);
        }
        //
        //Functionality of Calculator
        //
        private void digit0_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "0";
            else
                textBox1.Text += "0";
        }

        private void digit1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "1";
            else
                textBox1.Text += "1";
        }

        private void digit2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "2";
            else
                textBox1.Text += "2";
        }

        private void digit3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "3";
            else
                textBox1.Text += "3";
        }

        private void digit4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "4";
            else
                textBox1.Text += "4";
        }

        private void digit5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "5";
            else
                textBox1.Text += "5";
        }

        private void digit6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "6";
            else
                textBox1.Text += "6";
        }

        private void digit7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "7";
            else
                textBox1.Text += "7";
        }

        private void digit8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "8";
            else
                textBox1.Text += "8";
        }

        private void digit9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
                textBox1.Text = "9";
            else
                textBox1.Text += "9";
        }

        private void plus_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void minus_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void division_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void decimalPoint_Click(object sender, EventArgs e)
        {   
            textBox1.Text += ".";
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            string lastLine = "";
            var res = cal(textBox1.Text);

            if (textBox1.Lines.Any())//check if each line of textbox has any elements
            {
                lastLine = textBox1.Lines[textBox1.Lines.Length - 1];//get the newest line text of textbox
            }
            
            if (lastLine.Contains("^"))// if text contains "^" character
            {
                string[] num = lastLine.Split('^');//split x and y
                try
                {
                    double x = double.Parse(num[0]);
                    double y = double.Parse(num[1]);
                    res = Math.Pow(x, y);
                }
                catch
                {
                    res = "NaN";
                }
            }
            else // if text not contain "^" character than do the rest operation
            {
                res = cal(lastLine);
            }

            textBox1.Text += " = " + "\r\n" + res.ToString();
        }

        private object cal(string text)
        {
            DataTable dt = new DataTable();
            var v = new object();
            try
            {
                v = dt.Compute(text, "");
            }
            catch (Exception e)
            {
                v = "NaN";
            }

            return v;
        }
        
        private bool isNumber(string word)//check if the user input numerical value 
        {
            try
            {
                double.Parse(word);//convert string represent numberical value into a floating number
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private void negate_Click(object sender, EventArgs e)
        {
            string lastLine = "";
            if (textBox1.Lines.Any())
            {
                lastLine = textBox1.Lines[textBox1.Lines.Length - 1];
            }
            if (isNumber(lastLine))
            {
                var res = (-1) * double.Parse(lastLine);
                textBox1.Text += "\r\n" + res.ToString();
            }
        }

        private void square_Click(object sender, EventArgs e)
        {
            string lastLine = "";
            if (textBox1.Lines.Any())
            {
                lastLine = textBox1.Lines[textBox1.Lines.Length - 1];
            }
            if (isNumber(lastLine))
            {
                var res = Math.Pow(double.Parse(lastLine), 2);
                var lines = textBox1.Lines;
                lines[lines.Length - 1] =  lastLine + "^2";
                textBox1.Lines = lines;
                textBox1.Text += " = " + "\r\n" + res.ToString();
            }
        }

        private void squareRoot_Click(object sender, EventArgs e)
        {
            string lastLine = "";
            if (textBox1.Lines.Any())
            {
                lastLine = textBox1.Lines[textBox1.Lines.Length - 1];
            }
            if (isNumber(lastLine))
            {
                var res = Math.Sqrt(double.Parse(lastLine));
                var lines = textBox1.Lines;
                lines[lines.Length - 1] = "sqrt(" + lastLine + ")";
                textBox1.Lines = lines;
                textBox1.Text += " = " + "\r\n" + res.ToString();
            }
        }

        private void oneOverX_Click(object sender, EventArgs e)
        {
            string lastLine = "";
            if (textBox1.Lines.Any())
            {
                lastLine = textBox1.Lines[textBox1.Lines.Length - 1];
            }
            if (isNumber(lastLine))
            {
                var res = 1 / double.Parse(lastLine);
                var lines = textBox1.Lines;
                lines[lines.Length - 1] = "1/" + lastLine;
                textBox1.Lines = lines;
                textBox1.Text += " = " + "\r\n" + res.ToString();
            }
        }

        private void percent_Click(object sender, EventArgs e)
        {
            string lastLine = "";
            if (textBox1.Lines.Any())
            {
                lastLine = textBox1.Lines[textBox1.Lines.Length - 1];
            }
            if (isNumber(lastLine))
            {
                var res = double.Parse(lastLine) / 100;
                var lines = textBox1.Lines;
                lines[lines.Length - 1] = "%" + lastLine;
                textBox1.Lines = lines;
                textBox1.Text += " = " + "\r\n" + res.ToString();
            }
        }

        private void log_Click(object sender, EventArgs e)
        {
            string lastLine = "";
            if (textBox1.Lines.Any())
            {
                lastLine = textBox1.Lines[textBox1.Lines.Length - 1];
            }
            if (isNumber(lastLine))
            {
                var res = Math.Log10(double.Parse(lastLine));
                var lines = textBox1.Lines;
                lines[lines.Length - 1] = "log(" + lastLine + ")";
                textBox1.Lines = lines;
                textBox1.Text += " = " + "\r\n" + res.ToString();
            }
        }

        private void xPowerY_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
                return;
            textBox1.Text += "^";
        }

        private void sin_Click(object sender, EventArgs e)
        {
            string lastLine = "";
            if (textBox1.Lines.Any())
            {
                lastLine = textBox1.Lines[textBox1.Lines.Length - 1];
            }
            if (isNumber(lastLine))
            {
                var res = Math.Sin(double.Parse(lastLine));
                var lines = textBox1.Lines;
                lines[lines.Length - 1] = "sin(" + lastLine + ")";
                textBox1.Lines = lines;
                textBox1.Text += " = " + "\r\n" + res.ToString();
            }
        }

        private void cos_Click(object sender, EventArgs e)
        {
            string lastLine = "";
            if (textBox1.Lines.Any())
            {
                lastLine = textBox1.Lines[textBox1.Lines.Length - 1];
            }
            if (isNumber(lastLine))
            {
                var res = Math.Cos(double.Parse(lastLine));
                var lines = textBox1.Lines;
                lines[lines.Length - 1] = "cos(" + lastLine + ")";
                textBox1.Lines = lines;
                textBox1.Text += " = " + "\r\n" + res.ToString();
            }
        }

        private void tan_Click(object sender, EventArgs e)
        {
            string lastLine = "";
            if (textBox1.Lines.Any())
            {
                lastLine = textBox1.Lines[textBox1.Lines.Length - 1];
            }
            if (isNumber(lastLine))
            {
                var res = Math.Tan(double.Parse(lastLine));
                var lines = textBox1.Lines;
                lines[lines.Length - 1] = "tan(" + lastLine + ")";
                textBox1.Lines = lines;
                textBox1.Text += " = " + "\r\n" + res.ToString();
            }
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);//remove the most recently input
            if (textBox1.Text == "")
                textBox1.Text = "0";
        }

        private void CE_Click(object sender, EventArgs e)
        {
            List<String> lines = new List<String>(textBox1.Lines);
            string lastLine = "";
            if (lines.Any())
            {
                lastLine = lines[lines.Count - 1];
            }
            //using regeression expression to split a string by multiple delimiters by "+,-,*,/,^,%"
            //source:https://stackoverflow.com/questions/4680128/split-a-string-with-delimiters-but-keep-the-delimiters-in-the-result-in-c-sharp
            List<String> words = new List<String>(Regex.Split(lastLine, @"(?<=[-+*/^%=])"));
            words.RemoveAt(words.Count - 1);//remove last numerical value
            words.Add("0");//replace by 0 
            lines.RemoveAt(lines.Count - 1);
            lines.Add(String.Concat(words.ToArray()));
            textBox1.Lines = lines.ToArray();
        }

        private void C_Click(object sender, EventArgs e)
        {
            if (textBox1.Lines.Length > 1)//if current lines length larger than 1
                //Souce:https://social.msdn.microsoft.com/Forums/en-US/29118aad-dfec-4453-a653-18fa51d63252/how-to-clear-the-last-line-in-multiline-textbox?forum=vblanguage
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.LastIndexOf(Environment.NewLine));//remove the last line of display
            else
                textBox1.Text = "0";
        }

        private void clearCalculatorHistory_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void clearCalculatorHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void saveCalculatorHistory_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
        }

        private void saveCalculatorHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
        }

        private void calculatorHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileText = File.ReadAllText(openFileDialog1.FileName);
                textBox1.Text = fileText + "\r\n";
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
                printDocument1.Print();
        }
        //Print out calculator history
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font f = new Font("Arial", 10, FontStyle.Regular);//setting font 
            Brush b = new SolidBrush(Color.Black);//setting brush color
            PointF p = new PointF(10, 10);//initialize the dimensions

            e.Graphics.DrawString(textBox1.Text, f, b, p);
        }
        
        private void printCalculatorHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
                printDocument1.Print();
        }
        //
        //Functionality of Day Counter
        //
        private void fromDate_ValueChanged(object sender, EventArgs e)
        {
            if (((DateTimePicker)sender).ContainsFocus)
            {
                DateTime to = toDate.Value;
                DateTime from = fromDate.Value;
                numericUpDown1.Value = to.Subtract(from).Days;
                numericUpDown1.Value = numericUpDown1.Value + (decimal)1;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {   
            if (numericUpDown1.ContainsFocus)
            {
                if (numericUpDown1.Value > 0)
                    toDate.Value = fromDate.Value.AddDays((double)numericUpDown1.Value);
                else if (numericUpDown1.Value < 0)
                    fromDate.Value = toDate.Value.AddDays(-1 * (double)numericUpDown1.Value);
                else
                    toDate.Value = fromDate.Value;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateAndTime = DateTime.Now;
            toolStripStatusLabel1.Text = "Good day! Today is " + dateAndTime.ToString();
        }
        //
        //Change the background color of Day Counter, Calculator, and Graph Operator
        //
        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                splitContainer2.Panel1.BackColor = colorDialog1.Color;
                tableLayoutPanel1.BackColor = colorDialog1.Color;
            }
        }

        private void dayCounterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
                splitContainer2.Panel2.BackColor = colorDialog1.Color;
        }

        private void graphSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
                splitContainer1.Panel2.BackColor = colorDialog1.Color;
        }

        private void calculatorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                splitContainer2.Panel1.BackColor = colorDialog1.Color;
                tableLayoutPanel1.BackColor = colorDialog1.Color;
            }
        }

        private void dayCounterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
                splitContainer2.Panel2.BackColor = colorDialog1.Color;
        }

        private void graphSectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
                splitContainer1.Panel2.BackColor = colorDialog1.Color;
        }
        //
        //Functionality of Graph Operator
        //
        private void openTXT_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                g.ReadGraphFromTXTFile(openFileDialog1.FileName);
                listBox1.Items.Add(openFileDialog1.FileName);
            }
        }

        private void graphMatrictxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                g.ReadGraphFromTXTFile(openFileDialog1.FileName);
                listBox1.Items.Add(openFileDialog1.FileName);
            }
        }

        private void openCSV_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                g.ReadGraphFromCSVFile(openFileDialog2.FileName);
                listBox1.Items.Add(openFileDialog2.FileName);
            }
        }

        private void graphMatrixcsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK)
            {
                g.ReadGraphFromCSVFile(openFileDialog2.FileName);
                listBox1.Items.Add(openFileDialog2.FileName);
            }
        }

        private void openMultiple_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog3.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog3.FileNames)
                {
                    if (Path.GetExtension(fileName) == ".txt")
                    {
                        g.ReadGraphFromTXTFile(fileName);
                        listBox1.Items.Add(fileName);
                    }
                    if (Path.GetExtension(fileName) == ".csv")
                    {
                        g.ReadGraphFromCSVFile(fileName);
                        listBox1.Items.Add(fileName);
                    }
                }  
            }
        }

        private void multipleGraphsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog3.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog3.FileNames)
                {
                    if (Path.GetExtension(fileName) == ".txt")
                    {
                        g.ReadGraphFromTXTFile(fileName);
                        listBox1.Items.Add(fileName);
                    }
                    if (Path.GetExtension(fileName) == ".csv")
                    {
                        g.ReadGraphFromCSVFile(fileName);
                        listBox1.Items.Add(fileName);
                    }
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void deleteAll_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
 
        private void getMst_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                g.GetMST(listBox1.SelectedItem.ToString());
                listBox2.Items.Add("MST: " + listBox1.SelectedItem.ToString());
            }
            
        }

        private void getShortest_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                g.Dijkstra(listBox1.SelectedItem.ToString());
                listBox2.Items.Add("Shortest Paths:  " + listBox1.SelectedItem.ToString());
            }
        }

        private void saveResult_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (listBox2.SelectedItems.Count > 0)
            {
                if (result == DialogResult.OK)
                {
                    var fileName = listBox2.SelectedItem.ToString();

                    if (fileName.Contains("MST:"))
                    {
                        fileName = fileName.Remove(0, 5);
                        g.WriteMSTSolutionTo(saveFileDialog1.FileName, fileName);
                        Console.WriteLine("File Saved!");
                        listBox2.Items.Remove(listBox2.SelectedItem);
                    }
                    if (fileName.Contains("Shortest Paths:"))
                    {
                        fileName = fileName.Remove(0, 17);
                        g.WriteSSSPSolutionTo(saveFileDialog1.FileName, fileName);
                        Console.WriteLine("File Saved!");
                        listBox2.Items.Remove(listBox2.SelectedItem);
                    }
                }
            }

        }

        private void printResult_Click(object sender, EventArgs e)
        {
            DialogResult result = printDialog2.ShowDialog();
            if (listBox2.SelectedItems.Count > 0)
            {
                if (result == DialogResult.OK)
                {
                    printDocument2.Print();
                }  
            }
        }
        //print out the results of completed graph operation
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font f = new Font("Arial", 10, FontStyle.Regular);
            Brush b = new SolidBrush(Color.Black);
            PointF p = new PointF(10, 10);

            var fileText = "";
            var fileName = listBox2.SelectedItem.ToString();

            if (fileName.Contains("MST:"))//print our result of MST
            {
                fileName = fileName.Remove(0, 5);
                g.WriteMSTSolutionTo("PrintGraph.txt", fileName);

                fileText = File.ReadAllText("PrintGraph.txt");

                Console.WriteLine("File Read!");
            }
            if (fileName.Contains("Shortest Paths:"))//print out result of SSSP
            {
                fileName = fileName.Remove(0, 17);
                g.WriteSSSPSolutionTo("PrintGraph.txt", fileName);

                fileText = File.ReadAllText("PrintGraph.txt"); 

                Console.WriteLine("File Read!");
            }
            e.Graphics.DrawString(fileText, f, b, p);
        }
        
        private void saveMSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count > 0)
            {
                var fileName = listBox2.SelectedItem.ToString();

                if (fileName.Contains("MST:") && saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = fileName.Remove(0, 5);
                    g.WriteMSTSolutionTo(saveFileDialog1.FileName, fileName);
                    Console.WriteLine("File Saved!");
                    listBox2.Items.Remove(listBox2.SelectedItem);
                }
            }
        }

        private void saveShortestPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count > 0)
            {
                var fileName = listBox2.SelectedItem.ToString();

                if (fileName.Contains("Shortest Paths:") && saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = fileName.Remove(0, 17);
                    g.WriteSSSPSolutionTo(saveFileDialog1.FileName, fileName);
                    Console.WriteLine("File Saved!");
                    listBox2.Items.Remove(listBox2.SelectedItem);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //
        //Modify Calculator Display Text Font
        //
        private void modifyCalculatorDisplayFontToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            DialogResult result = fontDialog1.ShowDialog();     
            if (result == DialogResult.OK)
                textBox1.Font = fontDialog1.Font;
        }
    }
}
