using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
public sealed class RoomIdComponent : IComponent
{
    [PrimaryEntityIndex]
    public int value;
}
