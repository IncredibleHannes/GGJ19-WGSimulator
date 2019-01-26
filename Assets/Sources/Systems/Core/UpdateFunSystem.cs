using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class UpdateFunSystem : IExecuteSystem
{
    readonly CoreContext context;
    readonly IGroup<CoreEntity> entities;

    public UpdateFunSystem(Contexts contexts)
    {
        context = contexts.core;

        entities = context.GetGroup(CoreMatcher.AllOf(CoreMatcher.Flatmate, CoreMatcher.Fun, CoreMatcher.ActiveAction));
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            e.ReplaceFun(e.fun.value + e.activeAction.value.FunPerTick);
        }
    }
}
