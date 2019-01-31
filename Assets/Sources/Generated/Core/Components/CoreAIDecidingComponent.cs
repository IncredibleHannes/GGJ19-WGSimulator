//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CoreEntity {

    static readonly AIDecidingComponent aIDecidingComponent = new AIDecidingComponent();

    public bool isAIDeciding {
        get { return HasComponent(CoreComponentsLookup.AIDeciding); }
        set {
            if (value != isAIDeciding) {
                var index = CoreComponentsLookup.AIDeciding;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : aIDecidingComponent;

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

    static Entitas.IMatcher<CoreEntity> _matcherAIDeciding;

    public static Entitas.IMatcher<CoreEntity> AIDeciding {
        get {
            if (_matcherAIDeciding == null) {
                var matcher = (Entitas.Matcher<CoreEntity>)Entitas.Matcher<CoreEntity>.AllOf(CoreComponentsLookup.AIDeciding);
                matcher.componentNames = CoreComponentsLookup.componentNames;
                _matcherAIDeciding = matcher;
            }

            return _matcherAIDeciding;
        }
    }
}
