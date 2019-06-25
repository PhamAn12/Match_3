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
    private Button btn;
    Contexts _contexts;
    private bool isQuitting = false;
    public GameStateContext GameState { get; } = new GameStateContext();
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
        btn = GameObject.Find("Canvas/Panel/Text").GetComponent<Button>();
        
        _systems.Execute(); 
        _systems.Cleanup();
    }
    
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }
    
    private void OnDestroy()
    {
        _systems.TearDown();
        
        _systems.DeactivateReactiveSystems();
        Contexts.sharedInstance.Reset();
        //SceneManager.LoadScene("Lose");
        //Contexts.sharedInstance.game.Reset();
        //Contexts.sharedInstance.input.Reset();
        //_systems.ActivateReactiveSystems();

    }
    

}