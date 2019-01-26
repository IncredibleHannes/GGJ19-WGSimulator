using System.Collections.Generic;

public struct State
{
    public float motivation;
    public float fun;
    public Dictionary<int, float> opinion;

    public float totalDirtyness;

    public Dictionary<int, float> roomDirtyness;

    public float motivationMultiplyer;
    public float funMultiplyer;
    public float opinionMultiplyer;

    public float dirtynessMultiplayer;

    public int currentRoom;

    public State(float motivation, float fun, Dictionary<int, float> opinion, Dictionary<int, float> roomDirtyness, float totalDirtyness, float v3, float v4, float v5, float dirtynessMultiplayer, int currentRoom)
    {
        this.motivation = motivation;
        this.fun = fun;
        this.opinion = opinion;
        this.totalDirtyness = totalDirtyness;
        this.motivationMultiplyer = v3;
        this.funMultiplyer = v4;
        this.opinionMultiplyer = v5;
        this.dirtynessMultiplayer = dirtynessMultiplayer;
        this.currentRoom = currentRoom;
        this.roomDirtyness = roomDirtyness;
    }
}