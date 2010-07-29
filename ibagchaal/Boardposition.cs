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
            setParams(t, m, b);
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
            prevPosition = null;
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
                                    temp.setPlayer(BoardModel.TIGER);
                                    Boardposition tempPosition = new Boardposition((turn), mode, new BoardModel(temp));

                                    newPosition.prevPosition = this;
                                    if (temp.goatsCaptured > boardModel.goatsCaptured)
                                    {
                                        newPosition.boardModel.leadingToCapture++;
                                    }
                                    else
                                    {
                                        for (int xI = -2; xI <= 2; xI += 2)
                                        {
                                            for (int yJ = -2; yJ <= 2; yJ += 2)
                                            {
                                                if ((i + xI) >= 0 && (i + xI) <= 4 && (j + yJ) >= 0 && (j + yJ) <= 4)
                                                {
                                                    if (tempPosition.boardModel.checkMove(temp.tigers[k].getXPos(), temp.tigers[k].getYPos(), i + xI, j + yJ) == true)
                                                    {
                                                        newPosition.boardModel.leadingToThreat++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (i == 2 && j == 2)
                                        newPosition.boardModel.winningCenter++;
                                    
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
        public BoardModel calculateProbability()
        {
            Boardposition temp = (Boardposition)nextPosition[0];
            float probability = 1.0f/(float)(nextPosition.Count);
            float tempProb = 0.0f;
            float tempMax = 0.0f;
            foreach (Boardposition successor in nextPosition)
            {
                tempProb = probability;
                if (successor.boardModel.leadingToCapture > 0) tempProb += (CV*successor.boardModel.leadingToCapture);
                if (successor.boardModel.leadingToThreat > 0) tempProb += (TV * successor.boardModel.leadingToThreat);
                if (successor.boardModel.winningCenter > 0) tempProb += (WCV);
                if (tempMax == tempProb)
                {
                    Random rnd = new Random();
                    int num = rnd.Next(2);
                    if (num == 1)
                        temp = successor;
                }
                else
                {
                    tempMax = Math.Max(tempMax, tempProb);
                    if (tempMax == tempProb)
                        temp = successor;
                }
                
            }

            return (BoardModel)temp.boardModel.Clone();

        }
        public int Depth
        {
            get { return depth; }
            set { depth = value; }
        }
        public Tiger[] getTigers()
        {
            return tigers;
        }

        
        private float utility=0;
        private int depth=0;
        private Tiger[] tigers;
        private System.Collections.ArrayList goats;
        public BoardModel boardModel;
        private int turn;
        private int mode;
        private int[,] board;
        private int numMoves;
        public System.Collections.ArrayList nextPosition;
        public Boardposition prevPosition;
        public static float TV = 0.04f;
        public static float CV = 0.9f;
        public static float WCV = 0.01f;

    }
}
