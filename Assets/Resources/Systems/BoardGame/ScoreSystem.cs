using System.Collections.Generic;
using DefaultNamespace;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : ReactiveSystem<GameEntity>,IInitializeSystem
{
    readonly GameContext _context;
    int count = 0;
    private Text _label;
    public ScoreSystem(GameContext Game) : base(Game) {
        _context = Game;
    }

    public void Initialize()
    {
        updateScore(0);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BoadGameElement.Removed());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        
        var ban = entities.Count;
        
        Debug.Log("NMDMDddddddererererer : " + ban);
        count += ban;
        Debug.Log(count);
        updateScore(count);
    }
    void updateScore(int score)
    {
        _label = GameObject.Find("Canvas/Text").GetComponent<Text>();
        _label.transform.position = new Vector3(95,155);
        _label.text = "Score " + score; 
        
    }

    
}
