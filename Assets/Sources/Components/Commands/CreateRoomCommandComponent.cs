using Entitas;

[Command]
public sealed class CreateRoomCommandComponent : IComponent
{
    public int roomId;
    public Room roomType;
}
