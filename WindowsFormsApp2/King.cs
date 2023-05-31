using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class King
    {
        public float x;
        public float y;
        public int frameCount;

        public FrameDimension dimension;
        public Image kingImg;
        public King(int x, int y)
        {
            kingImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Gif\\King.gif");
            dimension = new FrameDimension(kingImg.FrameDimensionsList[0]);
            frameCount = kingImg.GetFrameCount(dimension);
            this.x = x;
            this.y = y;
        }


    }
}
