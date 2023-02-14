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

namespace ukol1txt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;   //xd
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();       
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                string line = "";
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                while (!sr.EndOfStream)
                {
                    listBox1.Items.Add(sr.ReadLine());
                }
                
                sr.Close();

                int soucet = 0, liche = 0, sude = 0;
                bool jecislo = false;
                foreach (string s in listBox1.Items)
                {
                    if(s != String.Empty)
                    {                       
                        foreach(char c in s)
                        {
                            jecislo = false;
                            if (char.IsDigit(c))
                            {
                                if (c % 2 == 0) sude += Convert.ToInt32(c)-48;
                                else liche += Convert.ToInt32(c)-48;
                                line += c;
                                jecislo = true;
                            }                                                   
                        }
                        if (jecislo)soucet += Convert.ToInt32(line);                        
                        line = String.Empty;
                    }
                }
                StreamWriter streamWriter = new StreamWriter(ofd.FileName,true);
                streamWriter.WriteLine(String.Empty);
                streamWriter.WriteLine(soucet);
                streamWriter.WriteLine(sude);
                streamWriter.WriteLine(liche);
                streamWriter.Close();

                StreamReader sr2 = new StreamReader(ofd.FileName);                
                while (!sr2.EndOfStream)
                {
                    listBox2.Items.Add(sr2.ReadLine());
                }
                sr2.Close();
            }
        }
    }
}
