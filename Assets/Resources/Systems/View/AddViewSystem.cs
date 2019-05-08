using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class AddViewSystem : ReactiveSystem<GameEntity>
{
    
    readonly Transform _viewContainer = new GameObject("Views").transform;
    readonly GameContext _context;

    public AddViewSystem(GameContext Game) : base(Game) {
        _context = Game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Asset);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAsset && !entity.hasView;

    }

    protected override void Execute(List<GameEntity> entities)
    {
        Debug.Log("inside Execute");
        foreach (var e in entities)
        {
            //Debug.Log(entities.Count);
            //GameObject go = new GameObject("Game View");
            //Debug.Log("GO" + go);
            //go.transform.SetParent(_viewContainer, false);
            //e.AddView(go);
            //go.Link(e);
            var asset = Resources.Load<GameObject>(e.asset.name);
            GameObject gameObject = null;
            try
            {
                gameObject = UnityEngine.Object.Instantiate(asset);

            }
            catch (Exception)
            {
                Debug.Log("Cannot instantiate " + e.asset.name);
            }

            if (gameObject != null)
            {
                gameObject.transform.SetParent(_viewContainer, false);
                e.AddView(gameObject);
                gameObject.Link(e);
            }
        }
    }
}
