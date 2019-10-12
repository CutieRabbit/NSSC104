using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemB {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) {
            String[] line = textBox1.Lines;
            String[] result = new string[line.Length];
            for (int i = 0; i < line.Length; i++) {
                result[i] = convertSoundex(line[i]);
            }
            textBox2.Lines = result;
        }

        public String convertSoundex(String str) {
            String result = "";
            result += str[0];
            int[] code = { 0, 1, 2, 3, 0, 1, 2, 0, 0, 2, 2, 4, 5, 5, 0, 1, 2, 6, 2, 3, 0, 1, 0, 2, 0, 2 };
            for (int i = 1; i < str.Length; i++) {
                char c = str[i];
                int j = c - 'A';
                result += code[j];
            }
            bool[] remove = new bool[result.Length];
            for(int i = 0; i < result.Length; i++) {
                remove[i] = true;
            }
            for(int i = 1; i < result.Length; i++) {
                if(i == 1) {
                    int a = code[result[0]-'A'];
                    if(a == (result[i] - '0')) {
                        remove[i] = false;
                    }
                }
                if(result[i] == '0') {
                    remove[i] = false;
                }
                if(result[i] == result[i - 1]) {
                    remove[i] = false;
                }
            }
            string temp = "";
            temp += str[0];
            for(int i = 1; i < result.Length; i++) {
                if (remove[i] == false) continue;
                temp += result[i];
            }
            result = temp.PadRight(4, '0').Substring(0,4);
            return result;
        }
    }
}//finish at 63min