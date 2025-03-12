using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Pendulum:Screen{
	Vector2 Base = new Vector2(400,200);
	PointParticle pendulum = new PointParticle(new Vector2(200,200), Vector2.UnitY*7);
	Vector2 Gravity = new Vector2(0,0.1f);
	float length = 200;
	public Pendulum(){
		length = (Base-pendulum.Position).Length();
		Main = pendulum;
	}

	public override void Update(){
		float delta_l = ((Base-pendulum.Position).Length()-length);
		pendulum.ApplyForce(delta_l*(Base-pendulum.Position)/(Base-pendulum.Position).Length()*2);
		pendulum.ApplyForce(Gravity);
		float kinetic = pendulum.Velocity.LengthSquared()/2;
		float elastic = delta_l*delta_l/100;
		float gravitational = (int)(length-pendulum.Position.Y)*Gravity.Length();
		System.Console.WriteLine((elastic+kinetic+gravitational));
		pendulum.Update();
	}
	public override void Draw(SpriteBatch spriteBatch){
		pendulum.Draw(spriteBatch);
		new GameBuilder.Shapes.Line(pendulum.Position, Base).Draw(spriteBatch);
	}

}
