using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class Goat: Player
    {
      
        private static int goatId = 0;
        private int myId;

        public Goat(int xp, int yp, BoardModel mod):base(xp,yp,mod)
        {

            myId = goatId++;
            myParent = mod;
        }

       override public int getTag()
        {
            return BoardModel.GOAT;
        }

    }
}
