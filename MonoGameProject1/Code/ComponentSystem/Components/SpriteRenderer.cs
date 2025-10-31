
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameProject1.Code.ComponentSystem.Components;

public class SpriteRenderer(Sprite sprite, float depth = 0f) : EntityComponent
{
    public Sprite Sprite = sprite;
    public float Depth = depth;
    public Vector2 Tiles = Vector2.One;

    public override void onDraw(SpriteBatch spriteBatch)
    {
        Sprite.DrawCenterd(spriteBatch, Camera.WorldToScreen(Owner.Position), depth: Depth);
    }
}