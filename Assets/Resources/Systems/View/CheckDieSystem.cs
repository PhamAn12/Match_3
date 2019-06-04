using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entitas;
using UnityEngine;


public class CheckDieSystem : ReactiveSystem<GameEntity>
{
    private int Size = 9;
    private readonly GameContext _context;
    private IGroup<GameEntity> _heartGroup;
    private IGroup<GameEntity> _blockGroup;
    private readonly string ASSET_NAME_BRICK = "Prefabs/GenerateBrick";

    public CheckDieSystem(GameContext Game) : base(Game)
    {
        _context = Game;
        _heartGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Heart, GameMatcher.Position));
        _blockGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.BoadGameElement));
    }


    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MoveNum);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var blocksHeart = _heartGroup.GetEntities();
        var blocks = _blockGroup.GetEntities();
        foreach (var e in entities)
        {
            Debug.Log("ALL ENTITY : " + e);
            if (e.moveNum.value.Equals(8) || e.moveNum.value.Equals(5) || e.moveNum.value.Equals(2))
            {
                Debug.Log("YOU DIED");
                blocksHeart[0].isDestroyed = true;
                foreach (var block in blocks)
                {
                    block.isDestroyed = true;
                }
            }
        }

//        var name = blocks[0].asset.name;
//        var x = blocks[0].position.value.x;
//        var y = blocks[0].position.value.y;
//        Queue<GameEntity> queue = new Queue<GameEntity>();
//        int[,] Free = new int[Size, Size];
//        for (int i = 0; i < Size * Size; i++) Free[i % Size, i / Size] = 0;
//        queue.Enqueue(entities[0]);
//        Free[(int) (x / 1.5f), (int) (y / 1.5f)] = 1;
//
//
//        {
//            GameEntity gameEntity = queue.Peek();
//            queue.Dequeue();
//            foreach (var e in blocks)
//            {
//                if (e.position.value.x == gameEntity.position.value.x + 1.5 &&
//                    e.position.value.y == gameEntity.position.value.y && e.asset.name != name &&
//                    Free[(int) (e.position.value.x / 1.5f), (int) (e.position.value.y / 1.5f)] == 0)
//                {
//                    Free[(int) (e.position.value.x / 1.5f), (int) (e.position.value.y / 1.5f)] = 1;
//                    queue.Enqueue(e);
//                }
//
//                if (e.position.value.x == gameEntity.position.value.x - 1.5 &&
//                    e.position.value.y == gameEntity.position.value.y && e.asset.name != name &&
//                    Free[(int) (e.position.value.x / 1.5f), (int) (e.position.value.y / 1.5f)] == 0)
//                {
//                    Free[(int) (e.position.value.x / 1.5f), (int) (e.position.value.y / 1.5f)] = 1;
//                    queue.Enqueue(e);
//                }
//
//                if (e.position.value.x == gameEntity.position.value.x &&
//                    e.position.value.y == gameEntity.position.value.y + 1.5 && e.asset.name != name &&
//                    Free[(int) (e.position.value.x / 1.5f), (int) (e.position.value.y / 1.5f)] == 0)
//                {
//                    Free[(int) (e.position.value.x / 1.5f), (int) (e.position.value.y / 1.5f)] = 1;
//                    queue.Enqueue(e);
//                }
//
//                if (e.position.value.x == gameEntity.position.value.x &&
//                    e.position.value.y == gameEntity.position.value.y - 1.5 && e.asset.name != name &&
//                    Free[(int) (e.position.value.x / 1.5f), (int) (e.position.value.y / 1.5f)] == 0)
//                {
//                    Free[(int) (e.position.value.x / 1.5f), (int) (e.position.value.y / 1.5f)] = 1;
//                    queue.Enqueue(e);
//                }
//            }
//
//            Debug.Log("Chua Die");
//        }
//
//        blocksHeart[0].isDestroyed = true;
//        foreach (var block in blocks)
//        {
//            block.isDestroyed = true;
//        }
    }
}