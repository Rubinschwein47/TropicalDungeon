using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameProject1.Code;

public class Sprite
{
    public const float SpriteUnitFactor = 1/8f;
    public Texture2D texture;

    public Rectangle sourceRectangle;


    public float spriteScale;

    public Sprite(Texture2D texture, Rectangle sourceRectangle, float spriteScale, float depth = 0f)
    {
        this.texture = texture;
        this.sourceRectangle = sourceRectangle;
        this.spriteScale = spriteScale;
    }

    public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, float depth = 0f, float scale = 1f,float rotation = 0f)
    {
        spriteBatch.Draw(
            texture,
            position,
            sourceRectangle, 
            Color.White,
            rotation,
            Vector2.Zero,
            Vector2.One*(scale*spriteScale*Game1.WorldUnitSize*SpriteUnitFactor),
            SpriteEffects.None,
            depth);
    }
    public virtual void DrawCenterd(SpriteBatch spriteBatch, Vector2 position, float depth = 0f, float scale = 1f,float rotation = 0f)
    {
        spriteBatch.Draw(
            texture,
            position,
            sourceRectangle, 
            Color.White,
            rotation,
            Vector2.One*(scale*spriteScale*Game1.WorldUnitSize*SpriteUnitFactor),
            Vector2.One*(scale*spriteScale*Game1.WorldUnitSize*SpriteUnitFactor),
            SpriteEffects.None,
            depth);
    }
}

public class SpriteDepths
{
    public const float Floor = 0.3f;
    public const float Wall = 0.4f;
    public const float Player = 0.75f;
}