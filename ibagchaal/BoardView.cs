using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace ibagchaal
{
    class BoardView: IObserver
    {
        public BoardView(Graphics grp)
        {
            graphics = grp;                         //setting the graphics object to the graphics object of the form where the board will be created
            boardPosition = new Point(0, 0);        //setting the initial position to (0,0)

            tigerBitmap = new Bitmap("Tiger.jpg");
            tigerBitmap.MakeTransparent(Color.White);
            
            goatBitmap = new Bitmap("goat.jpg");
            goatBitmap.MakeTransparent(Color.White);
        }

        public Point PositionBoard                      //Properties for setting and getting the location of Board
        {
            get
            {
                return boardPosition;
            }
            
        }
        public Point ScreenSize
        {
            set
            {
                screenSize = value;
            }
        }

        public void calculateBoardPosition()
        {
            boardPosition.X = screenSize.X / 2 - width / 2;
            boardPosition.Y = screenSize.Y / 2 - height / 2;
            
        }

        public void drawBoard(Color color, float penwidth)
        {
            boardColor = color;
            penWidth = penwidth;

            Pen boardDrawPen = new Pen(boardColor, penWidth);

            for (int i = 0; i < 5; i++)
            {
                graphics.DrawLine(boardDrawPen, boardPosition.X, boardPosition.Y + i * (height / 4), boardPosition.X + width, boardPosition.Y + i * (height / 4));
                graphics.DrawLine(boardDrawPen, boardPosition.X + i * (width / 4), boardPosition.Y, boardPosition.X + i * (width / 4), boardPosition.Y + height);
            }

            graphics.DrawLine(boardDrawPen, boardPosition.X, boardPosition.Y, boardPosition.X + width, boardPosition.Y + height);
            graphics.DrawLine(boardDrawPen, boardPosition.X + width, boardPosition.Y, boardPosition.X, boardPosition.Y + height);

            for (int i = 0; i < 2; i++)
            {
                graphics.DrawLine(boardDrawPen, boardPosition.X, boardPosition.Y + (height / 2), boardPosition.X + (width / 2), boardPosition.Y + (height * i));
                graphics.DrawLine(boardDrawPen, boardPosition.X + width, boardPosition.Y + (height / 2), boardPosition.X + (width / 2), boardPosition.Y + (height * i));

            }
        }

        public void placeCursor(int xP, int yP)
        {
            xP = boardPosition.X + xP * (width / 4);
            yP = boardPosition.Y + yP * (height / 4);
            Pen drawCursorPen = new Pen(Color.Blue, 4);
            try
            {
                graphics.DrawRectangle(drawCursorPen, xP - (cursorWidth / 2), yP - (cursorHeight / 2), cursorWidth, cursorHeight);    
            }
            catch (ArgumentException argException)
            {

            }
            
        }
        
        public void placeTiger(int xP,int yP)
        {
            try
            {
                graphics.DrawImage(tigerBitmap, new Rectangle(xP - (imageWidth / 2), yP - (imageHeight / 2), imageWidth, imageHeight));
            }
            catch (ArgumentException argException)
            {
               
            }
        }
        
        public void placeGoat(int xP, int yP)
        {
            try
            {
                graphics.DrawImage(goatBitmap, new Rectangle(xP - (imageWidth / 2), yP - (imageHeight / 2), imageWidth, imageHeight));
            }
            catch (ArgumentException argException)
            {

            }         
            
        }
        public void getBoard()
        {
            int X, Y;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    X = boardPosition.X + i * (width / 4);
                    Y = boardPosition.Y + j * (height / 4);
                    if (board[i, j] == BoardModel.GOAT) placeGoat(X, Y);
                    else if (board[i, j] == BoardModel.TIGER) placeTiger(X, Y);
                }
            }
        }

        public void update(String type,Object boardModel)
        {
            BoardModel boardMod = boardModel as BoardModel;
            //do change in view according to model
            
            if (type.Equals(Notifications.GOAT_MOVED) || type.Equals(Notifications.TIGER_MOVED))
            {
                board = boardMod.getboard();
                
            }        
        }
        private int[,] board;
        private Bitmap tigerBitmap;
        private Bitmap goatBitmap;
        private static int imageWidth = 120;
        private static int imageHeight = 120;
        private static int width = 600;
        private static int height = 600;
        private int cursorWidth=100;
        private int cursorHeight=100;
        private Graphics graphics;
        private Point boardPosition;                //the board position's point(x,y)
        private Point screenSize;
        private Color boardColor;                   //board's boarder color
        private float penWidth;                       // how wide the line we want
    }
}
