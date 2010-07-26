using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class MinMax                   
    {
        MinMax()
        {
        }

        public void setCurrentBoardPosition(Boardposition boardPosition,int t)
        {
            currentBoardPosition = boardPosition;
            turn = t;
        }

        public Boardposition alphaBetaSearch(Boardposition state)
        {
            int v = maxValue(state, -1000, +1000);           // infinty approximated by 1000 ....becoz..umm...ummm...just for fun..

            foreach (Boardposition successor in state.nextPosition)
            {
                if (successor.Utility == v) return successor;
            }

            return null;
        }

        private int maxValue(Boardposition state,int alpha,int beta)
        {
            int v =-1000;

            if (state.boardModel.checkGameOver() != 0)
            {
                if (state.boardModel.checkGameOver() == turn)
                    return 1;
                else return -1;
            }
            //check if state is in transposition table ..........if it is then return the evaluation funciton
            state.findMoves();
            
            foreach (Boardposition succesor in state.nextPosition)
            {
                v=Math.Max(v,minValue(succesor,alpha,beta));
                if(v>=beta) return v;
                alpha=Math.Max(alpha,v);

            }
            return v;
        }

        private int minValue(Boardposition state, int alpha, int beta)
        {
            int v = +1000;

            if (state.boardModel.checkGameOver() != 0)
            {
                if (state.boardModel.checkGameOver() == turn)
                    return 1;
                else return -1;
            }

            //check if state is in transposition table ..........if it is then return the evaluation funciton

            //check if the depth is 
            state.findMoves();
            if (state.Depth >= 40)  //we will  work on this
            {
                //we will return the value obtained from the evalution function
            }
            foreach (Boardposition succesor in state.nextPosition)
            {
                v = Math.Min(v, maxValue(succesor, alpha, beta));
                if (v <= alpha) return v;
                beta = Math.Min(alpha, v);

            }
            return v;
        }
        
        private Boardposition currentBoardPosition;
        private int turn;
    }
}
