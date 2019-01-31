using System.Collections.Generic;
using System;

public class AIDecisionLogic
{
    private int SEARCH_DEPTH = 3;
    private int DEFAULT_ACTION_LENGTH = 5;
    public AIDecisionLogic()
    {

    }

    public AIAction decideNextAction(State s)
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
            if (-(action.MotivationPerSecond * action.DefaultLength) <= s.motivation)
            {
                foreach (KeyValuePair<int, AIRoom> room in s.rooms)
                {
                    bool roomIsDirty = !(action.DirtPerSecond < 0) || room.Value.DirtLevel + (action.DirtPerSecond * action.DefaultLength) > 0;
                    bool actionAlreadyDone = false;
                    foreach (var flatmate in s.flatmates)
                    {
                        actionAlreadyDone = actionAlreadyDone || (flatmate.ActiveAction.Title == action.Title && flatmate.CurrentRoomId == room.Value.RoomId);
                    }
                    if (Array.Exists(action.AllowedRoomTypes, roomType => roomType == room.Value.Room.Type) && roomIsDirty && !actionAlreadyDone)
                        result.Add(new AIAction(action, room.Value.RoomId));
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
        float newMotivation = a.action.MotivationPerSecond * a.action.DefaultLength + s.motivation;
        float newFun = a.action.FunPerSecond * a.action.DefaultLength + s.fun;
        float madeDirt = a.action.DirtPerSecond * a.action.DefaultLength;
        Dictionary<int, float> newOpinion = s.opinion;
        if (!s.rooms.ContainsKey(s.currentRoom))
        {
            return s;
        }
        if (s.rooms[s.currentRoom].DirtLevel + madeDirt <= 0)
        {
            return new State(newMotivation, newFun, newOpinion, s.totalDirtyness, s.aiBehaviour, a.room, s.rooms, s.flatmates);
        }
        else
        {
            float newDirtyness = madeDirt + s.totalDirtyness;
            s.rooms[s.currentRoom].DirtLevel += madeDirt;
            return new State(newMotivation, newFun, newOpinion, newDirtyness, s.aiBehaviour, a.room, s.rooms, s.flatmates);
        }

    }
}