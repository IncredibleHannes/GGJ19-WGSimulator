using System.Collections.Generic;
using Entitas;

public sealed class StartActionSystem : ReactiveSystem<CommandEntity>
{
    private readonly CoreContext coreContext;

    public StartActionSystem(Contexts contexts) : base(contexts.command)
    {
        this.coreContext = contexts.core;
    }

    protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
    {
        return context.CreateCollector(CommandMatcher.StartActionCommand);
    }

    protected override bool Filter(CommandEntity entity)
    {
        return entity.hasStartActionCommand;
    }

    protected override void Execute(List<CommandEntity> entities)
    {
        foreach (var e in entities)
        {
            var command = e.startActionCommand;

            var flatmate = coreContext.GetEntityWithFlatmateId(command.flatmateId);
            flatmate.ReplaceActiveAction(command.action);

            e.isDestroyed = true;
        }
    }
}
