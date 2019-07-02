using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entitas;

using UnityEngine;

public class CheckDeleteSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext context;
    private readonly string ASSET_NAME_BRICK = "Prefabs/GenerateBrick";
    private IGroup<GameEntity> blockGroup;
    public CheckDeleteSystem(GameContext Game) : base(Game)
    {
        context = Game;
        blockGroup = context.GetGroup(GameMatcher.AllOf(GameMatcher.Position,GameMatcher.BoadGameElement).NoneOf(GameMatcher.Tabbed));

    }  
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        //return context.GetGroup(GameMatcher.Position);
        return context.CreateCollector(GameMatcher.Tabbed);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var name = entities[0].asset.name;
        var x = entities[0].position.value.x;
        var y = entities[0].position.value.y;
       
        Queue <GameEntity>q = new Queue<GameEntity>();
        int[,] Free = new int[9,9];
        for (int i = 0; i < 81; i++) Free[i % 9, i / 9] = 0;
        
        
        q.Enqueue(entities[0]);
        Free[(int) (x/1.5f), (int) (y/1.5f)] = 1;
        var flag = 0;
        if (name != ASSET_NAME_BRICK)
        {
            while (q.Count != 0)
            {
                GameEntity gameEntity = q.Peek();
                //Debug.Log("element in q : " + q.ToArray().ToList());
                //Debug.Log("first element x : " + gameEntity.position.value.x + " y " + gameEntity.position.value.y);
                q.Dequeue();
                
                var blocks = blockGroup.GetEntities();
                foreach (var b in blocks)
                {
                    //Debug.Log("free in b" + Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)]);
                    if (b.position.value.x == gameEntity.position.value.x + 1.5 && 
                        b.position.value.y == gameEntity.position.value.y && b.asset.name == name &&
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] == 0)
                    {
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] = 1;
                        q.Enqueue(b);
                        //Debug.Log("inin element x : " + gameEntity.position.value.x + " y " + gameEntity.position.value.y);
                        b.isDestroyed = true;
                        b.isMovable = true;
                        flag = 1;

                    }
                    if (b.position.value.x == gameEntity.position.value.x - 1.5 && 
                        b.position.value.y == gameEntity.position.value.y && b.asset.name == name &&
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] == 0)
                    {
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] = 1;
                        q.Enqueue(b);
                        //Debug.Log("inin element x : " + gameEntity.position.value.x + " y " + gameEntity.position.value.y);
                        b.isDestroyed = true;
                        flag = 1;

                    }
                    if (b.position.value.x == gameEntity.position.value.x  && 
                        b.position.value.y == gameEntity.position.value.y + 1.5 && b.asset.name == name &&
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] == 0)
                    {
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] = 1;
                        q.Enqueue(b);
                        //Debug.Log("inin element x : " + gameEntity.position.value.x + " y " + gameEntity.position.value.y);
                        b.isDestroyed = true;
                        flag = 1;

                    }
                    if (b.position.value.x == gameEntity.position.value.x && 
                        b.position.value.y == gameEntity.position.value.y - 1.5 && b.asset.name == name &&
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] == 0)
                    {
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] = 1;
                        q.Enqueue(b);
                        //Debug.Log("inin element x : " + gameEntity.position.value.x + " y " + gameEntity.position.value.y);
                        b.isDestroyed = true;
                        flag = 1;

                    }
                                        
                }
                
                
            }
        }    

        if (flag == 1) 
            entities[0].isDestroyed = true;
        else 
            entities[0].isTabbed = false;

    }

}