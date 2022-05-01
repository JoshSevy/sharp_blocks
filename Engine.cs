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

        private Action gameOver = () => { };
        public Action GameOver
        {
            set => gameOver = value;
        }

        public void Down()
        {
            var clone = board.Cloned;
            clone.Remove(curPiece, curRow, curCol);
            if (clone.CanPlace(curPiece, curRow + 1, curCol))
            {
                curRow++;
                clone.Place(curPiece, curRow, curCol);
                board = clone;
            }
            else
            {
                gameOver();
            }
        }

    }
}