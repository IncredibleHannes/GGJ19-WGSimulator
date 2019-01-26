using Entitas;

[Command]
public sealed class CreateFlatmateCommandComponent : IComponent
{
    public string name;
    public int startingRoomId;
}
