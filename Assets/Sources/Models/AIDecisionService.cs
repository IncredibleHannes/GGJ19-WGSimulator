using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
public class AIDecisionService
{
    private static Dictionary<int, AIAction> results = new Dictionary<int, AIAction>();
    public static bool hasResult(int key)
    {
        lock (results)
        {
            return results.ContainsKey(key);
        }
    }

    public static AIAction popResult(int key)
    {
        lock (results)
        {
            try
            {
                var res = results[key];
                results.Remove(key);
                return new AIAction(res);
            }
            catch
            {
                return null;
            }
        }
    }

    public static AIAction getResult(int key)
    {
        lock (results)
        {
            try
            {
                return new AIAction(results[key]);
            }
            catch
            {
                return null;
            }
        }
    }

    public static void decideNextAction(State s, int flatmateId)
    {
        Thread decideThread = new Thread(() => runThread(s, flatmateId));
        decideThread.Start();
    }

    private static void runThread(State s, int flatmateId)
    {
        var decitionLogic = new AIDecisionLogic();
        AIAction decition = decitionLogic.decideNextAction(s);
        lock (results)
        {
            results.Add(flatmateId, decition);
        }
    }
}