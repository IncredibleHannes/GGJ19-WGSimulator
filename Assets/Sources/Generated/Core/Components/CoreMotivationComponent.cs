//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CoreEntity {

    public MotivationComponent motivation { get { return (MotivationComponent)GetComponent(CoreComponentsLookup.Motivation); } }
    public bool hasMotivation { get { return HasComponent(CoreComponentsLookup.Motivation); } }

    public void AddMotivation(float newValue) {
        var index = CoreComponentsLookup.Motivation;
        var component = (MotivationComponent)CreateComponent(index, typeof(MotivationComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMotivation(float newValue) {
        var index = CoreComponentsLookup.Motivation;
        var component = (MotivationComponent)CreateComponent(index, typeof(MotivationComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMotivation() {
        RemoveComponent(CoreComponentsLookup.Motivation);
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

    static Entitas.IMatcher<CoreEntity> _matcherMotivation;

    public static Entitas.IMatcher<CoreEntity> Motivation {
        get {
            if (_matcherMotivation == null) {
                var matcher = (Entitas.Matcher<CoreEntity>)Entitas.Matcher<CoreEntity>.AllOf(CoreComponentsLookup.Motivation);
                matcher.componentNames = CoreComponentsLookup.componentNames;
                _matcherMotivation = matcher;
            }

            return _matcherMotivation;
        }
    }
}
