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
        
        
       _systems = new Feature("Systems").Add(new BoardSystems(contexts.game));
        _systems.Initialize();


    }
    
    
}