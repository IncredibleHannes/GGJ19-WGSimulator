using Entitas;

[Command]
public sealed class StartActionCommandComponent : IComponent
{
    public Action action;
    public int flatmateId;
}
