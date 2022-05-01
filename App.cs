using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Blocks
{
    class App : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private Texture2D  pixel;

        public Texture2D Pixel
        {
            get => pixel;
        }

        protected override void Initialize()
        {
            base.Initialize();
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new[] { Color.White });
        }

        private static App instance;
            public static App Instance
        {
            get  => instance;
        }

        public App()
        {
            instance = this;
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);
        }

        public static void Main()
        {
            using var app = new App();
            app.Run();
        }
    }
}
