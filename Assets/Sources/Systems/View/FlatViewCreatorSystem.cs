using System.Collections.Generic;
using Entitas;

public sealed class FlatViewCreatorSystem : ReactiveSystem<CoreEntity>
{
    private readonly ViewContext viewContext;

    public FlatViewCreatorSystem(Contexts contexts) : base(contexts.core)
    {
        viewContext = contexts.view;
    }

    protected override ICollector<CoreEntity> GetTrigger(IContext<CoreEntity> context)
    {
        return context.CreateCollector(CoreMatcher.AllOf(CoreMatcher.Flat, CoreMatcher.Id));
    }

    protected override bool Filter(CoreEntity entity)
    {
        return entity.isFlat && entity.hasId;
    }

    protected override void Execute(List<CoreEntity> entities)
    {
        foreach (var e in entities)
        {
            var view = viewContext.CreateEntity();
            view.AddCoreEntityReference(e.id.value);
            view.AddAsset("Flat");
        }
    }
}
