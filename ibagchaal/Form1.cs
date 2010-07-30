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
            selectedTiger = new Tiger(0, 0);
            selectedGoat = new Goat(0, 0);
            g = this.CreateGraphics();
            boardView = new BoardView(g);
            Rectangle rect = SystemInformation.VirtualScreen;
            boardView.ScreenSize = new Point(rect.Right, rect.Bottom);
            boardView.calculateBoardPosition();
            boardModel.registerObserver(boardView);
            boardModel.notifyObservers(Notifications.GOAT_MOVED);
            boardPosition = new Boardposition();
            minMaxSearch = new MinMax();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            boardView.placeCursor(cursorPosX, cursorPosY);
            boardView.drawBoard(Color.Black, 3);
            goatCapturedLabel.Text = boardModel.goatsCaptured.ToString();
            goatLeftLabel.Text = (20 - count).ToString();
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
        private Boardposition boardPosition;
        private MinMax minMaxSearch;
        private static int PLACEMENT = 0;
        private static int SLIDING = 1;
        private int mode = PLACEMENT;
        private int gameOver=0;

        private void AIPlayerI()
        {
            if (boardModel.checkGameOver() == BoardModel.GOAT)
            {
                winnerLabel.Text = "Goat Wins";
                gameOver = 1;
            }
            else if (boardModel.checkGameOver() == BoardModel.TIGER)
            {
                winnerLabel.Text = "Tiger Wins";
                gameOver = 1;
            }
            else
            {
                boardModel.AIPLAYER = 1;
                boardPosition.setParams(boardModel.returnPlayer(), mode, new BoardModel(boardModel));
                boardPosition.findMoves();
                BoardModel newBoard = boardPosition.calculateProbability();
                if (newBoard.checkGameOver() == BoardModel.GOAT)
                {
                    winnerLabel.Text = "Goat Wins";
                    gameOver = 1;
                }
                else if (newBoard.checkGameOver() == BoardModel.TIGER)
                {
                    winnerLabel.Text = "Tiger Wins";
                    gameOver = 1;
                }
                else
                    boardModel.copyEverything(new BoardModel(newBoard));
                this.Invalidate();
                boardModel.AIPLAYER = 0;
            }
                
        }
        private void AIPlayer()
        {
            
            if (boardModel.checkGameOver() == BoardModel.GOAT)
            {
                winnerLabel.Text = "Goat Wins";
            }
            else if (boardModel.checkGameOver() == BoardModel.TIGER)
            {
                winnerLabel.Text = "Tiger Wins";
            }
            else
            {
                boardModel.AIPLAYER = 1;
                boardPosition.setParams(boardModel.returnPlayer(), mode, new BoardModel(boardModel));
                minMaxSearch.setCurrentBoardPosition(boardPosition, boardModel.returnPlayer());
                Boardposition newBoard = minMaxSearch.alphaBetaSearch(boardPosition);
                if (newBoard.boardModel.checkGameOver() == BoardModel.GOAT)
                {
                    winnerLabel.Text = "Goat Wins";
                }
                else if (newBoard.boardModel.checkGameOver() == BoardModel.TIGER)
                {
                    winnerLabel.Text = "Tiger Wins";
                }
                else
                    boardModel.copyEverything(new BoardModel(newBoard.boardModel));
                this.Invalidate();
                boardModel.AIPLAYER = 0;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (boardModel.returnPlayer() != BoardModel.OPPONENT || gameOver!=0)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (cursorPosX != 0)
                    {
                        cursorPosX--;
                        this.Invalidate();

                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (cursorPosX != 4)
                    {
                        cursorPosX++;
                        this.Invalidate();
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (cursorPosY != 0)
                    {
                        cursorPosY--;
                        this.Invalidate();
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    if (cursorPosY != 4)
                    {
                        cursorPosY++;
                        this.Invalidate();
                    }
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (boardModel.returnPlayer() == BoardModel.TIGER)
                    {
                        currentTurnLabel.Text = "TIGER";
                        if (state == PLACED)
                        {
                            if (boardModel.getTigerAt(cursorPosX, cursorPosY) != null)
                            {
                                selectedTiger = boardModel.getTigerAt(cursorPosX, cursorPosY);
                                state = PICKED;
                                this.Invalidate();
                            }
                            else
                            {
                                //some error message signifying wrong thing picked
                            }
                        }

                        else if (state == PICKED)
                        {
                            int tx = selectedTiger.getXPos();
                            int ty = selectedTiger.getYPos();
                            boardModel.moveTiger(selectedTiger, cursorPosX, cursorPosY);
                            
                            state = PLACED;
                            this.Invalidate();
                            currentMoveLabel.Text = "[" + tx+ "," + ty + "]" +
                                " -> " + "[" + cursorPosX + "," + cursorPosY + "]";
                            AIPlayerI();
                        }
                    }

                    else if (boardModel.returnPlayer() == BoardModel.GOAT)
                    {
                        currentTurnLabel.Text = "GOAT";
                        //work remaining here...a lot actually....
                        if (count < 20)
                        {
                            boardModel.placeGoat(cursorPosX, cursorPosY);
                            count++;
                         
                            this.Invalidate();
                            currentMoveLabel.Text = "Goat Placed " + "[" + cursorPosX + "," + cursorPosY + "]";
                            AIPlayerI();
                        }
                        else
                        {
                            mode = SLIDING;
                            if (state == PLACED)
                            {
                                if (boardModel.getGoatAt(cursorPosX, cursorPosY) != null)
                                {
                                    selectedGoat = boardModel.getGoatAt(cursorPosX, cursorPosY);
                                    currentMoveLabel.Text = "Goat Selected " + "[" + cursorPosX + "," + cursorPosY + "]";
                                    state = PICKED;
                                    this.Invalidate();
                                }
                                else
                                {
                                    //some error message signifying wrong picked up
                                }
                            }
                            else if (state == PICKED)
                            {
                                int tx = selectedGoat.getXPos();
                                int ty = selectedGoat.getYPos();
                                boardModel.moveGoat(selectedGoat, cursorPosX, cursorPosY);
                                state = PLACED;
                              
                                this.Invalidate();
                                currentMoveLabel.Text = "[" + tx + "," + ty + "]" +
                             " -> " + "[" + cursorPosX + "," + cursorPosY + "]";
                                AIPlayerI();
                                
                            }
                        }
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                
            }
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}