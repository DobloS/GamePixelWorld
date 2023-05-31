using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class CaveEntrance
    {
        public float x;
        public float y;
        public int sizeX;
        public int sizeY;
        public Image caveEntranceImg;

        public CaveEntrance(int x, int y)
        {
            caveEntranceImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\CaveEntrance.png");
            this.x = x;
            this.y = y;
            sizeX = 1000;
            sizeY = 500;
        }
    }
}
