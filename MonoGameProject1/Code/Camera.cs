using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameProject1.Code;

public class Camera
{
    public static Camera Instance;
    public Vector2 Position;

    public static Vector2 WorldToScreen(Vector2 worldPos)
    {
        return (worldPos-Instance.Position)*Game1.WorldUnitSize+ Game1.Info.ScreenCenter;
    }
    
    public static Vector2 ScreenToWorld(Vector2 screenPos)
    {
        return (screenPos - Game1.Info.ScreenCenter) / Game1.WorldUnitSize + Instance.Position;
    }}