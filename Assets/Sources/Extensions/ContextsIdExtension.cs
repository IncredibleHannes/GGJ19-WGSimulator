using System;
using Entitas;

public partial class CoreContext
{
    private bool idAutogenerationEnabled = false;
    public bool IdAutogenerationEnabled
    {
        get => idAutogenerationEnabled;
        set
        {
            if (value && !IdAutogenerationEnabled) this.OnEntityCreated += AddId;
            else this.OnEntityCreated -= AddId;
            idAutogenerationEnabled = value;
        }
    }

    private static void AddId(IContext context, IEntity entity)
    {
        (entity as CoreEntity).ReplaceId(entity.creationIndex);
    }
}