using System.Collections.Generic;
using Entitas;

public sealed class ScoreSystem : ReactiveSystem<GameEntity>, IInitializeSystem {

    readonly GameStateContext _GameState;

    public ScoreSystem(GameContext Game, GameStateContext GameState) : base(Game) {
        _GameState = GameState;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.BoadGameElement.Removed());
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    public void Initialize()
    {
        //_GameState.AddScore(0);
        ;
    }

    protected override void Execute(List<GameEntity> entities) {
        //_GameState.ReplaceScore(_GameState.score.value + entities.Count);
    }
}
