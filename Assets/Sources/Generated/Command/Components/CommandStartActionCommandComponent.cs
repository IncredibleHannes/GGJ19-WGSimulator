//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CommandEntity {

    public StartActionCommandComponent startActionCommand { get { return (StartActionCommandComponent)GetComponent(CommandComponentsLookup.StartActionCommand); } }
    public bool hasStartActionCommand { get { return HasComponent(CommandComponentsLookup.StartActionCommand); } }

    public void AddStartActionCommand(Action newAction, int newFlatmateId) {
        var index = CommandComponentsLookup.StartActionCommand;
        var component = (StartActionCommandComponent)CreateComponent(index, typeof(StartActionCommandComponent));
        component.action = newAction;
        component.flatmateId = newFlatmateId;
        AddComponent(index, component);
    }

    public void ReplaceStartActionCommand(Action newAction, int newFlatmateId) {
        var index = CommandComponentsLookup.StartActionCommand;
        var component = (StartActionCommandComponent)CreateComponent(index, typeof(StartActionCommandComponent));
        component.action = newAction;
        component.flatmateId = newFlatmateId;
        ReplaceComponent(index, component);
    }

    public void RemoveStartActionCommand() {
        RemoveComponent(CommandComponentsLookup.StartActionCommand);
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
public sealed partial class CommandMatcher {

    static Entitas.IMatcher<CommandEntity> _matcherStartActionCommand;

    public static Entitas.IMatcher<CommandEntity> StartActionCommand {
        get {
            if (_matcherStartActionCommand == null) {
                var matcher = (Entitas.Matcher<CommandEntity>)Entitas.Matcher<CommandEntity>.AllOf(CommandComponentsLookup.StartActionCommand);
                matcher.componentNames = CommandComponentsLookup.componentNames;
                _matcherStartActionCommand = matcher;
            }

            return _matcherStartActionCommand;
        }
    }
}
