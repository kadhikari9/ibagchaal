using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class BoardModel: ISubject
    {
        public BoardModel()
        {
           
            //initialize the position of tigers;
            resetBoard();
            
        }

        public void resetBoard()
        {
            board = new int[boardSize, boardSize];
            tigers = new Tiger[4];
            goats = new Goat[20];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    board[i,j] = 0;
                }
            }
            
            board[0, 0] = TIGER;
            board[4, 4] = TIGER;
            board[0, 4] = TIGER;
            board[4, 0] = TIGER;
            tigers[0].setPos(0, 0);
            tigers[1].setPos(4, 4);
            tigers[2].setPos(0, 4);
            tigers[3].setPos(4, 0);
            boardViews = new System.Collections.ArrayList();
        }

        public void placeGoat(int i, int j)
        {
            if (isPositionOccupied(i, j))
            {
                notifyObservers(Notifications.ILLEGAL_MOVE);
            }
            else
            {
                board[i, j] = GOAT;
                if (checkGameOver())
                    notifyObservers(Notifications.GAME_OVER);
                else
                    notifyObservers(Notifications.GOAT_PLACED);
            }
        }

        public void moveTiger(int i, int j, int k, int l)
        {


        }

        public void captureGoat(int i, int j, int k, int l)
        {


        }

        public void moveGoat(int i, int j, int k, int l)
        {


        }

        public bool checkGameOver()
        {
            for (int i = 0; i < 4; i++)
            {

            }
            return true;

        }
        

        public  bool isPositionOccupied(int i, int j)
        {
            if (board[i, j] == EMPTY)
            {
                return false;
            }
            else
                return true;
        }

        public void registerObserver(IObserver o) //register views for the boardmodel
        {
            boardViews.Add(o);
           
        }

        public void removeObserver(IObserver o)
        {
            boardViews.Remove(o);
        }

        //notify observers that the model has changed
        public void notifyObservers(String notificationType)
        {
            for (int i = 0; i < boardViews.Count; i++)
            {
                IObserver curr = boardViews[i] as IObserver;
                curr.update(notificationType);
            }
        }


        private System.Collections.ArrayList boardViews;
        private int[,] board;
        private static int boardSize = 5;
        public static int TIGER = -1;
        public static int GOAT = 1;
        public static int EMPTY = 0;
        public Tiger[] tigers;
        public Goat[] goats;

    }
 

}
