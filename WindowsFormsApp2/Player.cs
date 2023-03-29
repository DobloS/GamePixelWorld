using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Image animatedPlayerImg;
        public Image animatedPlayerLeftImg;

        public AnimatePlayer(int x, int y)
        {
            animatedPlayerImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Gif\\AnimationPlayer.gif");
            animatedPlayerLeftImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Gif\\AnimationPlayerLeft.gif");
            this.x = x;
            this.y = y;

        }
    }
}



