using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Cave : Form
    {
        Forest forest;
        Menu menu;
        Settings settings;
        Road road;
        CeilingCave ceiling;
        CrystalCave blackCrystal;
        CrystalCave blackCrystalTwo;
        CrystalCave greenCrystal;
        CrystalCave greenCrystalTwo;
        King king;
        EnemyDarkKnight enemyDarkKnight;
        AnimatePlayer playerCaveGif;
        PlayerCave playerCave;
        //playerCave playerCave;
        Dice dice;
        Chest chest;
        Chest chestTwo;
        readonly Image playerCaveImg;

        private bool IsDialogKing = true;
        private bool IsDialogKnight = true;
        private bool IsKingDead = false;
        private bool IsKingLive = true;
        //private bool repeat = true;
        private int counterDarkKnight = 0;
        private bool IsDarkKnightDead = false;
        private bool IsDarkKnightLive = true;
        private int counterChest = 0;
        private int counterChestTwo = 0;
        private int counterKing = 0;
        private int counterKingWin = 0;
        private bool IsChestOpen = false;
        private bool IsChestClosed = true;
        private bool IsChestTwoOpen = false;
        private bool IsChestTwoClosed = true;
        private bool timer = false;
        private bool isPressedAnyKey = false;

        //private int counterPlayer = 0;
        private int currFrame = 0;
        //private bool currAnimation = false;
        Image playerCaveTwo;

        public delegate void Invoke();
        public Invoke myDelegate;

        SoundPlayer sp = new SoundPlayer();
        public Cave()
        {
            InitializeComponent();
            playerCaveImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\PlayerSprite1.png");
            //playerCaveTwo = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\PlayerSprite4.png");
            sp.SoundLocation = "C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\Music.wav";
            sp.Play();
            timer1.Interval = 75;
            timer1.Tick += new EventHandler(Update);
            Init();
            //Invalidate();
        }
        public void Init()
        {
            settings = new Settings();
            menu = new Menu();
            forest = new Forest();

            panel1.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            myDelegate += new Invoke(Update);

            dice = new Dice(forest, this);

            blackCrystal = new CrystalCave();
            blackCrystal.BlackCrystalPaint(550, 600);
            blackCrystalTwo = new CrystalCave();
            blackCrystalTwo.BlackCrystalTwoPaint(1800, 600);
            greenCrystal = new CrystalCave();
            greenCrystal.GreenCrystalPaint(0, 100);
            greenCrystalTwo = new CrystalCave();
            greenCrystalTwo.GreenCrystalTwoPaint(1500, 100);

            chest = new Chest(forest,this);
            chest.ChestPaint(500, 550);
            chestTwo = new Chest(forest,this);
            chestTwo.ChestTwoPaint(1900, 550);

            playerCave = new PlayerCave(new Size(200,200), 200, 515, playerCaveImg);
            playerCaveGif = new AnimatePlayer();
            playerCaveGif.AnimatePlayerCave(200, 515);
            king = new King(3200, 430);
            enemyDarkKnight = new EnemyDarkKnight();
            enemyDarkKnight.EnemyDarkKnightCave(1500, 500);

            road = new Road();
            road.RoadCave(0, 350);
            ceiling = new CeilingCave(0, 0);

            timer1.Start();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

       
        public async void TimerDice()
        {
            await Task.Delay(3000);
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox1.Visible = false;
            pictureBox3.Visible = false;
        }

        public async void TimerEnd()
        {
            if (!IsKingLive && !timer)
            {
                await Task.Delay(6000);
                pictureBox10.Visible = true;
                timer = true;
            }

        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    isPressedAnyKey = false;
                    /*ImageAnimator.StopAnimate(playerCaveGif.animatedPlayerCaveImg, new EventHandler(this.Update));
                    repeat = true;*/
                    //repeat = false;
                    break;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (!panel1.Visible)
                    {
                        panel1.Visible = true;
                    }
                    else
                        panel1.Visible = false;
                    break;

                case Keys.D:
                    if (!panel1.Visible && !pictureBox4.Visible && !pictureBox5.Visible && !pictureBox6.Visible)
                    {
                        //PlayAnimation();
                        isPressedAnyKey = true;
                         /*if (repeat)
                         {
                             ImageAnimator.Animate(playerCaveGif.animatedPlayerCaveImg, new EventHandler(this.Update));
                             repeat = false;
                         }*/
                        /*if (counterPlayer < playerCave.frameCount - 1)
                        {
                            playerCave.animatedPlayerCaveImg.SelectActiveFrame(playerCave.dimension, counterPlayer += 1);

                        }*/
                        //repeat = false;



                        MoveObjectRight();
                    }

                    break;

                case Keys.F:

                    if (playerCave.x > chest.x - 300 && playerCave.x < chest.x + 300 && !IsChestOpen)
                    {
                        IsChestOpen = true;
                        chest.ChestPrizesCave();
                    }

                    if (playerCave.x > chestTwo.x - 300 && playerCave.x < chestTwo.x + 300 && !IsChestTwoOpen)
                    {
                        IsChestTwoOpen = true;
                        chest.ChestPrizesCave();
                    }

                    else if (playerCave.x > enemyDarkKnight.x - 300 && IsDarkKnightLive && playerCave.x < enemyDarkKnight.x + 300)
                    {
                        if (pictureBox2.Image == chest.diceBonusImg)
                            Dice.AddBonus();

                        IsDarkKnightDead = dice.GoCave(@"C:\Users\smaks\source\repos\WindowsFormsApp2\WindowsFormsApp2\Dice");
                        TimerDice();
                    }

                    if (playerCave.x > king.x - 300 && IsKingLive && playerCave.x < king.x + 300)
                    {
                        if (pictureBox2.Image == chest.diceBonusImg)
                            Dice.AddBonus();

                        dice.GoCave(@"C: \Users\smaks\source\repos\WindowsFormsApp2\WindowsFormsApp2\Dice");

                        if (dice.playerNumber > dice.enemyDice)
                        {
                            counterKingWin += 1;
                            label1.Text = counterKingWin.ToString();
                            pictureBox3.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\" + label1.Text + ".png");
                            pictureBox3.Visible = true;
                            pictureBox8.Visible = false;

                            if (counterKingWin == 3)
                            {
                                pictureBox8.Visible = true;
                                IsKingDead = true;
                                pictureBox8.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\WinLose\\win.png");
                                TimerDice();                            
                            }
                        }

                        else if(dice.playerNumber < dice.enemyDice)
                        {
                            counterKingWin = 0;
                            label1.Text = counterKingWin.ToString();
                            pictureBox3.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\" + label1.Text + ".png");
                            pictureBox8.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\WinLose\\lose.png");
                        }

                        else
                        {
                            counterKingWin = 0;
                            label1.Text = counterKingWin.ToString();
                            pictureBox3.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\" + label1.Text + ".png");
                            pictureBox8.Image = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\WinLose\\draw.png");
                        } 
                    }
                    

                    break;
            }
        }

        private void MoveObjectRight()
        {
            if (pictureBox9.Image == chest.speedBonusImg)
            {
                chest.x -= 9;
                king.x -= 9;
                blackCrystal.x -= 9;
                greenCrystal.x -= 9;
                blackCrystalTwo.x -= 9;
                greenCrystalTwo.x -= 9;
                enemyDarkKnight.x -= 9;
                chestTwo.x -= 9;
            }
            else
            {
                chest.x -= 6;
                king.x -= 6;
                blackCrystal.x -= 6;
                greenCrystal.x -= 6;
                blackCrystalTwo.x -= 6;
                greenCrystalTwo.x -= 6;
                enemyDarkKnight.x -= 6;
                chestTwo.x -= 6;
            }
            CreateNewObjectRight();
        }

        private void CreateNewObjectRight()
        {
            if (blackCrystal.x < road.x - 125)
            {
                blackCrystal.BlackCrystalPaint(2400, 600);
            }

            if (greenCrystal.x < road.x - 125)
            {
                greenCrystal.GreenCrystalPaint(2500, 50);
            }

            if (blackCrystalTwo.x < road.x - 125)
            {
                blackCrystalTwo.BlackCrystalTwoPaint(2700, 600);
            }

            if (greenCrystal.x < road.x - 125)
            {
                greenCrystalTwo.GreenCrystalTwoPaint(3000, 50);
            }
        }

        private void Update(object sender, EventArgs e)
        {
            if (IsChestOpen)
            {
                if (counterChest < chest.frameCount - 1)
                {
                    chest.chestImg.SelectActiveFrame(chest.dimension, counterChest += 1);
                }
                IsChestClosed = false;
            }

            if (IsChestTwoOpen)
            {
                if (counterChestTwo < chestTwo.frameCountTwo - 1)
                {
                    chestTwo.chestTwoImg.SelectActiveFrame(chestTwo.dimensionTwo, counterChestTwo += 1);
                }
                IsChestTwoClosed = false;
            }

            if (IsKingDead)
            {
                if (counterKing < king.frameCount - 1)
                {
                    king.kingImg.SelectActiveFrame(king.dimension, counterKing += 1);
                }
                IsKingLive = false;
            }

            if (IsDarkKnightDead)
            {
                if (counterDarkKnight < enemyDarkKnight.frameCountCave - 1)
                {
                    enemyDarkKnight.animatedDeathDarkKnightCaveImg.SelectActiveFrame(enemyDarkKnight.dimensionCave, counterDarkKnight += 1);
                }
                IsDarkKnightLive = false;
            }

            if (IsDialogKnight && playerCave.x > enemyDarkKnight.x - 500 && playerCave.x < enemyDarkKnight.x + 500)
            {
                pictureBox5.Invoke(myDelegate);
                pictureBox5.Visible = true;
                IsDialogKnight = false;
            }

            if (IsDialogKing && playerCave.x > king.x - 500 && playerCave.x < king.x + 500)
            {
                pictureBox6.Invoke(myDelegate);
                pictureBox6.Visible = true;
                IsDialogKing = false;
            }

            if (isPressedAnyKey)
            {
                if (currFrame == 6)
                    currFrame = 0;
            }
            else
            {
                currFrame = 2;
            }
            currFrame++;
            /*if (currFrame == 7)
                currFrame = 0;
            currFrame++;*/


            TimerEnd();
            //ImageAnimator.UpdateFrames();
            Invalidate();
        }

       /* public void PlayAnimation()
        {
            Image part = new Bitmap(230, 257);
            Graphics graphics = Graphics.FromImage(part);
            graphics.DrawImage(playerCave.playerCaveImg, 0, 0, new Rectangle(new Point(225 * currFrame, 0), new Size(230, 257)), GraphicsUnit.Pixel);
            pictureBox11.Size = new Size(230, 257);
            pictureBox11.Image = part;
        }*/

        public void PlayAnimation(Graphics graphics)
        {
            graphics.DrawImage(playerCaveImg, playerCave.x, playerCave.y, new Rectangle(new Point(223 * currFrame, 55), new Size(220, 220)), GraphicsUnit.Pixel);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(road.roadCaveImg, road.x, road.y, road.sizeX, road.sizeY);
            graphics.DrawImage(ceiling.ceilingImg, ceiling.x, ceiling.y, ceiling.sizeX, ceiling.sizeY);
            graphics.DrawImage(chest.chestImg, chest.x, chest.y, chest.sizeX, chest.sizeY);
            graphics.DrawImage(chestTwo.chestTwoImg, chestTwo.x, chestTwo.y, chestTwo.sizeX, chestTwo.sizeY);
            graphics.DrawImage(king.kingImg, king.x, king.y);
            graphics.DrawImage(enemyDarkKnight.animatedDeathDarkKnightCaveImg, enemyDarkKnight.x, enemyDarkKnight.y);
            PlayAnimation(graphics);
            //graphics.DrawImage(playerCaveGif.animatedPlayerCaveImg, playerCaveGif.x, playerCaveGif.y);
            graphics.DrawImage(blackCrystal.blackCrystalImg, blackCrystal.x, blackCrystal.y, blackCrystal.sizeX, blackCrystal.sizeY);
            graphics.DrawImage(greenCrystal.greenCrystalImg, greenCrystal.x, greenCrystal.y, greenCrystal.sizeX, greenCrystal.sizeY);
            graphics.DrawImage(blackCrystalTwo.blackCrystalTwoImg, blackCrystalTwo.x, blackCrystalTwo.y, blackCrystalTwo.sizeX, blackCrystalTwo.sizeY);
            graphics.DrawImage(greenCrystalTwo.greenCrystalTwoImg, greenCrystalTwo.x, greenCrystalTwo.y, greenCrystalTwo.sizeX, greenCrystalTwo.sizeY);

            if (timer)
            {
                graphics.Clear(Color.DimGray);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Hide();
            menu.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            settings.ShowDialog();
            Show();
        }

        private void Cave_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox10.Visible)
            {
                Hide();
                menu.ShowDialog();
                Close();
            }

            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
        }
    }
}
