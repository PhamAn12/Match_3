using System.Collections;
using System.Linq.Expressions;
using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Systems _systems;
    Contexts _contexts;
    private static GameController _Instance = null;
    IGroup<GameEntity> _viewGroup;
    
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
        _systems.Cleanup();
    }
    
    
    
    private void OnDestroy()
    {
        _systems.TearDown();
        _systems.DeactivateReactiveSystems();
        //Contexts.sharedInstance.Reset();
        Contexts.sharedInstance.game.Reset();
        Contexts.sharedInstance.gameState.Reset();
        Contexts.sharedInstance.input.Reset();
        //_systems.ActivateReactiveSystems();

    }
    

}