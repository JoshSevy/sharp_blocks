using static Blocks.Constants;

namespace Blocks
{
    public class Engine
    {
        private Arr board = new(BOARD_ROWS, BOARD_COLS);
        public Arr Board
        {
            get => board;
        }
    }
}