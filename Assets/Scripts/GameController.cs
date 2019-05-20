using System.Collections;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Systems _systems;
    private void Start()
    {
        var contexts = Contexts.sharedInstance;


        _systems = new Feature("Systems")
            .Add(new InputSystem(contexts.input, contexts.game)
            .Add(new BoardSystems(contexts.game, contexts.gameState)
            ));
        _systems.Initialize();
        

    }

    private void Update()
    {
        _systems.Execute(); 
    }
}