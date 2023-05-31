using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Road
    {
        public int x;
        public int y;
        public int sizeX;
        public int sizeY;
        public Image roadImg;
        public Image roadCaveImg;

        public void RoadForest(int x, int y)
        {
            roadImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\Road.png");
            this.x = x;
            this.y = y;
            sizeX = 1700;
            sizeY = 600;
        }
        public void RoadCave(int x, int y)
        {
            roadCaveImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\RoadCave.png");
            this.x = x;
            this.y = y;
            sizeX = 1700;
            sizeY = 600;
        }
    }
}
