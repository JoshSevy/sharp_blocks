using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Blocks
{
    public class PlayScene
    {
        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                App.Instance.Pixel,
                new Rectangle(100, 100, 100, 100),
                Color.Red
                );
        }
    }
}