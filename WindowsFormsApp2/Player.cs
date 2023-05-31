using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class AnimatePlayer
    {
        public float x;
        public float y;
        public int frameCount;
       // public int frameCountCave;

        public FrameDimension dimension;
        public Image animatedPlayerImg;
        public Image animatedPlayerCaveImg;
        //public Image animatedPlayerLeftImg;

        public void AnimatePlayerForest(int x, int y)
        {
            animatedPlayerImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Gif\\AnimationPlayer.gif");
            //animatedPlayerLeftImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Gif\\AnimationPlayerLeft.gif");
            this.x = x;
            this.y = y;
        }

        public void AnimatePlayerCave(int x, int y)
        {
            animatedPlayerCaveImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Gif\\AnimationPlayerCave.gif");
            dimension = new FrameDimension(animatedPlayerCaveImg.FrameDimensionsList[0]);
            frameCount = animatedPlayerCaveImg.GetFrameCount(dimension);
            //animatedPlayerLeftImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Gif\\AnimationPlayerLeft.gif");
            this.x = x;
            this.y = y;
        }
    }
}



