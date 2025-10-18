using System;
using Microsoft.Xna.Framework;

namespace MonoGameProject1.Code.ComponentSystem.Components.Physics;

/// <summary>
/// The Equivalent to Unity's Rigidbody
/// responsible for actually doing something on collisions.
/// Requires a Collider to be Present on Initialisation
/// </summary>
public class ActiveCollider:EntityComponent
{
    public Collider Collider {get; private set;}
    public Vector2 Velocity;

    public override void OnAddedToEntity()
    {
        Collider = Owner.GetComponent<Collider>();
        if (Collider == null)
        {
            throw new Exception("No Collider is attached to the entity with name: " + Owner.Name);
        }
    }

    public override void Update()
    {
        
    }
}