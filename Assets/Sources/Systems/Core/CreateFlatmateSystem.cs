using System.Collections.Generic;
using Entitas;

public sealed class CreateFlatmateSystem : ReactiveSystem<CommandEntity>
{
    private readonly CoreContext coreContext;

    public CreateFlatmateSystem(Contexts contexts) : base(contexts.command)
    {
        coreContext = contexts.core;
    }

    protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
    {
        return context.CreateCollector(CommandMatcher.CreateFlatmateCommand);
    }

    protected override bool Filter(CommandEntity entity)
    {
        return entity.hasCreateFlatmateCommand;
    }

    protected override void Execute(List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var command = e.createFlatmateCommand;

            var flatmate = coreContext.CreateEntity();
            flatmate.isFlatmate = true;
            flatmate.AddFlatmateId(flatmate.creationIndex);
            flatmate.AddName(command.name);
            flatmate.AddMotivation(0);
            flatmate.AddFun(0);
            flatmate.AddCurrentRoom(command.startingRoomId);

            e.isDestroyed = true;
        }
    }
}
