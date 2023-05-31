using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class EnemyDarkKnight
    {
        public float x;
        public float y;
        public int frameCount;
        public int frameCountCave;

        public FrameDimension dimension;
        public FrameDimension dimensionCave;

        public Image animatedDeathDarkKnightImg;
        public Image animatedDeathDarkKnightCaveImg;
        public void EnemyDarkKnightForest(int x, int y)
        {
            animatedDeathDarkKnightImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Gif\\DarkKnightDeath.gif");
            dimension = new FrameDimension(animatedDeathDarkKnightImg.FrameDimensionsList[0]);
            frameCount = animatedDeathDarkKnightImg.GetFrameCount(dimension);
            this.x = x;
            this.y = y;
        }

        public void EnemyDarkKnightCave(int x, int y)
        {
            animatedDeathDarkKnightCaveImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Gif\\DarkKnightDeathCave.gif");
            dimensionCave = new FrameDimension(animatedDeathDarkKnightCaveImg.FrameDimensionsList[0]);
            frameCountCave = animatedDeathDarkKnightCaveImg.GetFrameCount(dimensionCave);
            this.x = x;
            this.y = y;
        }
    }
}
