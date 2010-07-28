using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class  Boardposition
    {
        public Boardposition()
        {
        }
        public Boardposition(int t,int m,BoardModel b)
        {
            turn = t;
            mode = m;
            boardModel = b;
            board = b.getboard();
            tigers = b.tigers;
            goats = b.goats;
            numMoves = 0;
            nextPosition = new System.Collections.ArrayList();
        }

        public void setParams(int t, int m, BoardModel b)
        {
            turn = t;
            mode = m;
            boardModel = (BoardModel)b.Clone();
           

            board = boardModel.getboard();
            tigers = boardModel.tigers;
            goats = boardModel.goats;
            numMoves = 0;
            nextPosition = new System.Collections.ArrayList();
        }
        public void findMoves()
        {
            depth++;
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
                                    
                                    BoardModel temp = (BoardModel)boardModel.Clone();
                                    temp.moveTiger(temp.tigers[k], i, j);
                                    Boardposition newPosition = new Boardposition(-(turn), mode, new BoardModel(temp));
                                    newPosition.Depth = depth;
                                    nextPosition.Add(newPosition);
                                    numMoves++;
                                }
                            }
                        }

                        else if (turn == BoardModel.GOAT)
                        {
                            if (mode == 0)  //supposing Placement mode = 0
                            {
                                BoardModel temp = (BoardModel)boardModel.Clone();
                                temp.placeGoat(i, j);
                                Boardposition newPosition = new Boardposition(-(turn), mode, new BoardModel(temp));
                                newPosition.Depth = depth;
                                nextPosition.Add(newPosition);
                                numMoves++;
                            }
                            else            //for the sliding mode
                            {
                                foreach (Goat newgoat in goats)
                                {
                                    if (boardModel.checkMove(newgoat.getXPos(), newgoat.getYPos(), i, j) == true)
                                    {
                                        BoardModel temp = (BoardModel)boardModel.Clone();
                                        temp.moveGoat(newgoat.Clone() as Goat, i, j);
                                        Boardposition newPosition = new Boardposition(-(turn), mode, new BoardModel(temp));
                                        newPosition.Depth = depth;
                                        nextPosition.Add(newPosition);
                                        numMoves++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public float Utility
        {
            set { utility = value; }
            get { return utility; }
        }

        public int Depth
        {
            get { return depth; }
            set { depth = value; }
        }
        private float utility;
        private int depth=0;
        private Tiger[] tigers;
        private System.Collections.ArrayList goats;
        public BoardModel boardModel;
        private int turn;
        private int mode;
        private int[,] board;
        private int numMoves;
        public System.Collections.ArrayList nextPosition;

    }
}
