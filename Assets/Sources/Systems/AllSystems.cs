public sealed class AllSystems : Feature
{
    public AllSystems(Contexts contexts)
    {
        Add(new InputSystems(contexts));
        Add(new CoreSystems(contexts));
        Add(new AISystems(contexts));

        Add(new ViewSystems(contexts));

        Add(new CommandCleanupSystems(contexts));
        Add(new CoreCleanupSystems(contexts));
        Add(new ViewCleanupSystems(contexts));
    }
}
