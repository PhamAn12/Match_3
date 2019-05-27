﻿using System.Collections;
using System.Linq.Expressions;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Systems _systems;
    public GameStateContext GameState { get; } = new GameStateContext();
    private static GameController _Instance = null;
    
    public static GameController Instance
    {
        get {
            if (_Instance == null)
                _Instance = FindObjectOfType<GameController>();
            return _Instance;
        }
    }
    private void Start()
    {
        
        var contexts = Contexts.sharedInstance;

        
        _systems = new Feature("Systems")
            .Add(new InputSystem(contexts.input, contexts.game)
            .Add(new BoardSystems(contexts.game)
            ));
        _systems.Initialize();
        

    }

    private void Update()
    {
        _systems.Execute(); 
    }
}