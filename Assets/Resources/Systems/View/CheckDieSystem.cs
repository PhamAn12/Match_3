using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Entitas;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;


public class CheckDieSystem : ReactiveSystem<GameEntity>
{
    private int Size = 9;
    private readonly GameContext _context;
    private IGroup<GameEntity> _heartGroup;
    private IGroup<GameEntity> _blockGroup;
    private IGroup<GameEntity> _blockSuffle;
    private readonly string ASSET_NAME_BRICK = "Prefabs/GenerateBrick";

    public CheckDieSystem(GameContext Game) : base(Game)
    {
        _context = Game;
        _heartGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Heart, GameMatcher.Position));
        _blockGroup = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.BoadGameElement).NoneOf(GameMatcher.Heart, GameMatcher.MoveNum));
        _blockSuffle = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.BoadGameElement,GameMatcher.Downable).NoneOf(GameMatcher.Heart, GameMatcher.MoveNum));
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
        var blockSuffle = _blockSuffle.GetEntities();
        int[,] Free = new int[Size, Size];
        List<int> randomList = new List<int>();
        int rnd;
        List<GameEntity> _listBlockSuffle = null;
        for (int i = 0; i < Size * Size; i++) Free[i % Size, i / Size] = 2;
        if (CheckDied(entities) == false)
        {
            Debug.Log("DIE");
            if(blocksHeart.Length > 0 )
                blocksHeart[0].isDestroyed = true;
            foreach (var b in blockSuffle)
            {
                 //Debug.Log("BBBB :" + b);
            }
            Debug.Log("Length Block Suffle: " + blockSuffle.Length);
            for (int t = 0; t < 1; t++ )
            {
//                var temp = blockSuffle[t];
//                do
//                {
//                    rnd = Random.Range(0,blockSuffle.Length);
//                    
//                } while (randomList.Contains(rnd));
//                randomList.Add(rnd);
//                Debug.Log(t + "_" + rnd + "_" + blockSuffle[rnd]);
//                Debug.Log("temp " + temp);
//                blockSuffle[t] = blockSuffle[rnd];
//                blockSuffle[rnd] = temp;
//                blockSuffle[t].ReplacePosition(new Vector2(blockSuffle[rnd].position.value.x,
//                    blockSuffle[rnd].position.value.y));
//                blockSuffle[rnd].ReplacePosition(new Vector2(temp.position.value.x, temp.position.value.y));
                var temp = blockSuffle[0].position.value;
                //Debug.Log("temp 1 : "+ temp.position.value + "_" + "b1 :" + blockSuffle[0].position.value + "_" + "b2" + blockSuffle[1].position.value);
                blockSuffle[0].ReplacePosition(new Vector2(blockSuffle[1].position.value.x,
                    blockSuffle[1].position.value.y));
                //Debug.Log("temp 2 : "+ temp.position.value + "_" + "b1 : " + blockSuffle[0].position.value + "_" + "b2" + blockSuffle[1].position.value);
                blockSuffle[1].ReplacePosition(new Vector2(temp.x, temp.y));

            }
            foreach (var b in blockSuffle)
            {
                //Debug.Log("AAAA :" + b);
            }
        }
        else 
            Debug.Log("CHUA DIE");
        
    }

    bool CheckDied(List<GameEntity> entities)
    {
        var blocksHeart = _heartGroup.GetEntities();
        var blocks = _blockGroup.GetEntities();
        foreach (var b in blocks)
        {
//            Debug.Log("all block : " + b  );
        }
//        Debug.Log("block 0 : " + blocks[0]);
        
// check can't move 
        var name = blocks[0].asset.name;
        var x = blocks[0].position.value.x;
        var y = blocks[0].position.value.y;
        Queue<GameEntity> queue = new Queue<GameEntity>();
        int[,] Free = new int[Size, Size];
        for (int i = 0; i < Size * Size; i++) Free[i % Size, i / Size] = 0;
        queue.Enqueue(blocks[0]);
        Free[(int) (x / 1.5f), (int) (y / 1.5f)] = 1;
        var flag = 0;
        while(queue.Count != 0)
        {
            //Debug.Log("Queue count :" + queue.Count);
            GameEntity blockPeek = queue.Peek();
            Debug.Log("GameEntityPeek :" + blockPeek.position.value.x + "  " + blockPeek.position.value.y);
            queue.Dequeue();
            foreach (var b in blocks.Skip(1))
            {
                if (b.position.value.x == blockPeek.position.value.x + 1.5 &&
                    b.position.value.y == blockPeek.position.value.y &&
                    Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] == 0)
                {
                    // check next to position with diffrent name or same name as Brick
                    if (b.asset.name != blockPeek.asset.name || (b.asset.name == blockPeek.asset.name && b.asset.name.Equals(ASSET_NAME_BRICK)))
                    {
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] = 1;
                        queue.Enqueue(b);
//                        Debug.Log("b1" + b.position.value.x + "  " + b.position.value.y);
                        flag = 0;
                    }
                    else if(b.asset.name == blockPeek.asset.name)
                    {
                        Debug.Log("ChuaDie1");
                        flag = 1;
                        return true;
                    }
                }

                if (b.position.value.x == blockPeek.position.value.x - 1.5 &&
                    b.position.value.y == blockPeek.position.value.y &&
                    Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] == 0)
                {
                    if (b.asset.name != blockPeek.asset.name|| (b.asset.name == blockPeek.asset.name && b.asset.name.Equals(ASSET_NAME_BRICK)))
                    {
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] = 1;
                        queue.Enqueue(b);
//                        Debug.Log("b2" + b.position.value.x + "  " + b.position.value.y);
                        flag = 0;
                    }
                    else if(b.asset.name == blockPeek.asset.name)
                    {
                        Debug.Log("ChuaDie2");
                        flag = 1;
                        return true;
                    }
                }

                if (b.position.value.x == blockPeek.position.value.x &&
                    b.position.value.y == blockPeek.position.value.y + 1.5 &&
                    Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] == 0)
                {
                    if (b.asset.name != blockPeek.asset.name|| (b.asset.name == blockPeek.asset.name && b.asset.name.Equals(ASSET_NAME_BRICK)))
                    {
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] = 1;
                        queue.Enqueue(b);
//                      Debug.Log("b3" + b.position.value.x + "  " + b.position.value.y);
                        flag = 0;
                    }
                    else if(b.asset.name == blockPeek.asset.name)
                    {
                        Debug.Log("ChuaDie3");
                        flag = 1;
                        return true;
                    }
                }

                if (b.position.value.x == blockPeek.position.value.x &&
                    b.position.value.y == blockPeek.position.value.y - 1.5 &&
                    Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] == 0)
                {
                    if (b.asset.name != blockPeek.asset.name|| (b.asset.name == blockPeek.asset.name && b.asset.name.Equals(ASSET_NAME_BRICK)))
                    {
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] = 1;
                        queue.Enqueue(b);
//                        Debug.Log("b4" + b.position.value.x + "  " + b.position.value.y);
                        flag = 0;
                    }
                    else if(b.asset.name == blockPeek.asset.name)
                    {
                        Debug.Log("ChuaDie4");
                        flag = 1;
                        return true;
                    }
                }
            }
            if(flag == 1) break;
            //Debug.Log("Chua Die");
        }
        Debug.Log("Flag :" + flag);
        if(flag == 0)
        {
            return false;

        }

        return true;
    }
}