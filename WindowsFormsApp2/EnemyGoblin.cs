using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class AnimateGoblinDeath
    {

        public float x;
        public float y;
        public int frameCount;

        public FrameDimension dimension;
        public Image animatedDeathGoblinImg;
        public AnimateGoblinDeath(int x, int y)
        {
            animatedDeathGoblinImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Gif\\DeathGoblinAnimated.gif");
            dimension = new FrameDimension(animatedDeathGoblinImg.FrameDimensionsList[0]);
            frameCount = animatedDeathGoblinImg.GetFrameCount(dimension);
            this.x = x;
            this.y = y;
        }
    }
}
