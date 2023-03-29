using System;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{

    public partial class Form1 : Form
    {
        Form3 form3;
        Form2 form2;
        Road road;
        Cloud cloud;
        Tree tree;
        House house;
        NPC npc;
        Mountain mountain;
        AnimatePlayer animatePlayer;
        AnimateGoblinDeath animateGoblinDeath;
        EnemyDarkKnight enemyDarkKnight;
        Dice dice;

        private bool repeat = true;
        public bool a;
        private int counterGoblin = 0;
        private int counterDarkKnight = 0;
        public bool IsGoblinDead = false;
        public bool IsDarkKnightDead = false;
        private bool IsGoblinLive = true;
        private bool IsDarkKnightLive = true;
        private bool timer = false;
        SoundPlayer sp = new SoundPlayer();
        public Form1()
        {
            InitializeComponent();
            sp.SoundLocation = "C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\Music.wav";
            sp.Play();
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(Update);
            Init();
            Invalidate();
        }
        public void Init()
        {
            form2 = new Form2();
            form3 = new Form3();
            panel1.Visible = false;
            pictureBox2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            dice = new Dice(this);
            animatePlayer = new AnimatePlayer(200, 515);
            animateGoblinDeath = new AnimateGoblinDeath(750, 525);
            enemyDarkKnight = new EnemyDarkKnight(3350, 515);

            road = new Road(0, 350);
            cloud = new Cloud(300, 50);
            tree = new Tree(700, 100);
            house = new House(-550, 215);
            npc = new NPC(2300, 525);
            mountain = new Mountain(1800, 70);

            timer1.Start();  
        }
        public async void TimerDice()
        {
            await Task.Delay(3000);
            pictureBox7.Visible=false;
            pictureBox8.Visible=false;
            pictureBox1.Visible=false;
        }
        public async void TimerEnd()
        {
            if (!IsDarkKnightLive && !timer)
            {
                await Task.Delay(6000);
                pictureBox4.Visible = true;
                timer = true;
            }
           
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
                    if (animatePlayer.x > animateGoblinDeath.x - 300 && IsGoblinLive)
                    {
                        IsGoblinDead = dice.Go(@"C: \Users\smaks\source\repos\WindowsFormsApp2\WindowsFormsApp2\Dice");
                    }
                    else if (animatePlayer.x > enemyDarkKnight.x - 300 && IsDarkKnightLive)
                    {
                        IsDarkKnightDead = dice.Go(@"C:\Users\smaks\source\repos\WindowsFormsApp2\WindowsFormsApp2\Dice");
                    }
                    if (animatePlayer.x > npc.x - 300 && animatePlayer.x < npc.x + 300)
                    {
                        pictureBox2.Visible = true;
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
            TimerEnd();
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
            cloud.x -= 2.005f;
            tree.x -= 2.525f;
            house.x -= 2.525f;
            npc.x -= 3;
            pictureBox2.Location = new Point(pictureBox2.Location.X - 3, pictureBox2.Location.Y);
            mountain.x -= 2.5f;
            animateGoblinDeath.x -= 3.030f;
            enemyDarkKnight.x -= 3.030f;
            CreateNewObjectRight();

        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(cloud.cloudImg, cloud.x, cloud.y, cloud.sizeX, cloud.sizeY);
            graphics.DrawImage(mountain.mountainImg, mountain.x, mountain.y, mountain.sizeX, mountain.sizeY);
            graphics.DrawImage(tree.treeImg, tree.x, tree.y, tree.size, tree.size);
            graphics.DrawImage(house.houseImg, house.x, house.y, house.sizeX, house.sizeY);
            graphics.DrawImage(road.roadImg, road.x, road.y, road.sizeX, road.sizeY);
            graphics.DrawImage(npc.npcImg, npc.x, npc.y, npc.size, npc.size);
            graphics.DrawImage(animateGoblinDeath.animatedDeathGoblinImg, animateGoblinDeath.x, animateGoblinDeath.y);
            graphics.DrawImage(enemyDarkKnight.animatedDeathDarkKnightImg, enemyDarkKnight.x, enemyDarkKnight.y);
            graphics.DrawImage(animatePlayer.animatedPlayerImg, animatePlayer.x, animatePlayer.y);

            if (timer)
            {
                graphics.Clear(Color.Bisque);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (pictureBox4.Visible)
            {
                Hide();
                form2.ShowDialog();
                Close();
            }
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            form2.ShowDialog();
            Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            Hide();
            form3.ShowDialog();
            Show();
        }
    }
}
