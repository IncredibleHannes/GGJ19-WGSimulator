using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
[Event(EventTarget.Self)]
public sealed class OpinionComponent : IComponent
{
    public Dictionary<int, float> value;
}
