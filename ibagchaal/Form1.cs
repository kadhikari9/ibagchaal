using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            boardView.PositionBoard = new Point(300, 100);
            boardView.drawBoard(800, 600, Color.Black, 3);
        }

        private Graphics g;         //to get graphics handler of this form that has already been created automatically.
        private BoardView boardView;
    }
}
