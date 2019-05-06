using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class CheckDeleteSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    public CheckDeleteSystem(GameContext Game) : base(Game)
    {
        _context = Game;
    }  
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.Position,GameMatcher.Tabbed));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
//        var currentPrefab = entities[40].asset.name;
//        var x = 4;
//        var y = 7;
//        Queue q = new Queue();
//        GameEntity[,] arrayGameEntities = new GameEntity[8,8];
//        Debug.Log("x and y :" + x + " " + y);
//        foreach(var e in entities)
//        {
//            for (var i = 0; i < 8; i++)
//            {
//                for (var j = 0; j < 8; j++)
//                {
//                    if (e.position.value.x == i && e.position.value.y == j)
//                    {
//                        arrayGameEntities[i, j] = e;
//                    }
//                }
//            }
//            
//        }
//
//        for (var i = x; i < 8; i++)
//        {
//            if (arrayGameEntities[i, y].asset.name == arrayGameEntities[i + 1, y].asset.name)
//            {
//                
//            } 
//        } 
//        arrayGameEntities[4, 6].isDestroyed = true;
//        var name = entities[0].asset.name;
//        var x = entities[0].position.value.x;
//        var y = entities[0].position.value.y;
//        
//        Debug.Log(name + " " + x + " " + y);
        foreach (var e in entities)
        {    
            Debug.Log("eeee" + e.isTabbed);
//            if(e.isTabbed)
//                Debug.Log("asssss" + e.asset.name);

        }
    }
}