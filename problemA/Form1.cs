using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSSC104 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        Label[,] check1 = new Label[4,4];
        Label[,] check2 = new Label[4,4];
        Label[,] check3 = new Label[4,4];
        Dictionary<Label, SearchData> searchTable = new Dictionary<Label, SearchData>();
        Label onClickLabel = null;

        private void Form1_Load(object sender, EventArgs e) {
            //註冊label事件
            for (int i = 0; i < 16; i++) {
                Label label = (Label)this.Controls["label" + (i + 1)];
                label.Tag = (i + 1) / 4 + "," + (i + 1) % 4;
                label.MouseClick += Label_MouseClick;
                searchTable[label] = new SearchData();
            }
            //註冊按紐事件
            for (int i = 0; i < 4; i++) {
                Button button = (Button)this.Controls["Button" + (i + 1)];
                button.Click += Button_Click;
            }
            //橫向
            for (int i = 0; i < 4; i++) {
                for(int j = 0; j < 4; j++) {
                    Label label = (Label)this.Controls["label" + (i * 4 + j + 1)];
                    check1[i, j] = label;
                    SearchData data = searchTable[label];
                    data.a = i;
                    searchTable[label] = data;
                }
            }
            //直向
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    Label label = (Label)this.Controls["label" + (i + j * 4 + 1)];
                    check2[i, j] = label;
                    SearchData data = searchTable[label];
                    data.b = i;
                    searchTable[label] = data;
                }
            }
            //方格
            int[] array = { 1, 2, 5, 6, 3, 4, 7, 8, 9, 10, 13, 14, 11, 12, 15, 16};
            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    Label label = (Label)this.Controls["label" + array[(i*4+j)]];
                    check3[i, j] = label;
                    SearchData data = searchTable[label];
                    data.c = i;
                    searchTable[label] = data;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e) {
            if (onClickLabel == null) return;
            Button button = (Button)sender;
            onClickLabel.Text = button.Text;
        }

        private void Label_MouseClick(object sender, MouseEventArgs e) {
            Label label = (Label) sender;
            label17.Text = label.Tag.ToString();
            onClickLabel = label;
        }

        private void Button5_Click(object sender, EventArgs e) { 
            //橫向
            for (int i = 0; i < 4; i++) {
                HashSet<int> hash = new HashSet<int>();
                for (int j = 0; j < 4; j++) {
                    int a = Convert.ToInt32(check1[i, j].Text);
                    hash.Add(a);
                }
                if(hash.Count != 4) {
                    label18.Text = "錯誤";
                    return;
                }
            }
            //直向
            for (int i = 0; i < 4; i++) {
                HashSet<int> hash = new HashSet<int>();
                for (int j = 0; j < 4; j++) {
                    int a = Convert.ToInt32(check2[i, j].Text);
                    hash.Add(a);
                }
                if (hash.Count != 4) {
                    label18.Text = "錯誤";
                    return;
                }
            }
            //方格
            for (int i = 0; i < 4; i++) {
                HashSet<int> hash = new HashSet<int>();
                for (int j = 0; j < 4; j++) {
                    int a = Convert.ToInt32(check3[i, j].Text);
                    hash.Add(a);
                }
                if (hash.Count != 4) {
                    label18.Text = "錯誤";
                    return;
                }
            }
            label18.Text = "正確";
            return;
        }

        private void Button6_Click(object sender, EventArgs e) {
            Dictionary<Label, String> value = new Dictionary<Label, String>();
            for(int  i = 1; i <= 16; i++) {
                Label label = (Label)this.Controls["label" + i];
                value.Add(label, label.Text);
            }
            for (int r = 1; r <= 16; r++) {
                Label label = (Label)this.Controls["label" + r];
                SearchData data = searchTable[label];
                int a = data.a;
                int b = data.b;
                int c = data.c;
                Console.WriteLine(r + "," + a + b + c);
                List<String> list = new List<String>();
                for(int i = 1; i <= 4; i++) {
                    list.Add(i.ToString());
                }
                for (int i = 0; i < 4; i++) {
                    Label subLabel = check1[a, i];
                    list.Remove(value[subLabel]);
                }
                for (int i = 0; i < 4; i++) {
                    Label subLabel = check2[b, i];
                    list.Remove(value[subLabel]);
                }
                for (int i = 0; i < 4; i++) {
                    Label subLabel = check3[c, i];
                    list.Remove(value[subLabel]);
                }
                String hintText = "";
                for(int i = 0; i < list.Count; i++) {
                    hintText += list[i];
                    if(i != list.Count - 1) {
                        hintText += ",";
                    }
                }
                if (label.Text == "") {
                    label.Text = hintText;
                }
            }
        }
    }
    public class SearchData {
        public int a, b, c;
    }
}//finish at 37min