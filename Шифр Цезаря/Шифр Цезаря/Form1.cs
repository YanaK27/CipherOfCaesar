using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Шифр_Цезаря
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        
        private void Button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = enc(textBox1.Text);
        }
        public string enc(string inp)
        {
            StringBuilder code = new StringBuilder();
            string encryption = textBox1.Text;
            int step = 3;
            string space = " ";

            for (int i = 0; i < encryption.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (encryption[i] == alphabet[j])
                    {
                        code.Append(alphabet[(j + step) % alphabet.Length]);
                        
                    }
                    else if (encryption[i] == space[0])
                    {
                        code.Append(space);
                        break;
                    }
                    
                }
           
            }
            return code.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = dec(textBox2.Text);

        }
        public string dec(string inp)
        {
            StringBuilder code = new StringBuilder();
            string encryption = textBox2.Text;
            int step = 3;
            string space = " ";

            for (int i = 0; i < encryption.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (encryption[i] == alphabet[j])
                    {
                        code.Append(alphabet[(j - step + alphabet.Length) % alphabet.Length]);

                    }
                    else if (encryption[i] == space[0])
                    {
                        code.Append(space);
                        break;
                    }
                }

            }
            return code.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            string text = "Шифрование: " + textBox1.Text + "\n" + "Дешифрование: " + textBox2.Text;
            string name; 
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name, text);
            }
        }
    }
}
