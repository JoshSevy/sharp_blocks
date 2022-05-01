using System;
using static Blocks.Constants;
using static Blocks.Pieces;

namespace Blocks
{
    public class Engine
    {
        private Arr board = new(BOARD_ROWS, BOARD_COLS);
        private int curRow;
        private int curCol;
        private Arr curPiece;
        private readonly Random rnd = new();

        public Arr Board
        {
            get => board;
        }

        public void Spawn()
        {
            int which = rnd.Next(PIECES.Length);
            curCol = 4;
            curRow = 0;
            curPiece = PIECES[which].Cloned;
        }

    }
}