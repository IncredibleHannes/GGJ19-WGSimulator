public sealed class CoreSystems : Feature
{
    public CoreSystems(Contexts contexts)
    {
        Add(new CreateRoomSystem(contexts));
        Add(new CreateFlatmateSystem(contexts));

        Add(new EnterRoomSystem(contexts));
        Add(new StartActionSystem(contexts));

        Add(new UpdateEnterRoomDirtynessOpinionSystem(contexts));

        Add(new UpdateMotivationSystem(contexts));
        Add(new UpdateFunSystem(contexts));
        Add(new UpdateRoomDirtLevelSystem(contexts));
        Add(new UpdateSameRoomOptionionSystem(contexts));
        Add(new UpdateOtherRoomOptionionSystem(contexts));
    }
}
