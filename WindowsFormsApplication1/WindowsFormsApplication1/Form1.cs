using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Programa feito por Mateus Amaral do Colégio Nave, Turma 2003.

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToDec();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ToHexa();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] v = INum(textBox1.Text, textBox2.Text);
            textBox1.Text = BinAdd(v[0], v[1]);
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] v = INum(textBox1.Text, textBox2.Text);
            textBox1.Text = BinMul(textBox1.Text, textBox2.Text);
            textBox2.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string[] v = INum(textBox1.Text, textBox2.Text);
            textBox1.Text = BinSub(v[0], v[1]);
            textBox2.Text = "";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string[] v = INum(textBox1.Text, textBox2.Text);
            textBox1.Text = BinDiv(v[0], v[1]);
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {}

        private void Pressed(object sender, KeyPressEventArgs e)
        {
            string valid = "01";
            e.Handled = (valid.IndexOf(e.KeyChar) == -1);
            if (e.KeyChar.Equals((char)8))
            {
                e.Handled = false;
            }
        }

        public void Start()
        {
            textBox1.Text = "Digite Algo:";
        }

        public void ToDec()
        {
            bool check = false;
            double r = 0;
            if (textBox1.Text != null && textBox1.Text != "Digite Algo:" && check == false)
            {
                int v = int.Parse(textBox1.Text);
                char[] n = textBox1.Text.ToCharArray();

                if (v >= 1)
                {
                    for (int i = 0; i < n.Length; i++)
                    {
                        r += double.Parse(n[n.Length - 1 - i].ToString()) * (Math.Pow(2, i));
                    }
                }
            }
            textBox1.Text = r.ToString();
        }

        public void ToHexa()
        {
            if (textBox1.Text != null && textBox1.Text != "Digite Algo:")
            {               
                int h = 0;
                string p = "";
                char[] k = textBox1.Text.ToArray();

                for (int i = 0; i < k.Length; i ++)
                {
                    h += int.Parse(k[k.Length - 1 - i].ToString()) * int.Parse((Math.Pow(2, i)).ToString());
                }
                while (h - h % 16 / 16 != 0)
                {
                    if (h % 16 < 10)
                    {
                        p =(h % 16).ToString() + p;
                    }
                    else
                    {
                        switch ((h % 16).ToString())
                        {
                            case "10":
                                p =  "A" + p;
                                break;
                            case "11":
                                p =  "B" + p;
                                break;
                            case "12":
                                p = "C" + p;
                                break;
                            case "13":
                                p = "D" + p;
                                break;
                            case "14":
                                p = "E" + p;
                                break;
                            case "15":
                                p = "F" + p;
                                break;
                        }
                    }
                    h = (h - h % 16) / 16;
                }
                textBox1.Text = p;
            }
        }

        string[] INum(string h1,string h2)
        {
            if(h1.Length > h2.Length)
            {
                int index = h1.Length - h2.Length;
                for(int i=0;i<index;i++)
                {
                    h2 = "0" + h2;
                }
            }
            if(h2.Length > h1.Length)
            {
                int index = h2.Length - h1.Length;
                for (int i = 0; i < index; i++)
                {
                    h1 = "0" + h1;
                }
            }
            return new string[2] { h1, h2 };
        }

        public string BinAdd(string h1 ,string h2)
        {
                char[] g = h1.ToArray();
                char[] l = h2.ToArray();
                string o = "";
                string r = "";

                for (int i = g.Length - 1; i >= 0; i--)
                {
                    if (string.IsNullOrWhiteSpace(o))
                    {

                        if (g[i] == '0' && l[i] == '0')
                        {
                            r = "0" + r;
                        }
                        else if ((g[i] == '1' && l[i] == '0') || (g[i] == '0' && l[i] == '1'))
                        {
                            r = "1" + r;
                        }
                        else if (g[i] == '1' && l[i] == '1')
                        {
                            r = "0" + r;
                            o = "1";
                        }
                    }
                    else if (g[i] == '0' && l[i] == '0') 
                    {
                        r = "1" + r;
                        o = "";
                    }
                    else if((g[i] == '1' && l[i] == '0') || (g[i] == '0' && l[i] == '1'))
                    {
                        r = "0" + r;
                        o = "1";
                    }
                    else if(g[i] == '1' && l[i] == '1')
                    {
                        r = "1" + r;
                        o = "1";
                    }
                }
                return o + r;
        }

        public string BinMul(string h3, string h4)
        {
            char[] p = h3.ToArray();
            char[] q = h4.ToArray();
            string[] res = new string[8];
            string[] res_ant = new string[8];
            string[] lin = new string[8];
            string h = "";
            int z = 0;
            int t = 0;
            int k = 0;
            int w = h4.Length;

            for (int j = h4.Length - 1; j >= 0; j--)
            {
                for (z = h3.Length - 1; z >= 0; z--)
                {
                    if ((p[z] == '0' && q[j] == '0') || (p[z] == '1' && q[j] == '0') || (p[z] == '0' && q[j] == '1'))
                    {
                        res[z] = "0" + res_ant[t];
                    }
                    else if (p[z] == '1' && q[j] == '1')
                    {
                        res[z] = "1" + res_ant[t];
                    }
                    res_ant[z] = res[z];
                    t = z;
                }

                lin[j] = res_ant[t];

                for (int s = 7; s >= 0; s--)
                {
                    res_ant[s] = "";
                }

                if (lin[j].Length == h3.Length && j != h4.Length - 1)   
                {
                   k++;
                   w--;
                   lin[j] = string.Concat(Enumerable.Repeat("0", w)) + lin[j] + string.Concat(Enumerable.Repeat("0", k));
                   h = BinAdd(lin[j], h);
                }

                else if (j == h4.Length - 1)
                {
                    w--;
                    h = string.Concat(Enumerable.Repeat("0", w)) + lin[j];
                }
            }
            return h;
        }

        public string BinSub(string h3, string h4)
        {
            char[] p = h3.ToArray();
            char[] q = h4.ToArray();
            string r = "";

            for (int i = q.Length - 1; i >= 0; i--)
            {
                switch (q[i].ToString())
                {
                    case "1":
                        r = "0" + r;
                        break;
                    case "0":
                        r = "1"+ r;
                        break;
                }

                if (i == 0)
                {
                    int w = r.Length - 1;
                    r = BinAdd(r, (string.Concat(Enumerable.Repeat("0", w)) + "1"));
                    r = BinAdd(r, h3);
                }
            }
            char[] m = r.ToArray();
            r = "";
            for (int i = 1; i < m.Length;i++ )
            {
                r += m[i];
            }
            return r;
        }

        public string BinDiv(string h3, string h4)
        {
            string r = "0";
            while(float.Parse(h3) >= float.Parse(h4))
            {
                h3 = BinSub(h3,h4);
                int w = r.Length - 1;
                r = BinAdd(r, (string.Concat(Enumerable.Repeat("0", w)) + "1"));
            }
            return h3 = r;
        }
    }
}
