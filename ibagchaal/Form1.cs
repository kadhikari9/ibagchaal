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
            this.TopMost = true;
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            boardView = new BoardView(g);
            Rectangle rect=SystemInformation.VirtualScreen;
            boardView.ScreenSize = new Point(rect.Right,rect.Bottom);
            boardView.calculateBoardPosition();
            boardView.drawBoard(Color.Black, 3);
            boardView.placeTiger(450, 150);
            boardView.placeGoat(600, 150);
        }

        private Graphics g;         //to get graphics handler of this form that has already been created automatically.
        private BoardView boardView;
    }
}
