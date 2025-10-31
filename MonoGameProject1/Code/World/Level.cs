using Microsoft.Xna.Framework;
using MonoGameProject1.Code.ComponentSystem;
using MonoGameProject1.Code.ComponentSystem.Components;
using MonoGameProject1.Code.ComponentSystem.Components.Physics;

namespace MonoGameProject1.Code.World;

public class Level
{
    private const string configuration =
        "11111111111111;" +
        "10000000000001;" +
        "10000000000001;" +
        "10000001110001;" +
        "10000000000001;" +
        "10001000000001;" +
        "10000100000001;" +
        "10000000000001;" +
        "10000000000001;" +
        "10000000000001;" +
        "10011111110001;" +
        "10000000000001;" +
        "11111111111111";

    public static void BuildLevel(Vector2 offset, string config = configuration)
    {
        var lines = config.Split(';');
        int totalWalls = 0;
        int totalFloors = 0;
        for (int y = 0; y < lines.Length; y++)
        {
            for (int x = 0; x < lines[y].Length; x++)
            {
                if (lines[y][x] == '1')
                {
                    var wall = new Entity(offset + new Vector2(x,y), "Wall_"+totalWalls);
                    wall.AddComponent(new SpriteRenderer(SpriteLoader.WallSprite));
                    wall.AddComponent(new Collider(Vector2.One*0.5f));
                    totalWalls++;
                }else if (lines[y][x] == '0')
                {
                    var floor = new Entity(offset + new Vector2(x,y), "Floor_"+totalFloors);
                    floor.AddComponent(new SpriteRenderer(SpriteLoader.FloorSprite));
                    totalFloors++;
                }
            }
        }
    }
}