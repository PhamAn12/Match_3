using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entitas;
using UnityEngine;

public class CheckDeleteSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;

    private IGroup<GameEntity> _blockGroup;
    public CheckDeleteSystem(GameContext Game) : base(Game)
    {
        _context = Game;
        _blockGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Position,GameMatcher.BoadGameElement).NoneOf(GameMatcher.Tabbed));

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

//        Debug.Log("check : " + name + " " + x + " " + y);
        foreach (var e in entities)
        {
            var flag = 0;
            var blocks = _blockGroup.GetEntities();
            foreach (var b in blocks)
            {
                if (b.position.value.x == x + 1.5 && b.position.value.y == y)
                {
                    if (b.asset.name == name)
                    {
                        b.isDestroyed = true;
                        flag = 1;
                    }
                        
                }
                if (b.position.value.x == x - 1.5 && b.position.value.y == y)
                {
                    if (b.asset.name == name)
                    {
                        b.isDestroyed = true;
                        flag = 1;
                    }
                }
                if (b.position.value.x == x && b.position.value.y == y + 1.5)
                {
                    if (b.asset.name == name)
                    {
                        b.isDestroyed = true;
                        flag = 1;
                    }
                }
                if (b.position.value.x == x  && b.position.value.y == y - 1.5)
                {
                    if (b.asset.name == name)
                    {
                        b.isDestroyed = true;
                        flag = 1;
                    }
                }
                if (b.position.value.x == x - 1.5  && b.position.value.y == y - 1.5)
                {
                    if (b.asset.name == name)
                    {
                        b.isDestroyed = true;
                        flag = 1;
                    }
                } 
                if (b.position.value.x == x + 1.5  && b.position.value.y == y - 1.5)
                {
                    if (b.asset.name == name)
                    {
                        b.isDestroyed = true;
                        flag = 1;
                    }
                } 
                if (b.position.value.x == x - 1.5  && b.position.value.y == y + 1.5)
                {
                    if (b.asset.name == name)
                    {
                        b.isDestroyed = true;
                        flag = 1;
                    }
                } 
                else if (b.position.value.x == x + 1.5 && b.position.value.y == y + 1.5)
                {
                    if (b.asset.name == name)
                    {
                        b.isDestroyed = true;
                        flag = 1;
                    }
                } 
            }

            if (flag == 1)
                
                e.isDestroyed = true;
            else
            {
                e.isTabbed = false;
            }
        }

        
    }
}