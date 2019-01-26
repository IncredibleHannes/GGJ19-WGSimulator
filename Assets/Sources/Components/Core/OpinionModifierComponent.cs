using Entitas;

[Core]
public sealed class OpinionModifierComponent : IComponent
{
    public float baseOpinionMultiplier;
    public float sameRoomOpinionMultiplier;
    public float otherRoomOpinionMultiplier;

    public float dirtToleranceLevel;
    public float dirtToleranceMultiplier;
    public float cleanlinessToleranceLevel;
    public float cleanlinessToleranceMultiplier;
}
