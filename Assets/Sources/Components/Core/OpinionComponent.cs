using System.Collections.Generic;
using Entitas;

[Core]
public sealed class OpinionComponent : IComponent
{
    public Dictionary<int, float> value;
}
