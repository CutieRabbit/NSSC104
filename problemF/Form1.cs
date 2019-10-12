using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemF {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.txt)|*.txt";
            ofd.ShowDialog();
            String path = ofd.FileName;
            System.IO.StreamReader sr = new System.IO.StreamReader(path);
            string line;
            string text = "";
            while ((line = sr.ReadLine()) != null) {
                text += line + Environment.NewLine;
            }
            richTextBox1.Text = text;
        }

        private void Button2_Click(object sender, EventArgs e) {
            String search = textBox1.Text;
            String text = richTextBox1.Text;
            int count = 0;
            for(int i = 0; i < text.Length - search.Length; i++) {
                string str = text.Substring(i, search.Length);
                if (str != search) continue;
                richTextBox1.Select(i, search.Length);
                richTextBox1.SelectionBackColor = Color.Yellow;
                count++;
            }
            label3.Text = Convert.ToString(count);
        }
    }
}//finish at 77min