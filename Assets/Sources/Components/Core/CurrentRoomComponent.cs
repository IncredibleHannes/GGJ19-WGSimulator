using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
public sealed class CurrentRoomComponent : IComponent
{
    [EntityIndex]
    public int roomId;
}
