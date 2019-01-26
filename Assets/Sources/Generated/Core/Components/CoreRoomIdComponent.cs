//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CoreEntity {

    public RoomIdComponent roomId { get { return (RoomIdComponent)GetComponent(CoreComponentsLookup.RoomId); } }
    public bool hasRoomId { get { return HasComponent(CoreComponentsLookup.RoomId); } }

    public void AddRoomId(int newValue) {
        var index = CoreComponentsLookup.RoomId;
        var component = (RoomIdComponent)CreateComponent(index, typeof(RoomIdComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceRoomId(int newValue) {
        var index = CoreComponentsLookup.RoomId;
        var component = (RoomIdComponent)CreateComponent(index, typeof(RoomIdComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveRoomId() {
        RemoveComponent(CoreComponentsLookup.RoomId);
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

    static Entitas.IMatcher<CoreEntity> _matcherRoomId;

    public static Entitas.IMatcher<CoreEntity> RoomId {
        get {
            if (_matcherRoomId == null) {
                var matcher = (Entitas.Matcher<CoreEntity>)Entitas.Matcher<CoreEntity>.AllOf(CoreComponentsLookup.RoomId);
                matcher.componentNames = CoreComponentsLookup.componentNames;
                _matcherRoomId = matcher;
            }

            return _matcherRoomId;
        }
    }
}