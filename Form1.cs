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

namespace FrameLab9
{
    public partial class Form1 : Form
    {
        string name = @"D:\Users\drall\source\repos\FrameLab9\binary", namecopy = @"D:\Users\drall\source\repos\FrameLab9\binarycopy";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int min = 99, max = 0, d;
            Random random = new Random();
            
            int a = Convert.ToInt32(textBox1.Text);

            FileStream f = new FileStream(name, FileMode.OpenOrCreate);
            f.SetLength(0);

            for (int i = 0; i < a; i++)
            {
                f.WriteByte((byte)(random.Next(0, 99)));
            }
            f.Seek(0, SeekOrigin.Begin);
            label2.Text = "";
            for (long i = 0; i < f.Length; i++)
            {
                label2.Text += (f.ReadByte() + " ");
            }

            f.Seek(0, SeekOrigin.Begin);
            for (long i = 0; i < f.Length; i++)
            {
                d = (int)f.ReadByte();
                if (d < min) { min = d; }
                if (d > max) { max = d; }
            }
            label5.Text = Convert.ToString(min + max);

            label12.Text = Convert.ToString(File.GetCreationTime(name));
            label13.Text = Convert.ToString(File.GetLastWriteTime(name));
            label14.Text = Convert.ToString(File.GetLastAccessTime(name));
            f.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream f = new FileStream(name, FileMode.OpenOrCreate);
            FileStream f2 = new FileStream(namecopy, FileMode.OpenOrCreate);
            f2.SetLength(0);

            f.CopyTo(f2);
            f2.Seek(0, SeekOrigin.Begin);

            label7.Text = "";
            for (long i = 0; i < f2.Length; i++)
            {
                label7.Text += ((int)f2.ReadByte() + " ");
            }

            label12.Text = Convert.ToString(File.GetCreationTime(name));
            label13.Text = Convert.ToString(File.GetLastWriteTime(name));
            label14.Text = Convert.ToString(File.GetLastAccessTime(name));

            f.Close();
            f2.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int min = 99, max = 0, d;
            FileStream f = new FileStream(name, FileMode.OpenOrCreate);
            Random random = new Random();
            int x = Convert.ToInt32(textBox2.Text);
            int number = random.Next(0, (int)f.Length);

            
            f.Seek(number, SeekOrigin.Begin);
            f.WriteByte((byte)(x));
            f.Seek(0, SeekOrigin.Begin);
            label2.Text = "";
            for (long i = 0; i < f.Length; i++)
            {
                label2.Text += ((int)f.ReadByte() + " ");
            }

            f.Seek(0, SeekOrigin.Begin);
            for (long i = 0; i < f.Length; i++)
            {
                d = (int)f.ReadByte();
                if (d < min) { min = d; }
                if (d > max) { max = d; }
            }
            label5.Text = Convert.ToString(min + max);

            label12.Text = Convert.ToString(File.GetCreationTime(name));
            label13.Text = Convert.ToString(File.GetLastWriteTime(name));
            label14.Text = Convert.ToString(File.GetLastAccessTime(name));
            f.Close();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream f = new FileStream(name, FileMode.OpenOrCreate);
            FileStream f2 = new FileStream(namecopy, FileMode.OpenOrCreate);
            int min = 99, max = 0, d;

            label2.Text = "";
            for (long i = 0; i < f.Length; i++)
            {
                label2.Text += ((int)f.ReadByte() + " ");
            }

            label7.Text = "";
            for (long i = 0; i < f2.Length; i++)
            {
                label7.Text += ((int)f2.ReadByte() + " ");
            }

            f.Seek(0, SeekOrigin.Begin);
            for (long i = 0; i < f.Length; i++)
            {
                d = (int)f.ReadByte();
                if (d < min) { min = d; }
                if (d > max) { max = d; }
            }
            label5.Text = Convert.ToString(min+max);

            label12.Text = Convert.ToString(File.GetCreationTime(name));
            label13.Text = Convert.ToString(File.GetLastWriteTime(name));
            label14.Text = Convert.ToString(File.GetLastAccessTime(name));
            f.Dispose();
            f2.Dispose();
            f.Close();
            f2.Close();
        }
    }
}
