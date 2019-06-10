using System.Collections.Generic;
using Entitas;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MoveSystem : ReactiveSystem<GameEntity>,IInitializeSystem
{
    private Text _labelMove;
    private GameContext _context;
    private int move = 10;
    public MoveSystem(GameContext Game) : base(Game)
    {
        _context = Game;
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
        move --;
        UpdateMove(move);
        
    }

    public void Initialize()
    {
        
        UpdateMove(10);
    }

    void UpdateMove(int move)
    {
        var moveEntiy = _context.CreateEntity();
        moveEntiy.ReplaceMoveNum(move);
        Debug.Log(moveEntiy.moveNum.value);
        _labelMove = GameObject.Find("Canvas/Panel/NumOfMove").GetComponent<Text>();
        _labelMove.text = "Move : " + move;

//        if (move == 8)
//        {
//            var gameBoard = _context.CreateGameBoard().boadGame;
//      
//            for (var r = 0; r < gameBoard.row; r++)
//            {
//                for (var c = 0; c < gameBoard.columns; c++)
//                {
//                    if (Random.value > 0.8f)
//                        _context.CreateRandomBlock(c, r);
//                    else
//                        _context.CreateRandomPiece(c, r);
//                }
//
//            
//            }
//        }
    }
}