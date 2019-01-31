using System.Collections.Generic;

public struct State
{
    public float motivation;
    public float fun;
    public Dictionary<int, float> opinion;

    public float totalDirtyness;

    public AIBehaviour aiBehaviour;

    public int currentRoom;

    public Dictionary<int, AIRoom> rooms;
    public List<AIFlatmate> flatmates;

    public State(float motivation, float fun, Dictionary<int, float> opinion, float totalDirtyness, AIBehaviour aiBehaviour, int currentRoom, Dictionary<int, AIRoom> allRooms, List<AIFlatmate> flatmates)
    {
        this.motivation = motivation;
        this.fun = fun;
        this.opinion = new Dictionary<int, float>(opinion);
        this.totalDirtyness = totalDirtyness;
        this.aiBehaviour = aiBehaviour;
        this.currentRoom = currentRoom;
        this.rooms = allRooms;
        this.flatmates = flatmates;
    }
}