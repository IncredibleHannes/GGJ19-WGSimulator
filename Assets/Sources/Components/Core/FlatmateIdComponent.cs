using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
public sealed class FlatmateIdComponent : IComponent
{
    [PrimaryEntityIndex]
    public int flatmateId;
}
