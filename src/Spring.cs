using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Spring : Screen{
	PointParticle particle = new PointParticle(new Vector2(200, 480-5), Vector2.UnitX*2);
	GameBuilder.Shapes.RectangleF spring = new GameBuilder.Shapes.RectangleF(640-length, 473, 240, 4);
	static int length = 40;

	public Spring(){
		Particles = new PointParticle[]{particle};
	}

    public override void Update(){
		if(particle.Position.X > 640-length-5){
			spring = new GameBuilder.Shapes.RectangleF(particle.Position.X + 5, 473, 240, 4);
			particle.ApplyForce(Vector2.UnitX*(600-particle.Position.X)/6000);
		}
		System.Console.WriteLine(particle.Velocity.LengthSquared()/2);
		particle.Update();
    }

    public override void Draw(SpriteBatch spriteBatch){
		particle.Draw(spriteBatch);
		spring.Draw(spriteBatch);

    }
}



