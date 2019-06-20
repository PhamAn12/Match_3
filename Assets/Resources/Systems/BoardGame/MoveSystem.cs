using System.Collections.Generic;
using System.Threading;
using Entitas;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MoveSystem : ReactiveSystem<GameEntity>,IInitializeSystem,ICleanupSystem
{
    private Text _labelMove;
    private GameContext _context;
    private int move = 10;
    IGroup<GameEntity> _moveGroup;
    public MoveSystem(GameContext Game) : base(Game)
    {
        _context = Game;
        _moveGroup = _context.GetGroup(GameMatcher.MoveNum);
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

    }

    public void Cleanup()
    {
        foreach(var e in _moveGroup.GetEntities())
        {
            e.Destroy();
        }
    }
}