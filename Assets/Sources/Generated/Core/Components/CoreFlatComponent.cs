//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CoreEntity {

    static readonly FlatComponent flatComponent = new FlatComponent();

    public bool isFlat {
        get { return HasComponent(CoreComponentsLookup.Flat); }
        set {
            if (value != isFlat) {
                var index = CoreComponentsLookup.Flat;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : flatComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<CoreEntity> _matcherFlat;

    public static Entitas.IMatcher<CoreEntity> Flat {
        get {
            if (_matcherFlat == null) {
                var matcher = (Entitas.Matcher<CoreEntity>)Entitas.Matcher<CoreEntity>.AllOf(CoreComponentsLookup.Flat);
                matcher.componentNames = CoreComponentsLookup.componentNames;
                _matcherFlat = matcher;
            }

            return _matcherFlat;
        }
    }
}
