using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace footFinal
{
    public class Pion
    {
        float PositionX;
        float PositionY;
        float Width;
        float Height;
        Image ImgPion;
        int Poste;

        public Pion(float positionX, float positionY, float width, float height, Image imgPion,int poste)
        {
            this.setPositionX(positionX);
            this.setPositionY(positionY);
            this.setWidth(width);
            this.setHeight(height);
            this.setImgPion(imgPion);
            this.setPoste(poste);
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

        public void setImgPion(Image imgPion)
        {
            this.ImgPion = imgPion;
        }

        public void setPoste(int poste)
        {
            this.Poste = poste;
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

        public Image getImgPion()
        {
            return this.ImgPion;
        }

        public int getPoste()
        {
            return this.Poste;
        }

        public float differenceAbsolue(float a,float b)
        {
            float c = a - b;
            if (c<0)
            {
                return -c;
            }
            return c;
        }

        public bool IfIntersecteBall(Ball BallFoot,double distance)
        {
            float differenceX = this.differenceAbsolue(this.getPositionX(), BallFoot.getPositionX());
            float differenceY = this.differenceAbsolue(this.getPositionY(), BallFoot.getPositionY());
            if (differenceX<distance && differenceY < distance)
            {
                return true;
            }
            return false;
        }
    }
}
