using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace ibagchaal
{
    class BoardView
    {
        public BoardView(Graphics grp)
        {
            graphics = grp;                         //setting the graphics object to the graphics object of the form where the board will be created
            boardPosition = new Point(0, 0);        //setting the initial position to (0,0)
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
        private static int width = 600;
        private static int height = 600;
        private Graphics graphics;
        private Point boardPosition;                //the board position's point(x,y)
        private Point screenSize;
        private Color boardColor;                   //board's boarder color
        private float penWidth;                       // how wide the line we want
    }
}
