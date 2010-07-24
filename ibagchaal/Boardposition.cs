using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class Boardposition
    {
        Boardposition(int t,int m,BoardModel b)
        {
            turn = t;
            mode = m;
            boardModel = b;
            board = b.getboard();
            tigers = b.tigers;
            goats = new Goat[20];
            numMoves = 0;
            nextPosition = new System.Collections.ArrayList();
        }

        
        public void findMoves()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //get an empty space
                    if (board[i, j] == BoardModel.EMPTY)
                    {
                        if (turn == BoardModel.TIGER)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                if(boardModel.checkMove(tigers[k].getXPos(),tigers[k].getYPos(),i,j)==true)
                                {
                                    BoardModel temp = boardModel;
                                    temp.moveTiger(tigers[k], i, j);
                                    Boardposition newPosition = new Boardposition(-(turn), mode, temp);
                                    nextPosition.Add(newPosition);
                                    numMoves++;
                                }
                            }
                        }

                        else if (turn == BoardModel.GOAT)
                        {
                            if (mode == 0)  //supposing Placement mode = 0
                            {
                                BoardModel temp = boardModel;
                                temp.placeGoat(i, j);
                                Boardposition newPosition = new Boardposition(-(turn), mode, temp);
                                nextPosition.Add(newPosition);
                                numMoves++;
                            }
                            else            //for the sliding mode
                            {
                                foreach (Goat newgoat in goats)
                                {
                                    if (boardModel.checkMove(newgoat.getXPos(), newgoat.getYPos(), i, j) == true)
                                    {
                                        BoardModel temp = boardModel;
                                        temp.moveGoat(newgoat, i, j);
                                        Boardposition newPostition = new Boardposition(-(turn), mode, temp);
                                        numMoves++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private Tiger[] tigers;
        private Goat[] goats;
        private BoardModel boardModel;
        private int turn;
        private int mode;
        private int[,] board;
        private int numMoves;
        private System.Collections.ArrayList nextPosition;

    }
}
