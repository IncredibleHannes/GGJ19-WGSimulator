using Entitas;

public sealed class UpdateRoomDirtLevelSystem : IExecuteSystem
{
    readonly Contexts contexts;
    readonly IGroup<CoreEntity> rooms;

    public UpdateRoomDirtLevelSystem(Contexts contexts)
    {
        this.contexts = contexts;

        rooms = contexts.core.GetGroup(CoreMatcher.AllOf(CoreMatcher.Room, CoreMatcher.RoomId, CoreMatcher.DirtLevel));
    }

    public void Execute()
    {
        foreach (var room in rooms)
        {
            var roomActions = contexts.core.GetEntitiesWithCurrentRoom(room.roomId.value);
            foreach (var action in roomActions)
            {
                if (!action.hasActiveAction) continue;

                Action a = action.activeAction.value;
                room.ReplaceDirtLevel(room.dirtLevel.value + a.DirtPerSecond * contexts.core.timeSinceLastTick.value);
            }
        }
    }
}
