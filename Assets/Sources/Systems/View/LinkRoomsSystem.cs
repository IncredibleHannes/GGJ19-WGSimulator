using System.Collections.Generic;
using Entitas;

public sealed class LinkRoomsSystem : ReactiveSystem<ViewEntity>
{
    CoreContext coreContext;

    public LinkRoomsSystem(Contexts contexts) : base(contexts.view)
    {
        coreContext = contexts.core;
    }

    protected override ICollector<ViewEntity> GetTrigger(IContext<ViewEntity> context)
    {
        return context.CreateCollector(ViewMatcher.View);
    }

    protected override bool Filter(ViewEntity entity)
    {
        return entity.hasView;
    }

    protected override void Execute(List<ViewEntity> entities)
    {
        foreach (var e in entities)
        {
            var flat = e.view.value as FlatView;

            flat.livingRoom.Link(coreContext.GetEntityWithRoomId(flat.livingRoom.roomId));
            flat.bathroom.Link(coreContext.GetEntityWithRoomId(flat.bathroom.roomId));
            flat.kitchen.Link(coreContext.GetEntityWithRoomId(flat.kitchen.roomId));
        }
    }
}
