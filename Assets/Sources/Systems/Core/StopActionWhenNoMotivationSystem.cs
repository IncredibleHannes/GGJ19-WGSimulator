using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class StopActionWhenNoMotivationSystem : IExecuteSystem
{
    readonly CoreContext context;
    readonly CommandContext command;
    readonly IGroup<CoreEntity> entities;

    public StopActionWhenNoMotivationSystem(Contexts contexts)
    {
        this.context = contexts.core;
        this.command = contexts.command;

        entities = context.GetGroup(CoreMatcher.AllOf(CoreMatcher.Motivation, CoreMatcher.ActiveAction, CoreMatcher.FlatmateId));
    }

    public void Execute()
    {
        foreach (var e in entities)
        {
            if (e.motivation.value <= 0 && e.activeAction.value.MotivationPerSecond < 0)
            {
                command.CreateEntity().AddStopActionCommand(e.flatmateId.value);
            }
        }
    }
}
