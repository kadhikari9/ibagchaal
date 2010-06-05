using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class Tiger:Player
    {
      
        public Tiger(int xP, int yP, BoardModel parent)
        {
            Player(xP, yP, parent);
        }

        public bool isBlocked(int[,] board)
        {
            if (myParent.isPositionOccupied(xPos - 1, yPos - 1) || myParent.isPositionOccupied(xPos + 1, yPos + 1) ||
                myParent.isPositionOccupied(xPos, yPos - 1) || myParent.isPositionOccupied(xPos, yPos + 1) ||
                myParent.isPositionOccupied(xPos-1, yPos ) || myParent.isPositionOccupied(xPos + 1, yPos))
                return true;
            else
                return false;

        }


        public int getMyId()
        {
            return BoardModel.TIGER;
        }
    }
}
