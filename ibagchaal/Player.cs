using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class Player
    {
        protected int xPos, yPos;
        protected BoardModel myParent;
       

        public Player(int xP, int yP, BoardModel parent)
        {
             xPos=xP;
            yPos=yP;
            myParent = parent;
        }

        public int getXPos()
        {
            return xPos;
        }

        public int getYPos()
        {
            return yPos;
        }

        public void setPos(int xp,int yp)
        {
            xPos = xp;
            yPos = yp;
        }


        public virtual int getTag()
        {
            return 0;
        }
       
    }
}
