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
            graphics = grp;                   //setting the graphics object to the graphics object of the form where the board will be created
            boardPosition = new Point(0, 0);        //setting the initial position to (0,0)
        }

        public Point PositionBoard                      //Properties for setting and getting the location of Board
        {
            get
            {
                return boardPosition;
            }
            set
            {
                boardPosition = value;
            }
        }

        public void drawBoard(int width, int height, Color color, float penwidth)
        {
            boardColor = color;
            penWidth = penwidth;

            Pen boardDrawPen = new Pen(boardColor, penWidth);

            for (int i = 0; i < 5; i++)
            {
                graphics.DrawLine(boardDrawPen, boardPosition.X, boardPosition.Y + i * (height / 4), boardPosition.X + width, boardPosition.Y + i * (height / 4));
                graphics.DrawLine(boardDrawPen, boardPosition.X + i * (width / 4), boardPosition.Y, boardPosition.X + i * (width / 4), boardPosition.Y + height);
            }

        }
        private Graphics graphics;
        private Point boardPosition;                //the board position's point(x,y)
        private Color boardColor;                   //board's boarder color
        private float penWidth;                       // how wide the line we want
    }
}
