using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Mountain
    {
        public float x;
        public float y;
        public int sizeX;
        public int sizeY;
        public Image mountainImg;

        public Mountain(int x, int y)
        {
            mountainImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\Mountain.png");
            this.x = x;
            this.y = y;
            sizeX = 700;
            sizeY = 700;
        }
    }
}
