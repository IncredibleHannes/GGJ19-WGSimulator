using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
public sealed class IdComponent : IComponent
{
    [PrimaryEntityIndex]
    public int value;
}
