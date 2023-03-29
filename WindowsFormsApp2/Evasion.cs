using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Evasion
    {
        public int x;
        public int y;
        public int size;
        public Image evasionImg;

        public Evasion(int x, int y)
        {
            evasionImg = new Bitmap("C:\\Users\\smaks\\OneDrive\\Рабочий стол\\Evasion.png");
            this.x = x;
            this.y = y;
            size = 100;
        }
    }
}
