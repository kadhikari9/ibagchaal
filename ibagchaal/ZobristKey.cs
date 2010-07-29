using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    public class ZobristKey
    {
        static private Int64[] m_pi64RndTable;// Random value for each piece/position.
        /*
        //Bagchal Board.
        // 0 1 2 3 4
        // 5 6 7 8 9
        // 10 11 12 13 14
        // 15 16 17 18 19
        // 20 21 22 23 24
        */

        // Type of pieces in the board.
        public enum Piece : byte{
            Empty = 0,
            Tiger =1,
            Goat = 2
        }
        // private Piece[] m_pBoard;
        // Static constructor. Use to create the random value for each case of the board.
        static ZobristKey()
        {
            Random rnd;
            long lPart1;
            long lPart2;
            long lPart3;
            long lPart4;
            
            //m_pBoard = new Piece[25];
            //m_i64ZobristKey         = ZobristKey.ComputeBoardZobristKey(m_pBoard);

            rnd = new Random(0);
            m_pi64RndTable=new Int64[25 * 4];
            for (int i = 0; i < 25 * 4; i++)
            {
                lPart1 = (long)rnd.Next(65536);
                lPart2 = (long)rnd.Next(65536);
                lPart3 = (long)rnd.Next(65536);
                lPart4 = (long)rnd.Next(65536);

                m_pi64RndTable[i] = (lPart1 << 48) | (lPart2 << 32) | (lPart3 << 16) | lPart4;
            }
        }
        
        // Update the Zobrist key using the specified move.
        public static long UpdateZobristKey(long i64ZobristKey, int iPos, Piece bOldPiece, Piece bNewPiece)
        {
            int iBaseIndex;
            iBaseIndex = iPos << 4;
            i64ZobristKey ^= m_pi64RndTable[iBaseIndex + (int)bOldPiece] ^
                             m_pi64RndTable[iBaseIndex + (int)bNewPiece];
            return i64ZobristKey;
        }

        // Compute the Zobrist key for a board.
        public static long ComputeBoardZobristKey(Piece[] peBoard)
        {
            long lRetVal = 0;
            for (int i = 0; i < 25; i++)
            { 
                lRetVal ^= m_pi64RndTable[(i << 4) + (int)peBoard[i] ];
            }
            return lRetVal;
        }
    };
}
