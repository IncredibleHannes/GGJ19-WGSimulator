//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CoreEntity {

    public AIBehaviourComponent aIBehaviour { get { return (AIBehaviourComponent)GetComponent(CoreComponentsLookup.AIBehaviour); } }
    public bool hasAIBehaviour { get { return HasComponent(CoreComponentsLookup.AIBehaviour); } }

    public void AddAIBehaviour(AIBehaviour newValue) {
        var index = CoreComponentsLookup.AIBehaviour;
        var component = (AIBehaviourComponent)CreateComponent(index, typeof(AIBehaviourComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAIBehaviour(AIBehaviour newValue) {
        var index = CoreComponentsLookup.AIBehaviour;
        var component = (AIBehaviourComponent)CreateComponent(index, typeof(AIBehaviourComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAIBehaviour() {
        RemoveComponent(CoreComponentsLookup.AIBehaviour);
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

    static Entitas.IMatcher<CoreEntity> _matcherAIBehaviour;

    public static Entitas.IMatcher<CoreEntity> AIBehaviour {
        get {
            if (_matcherAIBehaviour == null) {
                var matcher = (Entitas.Matcher<CoreEntity>)Entitas.Matcher<CoreEntity>.AllOf(CoreComponentsLookup.AIBehaviour);
                matcher.componentNames = CoreComponentsLookup.componentNames;
                _matcherAIBehaviour = matcher;
            }

            return _matcherAIBehaviour;
        }
    }
}
