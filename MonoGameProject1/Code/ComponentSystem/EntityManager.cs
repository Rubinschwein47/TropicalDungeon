using System.Collections.Generic;
using System.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameProject1.Code.ComponentSystem;

public class EntityManager
{
    public static EntityManager Instance;
    public static Dictionary<uint, Entity> Entities = new();

    public static void AddEntity(Entity entity)
    {
        if (Entities.ContainsKey(entity.ID))
        {
            throw new DuplicateNameException(
                "Entity already exists with the ID: "
                + entity.ID
                + ", IDs Must be unique!");
        }

        Entities.Add(entity.ID, entity);
    }

    public static void RemoveEntity(Entity entity)
    {
        Entities.Remove(entity.ID);
    }

    public static void Draw(SpriteBatch spriteBatch)
    {
        foreach (var keyValuePair in Entities)
        {
            keyValuePair.Value.Draw(spriteBatch);
        }
    }

    public static void Update()
    {
        foreach (var keyValuePair in Entities)
        {
            keyValuePair.Value.Update();
        }
    }
}