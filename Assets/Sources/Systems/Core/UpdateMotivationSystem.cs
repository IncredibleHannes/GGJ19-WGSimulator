using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class UpdateMotivationSystem : IExecuteSystem
{
    readonly CoreContext context;
    readonly IGroup<CoreEntity> entities;

    public UpdateMotivationSystem(Contexts contexts)
    {
        context = contexts.core;

        entities = context.GetGroup(CoreMatcher.AllOf(CoreMatcher.Flatmate, CoreMatcher.Motivation, CoreMatcher.ActiveAction));
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            e.ReplaceMotivation(e.motivation.value + e.activeAction.value.MotivationPerTick);
        }
    }
}
