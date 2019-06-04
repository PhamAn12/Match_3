using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
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
        if (Convert.ToInt32(rows) == 0 || Convert.ToInt32(cols) == 0)
        {
            rows = "8";
            cols = "8";
        }
        entity.AddBoadGame(Convert.ToInt32(cols), Convert.ToInt32(rows));
        
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

    public static GameEntity CreateHeart(this GameContext context, float x, float y)
    {
        var entity = context.CreateEntity();
        entity.AddPosition(new Vector2(x,y));
        entity.AddAsset("Prefabs/Heart");
        entity.isHeart = true;
        return entity;
    }
    
}
