using System.Collections.Generic;
using Entitas;

public sealed class CreateFlatSystem : ReactiveSystem<CommandEntity>
{
    private readonly CoreContext coreContext;
    private readonly CommandContext commandContext;

    public CreateFlatSystem(Contexts contexts) : base(contexts.command)
    {
        coreContext = contexts.core;
        commandContext = contexts.command;
    }

    protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
    {
        return context.CreateCollector(CommandMatcher.CreateFlatCommand);
    }

    protected override bool Filter(CommandEntity entity)
    {
        return entity.hasCreateFlatCommand;
    }

    protected override void Execute(List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var command = e.createFlatCommand;

            var flat = coreContext.CreateEntity();
            flat.isFlat = true;

            commandContext.CreateEntity().AddCreateRoomCommand(0, Room.LIVING_ROOM);
            commandContext.CreateEntity().AddCreateRoomCommand(1, Room.KITCHEN);
            commandContext.CreateEntity().AddCreateRoomCommand(2, Room.BATHROOM);
        }
    }
}
