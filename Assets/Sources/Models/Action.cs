public class Action
{
    public float MotivationPerTick { get; private set; }
    public float FunPerTick { get; private set; }
    public float DirtPerTick { get; private set; }

    public Action(float motivationPerTick, float funPerTick, float dirtPerTick)
    {
        MotivationPerTick = motivationPerTick;
        FunPerTick = funPerTick;
        DirtPerTick = dirtPerTick;
    }

    public Action() : this(1, 1, 1) { }
}