using System.Collections.Generic;
using Entitas;

public sealed class FlatmateViewCreatorSystem : ReactiveSystem<CoreEntity>
{

    ViewContext viewContext;
    public FlatmateViewCreatorSystem(Contexts contexts) : base(contexts.core)
    {
        viewContext = contexts.view;
    }

    protected override ICollector<CoreEntity> GetTrigger(IContext<CoreEntity> context)
    {
        return context.CreateCollector(CoreMatcher.AllOf(CoreMatcher.Flatmate, CoreMatcher.Id));
    }

    protected override bool Filter(CoreEntity entity)
    {
        return entity.hasId && entity.isFlatmate;
    }

    protected override void Execute(List<CoreEntity> entities)
    {
        foreach (var e in entities)
        {
            var view = viewContext.CreateEntity();
            view.AddCoreEntityReference(e.id.value);
            view.AddAsset("Flatmate");
        }
    }
}
