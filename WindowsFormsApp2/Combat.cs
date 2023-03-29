using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Entity
    {
        public int posX;
        public int posY;

        public int dirX;
        public int dirY;
        public bool isMoving;

        public int flip;

        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;

        public int idleFrames;
        public int runFrames;
        public int deathFrames;

        public int size;

        public Image sprite;

        public Entity(int posX, int posY, int idleFrames, int runFrames, int deathFrames, Image sprite)
        {
            this.posX = posX;
            this.posY = posY;
            this.idleFrames = idleFrames;
            this.runFrames = runFrames;
            this.deathFrames = deathFrames;
            this.sprite = sprite;
            size = 135;
            currentAnimation = 0;
            currentFrame = 0;
            currentLimit = idleFrames;
            flip = 1;
        }

        public void Move()
        {
            posX += dirX;
            posY = dirY;
        }

        public void PlayAnimation(Graphics g)
        {
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else currentFrame = 0;

            g.DrawImage(sprite, new Rectangle(new Point(posX, posY), new Size(size, size)), 131f * currentFrame, 131 * currentAnimation, size, size, GraphicsUnit.Pixel);
        }

        public void SetAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    currentLimit = idleFrames;
                    break;
                case 1:
                    currentLimit = runFrames;
                    break;
                case 2:
                    currentLimit = deathFrames;
                    break;
                case 3:
                    currentLimit = idleFrames;
                    break;
                case 4:
                    currentLimit = runFrames;
                    break;

            }
        }
    }
}
