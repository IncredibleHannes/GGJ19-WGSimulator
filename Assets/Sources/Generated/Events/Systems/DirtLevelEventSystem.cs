//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class DirtLevelEventSystem : Entitas.ReactiveSystem<CoreEntity> {

    readonly System.Collections.Generic.List<IDirtLevelListener> _listenerBuffer;

    public DirtLevelEventSystem(Contexts contexts) : base(contexts.core) {
        _listenerBuffer = new System.Collections.Generic.List<IDirtLevelListener>();
    }

    protected override Entitas.ICollector<CoreEntity> GetTrigger(Entitas.IContext<CoreEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(CoreMatcher.DirtLevel)
        );
    }

    protected override bool Filter(CoreEntity entity) {
        return entity.hasDirtLevel && entity.hasDirtLevelListener;
    }

    protected override void Execute(System.Collections.Generic.List<CoreEntity> entities) {
        foreach (var e in entities) {
            var component = e.dirtLevel;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.dirtLevelListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnDirtLevel(e, component.value);
            }
        }
    }
}
