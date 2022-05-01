using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Blocks.Constants;

namespace Blocks
{
    public class PlayScene
    {
        private Engine engine;

        private void Reset()
        {
            engine = new();
        }

        public void Playscene()
        {
            Reset();
        }

        public void Render(SpriteBatch spriteBatch)
        {
            var sx = (VIRTUAL_WIDTH - CELL * BOARD_COLS) / 2;
            var sy = (VIRTUAL_HEIGHT - CELL * (BOARD_ROWS - OVERFLOW)) / 2;

            for (int r = OVERFLOW; r < BOARD_ROWS; r++)
            {
                for (int c = 0; c < BOARD_COLS; c++)
                {
                    var rc = new Rectangle(
                        sx + c * CELL,
                        sy + (r - OVERFLOW) * CELL,
                        CELL,
                        CELL
                        );
                    spriteBatch.Draw(App.Instance.Pixel, rc, Color.Black);
                }
            }
            spriteBatch.Draw(
                App.Instance.Pixel,
                new Rectangle(100, 100, 100, 100),
                Color.Red
                );
        }
    }
}