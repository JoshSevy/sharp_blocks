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
        private Action gameOver = () => { };
        private Action<int> linesRemoved = (rows) => { };

        public Action GameOver
        {
            set => gameOver = value;
        }

        public Action Dropped
        {
            set => dropped = value;
        }

        public Action<int> LinesRemoved
        {
            set => linesRemoved = value;
        }

        public Arr Board
        {
            get => board;
        }

        // Spawns next random piece
        // if not gameover
        public void Spawn()
        {
            int which = rnd.Next(PIECES.Length);
            curCol = 4;
            curRow = 0;
            curPiece = PIECES[which].Cloned;

            if (!board.CanPlace(curPiece, curRow + 1, curCol))
            {
                gameOver();
            }
        }

        // Moves pieces down screen
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
                var rows = board.RemoveFullRows();
                linesRemoved(rows);
                Spawn();
            }
        }

        // Engine Move Piece Right
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

        // Engine Move Piece Left
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

        // Engine Rotate method
        // Can replace RotatedCounterClockWise to RotatedClockWise
        // If you prefer that rotation
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