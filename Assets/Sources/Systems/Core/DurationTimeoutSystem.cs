using Entitas;

public sealed class DurationTimeoutSystem : IExecuteSystem
{
    readonly CoreContext context;
    readonly CommandContext command;

    readonly IGroup<CoreEntity> timedObjects;

    public DurationTimeoutSystem(Contexts contexts)
    {
        this.context = contexts.core;
        this.command = contexts.command;
        timedObjects = context.GetGroup(CoreMatcher.AllOf(CoreMatcher.ActionDuration, CoreMatcher.FlatmateId));
    }

    public void Execute()
    {
        foreach (var timedObject in timedObjects)
        {
            if (timedObject.actionDuration.value <= 0)
            {
                command.CreateEntity().AddStopActionCommand(timedObject.flatmateId.value);
            }
        }
    }
}
