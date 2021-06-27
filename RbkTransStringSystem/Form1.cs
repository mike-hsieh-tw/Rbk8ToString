using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RbkTransStringSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 中文轉Rbk8進制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string hz = this.richTextBox1.Text;
            byte[] gbk = Encoding.GetEncoding("GBK").GetBytes(hz);
            string s1 = "";
            foreach (byte b in gbk)
            {
                s1 += $"\\{Convert.ToString(b, 8)}";
            }
            this.richTextBox2.Text = s1;
        }

        /// <summary>
        /// 中文轉Rbk8進制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string cd = this.richTextBox1.Text;
            string[] b4 = RemoveEmptyString(cd.Split('\\'));
            byte[] bs = new byte[b4.Length];
            for (int i = 0; i < b4.Length; i++)
            {
                bs[i] = (byte)Convert.ToByte(b4[i], 8);
            }
            this.richTextBox2.Text = Encoding.GetEncoding("GBK").GetString(bs);
        }

        private string[] RemoveEmptyString(string[] strArr)
        {
            List<string> strList = new List<string>(); ;
            foreach (var item in strArr)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    strList.Add(item);
                }
            }
            return strList.ToArray();
        }

        #region 參考資料
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //汉字转为Unicode编码：
        //    string hz = textBox1.Text.ToString();
        //    byte[] b = Encoding.Unicode.GetBytes(hz);
        //    string o = "";
        //    foreach (var x in b)
        //    {
        //        o += string.Format("{0:X2}", x) + " ";
        //    }
        //    textBox2.Text = o;
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //Unicode编码转为汉字：
        //    string cd = textBox3.Text.ToString();
        //    string cd2 = cd.Replace(" ", "");
        //    cd2 = cd2.Replace("\r", "");
        //    cd2 = cd2.Replace("\n", "");
        //    cd2 = cd2.Replace("\r\n", "");
        //    cd2 = cd2.Replace("\t", "");
        //    if (cd2.Length % 4 != 0)
        //    {
        //        MessageBox.Show("Unicode编码为双字节，请删多或补少！确保是二的倍数。");
        //    }
        //    else
        //    {
        //        int len = cd2.Length / 2;
        //        byte[] b = new byte[len];
        //        for (int i = 0; i < cd2.Length; i += 2)
        //        {
        //            string bi = cd2.Substring(i, 2);
        //            b[i / 2] = (byte)Convert.ToInt32(bi, 16);
        //        }
        //        string o = Encoding.Unicode.GetString(b);
        //        textBox4.Text = o;
        //    }
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    //汉字转成GBK十六进制码：
        //    string hz = textBox5.Text.ToString();
        //    byte[] gbk = Encoding.GetEncoding("GBK").GetBytes(hz);
        //    string s1 = ""; string s1d = "";
        //    foreach (byte b in gbk)
        //    {
        //        //s1 += Convert.ToString(b, 16)+" ";
        //        s1 += string.Format("{0:X2}", b) + " ";
        //        s1d += b + " ";
        //    }
        //    textBox6.Text = s1;

        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    //GBK十六进制码转成汉字：
        //    string cd = textBox7.Text.ToString();
        //    string[] b4 = cd.Split(' ');
        //    byte[] bs = new byte[2];
        //    bs[0] = (byte)Convert.ToByte(b4[0], 16);
        //    bs[1] = (byte)Convert.ToByte(b4[1], 16);
        //    textBox8.Text = Encoding.GetEncoding("GBK").GetString(bs);
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    string hz = textBox9.Text.ToString();
        //    //汉字转成UTF-8十六进制码：
        //    byte[] utf8 = Encoding.UTF8.GetBytes(hz);
        //    string s3 = ""; string s3d = "";
        //    foreach (byte b in utf8)
        //    {
        //        //s3 += Convert.ToString(b, 16) + " ";
        //        s3 += string.Format("{0:X2}", b) + " ";
        //        s3d += b + " ";
        //    }
        //    textBox10.Text = s3;
        //}

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    //UTF-8十六进制码转成汉字：
        //    string cd = textBox11.Text.ToString();
        //    string[] b6 = cd.Split(' ');
        //    byte[] bs = new byte[3];
        //    bs[0] = (byte)Convert.ToByte(b6[0], 16);
        //    bs[1] = (byte)Convert.ToByte(b6[1], 16);
        //    bs[2] = (byte)Convert.ToByte(b6[2], 16);
        //    textBox12.Text = Encoding.GetEncoding("UTF-8").GetString(bs);
        //}
        #endregion
    }
}
