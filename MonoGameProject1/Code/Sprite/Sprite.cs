using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameProject1.Code;

public class Sprite
{
    public const float SpriteUnitFactor = 1/8f;
    public Texture2D texture;

    public Rectangle sourceRectangle;

    public float scale;

    public Sprite(Texture2D texture, Rectangle sourceRectangle, float scale)
    {
        this.texture = texture;
        this.sourceRectangle = sourceRectangle;
        this.scale = scale;
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        spriteBatch.Draw(
            texture,
            position,
            sourceRectangle, 
            Color.White,
            0f,
            Vector2.Zero,
            Vector2.One*(scale*Game1.WorldUnitSize*SpriteUnitFactor),
            SpriteEffects.None,
            0f);
    }
}