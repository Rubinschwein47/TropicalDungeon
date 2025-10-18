using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameProject1.Code;

public class SpriteLoader
{
    public static Sprite PlayerSprite;
    public static Sprite WallSprite;
    public static Sprite FloorSprite;


    public static void Initialize(ContentManager Content)
    {
        var spriteSheet = Content.Load<Texture2D>("images/SpriteSheet");
        FloorSprite = new Sprite(spriteSheet, new Rectangle(0, 8, 8, 8), 1f);
        WallSprite = new Sprite(spriteSheet, new Rectangle(0, 16, 8, 8), 1f);
        PlayerSprite = new Sprite(spriteSheet, new Rectangle(0, 24, 8, 8), 1f);
    }
}