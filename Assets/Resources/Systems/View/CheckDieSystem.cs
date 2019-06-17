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
    Contexts context;
    private int Size = 9;
    private readonly GameContext _context;
    private IGroup<GameEntity> _heartGroup;
    // All block in the board
    private IGroup<GameEntity> _blockGroup;
    // All block without brick
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
        
        Debug.Log("HHHHHHHHHHHHHHHHHHH :" + Screen.width + "  " + Screen.height);
        var blocksHeart = _heartGroup.GetEntities();
        var blocks = _blockGroup.GetEntities();
        var blockSuffle = _blockSuffle.GetEntities();
        int[,] Free = new int[Size, Size];
        List<int> randomList = new List<int>();
        int rnd;
        List<GameEntity> _listBlockSuffle = null;
        for (int i = 0; i < Size * Size; i++) Free[i % Size, i / Size] = 2;
        if (CheckColorBlock(blockSuffle))
        {
            Debug.Log("chet");
        }
        else
            Debug.Log("CHUa chet");
        if(CheckColorBlock(blockSuffle) == false && CheckDied(entities) == false)
        {
            if(CheckDied(entities) == false)
            {
                Debug.Log("DIE");
                if (blocksHeart.Length > 0)
                    blocksHeart[0].isDestroyed = true;
                foreach (var b in blockSuffle)
                {
                    //Debug.Log("BBBB :" + b);
                }
                Debug.Log("Length Block Suffle: " + blockSuffle.Length);
                for (int t = 0; t < blockSuffle.Length; t++)
                {
                    var temp = blockSuffle[t].position.value;
                    do
                    {
                        rnd = Random.Range(0, blockSuffle.Length);

                    } while (randomList.Contains(rnd));
                    randomList.Add(rnd);
                    //Debug.Log(t + "_" + rnd + "_" + blockSuffle[rnd]);
                    //Debug.Log("temp " + temp);
                    blockSuffle[t].ReplacePosition(new Vector2(blockSuffle[rnd].position.value.x,
                        blockSuffle[rnd].position.value.y));
                    blockSuffle[rnd].ReplacePosition(new Vector2(temp.x, temp.y));
                    //var temp = blockSuffle[0].position.value;

                    //blockSuffle[0].ReplacePosition(new Vector2(blockSuffle[1].position.value.x,
                    //    blockSuffle[1].position.value.y));

                    //blockSuffle[1].ReplacePosition(new Vector2(temp.x, temp.y));

                }
                foreach (var b in blockSuffle)
                {
                    //Debug.Log("AAAA :" + b);
                }
            }
            if (CheckDied(entities))
                Debug.Log("CHUA DIE");
        }
        else if(CheckColorBlock(blockSuffle) == true)
        {
            Debug.Log("THUA CUOC");
        }

        if (entities[0].moveNum.value == 0)
        {
            SceneManager.LoadScene("Lose");
 
        }

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
        List<GameEntity> blockInQueue = new List<GameEntity>();
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
            foreach (var b in blocks)
            {
                if (b.position.value.x == blockPeek.position.value.x + 1.5 &&
                    b.position.value.y == blockPeek.position.value.y
                    && Free[(int)(b.position.value.x / 1.5f), (int)(b.position.value.y / 1.5f)] == 0
                    )
                {
                    if (b.asset.name != blockPeek.asset.name || (b.asset.name == blockPeek.asset.name && b.asset.name.Equals(ASSET_NAME_BRICK)))
                    {
                        Free[(int)(b.position.value.x / 1.5f), (int)(b.position.value.y / 1.5f)] = 1;
                        queue.Enqueue(b);
                        // Check trong queue co 2 block cung mau canh nhau hay ko
                        foreach (var i in queue.ToArray())
                        {
                            if (!b.asset.name.Equals(ASSET_NAME_BRICK) && i.asset.name.Equals(b.asset.name) && ((b.position.value.x == i.position.value.x && b.position.value.y
                                == i.position.value.y + 1.5) || (b.position.value.x == i.position.value.x && b.position.value.y
                                == i.position.value.y - 1.5) || (b.position.value.x == i.position.value.x + 1.5 && b.position.value.y
                                == i.position.value.y) || (b.position.value.x == i.position.value.x && b.position.value.y
                                == i.position.value.y - 1.5)))
                            {
                                Debug.Log("i11" + i.position.value.x + "  " + i.position.value.y);
                                Debug.Log("ChuaDie11");
                                Debug.Log("b11" + b.position.value.x + "  " + b.position.value.y);
                                return true;
                            }
                        }
                        Debug.Log("b1" + b.position.value.x + "  " + b.position.value.y);
                        flag = 0;
                    }
                    else if (b.asset.name == blockPeek.asset.name)
                    {
                        Debug.Log("ChuaDie1");
                        flag = 1;
                        return true;
                    }
                }

                if (b.position.value.x == blockPeek.position.value.x -1.5 &&
                    b.position.value.y == blockPeek.position.value.y
                    && Free[(int)(b.position.value.x / 1.5f), (int)(b.position.value.y / 1.5f)] == 0
                    )
                {
                    if (b.asset.name != blockPeek.asset.name || (b.asset.name == blockPeek.asset.name && b.asset.name.Equals(ASSET_NAME_BRICK)))
                    {
                        Free[(int)(b.position.value.x / 1.5f), (int)(b.position.value.y / 1.5f)] = 1;
                        queue.Enqueue(b);
                        // Check trong queue co 2 block cung mau canh nhau hay ko
                        foreach (var i in queue.ToArray())
                        {
                            if (!b.asset.name.Equals(ASSET_NAME_BRICK) && i.asset.name.Equals(b.asset.name) && ((b.position.value.x == i.position.value.x && b.position.value.y
                                == i.position.value.y + 1.5) || (b.position.value.x == i.position.value.x && b.position.value.y
                                == i.position.value.y - 1.5) || (b.position.value.x == i.position.value.x + 1.5 && b.position.value.y
                                == i.position.value.y) || (b.position.value.x == i.position.value.x && b.position.value.y
                                == i.position.value.y - 1.5)))
                            {
                                Debug.Log("i22" + i.position.value.x + "  " + i.position.value.y);
                                Debug.Log("ChuaDie22");
                                Debug.Log("b22" + b.position.value.x + "  " + b.position.value.y);
                                return true;
                            }
                        }
                        Debug.Log("b2" + b.position.value.x + "  " + b.position.value.y);
                        flag = 0;
                    }
                    else if (b.asset.name == blockPeek.asset.name)
                    {
                        Debug.Log("ChuaDie2");
                        flag = 1;
                        return true;
                    }
                }

                if (b.position.value.x == blockPeek.position.value.x &&
                    b.position.value.y == blockPeek.position.value.y + 1.5
                    && Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] == 0
                    )
                {
                    if (b.asset.name != blockPeek.asset.name|| (b.asset.name == blockPeek.asset.name && b.asset.name.Equals(ASSET_NAME_BRICK)))
                    {
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] = 1;
                        queue.Enqueue(b);
                        // Check trong queue co 2 block cung mau canh nhau hay ko
                        foreach (var i in queue.ToArray())
                        {
                            if (!b.asset.name.Equals(ASSET_NAME_BRICK) && i.asset.name.Equals(b.asset.name) && ((b.position.value.x == i.position.value.x && b.position.value.y
                                == i.position.value.y + 1.5) || (b.position.value.x == i.position.value.x && b.position.value.y
                                == i.position.value.y - 1.5) || (b.position.value.x == i.position.value.x + 1.5 && b.position.value.y
                                == i.position.value.y) || (b.position.value.x == i.position.value.x && b.position.value.y
                                == i.position.value.y - 1.5)))
                            {
                                Debug.Log("i33" + i.position.value.x + "  " + i.position.value.y);
                                Debug.Log("ChuaDie33");
                                Debug.Log("b33" + b.position.value.x + "  " + b.position.value.y);
                                return true;
                            }
                        }
                        Debug.Log("b3" + b.position.value.x + "  " + b.position.value.y);
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
                    b.position.value.y == blockPeek.position.value.y - 1.5
                    && Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] == 0
                   )
                {
                    if (b.asset.name != blockPeek.asset.name|| (b.asset.name == blockPeek.asset.name && b.asset.name.Equals(ASSET_NAME_BRICK)))
                    {
                        Free[(int) (b.position.value.x / 1.5f), (int) (b.position.value.y / 1.5f)] = 1;
                        queue.Enqueue(b);
                        // Check trong queue co 2 block cung mau canh nhau hay ko
                        foreach (var i in queue.ToArray())
                        {
                            if (!b.asset.name.Equals(ASSET_NAME_BRICK) && i.asset.name.Equals(b.asset.name) && ((b.position.value.x == i.position.value.x && b.position.value.y
                                == i.position.value.y + 1.5) || (b.position.value.x == i.position.value.x && b.position.value.y
                                == i.position.value.y - 1.5) || (b.position.value.x == i.position.value.x + 1.5 && b.position.value.y
                                == i.position.value.y) || (b.position.value.x == i.position.value.x && b.position.value.y
                                == i.position.value.y - 1.5)))
                            {
                                Debug.Log("i44" + i.position.value.x + "  " + i.position.value.y);
                                Debug.Log("ChuaDie44");
                                Debug.Log("b44" + b.position.value.x + "  " + b.position.value.y);
                                return true;
                            }
                        }
                        Debug.Log("b4" + b.position.value.x + "  " + b.position.value.y);
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
            //if(flag == 1) break;
            //Debug.Log("Chua Die");
        }
        //Debug.Log("Flag :" + flag);
        //if(flag == 0)
        //{
        //    return false;

        //}

        return false;
    }

    bool CheckColorBlock(GameEntity[] blockSuffle)
    {
        List<GameEntity> s1 = new List<GameEntity>();
        List<GameEntity> s2 = new List<GameEntity>();
        List<GameEntity> s3 = new List<GameEntity>();
        List<GameEntity> s4 = new List<GameEntity>();
        List<GameEntity> s5 = new List<GameEntity>();
        foreach (var block in blockSuffle)
        {
            if (block.asset.name.Equals("Prefabs/Block_1")) s1.Add(block);
            if (block.asset.name.Equals("Prefabs/Block_2")) s2.Add(block);
            if (block.asset.name.Equals("Prefabs/Piece0")) s3.Add(block);
            if (block.asset.name.Equals("Prefabs/Piece3")) s4.Add(block);
            if (block.asset.name.Equals("Prefabs/Piece4")) s5.Add(block);
        }

        Debug.Log("Counttttt :" + s1.Count + " " + s2.Count + " " + s3.Count + " " + s4.Count + " " + s5.Count);
        //Debug.Log("Lengthhhh :" + blockSuffle.Length);
        if ((s1.Count == 1 || s1.Count == 0) && (s2.Count == 1 || s2.Count == 0) && (s3.Count == 1 || s3.Count == 0) &&
            (s4.Count == 1 || s4.Count == 0) && (s5.Count == 1 || s5.Count == 0))
            return true;
        else
            return false;
    }
}