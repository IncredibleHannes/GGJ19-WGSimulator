public sealed class AISystems : Feature
{
    public AISystems(Contexts contexts)
    {
        Add(new DecideActionSystem(contexts));
        Add(new ApplyDecitionSystem(contexts));
    }
}
