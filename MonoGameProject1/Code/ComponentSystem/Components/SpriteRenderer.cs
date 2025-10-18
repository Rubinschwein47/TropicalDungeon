
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameProject1.Code.ComponentSystem.Components;

public class SpriteRenderer(Sprite sprite, float depth = 0f) : EntityComponent
{
    public Sprite Sprite = sprite;
    public float Depth = depth;

    public override void onDraw(SpriteBatch spriteBatch)
    {
        Sprite.Draw(spriteBatch, Camera.WorldToScreen(Owner.Position), depth: Depth);
    }
}