//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class ActiveActionEventSystem : Entitas.ReactiveSystem<CoreEntity> {

    readonly System.Collections.Generic.List<IActiveActionListener> _listenerBuffer;

    public ActiveActionEventSystem(Contexts contexts) : base(contexts.core) {
        _listenerBuffer = new System.Collections.Generic.List<IActiveActionListener>();
    }

    protected override Entitas.ICollector<CoreEntity> GetTrigger(Entitas.IContext<CoreEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(CoreMatcher.ActiveAction)
        );
    }

    protected override bool Filter(CoreEntity entity) {
        return entity.hasActiveAction && entity.hasActiveActionListener;
    }

    protected override void Execute(System.Collections.Generic.List<CoreEntity> entities) {
        foreach (var e in entities) {
            var component = e.activeAction;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.activeActionListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnActiveAction(e, component.value);
            }
        }
    }
}
