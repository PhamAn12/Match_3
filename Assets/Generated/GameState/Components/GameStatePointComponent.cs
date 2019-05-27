//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    public PointComponent point { get { return (PointComponent)GetComponent(GameStateComponentsLookup.Point); } }
    public bool hasPoint { get { return HasComponent(GameStateComponentsLookup.Point); } }

    public void AddPoint(int newValue) {
        var index = GameStateComponentsLookup.Point;
        var component = (PointComponent)CreateComponent(index, typeof(PointComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePoint(int newValue) {
        var index = GameStateComponentsLookup.Point;
        var component = (PointComponent)CreateComponent(index, typeof(PointComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePoint() {
        RemoveComponent(GameStateComponentsLookup.Point);
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
public sealed partial class GameStateMatcher {

    static Entitas.IMatcher<GameStateEntity> _matcherPoint;

    public static Entitas.IMatcher<GameStateEntity> Point {
        get {
            if (_matcherPoint == null) {
                var matcher = (Entitas.Matcher<GameStateEntity>)Entitas.Matcher<GameStateEntity>.AllOf(GameStateComponentsLookup.Point);
                matcher.componentNames = GameStateComponentsLookup.componentNames;
                _matcherPoint = matcher;
            }

            return _matcherPoint;
        }
    }
}
