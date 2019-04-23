using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomBoardElements 
{
    static readonly string[] _items = {
        "CellBlock",
        "Piece0"
        
    };
    public static GameEntity CreateGameBoard(this GameContext context)
    {
        var entity = context.CreateEntity();
        entity.AddBoadGame(8, 9);
        return entity;
    }
    
    public static GameEntity CreateRandomPiece(this GameContext context, int x, int y) {
        var entity = context.CreateEntity();
        
        entity.AddPosition(new Vector2(x, y));
        //GameObject obj = Resources.Load("CellBlock") as GameObject;

       // Instantiate(obj);
        entity.AddAsset(_items[Random.Range(0, _items.Length)]);
        return entity;
    }
}
