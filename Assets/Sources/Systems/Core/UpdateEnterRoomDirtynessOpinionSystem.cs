using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class UpdateEnterRoomDirtynessOpinionSystem : ReactiveSystem<CoreEntity>
{
    private readonly CoreContext coreContext;
    private readonly IGroup<CoreEntity> flatmates;
    System.Random random = new System.Random();

    public UpdateEnterRoomDirtynessOpinionSystem(Contexts contexts) : base(contexts.core)
    {
        coreContext = contexts.core;
        flatmates = coreContext.GetGroup(CoreMatcher.AllOf(CoreMatcher.FlatmateId));
    }

    protected override ICollector<CoreEntity> GetTrigger(IContext<CoreEntity> context)
    {
        return context.CreateCollector(CoreMatcher.CurrentRoom);
    }

    protected override bool Filter(CoreEntity entity)
    {
        if (!entity.hasCurrentRoom || !entity.hasOpinion || !entity.hasOpinionModifier) return false;

        var room = coreContext.GetEntityWithRoomId(entity.currentRoom.roomId);
        if (room == null || !room.hasLastCleanup) return false;

        return room.hasDirtLevel;
    }

    protected override void Execute(List<CoreEntity> entities)
    {
        if (flatmates.count < 1) return;

        foreach (var e in entities)
        {
            var room = coreContext.GetEntityWithRoomId(e.currentRoom.roomId);

            List<int> lastCleanup = room.lastCleanup.value;

            int victim;
            if (lastCleanup.Count == flatmates.count)
            {
                victim = lastCleanup[lastCleanup.Count - 1];
            }
            else
            {
                List<int> potentialVictims = new List<int>();
                foreach (var flatmate in flatmates) potentialVictims.Add(flatmate.flatmateId.value);
                foreach (var flatmateId in lastCleanup) potentialVictims.Remove(flatmateId);
                potentialVictims.Remove(e.flatmateId.value);

                // There's noone to be mad about.
                if (potentialVictims.Count == 0) continue;

                int victimIndex = random.Next(potentialVictims.Count);
                victim = potentialVictims[victimIndex];
            }

            var modifier = e.opinionModifier;

            float opinionDelta = 0;

            if (room.dirtLevel.value > modifier.dirtToleranceLevel)
            {
                opinionDelta -= (room.dirtLevel.value - modifier.dirtToleranceLevel) * modifier.dirtToleranceMultiplier;
            }

            e.opinion.value[victim] = e.opinion.value.GetOrDefault(victim, 0) + opinionDelta;
            e.ReplaceOpinion(e.opinion.value);
        }
    }
}
