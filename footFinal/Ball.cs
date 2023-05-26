using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace footFinal
{
    public class Ball
    {
        float PositionX;
        float PositionY;
        float Width;
        float Height;
        Image ImgBall;

        public Ball(float positionX, float positionY, float width, float height, Image imgBall)
        {
            this.setPositionX(positionX);
            this.setPositionY(positionY);
            this.setWidth(width);
            this.setHeight(height);
            this.setImgBall(imgBall);
        }

        public void setPositionX(float positionX)
        {
            this.PositionX = positionX;
        }

        public void setPositionY(float positionY)
        {
            this.PositionY = positionY;
        }

        public void setWidth(float width)
        {
            this.Width = width;
        }

        public void setHeight(float height)
        {
            this.Height = height;
        }

        public void setImgBall(Image imgBall)
        {
            this.ImgBall = imgBall;
        }

        public float getPositionX()
        {
            return this.PositionX;
        }

        public float getPositionY()
        {
            return this.PositionY;
        }

        public float getWidth()
        {
            return this.Width;
        }

        public float getHeight()
        {
            return this.Height;
        }

        public Image getImgBall()
        {
            return this.ImgBall;
        }

        public Pion getPionPassageBall(Joueur joueur)
        {
            List<Pion> listePion1 = joueur.getListePion();
            for (int i=0;i<listePion1.Count;i++)
            {
                if (listePion1[i].IfIntersecteBall(this,20))
                {
                    return listePion1[i];
                }
            }
            return null;
        }
    }
}
