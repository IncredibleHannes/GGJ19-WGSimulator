using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System;

public class DecideActionSystem : IExecuteSystem
{
    readonly CoreContext context;
    readonly CommandContext command;
    readonly IGroup<CoreEntity> flatmates;
    readonly IGroup<CoreEntity> busyFlatmates;
    readonly IGroup<CoreEntity> rooms;

    private int SEARCH_DEPTH = 3;
    private int DEFAULT_ACTION_LENGTH = 5;

    System.Random rnd = new System.Random();

    public DecideActionSystem(Contexts contexts)
    {
        context = contexts.core;
        command = contexts.command;
        rooms = context.GetGroup(CoreMatcher.RoomId);
        busyFlatmates = context.GetGroup(CoreMatcher.AllOf(CoreMatcher.Flatmate, CoreMatcher.ActiveAction, CoreMatcher.CurrentRoom));
        flatmates = context.GetGroup(CoreMatcher.AllOf(CoreMatcher.AIBehaviour, CoreMatcher.Flatmate, CoreMatcher.Motivation, CoreMatcher.Fun, CoreMatcher.CurrentRoom, CoreMatcher.Opinion).NoneOf(CoreMatcher.Player, CoreMatcher.ActiveAction));
    }

    public void Execute()
    {
        foreach (var flatmate in flatmates)
        {
            float totalDirtyness = 0;
            Dictionary<int, float> roomDirtyness = new Dictionary<int, float>();
            foreach (var room in rooms)
            {
                totalDirtyness += room.dirtLevel.value;
                roomDirtyness.Add(room.roomId.value, room.dirtLevel.value);
            }
            State s = new State(flatmate.motivation.value, flatmate.fun.value, flatmate.opinion.value, roomDirtyness, totalDirtyness, flatmate.aIBehaviour.value, flatmate.currentRoom.roomId);
            AIAction nextAction = decideNextAction(s);
            if (nextAction == null)
            {
                return;
            }
            if (nextAction.room != flatmate.currentRoom.roomId)
            {
                command.CreateEntity().AddEnterRoomCommand(nextAction.room, flatmate.flatmateId.value);
            }
            command.CreateEntity().AddStartActionCommand(nextAction.action, flatmate.flatmateId.value, DEFAULT_ACTION_LENGTH + (float)rnd.NextDouble());

        }
    }

    private AIAction decideNextAction(State s)
    {
        var maxScore = float.MinValue;
        AIAction bestAction = null;
        var possibleAcions = getPossibleActions(s);
        possibleAcions.Shuffle();
        foreach (var action in possibleAcions)
        {
            float score = findBestAction(applyAction(action, s), SEARCH_DEPTH);
            if (maxScore < score)
            {
                maxScore = score;
                bestAction = action;
            }
        }
        return bestAction;

    }

    private List<AIAction> getPossibleActions(State s)
    {
        var result = new List<AIAction>();
        foreach (var action in Action.Actions)
        {
            if (-(action.MotivationPerSecond * DEFAULT_ACTION_LENGTH) <= s.motivation)
            {
                foreach (var room in rooms)
                {
                    bool roomIsDirty = !(action.DirtPerSecond < 0) || room.dirtLevel.value + (action.DirtPerSecond * DEFAULT_ACTION_LENGTH) > 0;
                    bool actionAlreadyDone = false;
                    foreach (var flatmate in busyFlatmates)
                    {
                        actionAlreadyDone = actionAlreadyDone || (flatmate.activeAction.value.Title == action.Title && flatmate.currentRoom.roomId == room.roomId.value);
                    }
                    if (Array.Exists(action.AllowedRoomTypes, roomType => roomType == room.roomType.room.Type) && roomIsDirty && !actionAlreadyDone)
                        result.Add(new AIAction(action, room.roomId.value));
                }
            }

        }
        return result;
    }

    private float calculateScore(AIAction a, State s)
    {
        var newState = applyAction(a, s);
        float opinion = 0;
        foreach (KeyValuePair<int, float> entry in s.opinion)
        {
            opinion += entry.Value;
        }
        return s.motivation * s.aiBehaviour.motivationMultiplier + s.fun * s.aiBehaviour.funMultiplier + s.aiBehaviour.opinionMultiplier * opinion - s.totalDirtyness * s.aiBehaviour.dirtynessMultiplier;
    }

    private float findBestAction(State s, int searchDepth)
    {
        var maxScore = float.MinValue;
        if (searchDepth <= 0)
        {
            foreach (var action in getPossibleActions(s))
            {
                var score = calculateScore(action, s);
                if (maxScore < score)
                {
                    maxScore = score;
                }
            }
            return maxScore;
        }
        foreach (var action in getPossibleActions(s))
        {

            float score = findBestAction(applyAction(action, s), searchDepth - 1);
            if (maxScore < score)
            {
                maxScore = score;
            }
        }
        return maxScore;
    }

    private State applyAction(AIAction a, State s)
    {
        float newMotivation = a.action.MotivationPerSecond * DEFAULT_ACTION_LENGTH + s.motivation;
        float newFun = a.action.FunPerSecond * DEFAULT_ACTION_LENGTH + s.fun;
        float madeDirt = a.action.DirtPerSecond * DEFAULT_ACTION_LENGTH;
        Dictionary<int, float> newOpinion = s.opinion;
        if (!s.roomDirtyness.ContainsKey(s.currentRoom))
        {
            return s;
        }
        if (s.roomDirtyness[s.currentRoom] + madeDirt <= 0)
        {
            return new State(newMotivation, newFun, newOpinion, s.roomDirtyness, s.totalDirtyness, s.aiBehaviour, a.room);
        }
        else
        {
            float newDirtyness = madeDirt + s.totalDirtyness;
            s.roomDirtyness[s.currentRoom] += madeDirt;
            return new State(newMotivation, newFun, newOpinion, s.roomDirtyness, newDirtyness, s.aiBehaviour, a.room);
        }

    }
}
