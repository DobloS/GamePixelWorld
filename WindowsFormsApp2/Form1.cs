using System;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{

    public partial class Forest : Form
    {
        Settings settings;
        Menu menu;
        Chest chest;
        Cave cave;
        Road road;
        Cloud cloud;
        Tree tree;
        House house;
        NPC npc;
        Mountain mountain;
        CaveEntrance caveEntrance;
        AnimatePlayer animatePlayer;
        AnimateGoblinDeath animateGoblinDeath;
        EnemyDarkKnight enemyDarkKnight;
        Dice dice;

        private bool repeat = true;
        private int counterGoblin = 0;
        private int counterDarkKnight = 0;
        private int counterChest = 0;
        private bool IsGoblinDead = false;
        private bool IsDarkKnightDead = false;
        private bool IsChestOpen = false;
        private bool IsChestClosed = true;
        private bool IsGoblinLive = true;
        private bool IsDarkKnightLive = true;

        SoundPlayer sp = new SoundPlayer();
        public Forest()
        {
            InitializeComponent();
            sp.SoundLocation = "C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\Music.wav";
            sp.Play();
            timer1.Interval = 50;
            timer1.Tick += new EventHandler(Update);
            Init();
            //Invalidate();
        }
        public void Init()
        {
            menu = new Menu();
            settings = new Settings();
            panel1.Visible = false;
            pictureBox2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            dice = new Dice(this, cave);
            chest = new Chest(this, cave);
            chest.ChestPaint(1400, 570);

            animatePlayer = new AnimatePlayer();
            animatePlayer.AnimatePlayerForest(200, 515);
            animateGoblinDeath = new AnimateGoblinDeath(750, 525);
            enemyDarkKnight = new EnemyDarkKnight();
            enemyDarkKnight.EnemyDarkKnightForest(3350, 515);

            road = new Road();
            road.RoadForest(0, 350);
            cloud = new Cloud(300, 50);
            tree = new Tree(700, 100);
            house = new House(-550, 215);
            npc = new NPC(2300, 525);
            mountain = new Mountain(1800, 70);
            caveEntrance = new CaveEntrance(4500, 220);

            timer1.Start();  
        }
        public async void TimerDice()
        {
            await Task.Delay(3000);
            pictureBox7.Visible=false;
            pictureBox8.Visible=false;
            pictureBox1.Visible=false;
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    ImageAnimator.StopAnimate(animatePlayer.animatedPlayerImg, new EventHandler(this.Update));
                    repeat = true;
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
                        panel1.Visible=false;
                    break;

                case Keys.D:
                    if (!pictureBox2.Visible && !pictureBox3.Visible && !panel1.Visible)
                    {
                        if (repeat)
                        {
                            ImageAnimator.Animate(animatePlayer.animatedPlayerImg, new EventHandler(Update));
                            repeat = false;
                        }

                        MoveObjectRight();
                    }
                   
                    break;

                case Keys.F:
                    if (animatePlayer.x > animateGoblinDeath.x - 300 && IsGoblinLive && animatePlayer.x < animateGoblinDeath.x + 300)
                    {
                        if (pictureBox6.Image == chest.diceBonusImg)
                            Dice.AddBonus();
                            
                        IsGoblinDead = dice.Go(@"C: \Users\smaks\source\repos\WindowsFormsApp2\WindowsFormsApp2\Dice");
                    }

                    else if (animatePlayer.x > enemyDarkKnight.x - 300 && IsDarkKnightLive && animatePlayer.x < enemyDarkKnight.x + 300)
                    {
                        if (pictureBox6.Image == chest.diceBonusImg)
                            Dice.AddBonus();

                        IsDarkKnightDead = dice.Go(@"C:\Users\smaks\source\repos\WindowsFormsApp2\WindowsFormsApp2\Dice");
                    }

                    else if (animatePlayer.x > npc.x - 300 && animatePlayer.x < npc.x + 300)
                    {
                        pictureBox2.Visible = true;
                    }

                    else if(animatePlayer.x > chest.x - 300 && animatePlayer.x < chest.x + 300 && !IsChestOpen)
                    {
                        IsChestOpen = true;
                        chest.ChestPrizes();
                    }
                    else if (animatePlayer.x > caveEntrance.x - 300 && animatePlayer.x <  caveEntrance.x + 300)
                    {
                        cave = new Cave();
                        Hide();
                        cave.ShowDialog();
                        cave.Focus();
                        Close();
                    }

                    break;
            }
        } 

        private void Update(object sender, EventArgs e)
        {
            if (IsGoblinDead)
            {
                if (counterGoblin < animateGoblinDeath.frameCount - 1)
                {
                    animateGoblinDeath.animatedDeathGoblinImg.SelectActiveFrame(animateGoblinDeath.dimension, counterGoblin += 1);
                }
                IsGoblinLive = false;
            }

            if (IsDarkKnightDead)
            {
                if (counterDarkKnight < enemyDarkKnight.frameCount - 2)
                {
                    enemyDarkKnight.animatedDeathDarkKnightImg.SelectActiveFrame(enemyDarkKnight.dimension, counterDarkKnight += 1);
                }
                IsDarkKnightLive = false;
            }

            if (IsChestOpen)
            {
                if (counterChest < chest.frameCount - 1)
                {
                    chest.chestImg.SelectActiveFrame(chest.dimension, counterChest += 1);
                }
                IsChestClosed = false;
            }

            ImageAnimator.UpdateFrames();
            Invalidate();
        }

        private void CreateNewObjectRight()
        {
            if (cloud.x < road.x - 350)
            {
                cloud = new Cloud(1600, 50);
            }
            if (tree.x < road.x - 650)
            {
                tree = new Tree(2000, 100);
            }
        }

        private void MoveObjectRight()
        {
            if (pictureBox6.Image == chest.speedBonusImg)
            {
                cloud.x -= 4;
                tree.x -= 5;
                house.x -= 5;
                caveEntrance.x -= 5;
                npc.x -= 6;
                chest.x -= 6;
                pictureBox2.Location = new Point(pictureBox2.Location.X - 6, pictureBox2.Location.Y);
                mountain.x -= 5f;
                animateGoblinDeath.x -= 6;
                enemyDarkKnight.x -= 6;
                CreateNewObjectRight();
            }
            else
            {
                cloud.x -= 2;
                tree.x -= 2.5f;
                house.x -= 2.5f;
                npc.x -= 3;
                chest.x -= 3;
                caveEntrance.x -= 2.5f;
                pictureBox2.Location = new Point(pictureBox2.Location.X - 3, pictureBox2.Location.Y);
                mountain.x -= 2.5f;
                animateGoblinDeath.x -= 3;
                enemyDarkKnight.x -= 3;
                CreateNewObjectRight();
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(cloud.cloudImg, cloud.x, cloud.y, cloud.sizeX, cloud.sizeY);
            graphics.DrawImage(mountain.mountainImg, mountain.x, mountain.y, mountain.sizeX, mountain.sizeY);
            graphics.DrawImage(tree.treeImg, tree.x, tree.y, tree.size, tree.size);
            graphics.DrawImage(house.houseImg, house.x, house.y, house.sizeX, house.sizeY);
            graphics.DrawImage(caveEntrance.caveEntranceImg, caveEntrance.x, caveEntrance.y, caveEntrance.sizeX, caveEntrance.sizeY);
            graphics.DrawImage(chest.chestImg, chest.x, chest.y, chest.sizeX, chest.sizeY);
            graphics.DrawImage(road.roadImg, road.x, road.y, road.sizeX, road.sizeY);
            graphics.DrawImage(npc.npcImg, npc.x, npc.y, npc.size, npc.size);
            graphics.DrawImage(animateGoblinDeath.animatedDeathGoblinImg, animateGoblinDeath.x, animateGoblinDeath.y);
            graphics.DrawImage(enemyDarkKnight.animatedDeathDarkKnightImg, enemyDarkKnight.x, enemyDarkKnight.y);
            graphics.DrawImage(animatePlayer.animatedPlayerImg, animatePlayer.x, animatePlayer.y);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}