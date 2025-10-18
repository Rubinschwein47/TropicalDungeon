
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameProject1.Code.ComponentSystem.Components;

public class SpriteRenderer(Sprite sprite) : EntityComponent
{
    public Sprite Sprite = sprite;

    public override void onDraw(SpriteBatch spriteBatch)
    {
        Sprite.Draw(spriteBatch, Camera.WorldToScreen(Owner.Position));
    }
}