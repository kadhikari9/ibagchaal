using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class Tiger
    {
        private BoardModel myParent;

        public Tiger(int xP, int yP, BoardModel parent)
        {
            xP = xPos;
            yP = yPos;
            myParent = parent;
        }

        public bool isBlocked(int[,] board)
        {
            if (myParent.isPositionOccupied(xPos - 1, yPos - 1) || myParent.isPositionOccupied(xPos + 1, yPos + 1) ||
                myParent.isPositionOccupied(xPos, yPos - 1) || myParent.isPositionOccupied(xPos + 1, yPos + 1))
                return true;
            else
                return false;

        }

        public int getXPos()
        {
            return xPos;
        }

        public int getYPos()
        {
            return yPos;
        }

        public int setXPos(int xp)
        {
            xPos = xp;
        }

        public int setYPos(int yp)
        {
            yPos = yp;
        }

        public int getMyId()
        {
            return BoardModel.TIGER;
        }

        int xPos, yPos;
    }
}
