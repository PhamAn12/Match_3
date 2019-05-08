using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Entitas;
using UnityEngine;

public class FallSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    public FallSystem(GameContext context) : base(context)
    {
        _context = context;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BoadGameElement.Removed());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            Debug.Log("removed : " + e);
        }
        
        
//        var gameBoard = _context.CreateGameBoard().boadGame;
//        Debug.Log(gameBoard.columns + "va" + gameBoard.row);
//        for (int c = 0; c < gameBoard.columns; c++) {
//            for (int r = 1; r < gameBoard.row; r++) {
//                var position = new Vector2(c, r);
//                var movables = _context.GetEntitiesWithPosition(position)
//                    .Where(e => e.isMovable)
//                    .ToArray();
//                Debug.Log("all movables" + movables);
//                Debug.Log("Count" + movables.Count());
//                foreach (var e in movables) {
//                    Debug.Log("new Pos" + e);
//
//                    MoveDown(e, position);
//                }
//            }
//        }
    }

    void MoveDown(GameEntity entity, Vector2 position)
    {
        var nextRowPos = CheckEmptyPosition.GetEmptyRow(_context, position);
        //Debug.Log("new Pos" + nextRowPos);
        if (nextRowPos != position.y)
        {
            entity.ReplacePosition(new Vector2(position.x, nextRowPos));
        }
    }
}