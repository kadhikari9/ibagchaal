using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class EvalutionUtility
    {
        public EvalutionUtility(Boardposition pp)
        {
            p = pp;
        }

        public float getNumberOfTigerBlocked()
        {
            Tiger[] t = p.getTigers;
            int count=0;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i].isBlocked)
                {
                    count++;
                }
            }
            float value = 4 * Math.Pow(count, 4) + count * count * count + 2 * count;
            return value;
        }
        public  float noOfGoatsCaptured()
        {
            int c=p.boardModel.goatsCaptured;
            float value = 20 * Math.Pow(c, c);
            return value;
        }

        public  float noOfPosCheckedByTiger()
        {

        }
        public  float noOfSafeMovesForGoat()
        {
        }
        public float noOfGoatsOnCorner()
        {
            int c = 0;
            int[,] myboard = p.boardModel.getboard();

            if (myboard[0][0] == 1) { c++; }
            if (myboard[4][4] == 1) { c++; }
            if (myboard[0][4] == 1) { c++; }
            if (myboard[4][0] == 1) { c++; }
            return 25 * c;
           
        }

        public float noOfTigersOnCorner()
        {
            int c = 0;
            int[,] myboard = p.boardModel.getboard();

            if (myboard[0][0] == -1) { c++; }
            if (myboard[4][4] == -1) { c++; }
            if (myboard[0][4] == -1) { c++; }
            if (myboard[4][0] == -1) { c++; }
            return 50 * c;
        }

        public  float noOfGoatsOnEdge()
        {
            int count=0;
            int[,] myboard = p.boardModel.getboard;
            for(int i=0;i<5;i++)
            {
                for (int j=0;j<5;j++)
                {
                    if(i==0 || j==0) {
                        if (myboard[i][j] == 1)
                            count++;
                    }

                }
            }
            return 15 * x;
        }

        public float noOfTigersOnEdge()
        {
            int count = 0;
            int[,] myboard = p.boardModel.getboard;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        if (myboard[i][j] == 1)
                            count++;
                    }

                }
            }
            return 25 * x;
        }

        public  float emptyPointsSurroundedByGoats()
        {

        }

        public float goatsOnBoard()
        {
            int v = p.boardModel.goatCount;
            return 15 * v;
        }

        public float evaluateBoard()
        {

        }

        private Boardposition p;
    }
}
