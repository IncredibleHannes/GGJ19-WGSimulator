using System.Collections.Generic;
using Entitas;

public sealed class CheckZeroMotivationSystem : ReactiveSystem<CoreEntity>
{

    public CheckZeroMotivationSystem(Contexts contexts) : base(contexts.core)
    {

    }

    protected override ICollector<CoreEntity> GetTrigger(IContext<CoreEntity> context)
    {
        return context.CreateCollector(CoreMatcher.Motivation);
    }

    protected override bool Filter(CoreEntity entity)
    {
        return entity.hasMotivation;
    }

    protected override void Execute(List<CoreEntity> entities)
    {
        foreach (var e in entities)
        {
            if (e.motivation.value < 0)
            {
                e.ReplaceMotivation(0);
            }
        }
    }
}
