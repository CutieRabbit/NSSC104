using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace problemD {
    class Program {
        static List<List<int>> array = new List<List<int>>();
        static List<int> data = new List<int>();
        static List<double> per = new List<double>();
        static void Main(string[] args) {
            while (true) {
                Console.WriteLine("請選擇操作項目：");
                Console.WriteLine("　　　（１）輸入模型資料");
                Console.WriteLine("　　　（２）計算平均相似度");
                Console.WriteLine("　　　（３）顯示各資料相似度");
                Console.Write("請選擇：");
                int cmd = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (cmd == 1) {
                    data.Clear();
                    per.Clear();
                    array.Clear();
                    string[] title = { "　　序列＜ｘ軸＞：", "數值串列＜上限＞： ", "數值串列＜中心＞： ", "數值串列＜下限＞： " };                    
                    Console.Write("輸入模型資料，總筆數為：");
                    int n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write(title[0]);
                    for (int i = 0; i < n; i++) {
                        Console.Write(Convert.ToString(i).PadLeft(3, ' '));
                    }
                    Console.WriteLine();
                    for (int i = 0; i < 3; i++) {
                        Console.Write(title[i + 1]);
                        String line = Console.ReadLine();
                        String[] split = line.Split(' ');
                        array.Add(new List<int>());
                        for (int j = 0; j < split.Length; j++) {
                            int val = Convert.ToInt32(split[j]);
                            array[i].Add(val);
                        }
                    }
                    Console.WriteLine();
                }
                else if(cmd == 2) {
                    data.Clear();
                    per.Clear();
                    Console.Write("請輸入「資料串列」檔名：");
                    String path = Console.ReadLine();
                    Console.WriteLine("已開啟「資料串列」檔名：" + path);
                    StreamReader reader = new StreamReader(path);
                    String str = reader.ReadLine();
                    String[] array = str.Split(' ');
                    for(int i = 0; i < array.Length; i++) {
                        data.Add(Convert.ToInt32(array[i]));
                    }
                    Console.WriteLine();
                    Console.WriteLine(String.Format("平均相似度為 {0:0.000000}",reClac()));
                    Console.WriteLine();
                }else if(cmd == 3) {
                    per.Clear();
                    reClac();
                    for(int i = 0; i < per.Count; i++) {
                        Console.WriteLine("筆數" + i + " : " + per[i].ToString());
                    }
                }
                Console.Write("繼續請輸入1，否則請輸入0：");
                String con = Console.ReadLine();
                if (con == "0") break;
            }
        }
        public static double reClac() {
            double total = 0;
            for(int i = 0; i < data.Count; i++) {
                int v = data[i];
                int a = array[0][i];
                int b = array[1][i];
                int c = array[2][i];
                double e = 0;
                if (v >= a || v <= c) {
                    e = 0;
                }
                else if(v < a && v > b) {
                    int d = a - b;
                    e = 1.0 - ((v-b)*1.0) / (d*1.0);
                }else if(v == b) {
                    e = 1;
                }else if(v < b && v > c) {
                    int d = b - c;
                    e = ((v - c) * 1.0) / (d*1.0);
                }
                per.Add(e);
                total += e;
            }
            return total / (data.Count * 1.0);
        }
    }
}//finish at 163min