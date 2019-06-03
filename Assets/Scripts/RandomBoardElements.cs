using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Random = UnityEngine.Random;

public static class RandomBoardElements 
{
    // private static  GameObject block;
    static readonly string[] _items = {
        //"Prefabs/GenerateBrick",
        "Prefabs/Piece0",
        "Prefabs/Block_2",
        "Prefabs/Block_1",
        "Prefabs/Piece3",
        "Prefabs/Piece4"
        //"Prefabs/Piece5",

    };
    
    
    public static GameEntity CreateGameBoard(this GameContext context)
    {
        string rows = PlayerPrefs.GetString("SizeRows");
        string cols = PlayerPrefs.GetString("SizeCols");
        
        var entity = context.CreateEntity();
        //entity.AddBoadGame(Convert.ToInt32(cols), Convert.ToInt32(rows));
        entity.AddBoadGame(4,7);
        return entity;
    }
    
    public static GameEntity CreateRandomPiece(this GameContext context, float x, float y) 
    {
        var entity = context.CreateEntity();
        
        entity.AddPosition(new Vector2(x * 1.5f, y * 1.5f));
        entity.AddAsset(_items[Random.Range(0, _items.Length)]);
        //entity.isMovable = true;
        entity.isBoadGameElement = true;
        entity.isDownable = true;
        return entity;
    }

    public static GameEntity CreateRandomBlock(this GameContext context, float x, float y)
    {
        var entity = context.CreateEntity();
        entity.AddPosition(new Vector2(x * 1.5f, y * 1.5f));
        entity.AddAsset("Prefabs/GenerateBrick");
        entity.isBoadGameElement = true;
        //entity.isMovable = true;
        return entity;
    }

    
}
