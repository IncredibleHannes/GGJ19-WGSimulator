using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
[Unique]
public sealed class TimeSinceLastTickComponent : IComponent
{
    public float value;
}
