using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class Tiger
    {
        public Tiger(int xP, int yP)
        {
            xP = xPos;
            yP = yPos;
        }

        public bool isBlocked(int[,] board)
        {
            if (BoardModel.isPositionOccupied(xPos - 1, yPos - 1) || BoardModel.isPositionOccupied(xPos + 1, yPos + 1) ||
                BoardModel.isPositionOccupied(xPos, yPos - 1) || BoardModel.isPositionOccupied(xPos + 1, yPos + 1))
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
