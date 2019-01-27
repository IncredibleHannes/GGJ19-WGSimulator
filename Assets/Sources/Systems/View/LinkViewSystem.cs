using System.Collections.Generic;
using Entitas;

public sealed class LinkViewSystem : ReactiveSystem<ViewEntity>
{
    CoreContext context;

    public LinkViewSystem(Contexts contexts) : base(contexts.view)
    {
        this.context = contexts.core;
    }

    protected override ICollector<ViewEntity> GetTrigger(IContext<ViewEntity> context)
    {
        return context.CreateCollector(ViewMatcher.AllOf(ViewMatcher.View, ViewMatcher.CoreEntityReference));
    }

    protected override bool Filter(ViewEntity entity)
    {
        return entity.hasView && entity.hasCoreEntityReference;
    }

    protected override void Execute(List<ViewEntity> entities)
    {
        foreach (var e in entities)
        {
            CoreEntity coreEntity = context.GetEntityWithId(e.coreEntityReference.entityId);
            if (coreEntity == null) continue;

            e.view.value.Link(coreEntity);
        }
    }
}