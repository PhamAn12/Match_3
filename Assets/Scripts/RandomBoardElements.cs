using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomBoardElements 
{
    // private static  GameObject block;
    static readonly string[] _items = {
        "Prefabs/GenerateBrick",
        "Prefabs/Piece0",
        "Prefabs/Block_2"
        
    };
    public static GameEntity CreateGameBoard(this GameContext context)
    {
        var entity = context.CreateEntity();
        entity.AddBoadGame(8, 10);
        return entity;
    }
    
    public static GameEntity CreateRandomPiece(this GameContext context, int x, int y) {
        var entity = context.CreateEntity();
        
        entity.AddPosition(new Vector2(x, y));
        //GameObject obj = Resources.Load("CellBlock") as GameObject;

       // Instantiate(obj);
        entity.AddAsset(_items[Random.Range(0, _items.Length)]);
        
        //var block_instance = Instantiate(block) as GameObject;
        
        //block_instance.transform.position = new Vector3(3,3,0); 
        return entity;
    }
}
