using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Entitas;

public class InputMouseSystem : IExecuteSystem, ICleanupSystem
{
    private readonly InputContext _context;
    private readonly IGroup<InputEntity> _inputs;
    public InputMouseSystem(InputContext Input)
    {
        _context = Input;
        _inputs = _context.GetGroup(InputMatcher.Input);
    }


    public void Execute()
    {
        var elements = _inputs.GetEntities();
        var mousePosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero,100);
            //Debug.Log("HIT Collider" + hit.collider);
            if (hit.collider != null)
            {
                var pos = hit.collider.transform.position;
            
                _context.CreateEntity().AddInput( pos.x,  pos.y);
                Debug.Log(elements);
                Debug.Log("POS   " + pos);
            }
        }
        
    }
    
    public void Cleanup()
    {
        foreach (var e in _inputs.GetEntities())
        {
            Debug.Log("On cleanup system" + e.ToString());
            e.Destroy();
        }
    }
}