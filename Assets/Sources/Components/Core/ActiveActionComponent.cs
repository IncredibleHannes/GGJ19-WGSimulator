using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
[Event(EventTarget.Self)]
public sealed class ActiveActionComponent : IComponent
{
    public Action value;
}
