using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class ApplyDecitionSystem : IExecuteSystem
{
    readonly CoreContext context;
    readonly CommandContext command;

    readonly IGroup<CoreEntity> flatmates;

    System.Random rnd = new System.Random();

    public ApplyDecitionSystem(Contexts contexts)
    {
        context = contexts.core;

        command = contexts.command;

        flatmates = context.GetGroup(CoreMatcher.AllOf(CoreMatcher.AIDeciding, CoreMatcher.CurrentRoom));
    }

    public void Execute()
    {
        foreach (var flatmate in flatmates.GetEntities())
        {
            if (AIDecisionService.hasResult(flatmate.flatmateId.value))
            {

                var nextAction = AIDecisionService.popResult(flatmate.flatmateId.value);
                if (nextAction == null)
                {
                    flatmate.RemoveAIDeciding();
                    return;
                }
                if (nextAction.room != flatmate.currentRoom.roomId)
                {
                    command.CreateEntity().AddEnterRoomCommand(nextAction.room, flatmate.flatmateId.value);
                }
                command.CreateEntity().AddStartActionCommand(nextAction.action, flatmate.flatmateId.value, nextAction.action.DefaultLength - 1 + 2 * (float)rnd.NextDouble());
                flatmate.RemoveAIDeciding();
            }
        }

    }
}
