using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WindowsFormsApp2
{
    public class Dice   
    {
        Form1 form1;
        public int playerNumber;
        private int enemyDice;
        static readonly Random rand = new Random();

        public Dice(Form1 form1)
        {
            this.form1 = form1;
        }

        public bool Go(string path)
        {
            playerNumber = rand.Next(1, 7);
            enemyDice = rand.Next(1, 7);
            form1.label3.Text = playerNumber.ToString();
            form1.label4.Text =  enemyDice.ToString();
            form1.pictureBox7.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Dice\\" + form1.label3.Text + ".png");
            form1.pictureBox1.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Dice\\" + form1.label4.Text + ".png");
            form1.pictureBox7.Visible = true;
            form1.pictureBox8.Visible = true;
            form1.pictureBox1.Visible = true;

            return Battle();
        }

        public bool Battle()
        {
            Log();
            return playerNumber > enemyDice;
        }

        private void Log()
        {
            if (playerNumber > enemyDice)
            {
                form1.pictureBox8.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\WinLose\\win.png");
                form1.TimerDice();
            }
            else if (playerNumber == enemyDice)
            {
                form1.pictureBox8.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\WinLose\\draw.png");
            }
            else
            {
                form1.pictureBox8.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\WinLose\\lose.png");
            }
        }
    }
}