using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class BoardModel: ICloneable,ISubject
    {
        public BoardModel()
        {
           
            //initialize the position of tigers;
            resetBoard();
            
        }
        public BoardModel(BoardModel other)
        {
            resetBoard();
            for(int i=0;i<5;i++)
                for(int j=0;j<5;j++)
                    this.board[i,j] = other.board[i,j];
            
          //  for(int i=0;i<other.boardViews.Count;i++)
           //     this.boardViews.Add(other.boardViews[i]);

            for(int i=0;i<4;i++)
                this.tigers[i] = (Tiger)other.tigers[i].Clone();

            this.goatCount = other.goatCount;

            Object[] tempGoats = other.goats.ToArray();
            for (int i = 0; i < other.goats.Count; i++)
            {
                this.goats.Add(((Goat)tempGoats[i]).Clone());
            }

            this.goatsCaptured = other.goatsCaptured;
            this.remainingGoats = other.remainingGoats;
            this.turn = other.turn;
            this.player = other.player;
        }
        public void copyEverything(BoardModel other)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    this.board[i, j] = other.board[i, j];

        //    for (int i = 0; i < other.boardViews.Count; i++)
         //       this.boardViews.Add(other.boardViews[i]);

            for (int i = 0; i < 4; i++)
                this.tigers[i] = (Tiger)other.tigers[i].Clone();

            this.goatCount = other.goatCount;
            this.goats.Clear();
            Object[] tempGoats = other.goats.ToArray();
            for (int i = 0; i < other.goats.Count; i++)
            {
                this.goats.Add(((Goat)tempGoats[i]).Clone());
            }

            this.goatsCaptured = other.goatsCaptured;
            this.remainingGoats = other.remainingGoats;
            this.turn = other.turn;
            this.player = other.player;
        }
        public void resetBoard()
        {
            board = new int[boardSize, boardSize];
            tigers = new Tiger[4];
            goats = new System.Collections.ArrayList();

            for (int i = 0; i < 5; i++)
            {
               
                for (int j = 0; j < 5; j++)
                {
                    board[i,j] = 0;
                }
            }
            tigers[0] = new Tiger(0, 0);
            tigers[1] = new Tiger(0, 4);
            tigers[2] = new Tiger(4, 0);
            tigers[3] = new Tiger(4, 4);
            board[0, 0] = TIGER;
            board[4, 4] = TIGER;
            board[0, 4] = TIGER;
            board[4, 0] = TIGER;
            
            boardViews = new System.Collections.ArrayList();
        }

        public void placeGoat(int i, int j) //place goat on specified board position
        {
            if (remainingGoats == 0)
            {
                notifyObservers(Notifications.ALL_GOATS_PLACED);
            }

            else if (isPositionOccupied(i, j))
            {
                notifyObservers(Notifications.ILLEGAL_MOVE);
            }
            else
            {
                Goat newgoat = new Goat(i, j);
                goats.Add(newgoat);
                board[i, j] = GOAT;
                goatCount++;
                remainingGoats--;
                turn = -(turn);
                if (checkGameOver()==1)
                    notifyObservers(Notifications.GAME_OVER_GOAT_WIN);
                else
                    notifyObservers(Notifications.GOAT_PLACED);
            }
        }

        public object Clone()
        {
            return new BoardModel(this);
        }

        public void moveTiger(Tiger t, int k, int l) //move tiger into the postion
        {
            if (isPositionOccupied(k, l))
            {
                notifyObservers(Notifications.ILLEGAL_MOVE);
            }
            else if (!checkMove(t.getXPos(), t.getYPos(), k, l))
            {
                notifyObservers(Notifications.ILLEGAL_MOVE);
            }
            else
            {
                board[t.getXPos(), t.getYPos()] = 0;
                board[k, l] = t.getTag() ;
                if (stateCapture == true)
                {
                    captureGoat(t, getGoatAt(capPosX, capPosY), k, l);
                    stateCapture = false;
                }
                t.setPos(k, l);
                turn = -(turn);
                notifyObservers(Notifications.TIGER_MOVED);
            }
                
        }

        public bool checkMove(int i, int j, int k, int l) //check legal moves
        {
            if (i + 1 == k && j == l)
                return true;
            else if (i - 1 == k && j == l)
                return true;
            else if (i  == k && j-1 == l)
                return true;
            else if (i  == k && j+1 == l)
                return true;
            if ((i + j) % 2 == 0)
            {
                if (i + 1 == k && j + 1 == l)
                    return true;
                else if (i + 1 == k && j - 1 == l)
                    return true;
                else if (i - 1 == k && j + 1 == l)
                    return true;
                else if (i - 1 == k && j - 1 == l)
                    return true;
            }
            if (turn == TIGER)
            {
                if (i + 2 == k && j == l && board[i + 1, j] == BoardModel.GOAT)
                {
                    //captureGoat(getTigerAt(i, j), getGoatAt(i + 1, j), k, l);
                    capPosX = i + 1;
                    capPosY = j;
                    stateCapture = true;
                    return true;
                }
                else if (i - 2 == k && j == l && board[i - 1, j] == BoardModel.GOAT)
                {
                    //captureGoat(getTigerAt(i, j), getGoatAt(i - 1, j), k, l);
                    capPosX = i - 1;
                    capPosY = j;
                    stateCapture = true;
                    return true;
                }
                else if (i == k && j - 2 == l && board[i, j - 1] == BoardModel.GOAT)
                {
                    //captureGoat(getTigerAt(i, j), getGoatAt(i , j-1), k, l);
                    capPosX = i;
                    capPosY = j - 1;
                    stateCapture = true;
                    return true;
                }
                else if (i == k && j + 2 == l && board[i, j + 1] == BoardModel.GOAT)
                {
                    //captureGoat(getTigerAt(i, j), getGoatAt(i , j+1), k, l);
                    capPosX = i;
                    capPosY = j + 1;
                    stateCapture = true;
                    return true;
                }
                if ((i + j) % 2 == 0)
                {
                    if (i + 2 == k && j + 2 == l && board[i + 1, j + 1] == BoardModel.GOAT)
                    {
                        //captureGoat(getTigerAt(i, j), getGoatAt(i + 1, j+1), k, l);
                        capPosX = i + 1;
                        capPosY = j + 1;
                        stateCapture = true;
                        return true;
                    }
                    else if (i + 2 == k && j - 2 == l && board[i + 1, j - 1] == BoardModel.GOAT)
                    {
                        //captureGoat(getTigerAt(i, j), getGoatAt(i + 1, j-1), k, l);
                        capPosX = i + 1;
                        capPosY = j - 1;
                        stateCapture = true;
                        return true;
                    }
                    else if (i - 2 == k && j + 2 == l && board[i - 1, j + 1] == BoardModel.GOAT)
                    {
                        //captureGoat(getTigerAt(i, j), getGoatAt(i - 1, j+1), k, l);
                        capPosX = i - 1;
                        capPosY = j + 1;
                        stateCapture = true;
                        return true;
                    }
                    else if (i - 2 == k && j - 2 == l && board[i - 1, j - 1] == BoardModel.GOAT)
                    {
                        //captureGoat(getTigerAt(i, j), getGoatAt(i - 1, j-1), k, l);
                        capPosX = i - 1;
                        capPosY = j - 1;
                        stateCapture = true;
                        return true;
                    }
                }                
            }

            return false;


        }
        //capture goat g from tiger t x,y are final positon of tigers
        //hint: use getGoatAt(x,y) to get a goat at the specified postion

        public void captureGoat(Tiger t, Goat g,int x,int y) 
        {
      /*      if (!checkMove(t.getXPos(), t.getYPos(), g.getXPos(), g.getYPos()))
            {
                notifyObservers(Notifications.ILLEGAL_MOVE);
            }

            else if (board[x, y] != EMPTY)
            {
                notifyObservers(Notifications.ILLEGAL_MOVE);
            }


            else*/
            {
                goatCount--;
                board[g.getXPos(), g.getYPos()] = 0;
                goats.Remove(g);
                if (checkGameOver() == -1)
                {
                    notifyObservers(Notifications.GAME_OVER_TIGER_WIN);
                }
                else 
                    notifyObservers(Notifications.GOAT_CAPTURED);
            }
        }

        public void moveGoat(Goat g, int k, int l)
        {
            if (isPositionOccupied(k, l))
            {
                notifyObservers(Notifications.ILLEGAL_MOVE);
            }
            else if (!checkMove(g.getXPos(), g.getYPos(), k, l))
            {
                notifyObservers(Notifications.ILLEGAL_MOVE);
            }
            else
            {
                board[g.getXPos(), g.getYPos()] = 0;
                board[k, l] = g.getTag();
                g.setPos(k, l);
                turn = -(turn);
                if(checkGameOver()==1)
                    notifyObservers(Notifications.GAME_OVER_GOAT_WIN);
             //   else if (checkGameOver() == -1)
               // {
               //     notifyObservers(Notifications.GAME_OVER_TIGER_WIN);
              //  }
                else
                    notifyObservers(Notifications.GOAT_MOVED);
            }

        }

        public int checkGameOver() // checks if game has been over.
        {
            if (goatsCaptured > 5)
                return -1; //goat win
            int temp = 1;
            for (int i = 0; i < 4; i++)
            {
                if (!tigers[i].isBlocked(this))
                {
                    temp = 0;
                    break;
                }
            }
            if (temp == 1) return 1;
            return 0; //draw

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

            if (AIPLAYER != 1)
            {
                for (int i = 0; i < boardViews.Count; i++)
               {
                    IObserver curr = boardViews[0] as IObserver;
                    curr.update(notificationType, this);
                }
            }
            
        }

        public Tiger getTigerAt(int x, int y)
        {
            
            for (int i = 0; i < 4; i++)
            {
                Tiger currentTiger=tigers[i];
                if (currentTiger.getXPos() == x && currentTiger.getYPos() == y)
                    return currentTiger;    
            }
            return null;
                
        }
        public void setBoard(int[,] b)
        {
            board = b;
        }
        public Goat getGoatAt(int x, int y)
        {
            for (int i = 0; i < goatCount; i++)
            {
                Goat currentGoat = (Goat)goats[i];
                if (currentGoat.getXPos() == x && currentGoat.getYPos() == y)
                    return currentGoat;
            }
            return null;
        }

        public int[,] getboard()
        {
            return board;
        }
        public int returnPlayer()
        {
            return turn;
        }
        public void setPlayer(int t)
        {
            turn = t;
        }
        public int AIPLAYER
        {
            set { player = value; }
            get { return player; }
        }
        private System.Collections.ArrayList boardViews;
        public System.Collections.ArrayList goats;
        private int[,] board;
        private int goatCount = 0;
        private int remainingGoats = 20;
        private static int boardSize = 5;
        public static int TIGER = -1;
        public static int GOAT = 1;
        public static int EMPTY = 0;
        public Tiger[] tigers;
        public int goatsCaptured = 0;
        private int capPosX;
        private int capPosY;
        public bool stateCapture = false;
        public static int OPPONENT = TIGER;
        public static int PLAYER = GOAT;
        private int turn=GOAT;
        private int player = 0;

    }
 

}
