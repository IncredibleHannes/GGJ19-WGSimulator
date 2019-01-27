using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class CreateViewSystem : ReactiveSystem<ViewEntity>
{
    readonly Transform parent;

    public CreateViewSystem(Contexts contexts) : base(contexts.view)
    {
        parent = new GameObject("Views").transform;
    }

    protected override ICollector<ViewEntity> GetTrigger(IContext<ViewEntity> context)
    {
        return context.CreateCollector(ViewMatcher.AllOf(ViewMatcher.Asset).NoneOf(ViewMatcher.View));
    }

    protected override bool Filter(ViewEntity entity)
    {
        return entity.hasAsset && !entity.hasView;
    }

    protected override void Execute(List<ViewEntity> entities)
    {
        foreach (var e in entities)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + e.asset.value);
            IView view = Object.Instantiate(prefab, parent).GetComponent<IView>();
            e.AddView(view);
        }
    }
}