using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class PlayerCave
    {
        public int x;
        public int y;
        public Size scale;
        public Image playerCaveImg;

        //public Image animatedPlayerLeftImg;

        public PlayerCave(Size scale, int x, int y, Image playerCaveImg)
        {
            this.playerCaveImg = playerCaveImg;
            this.x = x;
            this.y = y;
            this.scale = scale;

        }
    }
}
