using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
[Event(EventTarget.Self)]
public sealed class FunComponent : IComponent
{
    public float value;
}
