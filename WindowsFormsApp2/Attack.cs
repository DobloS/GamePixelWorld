using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Attack
    {
        public int x;
        public int y;
        public int size;
        public Image attackImg;

        public Attack(int x, int y)
        {
            attackImg = new Bitmap("C:\\Users\\smaks\\OneDrive\\Рабочий стол\\attack.png");
            this.x = x;
            this.y = y;
            size = 100;
        }
    }
}
