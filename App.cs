using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Blocks.Constants;

namespace Blocks
{
    class App : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private Texture2D  pixel;
        private RenderTarget2D target;

        public Texture2D Pixel
        {
            get => pixel;
        }

        private SpriteBatch spriteBatch;

        protected override void Initialize()
        {
            base.Initialize();
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.ApplyChanges();
            Window.Title = "Blocks";
            Window.AllowUserResizing = true;
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new[] { Color.White });
            spriteBatch = new SpriteBatch(GraphicsDevice);

            target = new RenderTarget2D(
                GraphicsDevice,
                VIRTUAL_WIDTH,
                VIRTUAL_HEIGHT,
                false,
                SurfaceFormat.Color,
                DepthFormat.None, GraphicsDevice.PresentationParameters.MultiSampleCount,
                RenderTargetUsage.DiscardContents
                );
            
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
            graphics.GraphicsDevice.SetRenderTarget(target);
            GraphicsDevice.Clear(Color.DimGray);
            spriteBatch.Begin();
            scene.Render(spriteBatch);
            spriteBatch.End();
            graphics.GraphicsDevice.SetRenderTargets(null);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            var dst = new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height);
            spriteBatch.Draw(target, dst, Color.White);
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
