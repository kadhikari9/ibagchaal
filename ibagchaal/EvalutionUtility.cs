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
            Tiger[] t = p.getTigers();
            int count=0;
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i].isBlocked(p.boardModel))
                {
                    count++;
                }
            }
            float v =(float)Math.Pow(count, 4);
            float value = 4*v+ count * count * count + 2 * count;
            if (value > 1000)
                return 1000;
            else
                return value;
        }
        public  float noOfGoatsCaptured()
        {
            int c=p.boardModel.goatsCaptured;
            float value = 20 * (float)Math.Pow(c, c);
            if (value > 1000)
                return -1000;
            else
                return -value;
        }

        public  float noOfPosCheckedByTiger()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                Tiger t = p.boardModel.tigers[i];
                int tx = t.getXPos();
                int ty = t.getYPos();
                int[,] b=p.boardModel.getboard();
                if (tx + 2 < 5)
                {
                    if (b[tx + 2,ty] == 0 && b[tx + 1,ty] == 1)
                        count++;

                    if (ty - 2 >= 0)
                    {
                        if (b[tx+2, ty - 2] == 0 && b[tx+1, ty - 1] == 1)
                            count++;
                    }
                    if (ty + 2 < 5)
                    {
                        if (b[tx+2, ty + 2] == 0 && b[tx+1, ty + 1] == 1)
                            count++;
                    }
                }
                if (ty + 2 < 5)
                {
                    if (b[tx, ty + 2] == 0 && b[tx, ty + 1] == 1)
                        count++;
                }
                if (tx - 2 >=0)
                {
                    if (b[tx - 2, ty] == 0 && b[tx - 1, ty] == 1)
                        count++;
                    if (ty - 2 >= 0)
                    {
                        if (b[tx - 2, ty - 2] == 0 && b[tx - 1, ty - 1] == 1)
                            count++;
                    }
                    if (ty + 2 < 5)
                    {
                        if (b[tx - 2, ty + 2] == 0 && b[tx - 1, ty + 1] == 1)
                            count++;
                    }

                }
                if (ty - 2 >=0)
                {
                    if (b[tx, ty - 2] == 0 && b[tx, ty - 1] == 1)
                        count++;
                }

            }
            float retvalue = count * 250;
            if (retvalue > 1000)
                return -1000;
            else
                return -retvalue;
        }
        /*
        public  float noOfSafeMovesForGoat() // think it is not needed
        {
            return 0;
        }
          */
        public float noOfGoatsOnCorner()
        {
            int c = 0;
            int[,] myboard = p.boardModel.getboard();

            if (myboard[0,0] == 1) { c++; }
            if (myboard[4,4] == 1) { c++; }
            if (myboard[0,4] == 1) { c++; }
            if (myboard[4,0] == 1) { c++; }
            return 50 * c;
           
        }

        public float noOfTigersOnCorner()
        {
            int c = 0;
            int[,] myboard = p.boardModel.getboard();

            if (myboard[0,0] == -1) { c++; }
            if (myboard[4,4] == -1) { c++; }
            if (myboard[0,4] == -1) { c++; }
            if (myboard[4,0] == -1) { c++; }
            return -100 * c;
        }

        public  float noOfGoatsOnEdge()
        {
            int count=0;
            int[,] myboard = p.boardModel.getboard();
            for(int i=0;i<5;i++)
            {
                for (int j=0;j<5;j++)
                {
                    if(i==0 || j==0 && i!=j) {
                        if (myboard[i,j] == 1)
                            count++;
                    }

                }
            }
            return 25 * count;
        }

        public float noOfTigersOnEdge()
        {
            int count = 0;
            int[,] myboard = p.boardModel.getboard();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 0 || j == 0 && i!=j)
                    {
                        if (myboard[i,j] == 1)
                            count++;
                    }

                }
            }
            return -50* count;
        }

        public  float emptyPointsSurroundedByGoats() //have to discuss later hai about this 
        {
            int[,] b = p.boardModel.getboard();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                }
            }

            return 0;

        }

        public float goatsOnBoard()
        {
            int v = p.boardModel.goatCount;
            v = 25 * v;
            if (v > 1000)
                return 1000;
            else
              return v;
        }

        public float evaluateBoard()
        {
            float x1 = getNumberOfTigerBlocked();
            float x2 = noOfGoatsCaptured();
            float x3 = goatsOnBoard();
            float x4 = emptyPointsSurroundedByGoats();
            float x5 = noOfGoatsOnEdge();
            float x8 = noOfGoatsOnCorner();
            float x6 = noOfTigersOnCorner();
            float x7 = noOfTigersOnEdge();
            
            float x9 = noOfPosCheckedByTiger();
            float value = x1 + x2 + x3 + x4+x5 + x6 + x7 + x8 + x9;
            if (value > 1000)
                return 1000;
            if (value < -1000)
                return -1000;
            else
                return value;
        }

        private Boardposition p;
    }
}
