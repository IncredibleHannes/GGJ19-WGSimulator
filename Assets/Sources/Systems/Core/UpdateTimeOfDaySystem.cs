using Entitas;

public sealed class UpdateTimeOfDaySystem : IExecuteSystem
{
    readonly Contexts contexts;

    public UpdateTimeOfDaySystem(Contexts contexts)
    {
        this.contexts = contexts;
    }

    public void Execute()
    {
        float timeOfDay = contexts.core.hasTimeOfDay ? contexts.core.timeOfDay.value : 0;
        timeOfDay += contexts.core.timeSinceLastTick.value;
        timeOfDay %= 20;
        contexts.core.ReplaceTimeOfDay(timeOfDay);
    }
}
