using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomBoardElements 
{
    public static GameEntity CreateGameBoard(this GameContext context)
    {
        var entity = context.CreateEntity();
        entity.AddBoadGame(8, 9);
        return entity;
    }
}
