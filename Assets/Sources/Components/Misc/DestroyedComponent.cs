using Entitas;
using Entitas.CodeGeneration.Attributes;

[Command, Core, View]
[Event(EventTarget.Self)]
[Cleanup(CleanupMode.DestroyEntity)]
public sealed class DestroyedComponent : IComponent { }
