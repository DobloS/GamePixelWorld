using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Cloud
    {
        public float x;
        public float y;
        public int sizeX;
        public int sizeY;
        public Image cloudImg;

        public Cloud(int x, int y)
        {
            cloudImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\Cloud.png");
            this.x = x;
            this.y = y;
            sizeX = 350;
            sizeY = 350;
        }
    }
}
