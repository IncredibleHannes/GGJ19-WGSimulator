using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class UpdateEnterRoomCleanlinessOpinionSystem : ReactiveSystem<CoreEntity>
{
    private readonly CoreContext coreContext;
    private readonly IGroup<CoreEntity> flatmates;
    System.Random random = new System.Random();

    public UpdateEnterRoomCleanlinessOpinionSystem(Contexts contexts) : base(contexts.core)
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

            // There's noone to glorify.
            if (lastCleanup.Count == 0) continue;

            var modifier = e.opinionModifier;
            float opinionDelta = 0;

            if (room.dirtLevel.value < modifier.cleanlinessToleranceLevel)
            {
                opinionDelta += (modifier.cleanlinessToleranceLevel - room.dirtLevel.value) * modifier.cleanlinessToleranceMultiplier;
            }

            int heroId = lastCleanup[0];
            e.opinion.value[heroId] = e.opinion.value.GetOrDefault(heroId, 0) + opinionDelta;
            e.ReplaceOpinion(e.opinion.value);
        }
    }
}
