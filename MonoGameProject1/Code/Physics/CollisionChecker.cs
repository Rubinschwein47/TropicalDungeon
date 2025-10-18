using System;
using System.Numerics;
using MonoGameProject1.Code.ComponentSystem.Components.Physics;

namespace MonoGameProject1.Code.Physics;

public class CollisionChecker
{
    public static void CheckAll()
    {
        foreach (var activeCollider in ActiveCollider.Actives)
        {
            foreach (var collider in Collider.Colliders)
            {
                if (collider == activeCollider.Collider)
                {
                    continue;
                }

                var distX = Math.Abs(collider.Owner.Position.X - activeCollider.Owner.Position.X)
                            - (collider.Dimensions.X + activeCollider.Collider.Dimensions.X);
                if (distX > 0)
                {
                    continue;
                }
                var disty = Math.Abs(collider.Owner.Position.Y - activeCollider.Owner.Position.Y)
                            - (collider.Dimensions.Y + activeCollider.Collider.Dimensions.Y);
                if (disty > 0f)
                {
                    continue;
                }
                
                activeCollider.OnCollide(collider,new Vector2(distX,disty));
            }
        }
    }
}