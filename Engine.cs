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

        private Action dropped = () => { };
        public Action Dropped
        {
            set => dropped = value;
        }

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
                dropped();
                Spawn();
            }
        }

        public void Right()
        {
            var clone = board.Cloned;
            clone.Remove(curPiece, curRow, curCol);
            if (clone.CanPlace(curPiece, curRow, curCol + 1))
            {
                curCol++;
                clone.Place(curPiece, curRow, curCol);
                board = clone;
            }
        }

        public void Left()
        {
            var clone = board.Cloned;
            clone.Remove(curPiece, curRow, curCol);
            if (clone.CanPlace(curPiece, curRow, curCol - 1))
            {
                curCol--;
                clone.Place(curPiece, curRow, curCol);
                board = clone;
            }
        }

        public void Rotate()
        {
            var clone = board.Cloned;
            var rotated = curPiece.RotatedCounterClockwise;
            clone.Remove(curPiece, curRow, curCol);
            if (clone.CanPlace(rotated, curRow, curCol))
            {
                curPiece = rotated;
                clone.Place(curPiece, curRow, curCol);
                board = clone;
            }
        }

    }
}