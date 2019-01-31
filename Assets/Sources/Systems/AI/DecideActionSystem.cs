using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;
using System.Threading;


public class DecideActionSystem : IExecuteSystem
{
    readonly CoreContext context;
    readonly CommandContext command;
    readonly IGroup<CoreEntity> flatmates;
    readonly IGroup<CoreEntity> busyFlatmates;
    readonly IGroup<CoreEntity> rooms;

    public DecideActionSystem(Contexts contexts)
    {
        context = contexts.core;
        command = contexts.command;
        rooms = context.GetGroup(CoreMatcher.AllOf(CoreMatcher.Room, CoreMatcher.RoomId, CoreMatcher.DirtLevel));
        busyFlatmates = context.GetGroup(CoreMatcher.AllOf(CoreMatcher.Flatmate, CoreMatcher.ActiveAction, CoreMatcher.CurrentRoom));
        flatmates = context.GetGroup(CoreMatcher.AllOf(CoreMatcher.AIBehaviour, CoreMatcher.Flatmate, CoreMatcher.Motivation, CoreMatcher.Fun, CoreMatcher.CurrentRoom, CoreMatcher.Opinion).NoneOf(CoreMatcher.Player, CoreMatcher.ActiveAction, CoreMatcher.AIDeciding));
    }

    public void Execute()
    {
        foreach (var flatmate in flatmates.GetEntities())
        {
            float totalDirtyness = 0;
            Dictionary<int, AIRoom> aiRooms = new Dictionary<int, AIRoom>();
            foreach (var room in rooms)
            {
                totalDirtyness += room.dirtLevel.value;
                aiRooms.Add(room.roomId.value, new AIRoom(room.roomType.room, room.dirtLevel.value, room.roomId.value));
            }
            List<AIFlatmate> aIFlatmates = new List<AIFlatmate>();
            foreach (var busyFlatmate in busyFlatmates)
            {
                aIFlatmates.Add(new AIFlatmate(busyFlatmate.activeAction.value, busyFlatmate.currentRoom.roomId));
            }
            State s = new State(flatmate.motivation.value, flatmate.fun.value, flatmate.opinion.value, totalDirtyness, flatmate.aIBehaviour.value, flatmate.currentRoom.roomId, aiRooms, aIFlatmates);
            AIDecisionService.decideNextAction(s, flatmate.id.value);
            flatmate.isAIDeciding = true;
        }
    }
}
