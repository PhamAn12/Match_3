using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewSystems : ReactiveSystem<GameEntity> 
{
    readonly GameContext _context;

    public AddViewSystems(GameContext Game) : base(Game) {
        _context = Game;
    }
    public AddViewSystems(IContext<GameEntity> context) : base(context)
    {
    }

    public AddViewSystems(ICollector<GameEntity> collector) : base(collector)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(GameEntity entity)
    {
        throw new System.NotImplementedException();
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var asset = Resources.Load<GameObject>(e.asset.name);

            GameObject gameObject = null;

            gameObject = UnityEngine.Object.Instantiate(asset);
           
          
        }
    }
}