using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binarni_Ukol_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream datovytok = new FileStream("znaky.dat", FileMode.Open, FileAccess.Read);
            BinaryReader ctenar = new BinaryReader(datovytok, Encoding.GetEncoding("windows-1250"));
            bool nalez = false;
            char predchoziznak = ' ';
            ctenar.BaseStream.Position = 0;
            while(ctenar.BaseStream.Position < ctenar.BaseStream.Length)
            {
                char znak = ctenar.ReadChar();
                if(znak == '?' && nalez != true)
                {
                    nalez = true;
                    label2.Text = "První výskyt ?: " + ctenar.BaseStream.Position.ToString() + "\nA předchozí znak je: " + predchoziznak.ToString();
                }
                predchoziznak = znak;
            }
            datovytok.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Gold;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.LawnGreen;
        }
    }
}
