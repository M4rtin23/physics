public abstract class Screen{
	public PointParticle[] Particles;
	public abstract void Update();
	public abstract void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch);
}
