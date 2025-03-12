using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;


public class PointParticle{
	public Vector2 Position;
	public Vector2 Velocity;
	public Vector2 Acceleration;
	public Vector2[] Forces = new Vector2[1]{Vector2.Zero};
	public float Mass = 1;

	public PointParticle(Vector2 pos, Vector2 vel, Vector2 acc){
		Position = pos;
		Velocity = vel;
		Acceleration = acc;
	}
	public PointParticle(Vector2 pos, Vector2 vel){
		Position = pos;
		Velocity = vel;
		Acceleration = Vector2.Zero;
	}

	public PointParticle(Vector2 pos){
		Position = pos;
		Velocity = Vector2.Zero;
		Acceleration = Vector2.Zero;
	}
	public void ApplyForce(Vector2 force){
		Forces = Forces.Append(force).ToArray();

	}
	public void Update(){
		Vector2 totalForces = Vector2.Zero;
		for(int i = 0; i < Forces.Length; i++){
			totalForces += Forces[i];
		}
		Acceleration = totalForces/Mass;

		Velocity+=Acceleration;
		Position+=Velocity;
		Forces = new Vector2[0];
	}
	public void Draw(SpriteBatch spriteBatch){
		new GameBuilder.Shapes.Point(Position, 10, Color.White).Draw(spriteBatch);
	}
}