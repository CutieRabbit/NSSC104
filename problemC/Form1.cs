using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemC {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) {
            Random random = new Random();
            int a = random.Next(0, 2);
            int b = random.Next(0, 256);
            int c = random.Next(0, (int)Math.Pow(2, 24));
            textBox1.Text = Convert.ToString(a,2);
            textBox2.Text = Convert.ToString(b,2).PadLeft(8,'0');
            textBox3.Text = Convert.ToString(c,2).PadLeft(23,'0');
        }

        private void Button2_Click(object sender, EventArgs e) {
            string sa = textBox2.Text;
            string sb = textBox3.Text;
            string sc = textBox1.Text;
            int a = Convert.ToInt32(sa, 2);
            a -= 127;
            double d = 1;
            for(int i = 0, j = 2; i < sb.Length; i++,j*=2) {
                if(sb[i] == '1') {
                    d += (1.0 / (j*1.0));
                }
            }
            d *= Math.Pow(2, a);
            if (sc == "1") d *= -1;
            textBox4.Text = d.ToString();
        }
    }
}//done at 120min
