//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public DirectionComponent direction { get { return (DirectionComponent)GetComponent(GameComponentsLookup.Direction); } }
    public bool hasDirection { get { return HasComponent(GameComponentsLookup.Direction); } }

    public void AddDirection(float newValue) {
        var index = GameComponentsLookup.Direction;
        var component = (DirectionComponent)CreateComponent(index, typeof(DirectionComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDirection(float newValue) {
        var index = GameComponentsLookup.Direction;
        var component = (DirectionComponent)CreateComponent(index, typeof(DirectionComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDirection() {
        RemoveComponent(GameComponentsLookup.Direction);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDirection;

    public static Entitas.IMatcher<GameEntity> Direction {
        get {
            if (_matcherDirection == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Direction);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDirection = matcher;
            }

            return _matcherDirection;
        }
    }
}
