//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ViewEntity {

    public ViewComponent view { get { return (ViewComponent)GetComponent(ViewComponentsLookup.View); } }
    public bool hasView { get { return HasComponent(ViewComponentsLookup.View); } }

    public void AddView(IView newValue) {
        var index = ViewComponentsLookup.View;
        var component = (ViewComponent)CreateComponent(index, typeof(ViewComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceView(IView newValue) {
        var index = ViewComponentsLookup.View;
        var component = (ViewComponent)CreateComponent(index, typeof(ViewComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveView() {
        RemoveComponent(ViewComponentsLookup.View);
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
public sealed partial class ViewMatcher {

    static Entitas.IMatcher<ViewEntity> _matcherView;

    public static Entitas.IMatcher<ViewEntity> View {
        get {
            if (_matcherView == null) {
                var matcher = (Entitas.Matcher<ViewEntity>)Entitas.Matcher<ViewEntity>.AllOf(ViewComponentsLookup.View);
                matcher.componentNames = ViewComponentsLookup.componentNames;
                _matcherView = matcher;
            }

            return _matcherView;
        }
    }
}