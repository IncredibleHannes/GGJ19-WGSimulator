using Entitas;

public sealed class UpdateDurationTimeSystem : IExecuteSystem
{
    readonly CoreContext context;

    readonly IGroup<CoreEntity> timedObjects;

    public UpdateDurationTimeSystem(Contexts contexts)
    {
        this.context = contexts.core;
        timedObjects = context.GetGroup(CoreMatcher.ActionDuration);

    }

    public void Execute()
    {
        foreach (var timedObject in timedObjects)
        {
            timedObject.ReplaceActionDuration(timedObject.actionDuration.value - context.timeSinceLastTick.value);
        }
    }
}
