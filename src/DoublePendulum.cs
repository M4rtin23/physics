using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DoublePendulum:Screen{
	Vector2 Base = new Vector2(400,0);
	Vector2 Gravity = new Vector2(0,0.1f);

	PointParticle p0 = new PointParticle(new Vector2(400,200));
	PointParticle p1 = new PointParticle(new Vector2(400,100), Vector2.UnitX);

	float length = 200;
	float length2 = 100;
	public DoublePendulum(){
		length = (Base-p0.Position).Length();
		length2 = (p1.Position-p0.Position).Length();
		Particles = new PointParticle[]{p0,p1};
	}

	public override void Update(){
		float delta_l = ((Base-p0.Position).Length()-length);
		float delta_l2 = ((p0.Position-p1.Position).Length()-length2);

		p0.ApplyForce(delta_l*(Base-p0.Position)/(Base-p0.Position).Length()*2);
		p0.ApplyForce(Gravity*p0.Mass);
		p0.ApplyForce(-delta_l2*(p0.Position-p1.Position)/(p0.Position-p1.Position).Length());

		p1.ApplyForce(delta_l2*(p0.Position-p1.Position)/(p0.Position-p1.Position).Length());
		p1.ApplyForce(Gravity*p1.Mass);

		p0.Update();
		p1.Update();

		float kinetic = p0.Velocity.LengthSquared()/2;
		float kinetic2 = p1.Velocity.LengthSquared()/2;

		float elastic = delta_l*delta_l;
		float elastic2 = delta_l2*delta_l2/2;

		float gravitational = (int)(length+length2-p0.Position.Y)*Gravity.Length();
		float gravitational2 = (int)(length+length2-p1.Position.Y)*Gravity.Length();

		System.Console.WriteLine(elastic+kinetic+gravitational+elastic2+kinetic2+gravitational2);

	}
	public override void Draw(SpriteBatch spriteBatch){
		p0.Draw(spriteBatch);
		new GameBuilder.Shapes.Line(p0.Position, Base).Draw(spriteBatch);

		p1.Draw(spriteBatch);
		new GameBuilder.Shapes.Line(p0.Position, p1.Position).Draw(spriteBatch);
	}
}
