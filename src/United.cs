using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class United:Screen{
	PointParticle p0 = new PointParticle(new Vector2(350,225), Vector2.UnitX);
	PointParticle p1 = new PointParticle(new Vector2(300,200));
	float length = 80;

	public United(){
		Main = p1;
		p1.Mass = 5;
	}

	public override void Update(){
		float delta_l = (p0.Position-p1.Position).Length()-length;

		p0.ApplyForce(-delta_l*(p0.Position-p1.Position)/(p0.Position-p1.Position).Length()/10);
		p1.ApplyForce(delta_l*(p0.Position-p1.Position)/(p0.Position-p1.Position).Length()/10);

		p0.Update();
		p1.Update();

		float kinetic = p0.Velocity.LengthSquared()/2;
		float kinetic2 = p1.Velocity.LengthSquared()/2*p1.Mass;
		float elastic = delta_l*delta_l/20;
		System.Console.WriteLine(kinetic+elastic+kinetic2);
	}
	public override void Draw(SpriteBatch spriteBatch){
		p0.Draw(spriteBatch);
		p1.Draw(spriteBatch);
		new GameBuilder.Shapes.Line(p0.Position, p1.Position).Draw(spriteBatch);
	}
}
