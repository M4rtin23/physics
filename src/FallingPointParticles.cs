using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FallingPointParticles:Screen{
	Vector2 Gravity = new Vector2(0,0.1f);
	PointParticle p0 = new PointParticle(new Vector2(350,200));
	PointParticle p1 = new PointParticle(new Vector2(450,100));
	PointParticle p2 = new PointParticle(new Vector2(400,0));

	float length = 200;
	float length2 = 100;
	float length3 = 100;
	public FallingPointParticles(){
		GameBuilder.Shapes.Triangle triangle = new GameBuilder.Shapes.Triangle(System.Math.PI, 51, System.Math.PI/2, 50, 0, 50)+ new Vector2(400,200);
		p0.Position = triangle.Vertices[0];
		p1.Position = triangle.Vertices[1];
		p2.Position = triangle.Vertices[2];

		length = (p2.Position-p0.Position).Length();
		length2 = (p1.Position-p0.Position).Length();
		length3 = (p1.Position-p2.Position).Length();

		Particles = new PointParticle[]{p0,p1,p2};
	}

	public override void Update(){
		float delta_l = (p2.Position-p0.Position).Length()-length;
		float delta_l2 = (p0.Position-p1.Position).Length()-length2;
		float delta_l3 = (p2.Position-p1.Position).Length()-length3;
		p0.ApplyForce(Gravity);
		p1.ApplyForce(Gravity);
		p2.ApplyForce(Gravity);

		p0.ApplyForce(delta_l*(p2.Position-p0.Position)/(p2.Position-p0.Position).Length());
		p2.ApplyForce(-delta_l*(p2.Position-p0.Position)/(p2.Position-p0.Position).Length());

		p1.ApplyForce(delta_l3*(p2.Position-p1.Position)/(p2.Position-p1.Position).Length());
		p2.ApplyForce(-delta_l3*(p2.Position-p1.Position)/(p2.Position-p1.Position).Length());

		p1.ApplyForce(delta_l2*(p0.Position-p1.Position)/(p0.Position-p1.Position).Length());
		p0.ApplyForce(-delta_l2*(p0.Position-p1.Position)/(p0.Position-p1.Position).Length());

		p0.Update();
		p1.Update();
		p2.Update();

		if(p0.Position.Y > 400){
			p0.ApplyForce(-(p0.Position.Y-400)*Vector2.UnitY/5);
			p0.Velocity -= p0.Velocity/50;

		}
		if(p1.Position.Y > 400){
			p1.ApplyForce(-(p1.Position.Y-400)*Vector2.UnitY/5);
			p1.Velocity -= p1.Velocity/50;

		}
		if(p2.Position.Y > 400){
			p2.ApplyForce(-(p2.Position.Y-400)*Vector2.UnitY/5);
			p2.Velocity -= p2.Velocity/50;

		}		
	}
	public override void Draw(SpriteBatch spriteBatch){
		p0.Draw(spriteBatch);
		new GameBuilder.Shapes.Line(p0.Position, p2.Position).Draw(spriteBatch);

		p1.Draw(spriteBatch);
		new GameBuilder.Shapes.Line(p0.Position, p1.Position).Draw(spriteBatch);

		p2.Draw(spriteBatch);
		new GameBuilder.Shapes.Line(p1.Position, p2.Position).Draw(spriteBatch);
	}

}
