public class AIBehaviour
{
    public float motivationMultiplier { get; private set; }
    public float funMultiplier { get; private set; }
    public float opinionMultiplier { get; private set; }
    public float dirtynessMultiplier { get; private set; }

    public AIBehaviour(float motivationMultiplier, float funMultiplier, float opinionMultiplier, float dirtynessMultiplier)
    {
        this.motivationMultiplier = motivationMultiplier;
        this.funMultiplier = funMultiplier;
        this.opinionMultiplier = opinionMultiplier;
        this.dirtynessMultiplier = dirtynessMultiplier;
    }
}