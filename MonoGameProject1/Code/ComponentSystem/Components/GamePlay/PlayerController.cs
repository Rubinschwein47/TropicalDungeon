using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGameProject1.Code.ComponentSystem.Components.GamePlay;

public class PlayerController : EntityComponent
{
    private const float _speed = 2f; 
    public override void Update()
    {
        var keyboard = Keyboard.GetState();
        Vector2 desiredDirections = new Vector2(
            keyboard.IsKeyDown(Keys.A) ? -1 : keyboard.IsKeyDown(Keys.D) ? 1 : 0,
        keyboard.IsKeyDown(Keys.W)? -1 : keyboard.IsKeyDown(Keys.S)?1:0);

        Vector2 Velocity = desiredDirections * Game1.Info.ElapsedSeconds * _speed;
        
        Owner.Position += Velocity;
    }
}