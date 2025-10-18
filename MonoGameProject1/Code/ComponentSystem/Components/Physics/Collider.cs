using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoGameProject1.Code.ComponentSystem.Components.Physics;

public class Collider:EntityComponent
{
    public static List<Collider> Colliders = new();

    public Vector2 Dimensions;

    public Collider(Vector2 dimensions)
    {
        Dimensions = dimensions;
    }
    
    
    public override void OnAddedToEntity()
    {
        Colliders.Add(this);
    }

    public override void OnRemovedFromEntity()
    {
        Colliders.Remove(this);
    }
}