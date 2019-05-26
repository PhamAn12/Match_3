using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class AnimatePositionSystem : ReactiveSystem<GameEntity> {
    private readonly float SPEED = 1.5f;
    readonly GameContext _context;
    IGroup<GameEntity> _movebleBlock;

    public AnimatePositionSystem(GameContext Game) : base(Game) {
        _context = Game;
        _movebleBlock = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Movable));
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasAsset && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities) {
        
        
        var gameBoard = _context.CreateGameBoard().boadGame;
        Debug.Log("gameboard columns:" + gameBoard.columns );
        var topRow = _context.CreateGameBoard().boadGame.row * 1.5f;

        var movebleBlock = _movebleBlock.GetEntities();
        List<GameEntity> movebleBlockList = new List<GameEntity>();
        foreach(var m in movebleBlock)
        {
            movebleBlockList.Add(m);
            m.isMovable = false;
        }

        //foreach(var e in entities)
        //{
        //    var pos = e.position;
            //var isTopRow = (pos.value.y.Equals(topRow - 1.5f));
            //var isSecondRow = (pos.value.y.Equals(topRow - 3f));
            //var isThirdRow = (pos.value.y.Equals(topRow - 4.5f));
            //var is4thRow = (pos.value.y.Equals(topRow - 6f));
            //var is5thRow = (pos.value.y.Equals(topRow - 7.5f));
            //var is6thRow = (pos.value.y.Equals(topRow - 9f));
            //var is7thRow = (pos.value.y.Equals(topRow - 10.5f));
            //var is8thRow = (pos.value.y.Equals(topRow - 12f));
            
            for (var r = 0*1.5f; r< topRow; r+=1.5f)
            {
                var count = 0;
                var tempr = r;
                foreach(var m in movebleBlockList)
                {
                    if(m.view.gameObject.transform.position.x == tempr)
                    {
                        count++;
                    }
                }
                Debug.Log("COUNT : " + count + " r : " + r );
                if(count == 1)
                {
                    foreach(var e in entities)
                    {
                        var pos = e.position;
                        if(e.position.value.x == tempr)
                        {
                            
                            e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 1.5f);                           
                        }
                        e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                    }
                }
                else if(count == 2)
                {
                    foreach(var e in entities)
                    {
                        var pos = e.position;
                        if(e.position.value.x == tempr)
                        {
                            
                            e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 3f);
                            
                        }
                        e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                    }
                }
                else if(count == 3)
                {
                    foreach(var e in entities)
                    {
                        var pos = e.position;
                        if(e.position.value.x == tempr)
                        {
                            
                            e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 4.5f);                           
                        }
                        e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                    }
                }
                else if(count == 4)
                {
                    foreach(var e in entities)
                    {
                        var pos = e.position;
                        if(e.position.value.x == tempr)
                        {
                            
                            e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 6f);
                            
                        }
                        e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                    }
                }
                else if(count == 5)
                {
                    foreach(var e in entities)
                    {
                        var pos = e.position;
                        if(e.position.value.x == tempr)
                        {
                            
                            e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 7.5f);                           
                        }
                        e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                    }
                }
                else if(count == 6)
                {
                    foreach(var e in entities)
                    {
                        var pos = e.position;
                        if(e.position.value.x == tempr)
                        {
                            
                            e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 9f);
                            
                        }
                        e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                    }
                }
                else if(count == 7)
                {
                    foreach(var e in entities)
                    {
                        var pos = e.position;
                        if(e.position.value.x == tempr)
                        {
                            
                            e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 10.5f);                           
                        }
                        e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                    }
                }
                else if(count == 8)
                {
                    foreach(var e in entities)
                    {
                        var pos = e.position;
                        if(e.position.value.x == tempr)
                        {
                            
                            e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 12f);
                            
                        }
                        e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), SPEED);
                    }
                }
            
            //else if (count == 3)
            //{
            //    e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 4.5f);
            //    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), 6.3f);
            //}
            //else if (count == 4)
            //{
            //    e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 6f);
            //    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), 6.3f);
            //}
            //else if (count == 5)
            //{
            //    e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 7.5f);
            //    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), 6.3f);
            //}
            //else if (count == 6)
            //{
            //    e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 9f);
            //    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), 6.3f);
            //}
            //else if (count == 7)
            //{
            //    e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 10.5f);
            //    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), 6.3f);
            //}
            //else if (count == 8)
            //{
            //    e.view.gameObject.transform.position = new Vector3(pos.value.x, pos.value.y + 12f);
            //    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), 6.3f);
            //}

            //   }

        }
        //foreach (var e in entities)
        //{
        //    var pos = e.position;
        //    var isTopRow = (pos.value.y.Equals(topRow - 1.5f));
        //    var isSecondRow = (pos.value.y.Equals(topRow - 3f));
        //    var isThirdRow = (pos.value.y.Equals(topRow - 4.5f));
        //    var is4thRow = (pos.value.y.Equals(topRow - 6f));
        //    var is5thRow = (pos.value.y.Equals(topRow - 7.5f));
        //    var is6thRow = (pos.value.y.Equals(topRow - 9f));
        //    var is7thRow = (pos.value.y.Equals(topRow - 10.5f));
        //    var is8thRow = (pos.value.y.Equals(topRow - 12f));
        //    var count = 0;
        //    for (var r = 0 * 1.5f; r < topRow; r += 1.5f)
        //    {
        //        var tempr = r;


        //        if (e.view.gameObject.transform.position.x == tempr)
        //        {
        //            if (pos.value.y.Equals(topRow - 1.5f) || pos.value.y.Equals(topRow - 3f)) count++;

        //        }

        //    }
        //    Debug.Log("COUNT : " + count);
        //    if (count == 1)
        //    {
        //        e.view.gameObject.transform.localPosition = new Vector3(pos.value.x, pos.value.y + 1.5f);
        //    }

        //    //else if (count == 2)
        //    //{
        //    //    e.view.gameObject.transform.localPosition = new Vector3(pos.value.x, pos.value.y + 3f);
        //    //}

        //    e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), 6.3f);
        //    //checkDown(e);
        //}


    }

    private void checkDown( GameEntity e)
    {
        List<GameEntity> entities;
        
        //Debug.Log("E" + e);
        //Debug.Log( "Cood e    " + "x : " + e.position.value.x + " y : " + e.position.value.y);
            
        
        
        //if (isTopRow || isSecondRow)
        //{
        //    e.view.gameObject.transform.localPosition = new Vector3(pos.value.x, pos.value.y + 3f);
        //}
        //else if (isTopRow)
        //{
        //    e.view.gameObject.transform.localPosition = new Vector3(pos.value.x, pos.value.y + 1.5f);
        //}

        //e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), 6.3f);
        //if (isSecondRow || isTopRow || isThirdRow || is4thRow|| is5thRow|| is6thRow || is7thRow || is8thRow) {
        //   // Debug.Log("posX2in : " + pos.value.x + "posY2in : " + pos.value.y);
        //    e.view.gameObject.transform.localPosition = new Vector3(pos.value.x, pos.value.y + i);                
                
        //    //Debug.Log("x : " + e.view.gameObject.transform.localPosition.x + "y : " + e.view.gameObject.transform.localPosition.y);
                
        //}
        ////Debug.Log("e position " + "x " + e.view.gameObject.transform.position.x + " y " + e.view.gameObject.transform.position.y);
        ////Debug.Log("posXout : " + pos.value.x + "posYout : " + pos.value.y);
        //e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f),
        //    6.3f);
    }
    
}