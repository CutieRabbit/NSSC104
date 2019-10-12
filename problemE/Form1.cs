using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemE {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        TextBox[,] table1 = new TextBox[7, 7];
        TextBox[,] table2 = new TextBox[7, 7];
        TextBox[,] kernel = new TextBox[3, 3];

        private void Button1_Click(object sender, EventArgs e) {
            for(int i = 0; i < 7; i++) {
                for(int j = 0; j < 7; j++) {
                    if (table1[i, j].Text == "") continue;
                    int[] array = { -1, 0, 1 };
                    int a = Convert.ToInt32(table1[i, j].Text);
                    for(int k = 0; k < 3; k++) {
                        for(int l = 0; l < 3; l++) {
                            int fx = i + array[k];
                            int fy = j + array[l];
                            if (fx < 0 || fx >= 7 || fy < 0 || fy >= 7) continue;
                            int value = Convert.ToInt32(table2[fx, fy].Text);
                            int kenrelValue = Convert.ToInt32(kernel[1 + array[k], 1 + array[l]].Text);
                            value += a * kenrelValue;
                            table2[fx, fy].Text = value.ToString();
                        }
                    }
                }
            }
            getMSE();
            getMAE();
            getPSNR();
        }

        private void getMSE() {
            double total = 0;
            for(int i = 0; i < 7; i++) {
                for(int j = 0; j < 7; j++) {
                    double I = Convert.ToDouble(table1[i, j].Text);
                    double O = Convert.ToDouble(table2[i, j].Text);
                    total += Math.Pow((I - O), 2);
                }
            }
            total /= 49;
            textBox108.Text = total.ToString();
        }
        private void getMAE() {
            double total = 0;
            for (int i = 0; i < 7; i++) {
                for (int j = 0; j < 7; j++) {
                    double I = Convert.ToDouble(table1[i, j].Text);
                    double O = Convert.ToDouble(table2[i, j].Text);
                    total += Math.Abs((I - O));
                }
            }
            total /= 49;
            textBox109.Text = total.ToString();
        }

        private void getPSNR() {
            double MSE = Convert.ToDouble(textBox108.Text);
            textBox110.Text = (10*Math.Log10((255 * 255 * 1.0) / (MSE))).ToString();
        }

        private void Form1_Load(object sender, EventArgs e) {
            for(int i = 0; i < 7; i++) {
                for(int j = 0; j < 7; j++) {
                    TextBox textbox = (TextBox)this.Controls["textBox" + (i * 7 + j + 1)];
                    table1[i, j] = textbox;
                }
            }
            for (int i = 0; i < 7; i++) {
                for (int j = 0; j < 7; j++) {
                    TextBox textbox = (TextBox)this.Controls["textBox" + (i * 7 + j + 59)];
                    table2[i, j] = textbox;
                }
            }
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    TextBox textbox = (TextBox)this.Controls["textBox" + (i * 3 + j + 50)];
                    kernel[i, j] = textbox;
                }
            }
        }
    }
}//finish at 101min
