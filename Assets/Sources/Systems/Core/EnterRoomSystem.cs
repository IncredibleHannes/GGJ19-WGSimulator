using System.Collections.Generic;
using Entitas;

public sealed class EnterRoomSystem : ReactiveSystem<CommandEntity>
{
    private readonly CoreContext coreContext;

    public EnterRoomSystem(Contexts contexts) : base(contexts.command)
    {
        coreContext = contexts.core;
    }

    protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
    {
        return context.CreateCollector(CommandMatcher.EnterRoomCommand);
    }

    protected override bool Filter(CommandEntity entity)
    {
        return entity.hasEnterRoomCommand;
    }

    protected override void Execute(List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var command = e.enterRoomCommand;

            var flatmate = coreContext.GetEntityWithFlatmateId(command.flatmateId);
            flatmate.ReplaceCurrentRoom(command.roomId);

            e.isDestroyed = true;
        }
    }
}
