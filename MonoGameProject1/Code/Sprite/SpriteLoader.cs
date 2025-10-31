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
    public static Sprite PlayerPointer;
    public static Sprite PlayerPointerFlash;
    public static Sprite MeleeEnemy;
    public static Sprite MeleeEnemy1;
    public static Sprite RangedEnemy;
    public static Sprite RangedEnemy1;
    public static Sprite EnemyBullet;
    public static Sprite EnemyBullet1;


    public static void Initialize(ContentManager Content)
    {
        var spriteSheet = Content.Load<Texture2D>("images/SpriteSheet");
        FloorSprite = new Sprite(spriteSheet, new Rectangle(0, 8, 8, 8), 1f);
        WallSprite = new Sprite(spriteSheet, new Rectangle(0, 16, 8, 8), 1f);
        PlayerSprite = new Sprite(spriteSheet, new Rectangle(0, 24, 8, 8), 1f);
        PlayerPointer = new Sprite(spriteSheet, new Rectangle(32, 24, 8, 8), 1f);
        PlayerPointerFlash = new Sprite(spriteSheet, new Rectangle(40, 24, 8, 8), 1f);
        MeleeEnemy = new Sprite(spriteSheet, new Rectangle(0, 32, 8, 8), 1f);
        MeleeEnemy1 = new Sprite(spriteSheet, new Rectangle(8, 32, 8, 8), 1f);
        RangedEnemy = new Sprite(spriteSheet, new Rectangle(32, 32, 8, 8), 1f);
        RangedEnemy1 = new Sprite(spriteSheet, new Rectangle(40, 32, 8, 8), 1f);
        EnemyBullet = new Sprite(spriteSheet, new Rectangle(32, 40, 8, 8), 1f);
        EnemyBullet1 = new Sprite(spriteSheet, new Rectangle(40, 40, 8, 8), 1f);
    }
}