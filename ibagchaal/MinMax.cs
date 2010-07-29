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
            zobristKey = new ZobristKey();
            transTable = new TransTable(MAXENTRYHASH);
            evaluationUtility = new EvalutionUtility(null);
        }

        public void setCurrentBoardPosition(Boardposition boardPosition,int t)
        {
            currentBoardPosition = boardPosition;
            turn = t;
        }

        public Boardposition alphaBetaSearch(Boardposition state)
        {
            float v = maxValue(state, -10000, +10000);           // infinty approximated by 1000 ....becoz..umm...ummm...just for fun..

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
                    state.Utility = 1000;
                else state.Utility = -1000;

                return state.Utility;
            }
            //check if state is in transposition table ..........if it is then return the evaluation funciton
          /*  long key = ZobristKey.ComputeBoardZobristKey(state.boardModel.getboard());
            int val = transTable.ProbeEntry(key, state.Depth, (int)alpha, (int)beta);
            if (val != Int32.MaxValue)
                return val;

            if (state.Depth >= 3 && state.Depth < 5)
            {
                Random rand = new Random();
                transTable.RecordEntry(key, state.Depth, (int)alpha, TransEntryType.Alpha);
                transTable.RecordEntry(key, state.Depth, (int)beta, TransEntryType.Beta);
                evaluationUtility.setBoardPosition(state);
                transTable.RecordEntry(key, state.Depth, (int)evaluationUtility.evaluateBoard(), TransEntryType.Exact);

            }
            */
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
                    state.Utility = 1000;
                else state.Utility = -1000;

                return state.Utility;
            }

            //check if state is in transposition table ..........if it is then return the evaluation funciton
            /*long key = ZobristKey.ComputeBoardZobristKey(state.boardModel.getboard());
            int val = transTable.ProbeEntry(key, state.Depth, (int)alpha, (int)beta);
            if (val != Int32.MaxValue)
                return val;

            if (state.Depth >= 3 && state.Depth < 5)
            {
                Random rand = new Random();
                transTable.RecordEntry(key, state.Depth, (int)alpha, TransEntryType.Alpha);
                transTable.RecordEntry(key, state.Depth, (int)beta, TransEntryType.Beta);
                evaluationUtility.setBoardPosition(state);
                transTable.RecordEntry(key, state.Depth,(int) evaluationUtility.evaluateBoard(), TransEntryType.Exact);

            }
            */
            //check if the depth is 
           
            if (state.Depth >= 5)  //we will  work on this
            {
                evaluationUtility.setBoardPosition(state);
                state.Utility = evaluationUtility.evaluateBoard();
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
        private EvalutionUtility evaluationUtility;
        private ZobristKey zobristKey;
        private TransTable transTable;
        private static int MAXENTRYHASH = 100;
        private Boardposition currentBoardPosition;
        private int turn;
    }
}
