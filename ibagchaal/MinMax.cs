using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    class MinMax                   
    {
        public MinMax()
        {
        }

        public void setCurrentBoardPosition(Boardposition boardPosition,int t)
        {
            currentBoardPosition = boardPosition;
            turn = t;
        }

        public Boardposition alphaBetaSearch(Boardposition state)
        {
            float v = maxValue(state, -1000, +1000);           // infinty approximated by 1000 ....becoz..umm...ummm...just for fun..

            foreach (Boardposition successor in state.nextPosition)
            {
                if (successor.Utility == v) return successor;
            }
            return null;
            
        }

        private float maxValue(Boardposition state,float alpha,float beta)
        {
            float v =-1000;
            if (state.boardModel.checkGameOver() != 0)
            {
                if (state.boardModel.checkGameOver() == turn)
                    state.Utility = 1;
                else state.Utility = -1;

                return state.Utility;
            }
            //check if state is in transposition table ..........if it is then return the evaluation funciton
            state.findMoves();
            
            foreach (Boardposition succesor in state.nextPosition)
            {
                succesor.Utility = minValue(succesor, alpha, beta);
                v=Math.Max(v,succesor.Utility);
                if(v>=beta) return v;
                alpha=Math.Max(alpha,v);
                
            }
            
            return v;
        }

        private float minValue(Boardposition state, float alpha, float beta)
        {
            float v = 1000;

            if (state.boardModel.checkGameOver() != 0)
            {
                if (state.boardModel.checkGameOver() == turn)
                    state.Utility = 1;
                else state.Utility = -1;

                return state.Utility;
            }

            //check if state is in transposition table ..........if it is then return the evaluation funciton

            //check if the depth is 
           
            if (state.Depth >= 4)  //we will  work on this
            {
                Random rand = new Random();
                state.Utility= (float)rand.Next(10)/(float)10.0;
                return state.Utility;
                //we will return the value obtained from the evalution function
            }
            state.findMoves();
            foreach (Boardposition succesor in state.nextPosition)
            {
                succesor.Utility=maxValue(succesor, alpha, beta);
                v = Math.Min(v, succesor.Utility);
                if (v <= alpha) return v;
                beta = Math.Min(beta, v);

            }
            return v;
        }
        
        private Boardposition currentBoardPosition;
        private int turn;
    }
}
