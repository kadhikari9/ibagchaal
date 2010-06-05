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
            tigers[0] = new Tiger(0, 0, this);
            tigers[1] = new Tiger(0, 4, this);
            tigers[2] = new Tiger(4, 0, this);
            tigers[3] = new Tiger(4, 4, this);
            board[0, 0] = TIGER;
            board[4, 4] = TIGER;
            board[0, 4] = TIGER;
            board[4, 0] = TIGER;
            
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
                goats[goatCount++] = new Goat(i, j, this);
                board[i, j] = GOAT;
                if (checkGameOver())
                    notifyObservers(Notifications.GAME_OVER);
                else
                    notifyObservers(Notifications.GOAT_PLACED);
            }
        }

        public void moveTiger(Tiger t, int k, int l)
        {
            if (isPositionOccupied(k, l))
            {
                notifyObservers(Notifications.ILLEGAL_MOVE);
            }
            else if (!checkMove(t.getXPos, t.getYPos, k, l))
            {
                notifyObservers(Notifications.ILLEGAL_MOVE);
            }
            else
            {
                board[t.getXPos, t.getYPos] = 0;
                board[k, l] = t.getTag() ;
                t.setPos(k, l);
                notifyObservers(Notifications.TIGER_MOVED);
            }
                
        }

        public bool checkMove(int i, int j, int k, int l)
        {
            if (i + 1 == k && j = l)
                return true;
            else if (i - 1 == k && j = l)
                return true;
            else if(i+1==k&& j+1==k)
                return true;
            else if(i+1==k && j-1==k)
                return true;
            else if (i  == k && j = l+1)
                return true;
            else if (i  == k && j-1 = l)
                return true;
            else if (i - 1 == k && j + 1 == l)
                return true;
            else if (i - 1 == k && j - 1 == l)
                return true;
            else
                return false;


        }

        public void captureGoat(Tiger t, Goat g)
        {


        }

        public void moveGoat(Goat g, int k, int l)
        {
            if (isPositionOccupied(k, l))
            {
                notifyObservers(Notifications.ILLEGAL_MOVE);
            }
            else if (!checkMove(g.getXPos, g.getYPos, k, l))
            {
                notifyObservers(Notifications.ILLEGAL_MOVE);
            }
            else
            {
                board[g.getXPos, g.getYPos] = 0;
                board[k, l] = t.getTag();
                g.setPos(k, l);
                notifyObservers(Notifications.GOAT_MOVED);
            }

        }

        public bool checkGameOver()
        {
            for (int i = 0; i < 4; i++)
            {
                if (!tigers[i].isBlocked)
                    return false;
            }
            return true;

        }
        

        public  bool isPositionOccupied(int i, int j)
        {
            if (i < 0 || j < 0||i>4 ||j>4) 
            {
                return true;

            }
            else if (board[i, j] == EMPTY)
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
        private int goatCount = 0;
        private int remainingGoats = 20;
        private static int boardSize = 5;
        public static int TIGER = -1;
        public static int GOAT = 1;
        public static int EMPTY = 0;
        public Tiger[] tigers;
        public Goat[] goats;


    }
 

}
