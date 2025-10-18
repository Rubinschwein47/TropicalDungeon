using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoGameProject1.Code.ComponentSystem.Components.Physics;

/// <summary>
/// The Equivalent to Unity's Rigidbody
/// responsible for actually doing something on collisions.
/// Requires a Collider to be Present on Initialisation
/// </summary>
public class ActiveCollider:EntityComponent
{
    public static List<ActiveCollider> Actives = new();
    public Collider Collider {get; private set;}
    public Vector2 Velocity;

    public override void OnAddedToEntity()
    {
        Collider = Owner.GetComponent<Collider>();
        if (Collider == null)
        {
            throw new Exception("No Collider is attached to the entity with name: " + Owner.Name);
        }
        Actives.Add(this);
    }

    public override void OnRemovedFromEntity()
    {
        Actives.Remove(this);
    }

    public override void Update()
    {
    }

    public void OnCollide(Collider otherCollider,Vector2 overlap)
    {
        if (overlap.X > overlap.Y)
        {
            this.Owner.Position.X += otherCollider.Owner.Position.X - this.Owner.Position.X > 0? overlap.X : -overlap.X;
        }
        else
        {
            this.Owner.Position.Y += otherCollider.Owner.Position.Y - this.Owner.Position.Y > 0? overlap.Y : -overlap.Y;
        }
    }
}