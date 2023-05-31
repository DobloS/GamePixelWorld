using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class CeilingCave
    {
        public float x;
        public float y;
        public int sizeX;
        public int sizeY;
        public Image ceilingImg;

        public CeilingCave(int x, int y)
        {
            ceilingImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\CeilingCave.png");
            this.x = x;
            this.y = y;
            sizeX = 1700;
            sizeY = 600;
        }
    }
}
