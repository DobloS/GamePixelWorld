using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    /*!
    *   Отрисовка сундука с последующим получением награды в виде бонуса.
    *   Этот класс используется в учебных целях.
    */
    public class Chest 
    {
        Forest forest;
        Cave cave;
        public int x;
        public int y;
        public int sizeX;
        public int sizeY;
        public int frameCount;
        public int frameCountTwo;
        public int diceBonus;
        public int speedBonus;
        private bool rndOneTime = true;
        private bool rndOneTimeCave = true;
        public FrameDimension dimension;
        public FrameDimension dimensionTwo;
        public Image chestImg;
        public Image chestTwoImg;
        public Image diceBonusImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\DiceBonus.png");
        public Image speedBonusImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\SpeedBonus.png");

        /*!
        *   Инициализация форм.
        */
        public Chest(Forest forest, Cave cave)
        {
            this.forest = forest;
            this.cave = cave;
        }

        /*!
        *   Задает параметры отрисовки изображения.
        *   Переменная dimension задает массив идентификаторов, представляющих размер кадров gif файла.
        *   Переменная frameCount возвращает количество кадров.
        */
        public void ChestPaint(int x, int y) 
        {
            chestImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\gif\\Chest.gif"); 
            dimension = new FrameDimension(chestImg.FrameDimensionsList[0]);
            frameCount = chestImg.GetFrameCount(dimension);
            this.x = x;
            this.y = y;
            sizeX = 200;
            sizeY = 150;
        }

        public void ChestTwoPaint(int x, int y)
        {
            chestTwoImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\gif\\ChestTwo.gif");
            dimensionTwo = new FrameDimension(chestTwoImg.FrameDimensionsList[0]);
            frameCountTwo = chestTwoImg.GetFrameCount(dimensionTwo);
            this.x = x;
            this.y = y;
            sizeX = 200;
            sizeY = 150;
        }

        /*!
        *   Возвращает случайное значение один раз.
        */
        public void RandomBonus() 
        {
            if (rndOneTime)
            {
                Random rnd = new Random();
                diceBonus = rnd.Next(1, 3);
                rndOneTime = false;
            }
        }

        public void RandomBonusCave()
        {
            if (rndOneTimeCave)
            {
                Random rnd = new Random();
                speedBonus = rnd.Next(1, 3);
                rndOneTimeCave = false;
            }
        }

        /*!
        *  Отрисовка призов с сундука в начальной локации. 
        *  1-ый бонус достается случайно, 2-ой, что не первый.
        */
        public void ChestPrizes() 
        {
            RandomBonus();
            if (diceBonus == 1 && forest.pictureBox6.Image !=diceBonusImg)
            {
                forest.pictureBox6.Image = diceBonusImg;
                forest.pictureBox6.Visible = true;
                TimerChestPrizes();
                diceBonus = 2;
            }

            else if (diceBonus == 2 && forest.pictureBox6.Image != speedBonusImg)
            {
                forest.pictureBox6.Image = speedBonusImg;
                forest.pictureBox6.Visible = true;
                TimerChestPrizes();
                diceBonus = 1;
            }
        }

        /*!
        *  Отрисовка призов с сундука в локации "пещера". 
        *  1-ый бонус достается случайно, 2-ой, что не первый.
        */
        public void ChestPrizesCave() 
        {
            RandomBonusCave();
            if (speedBonus == 1 && cave.pictureBox2.Image != diceBonusImg)
            {
                cave.pictureBox2.Image = diceBonusImg;
                cave.pictureBox2.Visible = true;
                TimerChestPrizesCave();
                speedBonus = 2;
            }

            else if (speedBonus == 2 && cave.pictureBox2.Image != speedBonusImg)
            {
                cave.pictureBox9.Image = speedBonusImg;
                cave.pictureBox9.Visible = true;
                TimerChestPrizesCave();
                speedBonus = 1;
            }
        }

        /*!
        *  Задает таймер, по истечению которого перестанут быть видимыми на экране изображения бонусов.
        */
        private async void TimerChestPrizes()                                   
        {                                     
            await Task.Delay(3000);
            forest.pictureBox6.Visible = false;
        }

        private async void TimerChestPrizesCave()
        {
            await Task.Delay(3000);
            cave.pictureBox9.Visible = false;
            cave.pictureBox2.Visible = false;
        }
    }
}
