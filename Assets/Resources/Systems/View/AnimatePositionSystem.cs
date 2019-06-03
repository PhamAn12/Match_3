using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class AnimatePositionSystem : ReactiveSystem<GameEntity>
{
    private readonly float SPEED = 1.2f;
    readonly GameContext _context;
    IGroup<GameEntity> _movebleBlock;

    public AnimatePositionSystem(GameContext Game) : base(Game)
    {
        _context = Game;
        _movebleBlock = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Movable,GameMatcher.Downable));
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsset && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        
        var gameBoard = _context.CreateGameBoard().boadGame;
        Debug.Log("gameboard columns:" + gameBoard.columns);
        var topRow = _context.CreateGameBoard().boadGame.row * 1.5f;

        var movebleBlock = _movebleBlock.GetEntities();
        List<GameEntity> movebleBlockList = new List<GameEntity>();
        foreach (var m in movebleBlock)
        {
            movebleBlockList.Add(m);
            m.isMovable = false;
        }


        for (var r = 0 * 1.5f; r < topRow; r += 1.5f)
        {
            var count = 0; // count number of block be created in a column
            var tempr = r;
            foreach (var m in movebleBlockList)
            {
                if (m.view.gameObject.transform.position.x == tempr && m.asset.name != "Prefabs/GenerateBrick")
                {
                    count++;
                }
            }    

//            Debug.Log("COUNT : " + count + " r : " + r);
            if (count == 0)
                foreach (var e in entities)
                {
                    var pos = e.position;
                    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                }
            if (count == 1)
            {
                foreach (var e in entities)
                {
                    var pos = e.position;
                    var isTopRow = (pos.value.y.Equals(topRow - 1.5f));
                    //set local position for the block is top row
                    if (e.position.value.x == tempr && isTopRow)
                    {
                        e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 1.5f);
                    }

                    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                }
            }
            else if (count == 2)
            {
                foreach (var e in entities)
                {
                    var pos = e.position;
                    var isTopRow = (pos.value.y.Equals(topRow - 1.5f));
                    var isSecondRow = (pos.value.y.Equals(topRow - 3f));
                    if (e.position.value.x == tempr && (isTopRow || isSecondRow))
                    {
                        e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 3f);
                    }

                    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                }
            }
            else if (count == 3)
            {
                foreach (var e in entities)
                {
                    var pos = e.position;
                    var isTopRow = (pos.value.y.Equals(topRow - 1.5f));
                    var isSecondRow = (pos.value.y.Equals(topRow - 3f));
                    var isThirdRow = (pos.value.y.Equals(topRow - 4.5f));
                    if (e.position.value.x == tempr && (isTopRow || isSecondRow || isThirdRow))
                    {
                        e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 4.5f);
                    }

                    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                }
            }
            else if (count == 4)
            {
                foreach (var e in entities)
                {
                    var pos = e.position;
                    var isTopRow = (pos.value.y.Equals(topRow - 1.5f));
                    var isSecondRow = (pos.value.y.Equals(topRow - 3f));
                    var isThirdRow = (pos.value.y.Equals(topRow - 4.5f));
                    var is4thRow = (pos.value.y.Equals(topRow - 6f));
                    if (e.position.value.x == tempr && (isTopRow || isSecondRow || isThirdRow || is4thRow))
                    {
                        e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 6f);
                    }

                    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                }
            }
            else if (count == 5)
            {
                foreach (var e in entities)
                {
                    var pos = e.position;
                    var isTopRow = (pos.value.y.Equals(topRow - 1.5f));
                    var isSecondRow = (pos.value.y.Equals(topRow - 3f));
                    var isThirdRow = (pos.value.y.Equals(topRow - 4.5f));
                    var is4thRow = (pos.value.y.Equals(topRow - 6f));
                    var is5thRow = (pos.value.y.Equals(topRow - 7.5f));
                    if (e.position.value.x == tempr && (isTopRow || isSecondRow || isThirdRow || is4thRow || is5thRow))
                    {
                        e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 7.5f);
                    }

                    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                }
            }
            else if (count == 6)
            {
                foreach (var e in entities)
                {
                    var pos = e.position;
                    var isTopRow = (pos.value.y.Equals(topRow - 1.5f));
                    var isSecondRow = (pos.value.y.Equals(topRow - 3f));
                    var isThirdRow = (pos.value.y.Equals(topRow - 4.5f));
                    var is4thRow = (pos.value.y.Equals(topRow - 6f));
                    var is5thRow = (pos.value.y.Equals(topRow - 7.5f));
                    var is6thRow = (pos.value.y.Equals(topRow - 9f));
                    if (e.position.value.x == tempr &&
                        (isTopRow || isSecondRow || isThirdRow || is4thRow || is5thRow || is6thRow))
                    {
                        e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 9f);
                    }

                    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                }
            }
            else if (count == 7)
            {
                foreach (var e in entities)
                {
                    var pos = e.position;
                    var isTopRow = (pos.value.y.Equals(topRow - 1.5f));
                    var isSecondRow = (pos.value.y.Equals(topRow - 3f));
                    var isThirdRow = (pos.value.y.Equals(topRow - 4.5f));
                    var is4thRow = (pos.value.y.Equals(topRow - 6f));
                    var is5thRow = (pos.value.y.Equals(topRow - 7.5f));
                    var is6thRow = (pos.value.y.Equals(topRow - 9f));
                    var is7thRow = (pos.value.y.Equals(topRow - 10.5f));
                    if (e.position.value.x == tempr &&
                        (isTopRow || isSecondRow || isThirdRow || is4thRow || is5thRow || is6thRow || is7thRow))
                    {
                        e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 10.5f);
                    }

                    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                }
            }
            else if (count == 8)
            {
                foreach (var e in entities)
                {
                    var pos = e.position;
                    var isTopRow = (pos.value.y.Equals(topRow - 1.5f));
                    var isSecondRow = (pos.value.y.Equals(topRow - 3f));
                    var isThirdRow = (pos.value.y.Equals(topRow - 4.5f));
                    var is4thRow = (pos.value.y.Equals(topRow - 6f));
                    var is5thRow = (pos.value.y.Equals(topRow - 7.5f));
                    var is6thRow = (pos.value.y.Equals(topRow - 9f));
                    var is7thRow = (pos.value.y.Equals(topRow - 10.5f));
                    var is8thRow = (pos.value.y.Equals(topRow - 12f));
                    if (e.position.value.x == tempr && (isTopRow || isSecondRow || isThirdRow || is4thRow || is5thRow ||
                                                        is6thRow || is7thRow || is8thRow))
                    {
                        e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 12f);
                    }

                    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                }
            }
        }
    }
}