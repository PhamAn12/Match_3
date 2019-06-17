﻿using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using Entitas.VisualDebugging.Unity;
using UnityEngine;
using Object = UnityEngine.Object;

public class AddViewSystem : ReactiveSystem<GameEntity>, ITearDownSystem
{
    
    readonly Transform _viewContainer = new GameObject("Views").transform;
    readonly GameContext _context;
    private Systems _systems;
    IGroup<GameEntity> _viewGroup;
    public AddViewSystem(GameContext Game) : base(Game) {
        _context = Game;
        _viewGroup = _context.GetGroup(GameMatcher.View);
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
       // Debug.Log("inside Execute");
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
        foreach(var view in _viewGroup.GetEntities())
        {
            Debug.Log("view in group : " + view.view.gameObject.GetEntityLink());
        }
    }

    public void TearDown()
    {
        Debug.Log("Length of viewGroup arr : " + _viewGroup.GetEntities().Length);
        foreach (var viewElement in _viewGroup.GetEntities())
        {
            Debug.Log("LENGTHTHTHTHTHTHTHTHTHTHTHT :" + viewElement);
            Debug.Log("run in teardown : " + viewElement.view.gameObject.GetEntityLink());
        }
        foreach (var viewElement in _viewGroup.GetEntities())
        {
            Debug.Log("check condition if : " + viewElement.view.gameObject);
            if (viewElement.view.gameObject != null)
            {
                viewElement.view.gameObject.Unlink();
                Object.Destroy(viewElement.view.gameObject);
                Debug.Log("IN TEARDOWN :" + viewElement);

            } 
        }
        
    }
    
}
