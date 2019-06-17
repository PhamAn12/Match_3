using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


// Create board game by using RandomBoardElement
public class CreateBoardSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    readonly GameContext _context;
    readonly IGroup<GameEntity> _gameBoardElements;
    static readonly string[] _items = {
        "Prefabs/GenerateBrick",
        "Prefabs/Piece0",
        "Prefabs/Block_2"
    };
    public CreateBoardSystem(GameContext Game) : base(Game)
    {
        _context = Game;
        _gameBoardElements = _context.GetGroup(GameMatcher.AllOf(GameMatcher.BoadGameElement, GameMatcher.Position));
    }

    public void Initialize()
    {
        //GameObject.Find("Main Camera").transform.localPosition = new Vector3(0.65f,1.55f,0);
        _context.CreateHeart(15, 12);
        _context.CreateHeart(12, 12);
        _context.CreateHeart(13.5f, 12);
        var gameBoard = _context.CreateGameBoard().boadGame;
        
        for (var r = 0; r < gameBoard.row; r++)
        {
            for (var c = 0; c < gameBoard.columns; c++)
            {
                if (Random.value > 0.81f)
                    _context.CreateRandomBlock(c, r);
                else
                    _context.CreateRandomPiece(c, r);
            }

            
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