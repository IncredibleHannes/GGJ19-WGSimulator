public sealed class CoreSystems : Feature
{
    public CoreSystems(Contexts contexts)
    {
        Add(new CreateRoomSystem(contexts));
        Add(new CreateFlatmateSystem(contexts));

        Add(new EnterRoomSystem(contexts));

        Add(new UpdateMotivationSystem(contexts));
        Add(new UpdateFunSystem(contexts));
        Add(new UpdateRoomDirtLevelSystem(contexts));
    }
}
