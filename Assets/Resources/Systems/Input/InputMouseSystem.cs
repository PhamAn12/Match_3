using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
public class InputMouseSystem : IExecuteSystem, ICleanupSystem
{
    GameContext _context;

    public InputMouseSystem(Context Input)
    {
        _context = Input.game;
        
    }

    public InputMouseSystem(GameContext game)
    {
        _context = game;
    }

    public void Cleanup()
    {
        throw new System.NotImplementedException();
    }

    public void Execute()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse Click");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Mouse CLick");
        }
    }
}
