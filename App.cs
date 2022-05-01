using System;
using System.Collections.Generic;
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

        private SpriteBatch spriteBatch;

        protected override void Initialize()
        {
            base.Initialize();
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new[] { Color.White });
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
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

        private PlayScene scene = new();

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);
            spriteBatch.Begin();
            scene.Render(spriteBatch);
            spriteBatch.End();
            
        }

        public static void Main()
        {
            using var app = new App();
            app.Run();
        }

        public override bool Equals(object obj)
        {
            return obj is App app &&
                   EqualityComparer<Texture2D>.Default.Equals(Pixel, app.Pixel);
        }
    }
}
