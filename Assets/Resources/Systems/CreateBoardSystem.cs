using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class CreateBoardSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    readonly GameContext _context;
    readonly IGroup<GameEntity> _gameBoardElements;
    public CreateBoardSystem(GameContext Game) : base(Game)
    {
        _context = Game;
        _gameBoardElements = _context.GetGroup(GameMatcher.AllOf(GameMatcher.BoadGameElement, GameMatcher.Position));
    }

    public void Initialize()
    {
        var gameBoard = _context.CreateGameBoard().boadGame;
        UnityEngine.Debug.Log(gameBoard.row);
        UnityEngine.Debug.Log(gameBoard.columns);
        for (int r = 0; r < gameBoard.row; r++)
        {
            for (int column = 0; column < gameBoard.columns; column++)
            {
                UnityEngine.Debug.Log("A");
                
            }

            UnityEngine.Debug.Log("\n");
        }
    }

    protected override void Execute(List<GameEntity> entities)
    {
        UnityEngine.Debug.Log("abc");
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasBoadGame;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BoadGame);
    }

}