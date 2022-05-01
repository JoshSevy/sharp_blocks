using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Blocks.Constants;

namespace Blocks
{
    public class PlayScene
    {
        private Engine engine;
        private double baseDelay;
        private double curDelay;
        private double elapsed;

        private readonly Color[] palatte = new Color[]
        {
            Color.Black,
            Color.Cyan,
            Color.Yellow,
            Color.Purple,
            Color.Orange,
            Color.Blue,
            Color.Green,
            Color.Red,
        };

        private void Reset()
        {
            baseDelay = NORMAL_DELAY;
            curDelay = baseDelay;
            engine = new();
            engine.Spawn();
            engine.GameOver = () =>
            {
                Console.WriteLine("Game Over");
            };
            engine.Down();
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
                    var v = engine.Board[r, c];
                    spriteBatch.Draw(App.Instance.Pixel, rc, palatte[v]);
                }
            }
        }

        public void Update(double dt)
        {
            elapsed += dt;
            if (elapsed >= curDelay)
            {
                elapsed = 0;
                engine.Down();
            }
        }
    }
}