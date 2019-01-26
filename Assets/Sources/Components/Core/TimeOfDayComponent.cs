using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
[Unique]
public sealed class TimeOfDayComponent : IComponent
{
    public float value;
}
