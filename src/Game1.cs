using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace physics;
public class Game1 : Game{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

	Screen screen = new Pendulum();
    public Game1(){
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void LoadContent(){
        spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime){
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Q))
            Exit();
        base.Update(gameTime);
		screen.Update();
    }

    protected override void Draw(GameTime gameTime){
        GraphicsDevice.Clear(Color.CornflowerBlue);
		spriteBatch.Begin();

		screen.Draw(spriteBatch);
		new GameBuilder.Shapes.Line(screen.Main.Position, screen.Main.Position+screen.Main.Acceleration*400, 2, Color.Red).Draw(spriteBatch);
		new GameBuilder.Shapes.Line(screen.Main.Position, screen.Main.Position+screen.Main.Velocity*10, 2, Color.Blue).Draw(spriteBatch);


		spriteBatch.End();

        base.Draw(gameTime);
    }
}



