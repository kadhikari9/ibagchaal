using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ibagchaal
{
    // Type of transposition table entry.
    public enum TransEntryType
    { 
        Exact = 0,// Exact move value.
        Alpha = 1,// Alpha cut off value.
        Beta = 2// Beta cut off value.
    }

    // Transposition table is used to cache already computer board position.
    public class TransTable
    {
        private struct TransEntry
        {
            public Int64 m_i64Key;// Zobrist key.
            public int m_iDepth;// Depth of the move.
            public TransEntryType m_eType;// Type of the entry.
            public int m_iValue;// Value of the entry.
        };

        static TransTable[] m_arrTransTable;// Array of static transposition table.
        static int m_arrTransTableSize = 1000;// Size of the transposition table.
        private TransEntry[] m_arrTransEntry;// Hashlist of entries.
        //private int m_iCacheHit;// Number of cache hit.

        // Static constructor. Use to create the random value for each case of the board.
        static TransTable()
        {
            m_arrTransTable = new TransTable[Environment.ProcessorCount];
        }

        // Size of the transposition table.
        static public int TransTableSize
        {
            get {
                return m_arrTransTableSize;
            }
            set {
                if (m_arrTransTableSize != value) {
                    m_arrTransTableSize = value;
                    for (int iIndex = 0; iIndex < m_arrTransTable.Length; iIndex++){
                        m_arrTransTable[iIndex] = null;                        
                    }
                }
            }
        }

        // Gets one of the static translation table.
        static public TransTable GetTransTable(int iIndex)
        {
            if (m_arrTransTable[iIndex] == null) {
                m_arrTransTable[iIndex] = new TransTable(TransTableSize);
            }
            return m_arrTransTable[iIndex];
        }

        // Class constructor.
        public TransTable(int iTransTableSize)
        {
            m_arrTransEntry = new TransEntry[iTransTableSize];
            //m_iCacheHit = 0;
        }

        // Record a new entry in the table.
        public void RecordEntry(long i64ZobristKey, int iDepth, int iValue, TransEntryType eType)
        {
            TransEntry entry;
            entry.m_i64Key = i64ZobristKey;// Zobrist key.
            entry.m_iDepth = iDepth;// Current depth.
            entry.m_iValue = iValue;// Board evaluation.
            entry.m_eType = eType;// Type of the entry.
            m_arrTransEntry[(UInt64)i64ZobristKey % (UInt64)m_arrTransEntry.Length] = entry;
        }

        // To check if the current board has already been evaluated.
        // Return Int32.MaxValue if no valid value found, else value of the board.
        public int ProbeEntry(long i64ZobristKey, int iDepth, int iAlpha, int iBeta)
        {
            int iRetVal = Int32.MaxValue;
            TransEntry entry;

            entry = m_arrTransEntry[(UInt64)i64ZobristKey % (UInt64)m_arrTransEntry.Length];
            if (entry.m_i64Key == i64ZobristKey && entry.m_iDepth >= iDepth)
            {
                switch (entry.m_eType)
                { 
                    case TransEntryType.Exact:
                        iRetVal = entry.m_iValue;
                        break;
                    case TransEntryType.Alpha:
                        if (entry.m_iValue <= iAlpha) {
                            iRetVal = iAlpha;
                        }
                        break;
                    case TransEntryType.Beta:
                        if (entry.m_iValue >= iBeta) {
                            iRetVal = iBeta;
                        }
                        break;
                }
                //m_iCacheHit++;
            }
            return iRetVal;
        }

        /*
        // Number of cache hit
        public int CacheHit
        {
            get {
                return m_iCacheHit;
            }
            set {
                m_iCacheHit = value;
            }
        }

        // Reset the cache.
        public void Reset()
        {
            m_iCacheHit = 0;
        }*/
    }
}
