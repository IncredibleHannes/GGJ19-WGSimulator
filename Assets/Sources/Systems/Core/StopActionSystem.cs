using System.Collections.Generic;
using Entitas;

public sealed class StopActionSystem : ReactiveSystem<CommandEntity>
{
    private readonly CoreContext coreContext;
    public StopActionSystem(Contexts contexts) : base(contexts.command)
    {
        this.coreContext = contexts.core;
    }

    protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
    {
        return context.CreateCollector(CommandMatcher.StopActionCommand);
    }

    protected override bool Filter(CommandEntity entity)
    {
        return entity.hasStopActionCommand;
    }

    protected override void Execute(List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var command = e.stopActionCommand;

            var flatmate = coreContext.GetEntityWithFlatmateId(command.flatmateId);
            flatmate.RemoveActiveAction();
            flatmate.RemoveActionDuration();

            e.isDestroyed = true;
        }
    }
}
