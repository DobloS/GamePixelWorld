using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class EnemyDarkKnight
    {
        public float x;
        public float y;
        public int frameCount;

        public FrameDimension dimension;
        public Image animatedDeathDarkKnightImg;
        public EnemyDarkKnight(int x, int y)
        {
            animatedDeathDarkKnightImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Gif\\DarkKnightDeath.gif");
            dimension = new FrameDimension(animatedDeathDarkKnightImg.FrameDimensionsList[0]);
            frameCount = animatedDeathDarkKnightImg.GetFrameCount(dimension);
            this.x = x;
            this.y = y;
        }
    }
}
