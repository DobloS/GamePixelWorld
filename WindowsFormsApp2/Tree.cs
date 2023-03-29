using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Tree
    {
        public float x;
        public float y;
        public int size;
        public Image treeImg;

        public Tree(int x, int y)
        {
            treeImg = new Bitmap("C:\\Users\\smaks\\source\\repos\\WindowsFormsApp2\\WindowsFormsApp2\\Sprites\\Tree.png");
            this.x = x;
            this.y = y;
            size = 650;
        }
    }
}
