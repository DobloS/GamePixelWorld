using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{   
    /*!
    *   Класс реализует отрисовку и применение кубиков в боевой системе.
    *   Этот класс используется в учебных целях.
    */
    public class Dice 
    {
        Forest forest;
        Cave cave;
        public int playerNumber;
        public int enemyDice;
        static readonly Random rnd = new Random();
        public static int bonusCounter;

        /*!
        *   При обращении к методу, добавляет единицу к переменной bonusCounter.
        *   bonusCounter используется для отслеживания наличия бонуса.
        */
        public static int AddBonus()
        {
            return bonusCounter++;
        }

        /*!
        *   Инициализация форм.
        */
        public Dice(Forest forest, Cave cave)
        {
            this.forest = forest; 
            this.cave = cave;
        }

        /*!
        *   Присваивает случайные значения переменным,
        *   исходя из значений которых происходит отрисовка нужного изображения в начальной локации.
        */
        public bool Go(string path) 
        {
            playerNumber = rnd.Next(1, 7);
            if (bonusCounter != 0 && playerNumber != 6)
                playerNumber += 1; 
            
            enemyDice = rnd.Next(1, 7);
            forest.label3.Text = playerNumber.ToString();
            forest.label4.Text =  enemyDice.ToString();
            forest.pictureBox7.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Dice\\" + 
                forest.label3.Text + ".png");
            forest.pictureBox1.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Dice\\" + 
                forest.label4.Text + ".png");
            forest.pictureBox7.Visible = true;
            forest.pictureBox8.Visible = true;
            forest.pictureBox1.Visible = true;

            return BattleWin();
        }
        /*!
        *   Присваивает случайные значения переменным,
        *   исходя из значений которых происходит отрисовка нужного изображения в локации "пещера".
        */
        public bool GoCave(string path) 
        {
            playerNumber = rnd.Next(1, 7);
            if (bonusCounter != 0 && playerNumber != 6)
                playerNumber += 1;

            enemyDice = rnd.Next(1, 7);
            cave.label3.Text = playerNumber.ToString();
            cave.label4.Text = enemyDice.ToString();
            cave.pictureBox7.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Dice\\" + 
                cave.label3.Text + ".png");
            cave.pictureBox1.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Dice\\" + 
                cave.label4.Text + ".png");
            cave.pictureBox7.Visible = true;
            cave.pictureBox8.Visible = true;
            cave.pictureBox1.Visible = true;

            return BattleWinCave();
        }

        /*!
        *   Возвращает победный исход битвы.
        */
        public bool BattleWin() 
        {
            Log();
            return playerNumber > enemyDice;
        }

        public bool BattleWinCave()
        {
            LogCave();
            return playerNumber > enemyDice;
        }

        /*!
        *   Проверяет исход битвы с последующей отрисовкой нужного изображения.
        */
        public void Log() 
        {
            if (playerNumber > enemyDice)
            {
                forest.pictureBox8.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\WinLose\\win.png");
                forest.TimerDice();
            }
            else if (playerNumber == enemyDice)
            {
                forest.pictureBox8.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\WinLose\\draw.png");
            }
            else
            {
                forest.pictureBox8.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\WinLose\\lose.png");
            }
        }
        public void LogCave()
        {
            if (playerNumber > enemyDice)
            {
                cave.pictureBox8.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\WinLose\\win.png");
                
            }
            else if (playerNumber == enemyDice)
            {
                cave.pictureBox8.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\WinLose\\draw.png");
            }
            else
            {
                cave.pictureBox8.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\WinLose\\lose.png");
            }
        }
    }
}