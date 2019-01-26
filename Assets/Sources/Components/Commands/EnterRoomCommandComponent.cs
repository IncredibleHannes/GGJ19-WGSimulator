using Entitas;

[Command]
public sealed class EnterRoomCommandComponent : IComponent
{
    public int roomId;
    public int flatmateId;
}
