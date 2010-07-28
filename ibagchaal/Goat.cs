using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class Goat: Player,ICloneable
    {
      
        private static int goatId = 0;
        private int myId;

        public Goat(int xp, int yp):base(xp,yp)
        {

            myId = goatId++;
            
        }
        
       override public int getTag()
        {
            return BoardModel.GOAT;
        }
       public object Clone()
       {
           return new Goat(xPos, yPos);
       }

    }
}
