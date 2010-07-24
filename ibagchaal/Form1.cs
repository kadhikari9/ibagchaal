using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

namespace ibagchaal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            // this.TopMost = true;
            boardModel = new BoardModel();
            cursorPosX = 0;
            cursorPosY = 0;
            selectedTiger = new Tiger(0, 0, null);
            selectedGoat = new Goat(0, 0, null);
            g = this.CreateGraphics();
            boardView = new BoardView(g);
            Rectangle rect = SystemInformation.VirtualScreen;
            boardView.ScreenSize = new Point(rect.Right, rect.Bottom);
            boardView.calculateBoardPosition();
            boardModel.registerObserver(boardView);
            boardModel.notifyObservers(Notifications.GOAT_MOVED);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            boardView.placeCursor(cursorPosX, cursorPosY);
            boardView.drawBoard(Color.Black, 3);
            boardView.getBoard();
        }

        private Graphics g;         //to get graphics handler of this form that has already been created automatically.
        private BoardView boardView;
        private BoardModel boardModel;
        private int cursorPosX;
        private int cursorPosY;
        public static int PICKED = 1;
        public static int PLACED = 0;
        private int state = PLACED;
        private Tiger selectedTiger;
        private Goat selectedGoat;
        private int count = 0;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //      if (boardModel.returnPlayer() != BoardModel.OPPONENT)
            //    {
            if (e.KeyCode == Keys.Left)
            {
                if (cursorPosX != 0)
                {
                    cursorPosX--;


                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (cursorPosX != 4)
                {
                    cursorPosX++;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (cursorPosY != 0)
                {
                    cursorPosY--;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (cursorPosY != 4)
                {
                    cursorPosY++;
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (boardModel.returnPlayer() == BoardModel.TIGER)
                {
                    if (state == PLACED)
                    {
                        if (boardModel.getTigerAt(cursorPosX, cursorPosY) != null)
                        {
                            selectedTiger = boardModel.getTigerAt(cursorPosX, cursorPosY);
                            state = PICKED;
                        }
                        else
                        {
                            //some error message signifying wrong thing picked
                        }
                    }

                    else if (state == PICKED)
                    {
                        boardModel.moveTiger(selectedTiger, cursorPosX, cursorPosY);
                        state = PLACED;
                    }
                }

                else if (boardModel.returnPlayer() == BoardModel.GOAT)
                {
                    //work remaining here...a lot actually....
                    if (count < 20)
                    {
                        boardModel.placeGoat(cursorPosX, cursorPosY);
                        count++;
                    }
                    else
                    {
                        if (state == PLACED)
                        {
                            if (boardModel.getGoatAt(cursorPosX, cursorPosY) != null)
                            {
                                selectedGoat = boardModel.getGoatAt(cursorPosX, cursorPosY);
                                state = PICKED;
                            }
                            else
                            {
                                //some error message signifying wrong picked up
                            }
                        }
                        else if (state == PICKED)
                        {
                            boardModel.moveGoat(selectedGoat, cursorPosX, cursorPosY);
                            state = PLACED;
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }




            this.Invalidate();
        }
    }
}