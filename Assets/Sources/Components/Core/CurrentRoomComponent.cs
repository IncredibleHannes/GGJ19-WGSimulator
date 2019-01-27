using Entitas;
using Entitas.CodeGeneration.Attributes;

[Core]
[Event(EventTarget.Self)]
public sealed class CurrentRoomComponent : IComponent
{
    [EntityIndex]
    public int roomId;
}
