using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
[Unique]
[Event(EventTarget.Self)]
public sealed class TimeOfDayComponent : IComponent
{
    public float value;
}
