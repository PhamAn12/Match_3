using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class AnimatePositionSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;
    

    public AnimatePositionSystem(GameContext Game) : base(Game) {
        _context = Game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities) {
        
        
        var gameBoard = _context.CreateGameBoard().boadGame;
        Debug.Log("gameboard columns:" + gameBoard.columns );
        
        foreach (var e in entities)
        {
//            var count = 0;
//            for (int i = 0; i < gameBoard.columns; i++)
//            {
//                if (e.isDestroyed) count++;
//            }
//            Debug.Log("Count : " + count);
            checkDown(1.5f, e);
            
        }

    }

    private void checkDown(float i, GameEntity e)
    {
        var topRow = _context.CreateGameBoard().boadGame.row * 1.5f;
        //Debug.Log("E" + e);
        //Debug.Log( "Cood e    " + "x : " + e.position.value.x + " y : " + e.position.value.y);
            
        var pos = e.position;
        var isTopRow = (pos.value.y.Equals(topRow - 1.5f));
        var isSecondRow = (pos.value.y.Equals(topRow - 3f));
        var isThirdRow = (pos.value.y.Equals(topRow - 4.5f));
        var is4thRow = (pos.value.y.Equals(topRow - 6f));
        var is5thRow = (pos.value.y.Equals(topRow - 7.5f));
        var is6thRow = (pos.value.y.Equals(topRow - 9f));
        var is7thRow = (pos.value.y.Equals(topRow - 10.5f));
        var is8thRow = (pos.value.y.Equals(topRow - 12f));
        
        if (isSecondRow || isTopRow || isThirdRow || is4thRow|| is5thRow|| is6thRow || is7thRow || is8thRow) {
           // Debug.Log("posX2in : " + pos.value.x + "posY2in : " + pos.value.y);
            e.view.gameObject.transform.localPosition = new Vector3(pos.value.x, pos.value.y + i);                
                
            //Debug.Log("x : " + e.view.gameObject.transform.localPosition.x + "y : " + e.view.gameObject.transform.localPosition.y);
                
        }
        //Debug.Log("e position " + "x " + e.view.gameObject.transform.position.x + " y " + e.view.gameObject.transform.position.y);
        //Debug.Log("posXout : " + pos.value.x + "posYout : " + pos.value.y);
        e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f),
            6.3f);
    }
    
}