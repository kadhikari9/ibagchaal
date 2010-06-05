using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class Goat: Player
    {
        private BoardModel myParent;
        private static int goatId = 0;
        private int myId;

        public Goat(int xp, int yp, BoardModel mod)
        {

            Player(xp, yp, BoardModel);
            myId = goatId++;
        }

        public int getTag()
        {
            return BoardModel.GOAT;
        }

    }
}
