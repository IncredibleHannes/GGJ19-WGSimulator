public sealed class InputSystems : Feature
{
    public InputSystems(Contexts contexts)
    {
        Add(new DeltaTSystem(contexts));
    }
}
