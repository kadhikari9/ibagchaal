using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class Tiger:Player,ICloneable
    {
      
        private static int tigerId=0;
        private int myId;
        public Tiger(int xP, int yP): base(xP, yP)
        {
            
            myId = tigerId++;
        }
                
        public bool isBlocked(BoardModel myParent)
        {
            if ((xPos+yPos)%2!=0 && myParent.isPositionOccupied(xPos, yPos - 1) && myParent.isPositionOccupied(xPos, yPos + 1) &&
                myParent.isPositionOccupied(xPos-1, yPos ) && myParent.isPositionOccupied(xPos + 1, yPos) && myParent.isPositionOccupied(xPos, yPos - 2) && myParent.isPositionOccupied(xPos, yPos + 2) &&
                myParent.isPositionOccupied(xPos-2, yPos ) && myParent.isPositionOccupied(xPos + 2, yPos))
                return true;
            else if((xPos+yPos)%2==0 && myParent.isPositionOccupied(xPos - 1, yPos - 1) && myParent.isPositionOccupied(xPos + 1, yPos + 1) &&
                myParent.isPositionOccupied(xPos - 1, yPos + 1) && myParent.isPositionOccupied(xPos + 1, yPos - 1) && myParent.isPositionOccupied(xPos, yPos - 1) && myParent.isPositionOccupied(xPos, yPos + 1) &&
                myParent.isPositionOccupied(xPos - 1, yPos) && myParent.isPositionOccupied(xPos + 1, yPos) && myParent.isPositionOccupied(xPos, yPos - 2) && myParent.isPositionOccupied(xPos, yPos + 2) &&
                myParent.isPositionOccupied(xPos-2, yPos ) && myParent.isPositionOccupied(xPos + 2, yPos) && myParent.isPositionOccupied(xPos - 2, yPos - 2) && myParent.isPositionOccupied(xPos + 2, yPos + 2) &&
                myParent.isPositionOccupied(xPos - 2, yPos + 2) && myParent.isPositionOccupied(xPos + 2, yPos - 2))
                return true;
            
            else
                return false;

        }
        public int getMyId()
        {
            return myId;
        }


       override public int getTag()
        {
            return BoardModel.TIGER;
        }
       public object Clone()
       {
           return new Tiger(xPos, yPos);
       }
    }
}

