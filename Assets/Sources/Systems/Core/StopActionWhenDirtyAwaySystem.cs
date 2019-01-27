using System.Collections.Generic;
using Entitas;

public sealed class StopActionWhenDirtyAwaySystem : ReactiveSystem<CoreEntity>
{

    readonly CommandContext commandContext;

    readonly CoreContext coreContext;

    public StopActionWhenDirtyAwaySystem(Contexts contexts) : base(contexts.core)
    {
        this.commandContext = contexts.command;
        this.coreContext = contexts.core;
    }

    protected override ICollector<CoreEntity> GetTrigger(IContext<CoreEntity> context)
    {
        return context.CreateCollector(CoreMatcher.AllOf(CoreMatcher.DirtLevel, CoreMatcher.RoomId));
    }

    protected override bool Filter(CoreEntity entity)
    {
        return entity.hasDirtLevel && entity.hasRoomId;
    }

    protected override void Execute(List<CoreEntity> entities)
    {
        foreach (var room in entities)
        {
            if (room.dirtLevel.value <= 0)
            {
                var flatmatesInRoom = coreContext.GetEntitiesWithCurrentRoom(room.roomId.value);

                foreach (var flatmateWithTidyUpJob in flatmatesInRoom)
                {
                    if (flatmateWithTidyUpJob.hasActiveAction && flatmateWithTidyUpJob.activeAction.value.DirtPerSecond < 0)
                    {
                        commandContext.CreateEntity().AddStopActionCommand(flatmateWithTidyUpJob.flatmateId.value);
                    }
                }
            }
        }
    }
}
