using Microsoft.Xna.Framework.Graphics;

namespace MonoGameProject1.Code.ComponentSystem;


public abstract class EntityComponent
{
    private static uint LastID;
    public uint ID {get; private set;}

    public Entity Owner;
    
    public bool IsActive => Owner != null;
    
    public EntityComponent()
    {
        ID = LastID;
        LastID = 0;
    }
    
    public virtual void OnAddedToEntity() {}

    public virtual void OnRemovedFromEntity(){}
    
    public virtual void onDraw(SpriteBatch spriteBatch){}
    
    public virtual void Update(){}
}