using Entitas;
using UnityEngine;

public sealed class DeltaTSystem : IExecuteSystem
{
    readonly Contexts contexts;

    public DeltaTSystem(Contexts contexts)
    {
        this.contexts = contexts;
    }

    public void Execute()
    {
        contexts.input.ReplaceDeltaT(Time.deltaTime);
    }
}
