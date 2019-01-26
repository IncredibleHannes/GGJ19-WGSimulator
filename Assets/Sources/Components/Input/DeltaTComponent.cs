using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
[Unique]
public sealed class DeltaTComponent : IComponent
{
    public float value;
}
