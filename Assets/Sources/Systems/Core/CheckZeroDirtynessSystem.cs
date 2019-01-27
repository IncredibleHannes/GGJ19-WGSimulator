using System.Collections.Generic;
using Entitas;

public sealed class CheckZeroDirtynessSystem : ReactiveSystem<CoreEntity>
{

    public CheckZeroDirtynessSystem(Contexts contexts) : base(contexts.core)
    {

    }

    protected override ICollector<CoreEntity> GetTrigger(IContext<CoreEntity> context)
    {
        return context.CreateCollector(CoreMatcher.DirtLevel);
    }

    protected override bool Filter(CoreEntity entity)
    {
        return entity.hasDirtLevel;
    }

    protected override void Execute(List<CoreEntity> entities)
    {
        foreach (var room in entities)
        {
            if (room.dirtLevel.value < 0)
            {
                room.ReplaceDirtLevel(0);
            }
        }
    }
}
