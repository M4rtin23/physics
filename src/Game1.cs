using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace physics;
public class Game1 : Game{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

	Scene Scene = new PendulumScene();
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
		Scene.Update();
    }

    protected override void Draw(GameTime gameTime){
        GraphicsDevice.Clear(Color.CornflowerBlue);
		spriteBatch.Begin();

		Scene.Draw(spriteBatch);
        for(int i = 0; i < Scene.Particles.Length; i++){
            new GameBuilder.Shapes.Line(Scene.Particles[i].Position, Scene.Particles[i].Position+Scene.Particles[i].Acceleration*400, 2, Color.Red).Draw(spriteBatch);
            new GameBuilder.Shapes.Line(Scene.Particles[i].Position, Scene.Particles[i].Position+Scene.Particles[i].Velocity*10, 2, Color.Blue).Draw(spriteBatch);
        }


		spriteBatch.End();

        base.Draw(gameTime);
    }
}



