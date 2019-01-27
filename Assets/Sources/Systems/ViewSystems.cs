public sealed class ViewSystems : Feature
{
    public ViewSystems(Contexts contexts)
    {
        Add(new FlatViewCreatorSystem(contexts));

        Add(new CreateViewSystem(contexts));
        Add(new LinkViewSystem(contexts));

        Add(new LinkRoomsSystem(contexts));

        Add(new CoreEventSystems(contexts));
        Add(new ViewEventSystems(contexts));
    }
}
