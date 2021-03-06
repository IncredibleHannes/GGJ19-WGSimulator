//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity deltaTEntity { get { return GetGroup(InputMatcher.DeltaT).GetSingleEntity(); } }
    public DeltaTComponent deltaT { get { return deltaTEntity.deltaT; } }
    public bool hasDeltaT { get { return deltaTEntity != null; } }

    public InputEntity SetDeltaT(float newValue) {
        if (hasDeltaT) {
            throw new Entitas.EntitasException("Could not set DeltaT!\n" + this + " already has an entity with DeltaTComponent!",
                "You should check if the context already has a deltaTEntity before setting it or use context.ReplaceDeltaT().");
        }
        var entity = CreateEntity();
        entity.AddDeltaT(newValue);
        return entity;
    }

    public void ReplaceDeltaT(float newValue) {
        var entity = deltaTEntity;
        if (entity == null) {
            entity = SetDeltaT(newValue);
        } else {
            entity.ReplaceDeltaT(newValue);
        }
    }

    public void RemoveDeltaT() {
        deltaTEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public DeltaTComponent deltaT { get { return (DeltaTComponent)GetComponent(InputComponentsLookup.DeltaT); } }
    public bool hasDeltaT { get { return HasComponent(InputComponentsLookup.DeltaT); } }

    public void AddDeltaT(float newValue) {
        var index = InputComponentsLookup.DeltaT;
        var component = (DeltaTComponent)CreateComponent(index, typeof(DeltaTComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDeltaT(float newValue) {
        var index = InputComponentsLookup.DeltaT;
        var component = (DeltaTComponent)CreateComponent(index, typeof(DeltaTComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDeltaT() {
        RemoveComponent(InputComponentsLookup.DeltaT);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherDeltaT;

    public static Entitas.IMatcher<InputEntity> DeltaT {
        get {
            if (_matcherDeltaT == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.DeltaT);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherDeltaT = matcher;
            }

            return _matcherDeltaT;
        }
    }
}
