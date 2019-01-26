public sealed class CoreSystems : Feature
{
    public CoreSystems(Contexts contexts)
    {
        Add(new UpdateTimeSinceLastTickSystem(contexts));
        Add(new UpdateTimeOfDaySystem(contexts));

        Add(new CreateRoomSystem(contexts));
        Add(new CreateFlatmateSystem(contexts));

        Add(new EnterRoomSystem(contexts));
        Add(new StartActionSystem(contexts));
        Add(new StopActionSystem(contexts));

        Add(new UpdateEnterRoomDirtynessOpinionSystem(contexts));
        Add(new UpdateEnterRoomCleanlinessOpinionSystem(contexts));

        Add(new UpdateMotivationSystem(contexts));
        Add(new UpdateFunSystem(contexts));
        Add(new UpdateRoomDirtLevelSystem(contexts));
        Add(new UpdateSameRoomOpinionSystem(contexts));
        Add(new UpdateOtherRoomOpinionSystem(contexts));
        Add(new UpdateDurationTimeSystem(contexts));

        Add(new DurationTimeoutSystem(contexts));
    }
}
