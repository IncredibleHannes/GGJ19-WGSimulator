using System.Collections.Generic;
using Entitas;

public sealed class CreateRoomSystem : ReactiveSystem<CommandEntity>
{
    private readonly CoreContext coreContext;

    public CreateRoomSystem(Contexts contexts) : base(contexts.command)
    {
        this.coreContext = contexts.core;
    }

    protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
    {
        return context.CreateCollector(CommandMatcher.CreateRoomCommand);
    }

    protected override bool Filter(CommandEntity entity)
    {
        return entity.hasCreateRoomCommand;
    }

    protected override void Execute(List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var room = coreContext.CreateEntity();
            room.isRoom = true;
            room.ReplaceRoomType(e.createRoomCommand.roomType);
            room.ReplaceRoomId(room.creationIndex);
            room.ReplaceDirtLevel(10000);
            room.AddLastCleanup(new List<int>());

            e.isDestroyed = true;
        }
    }
}
