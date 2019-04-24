using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
        
        var gameBoard = _context.CreateGameBoard().boadGame;
        UnityEngine.Debug.Log(gameBoard.row);
        UnityEngine.Debug.Log(gameBoard.columns);
        for (var r = 0; r < gameBoard.row; r = r + 2)
        {
            for (var c = 0; c < gameBoard.columns; c = c + 2)
            {              
                _context.CreateRandomPiece(r, c);
                
//                GameObject GO = Resources.Load(_items[Random.Range(0, _items.Length)]) as GameObject;
//                GO.transform.position = new Vector3(r - 4,c - 3, 0);
//                try
//                {
//                    UnityEngine.Object.Instantiate(GO);
//                    
//                    
//                }
//                catch (Exception e)
//                {
//                    Debug.Log("can't not initialize");
//                }
                
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