public sealed class GameStateSystems : Feature {

    public GameStateSystems(GameContext Game, GameStateContext GameState) {
        Add(new ScoreSystem(Game, GameState));
    }
}