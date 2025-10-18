using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameProject1.Code;
using MonoGameProject1.Code.ComponentSystem;
using MonoGameProject1.Code.ComponentSystem.Components;
using MonoGameProject1.Code.ComponentSystem.Components.GamePlay;
using MonoGameProject1.Code.ComponentSystem.Components.Physics;
using MonoGameProject1.Code.Physics;

namespace MonoGameProject1;

public class Game1 : Game
{
    public const float WorldUnitSize = 32f;
    public static GameInfo Info;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _spriteSheet;
    private Entity _player;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 1080;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.IsFullScreen = false;
        _graphics.ApplyChanges();

        Window.AllowUserResizing = true;

        Window.Title = "Tropical Dungeon";

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
        Camera.Instance = new Camera();
        Info = new GameInfo();
        PopulateInfo();
        _player = new Entity(Vector2.One * 5, "Player");
        _player.AddComponent(new SpriteRenderer(SpriteLoader.PlayerSprite,depth:SpriteDepths.Player));
        _player.AddComponent(new PlayerController());
        _player.AddComponent(new Collider(Vector2.One*0.5f));
        _player.AddComponent(new ActiveCollider());
        
        var wall = new Entity(Vector2.Zero, "Wall");
        wall.AddComponent(new SpriteRenderer(SpriteLoader.WallSprite));
        wall.AddComponent(new Collider(Vector2.One*0.5f));
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        SpriteLoader.Initialize(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        PopulateInfo(gameTime);

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        EntityManager.Update();
        CollisionChecker.CheckAll();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(new Color(17, 121, 92));
        _spriteBatch.Begin(
            samplerState: SamplerState.PointClamp,
            sortMode: SpriteSortMode.FrontToBack
            );

        EntityManager.Draw(_spriteBatch);
        // playerSprite.Draw(_spriteBatch, Camera.WorldToScreen(new Vector2(0, 0)));


        _spriteBatch.End();

        base.Draw(gameTime);
    }

#nullable enable
    void PopulateInfo(GameTime? gameTime = null)
    {
        if (gameTime != null)
        {
            Info.ElapsedSeconds =
                (float)gameTime.ElapsedGameTime.TotalSeconds +
                (gameTime.ElapsedGameTime.Milliseconds / 1000f) +
                (gameTime.ElapsedGameTime.Microseconds / 1000f / 1000f);
        }

        var screenHeight = GraphicsDevice.Viewport.Height;
        var screenWidth = GraphicsDevice.Viewport.Width;
        Info.ScreenCenter = new Vector2(screenWidth, screenHeight) * 0.5f;
        Info.ScreenDimensions = new Vector2(screenWidth, screenHeight);
    }
}