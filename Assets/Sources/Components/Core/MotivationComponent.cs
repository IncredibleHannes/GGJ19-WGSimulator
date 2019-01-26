using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
[Event(EventTarget.Self)]
public sealed class MotivationComponent : IComponent
{
    public float value;
}
