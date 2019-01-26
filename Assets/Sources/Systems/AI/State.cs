using System.Collections.Generic;

public struct State
{
    public float motivation;
    public float fun;
    public Dictionary<int, float> opinion;

    public float totalDirtyness;

    public Dictionary<int, float> roomDirtyness;

    public AIBehaviour aiBehaviour;

    public int currentRoom;

    public State(float motivation, float fun, Dictionary<int, float> opinion, Dictionary<int, float> roomDirtyness, float totalDirtyness, AIBehaviour aiBehaviour, int currentRoom)
    {
        this.motivation = motivation;
        this.fun = fun;
        this.opinion = opinion;
        this.totalDirtyness = totalDirtyness;
        this.aiBehaviour = aiBehaviour;
        this.currentRoom = currentRoom;
        this.roomDirtyness = roomDirtyness;
    }
}