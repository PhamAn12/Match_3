using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Entitas;
using UnityEngine;

public class CountRemovedBlock : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    public CountRemovedBlock(GameContext context) : base(context)
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
        


        var gameBoard = _context.CreateGameBoard().boadGame;

        Debug.Log(gameBoard.columns + "va" + gameBoard.row);
        for (var c = 0 * 1.5f; c < gameBoard.columns * 1.5f; c += 1.5f)
        {
            for (var r = 0 * 1.5f; r < gameBoard.row * 1.5f; r += 1.5f)
            {
                var position = new Vector2(c, r);

                //Debug.Log(position.x + " and " + position.y);
                var movables = _context.GetEntitiesWithPosition(position)
                    .ToArray();

                foreach (var e in movables)
                {
                    
                }
            }
        }
    }

    
}