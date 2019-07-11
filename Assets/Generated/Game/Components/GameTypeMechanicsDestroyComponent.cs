//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TypeMechanicsDestroyComponent typeMechanicsDestroy { get { return (TypeMechanicsDestroyComponent)GetComponent(GameComponentsLookup.TypeMechanicsDestroy); } }
    public bool hasTypeMechanicsDestroy { get { return HasComponent(GameComponentsLookup.TypeMechanicsDestroy); } }

    public void AddTypeMechanicsDestroy(string newType) {
        var index = GameComponentsLookup.TypeMechanicsDestroy;
        var component = (TypeMechanicsDestroyComponent)CreateComponent(index, typeof(TypeMechanicsDestroyComponent));
        component.type = newType;
        AddComponent(index, component);
    }

    public void ReplaceTypeMechanicsDestroy(string newType) {
        var index = GameComponentsLookup.TypeMechanicsDestroy;
        var component = (TypeMechanicsDestroyComponent)CreateComponent(index, typeof(TypeMechanicsDestroyComponent));
        component.type = newType;
        ReplaceComponent(index, component);
    }

    public void RemoveTypeMechanicsDestroy() {
        RemoveComponent(GameComponentsLookup.TypeMechanicsDestroy);
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

    static Entitas.IMatcher<GameEntity> _matcherTypeMechanicsDestroy;

    public static Entitas.IMatcher<GameEntity> TypeMechanicsDestroy {
        get {
            if (_matcherTypeMechanicsDestroy == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TypeMechanicsDestroy);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTypeMechanicsDestroy = matcher;
            }

            return _matcherTypeMechanicsDestroy;
        }
    }
}