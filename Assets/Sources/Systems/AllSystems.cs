public sealed class AllSystems : Feature
{
    public AllSystems(Contexts contexts)
    {
        Add(new CoreSystems(contexts));

        Add(new CommandCleanupSystems(contexts));
        Add(new CoreCleanupSystems(contexts));
        Add(new ViewCleanupSystems(contexts));
    }
}
