using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameProject1.Code.ComponentSystem;

public class Entity
{
    private static uint LastID;
    public Vector2 Position;
    /// <summary>
    /// Unique Identifier
    /// </summary>
    public uint ID {get; private set;}
    /// <summary>
    /// Non Unique Identifier
    /// </summary>
    public string Name {get; private set;}
    public List<EntityComponent> Components { get; private set; } = new();

    public Entity(Vector2 position,string name)
    {
        Position = position;
        Name = name;
        ID = LastID;
        LastID++;
        EntityManager.AddEntity(this);
    }

    public void AddComponent(EntityComponent component)
    {
        Components.Add(component);
        component.Owner = this;
    }

    public void RemoveComponent(EntityComponent component)
    {
        Components.Remove(component);
        component.Owner = null;
        component.OnRemovedFromEntity();
    }

    /// <summary>
    /// Returns the first component of the Specified Type
    /// </summary>
    /// <returns>null if none are found</returns>
    public T GetComponent<T>() where T : EntityComponent
    {
        for (int i = 0; i < Components.Count; i++)
        {
            if (Components[i] is T)
            {
                return Components[i] as T;
            }
        }
        return null;
    }

    /// <summary>
    /// runs the draw Call for all Components
    /// </summary>
    /// <param name="spriteBatch">The Spritebatch used by all components</param>
    public void Draw(SpriteBatch spriteBatch)
    {
        for (int i = 0; i < Components.Count; i++)
        {
            Components[i].onDraw(spriteBatch);
        }
    }
    /// <summary>
    /// Runs the Update Method of all components
    /// </summary>
    public void Update()
    {
        for (int i = 0; i < Components.Count; i++)
        {
            Components[i].Update();
        }
    }
}