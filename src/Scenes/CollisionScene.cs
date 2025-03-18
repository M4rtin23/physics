using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class CollisionScene:Scene{
	PointParticle p0 = new PointParticle(new Vector2(250,200), Vector2.UnitX);
	PointParticle p1 = new PointParticle(new Vector2(400,200), Vector2.UnitX*-1);

	public CollisionScene(){
		Particles = new PointParticle[]{p0,p1};
		p1.Mass = 5;
	}

	public override void Update(){
		float length = (int)(10*System.Math.Sqrt(p1.Mass)+10*System.Math.Sqrt(p0.Mass))/2;
		float distace = (p0.Position-p1.Position).Length();

		if(distace <= length){
			float delta_l = distace - length;
			p1.ApplyForce(delta_l*(p0.Position-p1.Position)/distace);
			p0.ApplyForce(-delta_l*(p0.Position-p1.Position)/distace);
		}

		p0.Update();
		p1.Update();

		float kinetic = p0.Velocity.LengthSquared()/2;
		float kinetic2 = p1.Velocity.LengthSquared()/2*p1.Mass;
		System.Console.WriteLine(kinetic+kinetic2);
	}
	public override void Draw(SpriteBatch spriteBatch){
		p0.Draw(spriteBatch);
		p1.Draw(spriteBatch);
	}
}
