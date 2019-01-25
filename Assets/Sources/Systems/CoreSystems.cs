public sealed class CoreSystems : Feature
{
    public CoreSystems(Contexts contexts)
    {
        Add(new CreateRoomSystem(contexts));

        Add(new UpdateRoomDirtLevelSystem(contexts));
    }
}
