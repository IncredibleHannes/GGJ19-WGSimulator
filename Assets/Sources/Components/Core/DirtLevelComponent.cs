using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
[Event(EventTarget.Self)]
public sealed class DirtLevelComponent : IComponent
{
    public float value;
}
