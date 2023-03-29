using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class NPC
    {
        public float x;
        public float y;
        public int size;
        public Image npcImg;

        public NPC(int x, int y)
        {
            npcImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\NPC.png");
            this.x = x;
            this.y = y;
            size = 200;
        }
    }
}
