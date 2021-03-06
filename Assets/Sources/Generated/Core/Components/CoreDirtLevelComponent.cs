//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CoreEntity {

    public DirtLevelComponent dirtLevel { get { return (DirtLevelComponent)GetComponent(CoreComponentsLookup.DirtLevel); } }
    public bool hasDirtLevel { get { return HasComponent(CoreComponentsLookup.DirtLevel); } }

    public void AddDirtLevel(float newValue) {
        var index = CoreComponentsLookup.DirtLevel;
        var component = (DirtLevelComponent)CreateComponent(index, typeof(DirtLevelComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDirtLevel(float newValue) {
        var index = CoreComponentsLookup.DirtLevel;
        var component = (DirtLevelComponent)CreateComponent(index, typeof(DirtLevelComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDirtLevel() {
        RemoveComponent(CoreComponentsLookup.DirtLevel);
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
public sealed partial class CoreMatcher {

    static Entitas.IMatcher<CoreEntity> _matcherDirtLevel;

    public static Entitas.IMatcher<CoreEntity> DirtLevel {
        get {
            if (_matcherDirtLevel == null) {
                var matcher = (Entitas.Matcher<CoreEntity>)Entitas.Matcher<CoreEntity>.AllOf(CoreComponentsLookup.DirtLevel);
                matcher.componentNames = CoreComponentsLookup.componentNames;
                _matcherDirtLevel = matcher;
            }

            return _matcherDirtLevel;
        }
    }
}
