using System;
using System.Collections.Generic;

using DefaultNamespace;
using Entitas;
using UnityEngine;

public sealed class FillSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;

    public FillSystem(GameContext Game) : base(Game) {
        _context = Game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.BoadGameElement.Removed());
    }

    protected override bool Filter(GameEntity entity) {
        return true;
    }

    protected override void Execute(List<GameEntity> entities) {
        var gameBoard = _context.CreateGameBoard().boadGame;
        Debug.Log("gameboard columns:" + gameBoard.columns );
        for (var c = 0*1.5f; c < gameBoard.columns *1.5f; c = c + 1.5f) {
            var position = new Vector2(c, gameBoard.row*1.5f);
            var nextRowPos = CheckEmptyPosition.GetNextEmptyRow(_context, position);
            Debug.Log("position : " + position + " nextRowpos : " + nextRowPos + " row : " + gameBoard.row*1.5f);
            //if(nextRowPos != 12)
            //{
            //    Debug.Log("C : " + c/1.5f + "next pos : " + nextRowPos/1.5f);
            //    _context.CreateRandomPiece(c/1.5f, nextRowPos/1.5f);
            //}
            while(Math.Abs(nextRowPos - gameBoard.row*1.5f) > 0) {
                Debug.Log("c : " + c  + " nextpost" + nextRowPos);
                _context.CreateRandomPiece(c/1.5f, nextRowPos/1.5f);
                nextRowPos = CheckEmptyPosition.GetNextEmptyRow(_context, position);
            }
        }
    }
}