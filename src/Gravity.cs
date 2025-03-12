using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Gravity : Screen{
	private PointParticle Planet = new PointParticle(new Vector2(200,300), new Vector2(0,2), new Vector2(0,1));
	private Vector2 Star = new Vector2(400,240);

	public Gravity(){
		Main = Planet;
	}

    public override void Update(){
		float length = (Star - Planet.Position).Length();
		if(length > 20){
			Planet.ApplyForce(Planet.Mass*6*(Star - Planet.Position)/(length*length));
		}
		Planet.Update();

    }

    public override void Draw(SpriteBatch spriteBatch){
		Planet.Draw(spriteBatch);
		new GameBuilder.Shapes.Point(Star, 10, Color.White).Draw(spriteBatch);

    }
}



