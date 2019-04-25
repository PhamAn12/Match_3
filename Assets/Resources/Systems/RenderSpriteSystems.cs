using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class RenderSpriteSystems : ReactiveSystem<GameEntity> 
{
    readonly GameContext _context;

    public RenderSpriteSystems(GameContext Game) : base(Game) {
        _context = Game;
    }
    public RenderSpriteSystems(IContext<GameEntity> context) : base(context)
    {
    }

    public RenderSpriteSystems(ICollector<GameEntity> collector) : base(collector)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        
        Debug.Log("SL  " + entities.Count);
        int i = 0, j = 0;
        
        foreach (var e in entities)
        {
            

            Debug.Log("Asset name :" + e.asset.name);

            GameObject GO = Resources.Load(e.asset.name) as GameObject;
            //GO.transform.position = new Vector3(i,j, 0);
            
            try
            {
                UnityEngine.Object.Instantiate(GO);
                    
                    
            }
            catch (EntitasException)
            {
                 Debug.Log("can't not initialize");
            }

            i++;
            if (i >= 5)
            {
                j++;
                i--;
            }

        }
    }
}