using Entitas;

public sealed class UpdateTimeSinceLastTickSystem : IExecuteSystem
{
    readonly Contexts contexts;

    public UpdateTimeSinceLastTickSystem(Contexts contexts)
    {
        this.contexts = contexts;
    }

    public void Execute()
    {
        contexts.core.ReplaceTimeSinceLastTick(contexts.input.hasDeltaT ? contexts.input.deltaT.value : 0);
    }
}
