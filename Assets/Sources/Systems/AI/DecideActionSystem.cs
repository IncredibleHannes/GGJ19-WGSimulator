using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class DecideActionSystem : IExecuteSystem
{
    readonly CoreContext context;
    readonly CommandContext command;
    readonly IGroup<CoreEntity> flatmates;
    readonly IGroup<CoreEntity> rooms;

    private int SEARCH_DEPTH = 5;
    private int DEFAULT_ACTION_LENGTH = 5;

    public DecideActionSystem(Contexts contexts)
    {
        context = contexts.core;
        command = contexts.command;
        rooms = context.GetGroup(CoreMatcher.RoomId);
        flatmates = context.GetGroup(CoreMatcher.AllOf(CoreMatcher.Flatmate, CoreMatcher.Motivation, CoreMatcher.Fun, CoreMatcher.CurrentRoom, CoreMatcher.Opinion).NoneOf(CoreMatcher.Player, CoreMatcher.ActiveAction));
    }

    public void Execute()
    {
        foreach (var flatmate in flatmates)
        {
            float totalDirtyness = 0;
            foreach (var room in rooms)
            {
                totalDirtyness += room.dirtLevel.value;
            }
            State s = new State(flatmate.motivation.value, flatmate.fun.value, flatmate.opinion.value, totalDirtyness, 0, 0, 0, 1);
            AIAction nextAction = decideNextAction(s);
            if (nextAction.room != flatmate.currentRoom.roomId)
            {
                command.CreateEntity().AddEnterRoomCommand(nextAction.room, flatmate.flatmateId.value);
            }
            command.CreateEntity().AddStartActionCommand(nextAction.action, flatmate.flatmateId.value);

        }
    }

    private AIAction decideNextAction(State s)
    {
        var maxScore = float.MinValue;
        AIAction bestAction = null;
        var possibleAcions = getPossibleActions(s);
        foreach (var action in possibleAcions)
        {
            float score = findBestAction(applyAction(action, s), SEARCH_DEPTH);
            Debug.Log(action.action.Title + score);
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
        return s.motivation * s.motivationMultiplyer + s.fun * s.funMultiplyer + s.opinionMultiplyer * opinion - s.totalDirtyness * s.dirtynessMultiplayer;
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
        float newDirtyness = a.action.DirtPerSecond * DEFAULT_ACTION_LENGTH + s.totalDirtyness;
        Dictionary<int, float> newOpinion = s.opinion;
        return new State(newMotivation, newFun, newOpinion, newDirtyness, s.motivationMultiplyer, s.funMultiplyer, s.opinionMultiplyer, s.dirtynessMultiplayer);
    }
}
