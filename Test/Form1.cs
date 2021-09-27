using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text.Trim());
            //int b = Convert.ToInt32(textBox2.Text.Trim());
            var result = a & 0xFF;
            textBox3.Text = ((byte)(a & 0xFF)).ToString();
        }

        byte[] buf = new byte[4];
        private void button2_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox4.Text.Trim());

            ConvertIntToByteArray(a, ref buf);
            textBox5.Text = buf[0].ToString() +"\r\n"+ buf[1].ToString() + "\r\n" + buf[2].ToString() + "\r\n" + buf[3].ToString();

        }


        /// <summary>
        /// 把int32类型的数据转存到4个字节的byte数组中
        /// </summary>
        /// <param name="m">int32类型的数据</param>
        /// <param name="arry">4个字节大小的byte数组</param>
        /// <returns></returns>
        static bool ConvertIntToByteArray(Int32 m, ref byte[] arry)
        {
            if (arry == null) return false;
            if (arry.Length < 4) return false;

            arry[0] = (byte)(m & 0xFF);
            arry[1] = (byte)((m & 0xFF00) >> 8);
            arry[2] = (byte)((m & 0xFF0000) >> 16);
            arry[3] = (byte)((m >> 24) & 0xFF);

            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = BitConverter.ToInt32(buf, 0);
            textBox6.Text = i.ToString();
        }
    }
}
