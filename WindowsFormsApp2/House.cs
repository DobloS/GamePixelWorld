using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class House
    {
        public float x;
        public float y;
        public int sizeX;
        public int sizeY;
        public Image houseImg;

        public House(int x, int y)
        {
            houseImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\House.png");
            this.x = x;
            this.y = y;
            sizeY = 500;
            sizeX = 1000;
        }
    }
}
