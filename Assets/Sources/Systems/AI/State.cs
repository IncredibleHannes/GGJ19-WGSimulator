using System.Collections.Generic;

public struct State
{
    public float motivation;
    public float fun;
    public Dictionary<int, float> opinion;

    public float totalDirtyness;

    public float motivationMultiplyer;
    public float funMultiplyer;
    public float opinionMultiplyer;

    public float dirtynessMultiplayer;

    public State(float v1, float v2, Dictionary<int, float> dictionary, float totalDirtyness, float v3, float v4, float v5, float dirtynessMultiplayer)
    {
        this.motivation = v1;
        this.fun = v2;
        this.opinion = dictionary;
        this.totalDirtyness = totalDirtyness;
        this.motivationMultiplyer = v3;
        this.funMultiplyer = v4;
        this.opinionMultiplyer = v5;
        this.dirtynessMultiplayer = dirtynessMultiplayer;
    }
}