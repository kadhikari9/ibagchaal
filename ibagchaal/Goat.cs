using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class Goat: Player
    {
        private BoardModel myParent;

        public Goat(int xp, int yp, BoardModel mod)
        {

            Player(xp, yp, BoardModel);
        }

        public int getMyId()
        {
            return BoardModel.GOAT;
        }

    }
}
