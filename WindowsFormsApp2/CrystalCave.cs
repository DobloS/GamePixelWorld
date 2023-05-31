using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class CrystalCave
    {
        public int x;
        public int y;
        public int sizeX;
        public int sizeY;
        public Image blackCrystalImg;
        public Image greenCrystalImg;
        public Image blackCrystalTwoImg;
        public Image greenCrystalTwoImg;

        public void BlackCrystalPaint(int x, int y)
        {
            blackCrystalImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\BlackCrystal.png");
            this.x = x;
            this.y = y;
            sizeX = 125;
            sizeY = 125;
        }
        public void GreenCrystalPaint(int x, int y)
        {
            greenCrystalImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\GreenCrystal.png");
            this.x = x;
            this.y = y;
            sizeX = 125;
            sizeY = 125;
        }
        public void BlackCrystalTwoPaint(int x, int y)
        {
            blackCrystalTwoImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\BlackCrystalTwo.png");
            this.x = x;
            this.y = y;
            sizeX = 125;
            sizeY = 125;
        }
        public void GreenCrystalTwoPaint(int x, int y)
        {
            greenCrystalTwoImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\GreenCrystalTwo.png");
            this.x = x;
            this.y = y;
            sizeX = 125;
            sizeY = 125;
        }
    }
}
