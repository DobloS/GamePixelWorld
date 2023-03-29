using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        Form1 form1;
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
        public Form2()
        {
            InitializeComponent();
            sp.SoundLocation = "C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\Music.wav";
            sp.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1 = new Form1();
            Hide();
            form1.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
