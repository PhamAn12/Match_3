//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly TabbedComponent tabbedComponent = new TabbedComponent();

    public bool isTabbed {
        get { return HasComponent(GameComponentsLookup.Tabbed); }
        set {
            if (value != isTabbed) {
                var index = GameComponentsLookup.Tabbed;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : tabbedComponent;

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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTabbed;

    public static Entitas.IMatcher<GameEntity> Tabbed {
        get {
            if (_matcherTabbed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Tabbed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTabbed = matcher;
            }

            return _matcherTabbed;
        }
    }
}