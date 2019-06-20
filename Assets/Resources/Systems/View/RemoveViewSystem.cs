using System.Collections.Generic;
using System.Threading;
using DG.Tweening;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class RemoveViewSystem : ReactiveSystem<GameEntity>,ITearDownSystem
{
    public RemoveViewSystem(GameContext Game) : base(Game) {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(
            GameMatcher.Asset.Removed(),
            GameMatcher.Destroyed.Added()
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var e in entities) {  
            
                destroyView(e.view);
                e.RemoveView();
            
                          
        }
    }

    void destroyView(ViewComponent viewComponent) {
        var gameObject = viewComponent.gameObject;
        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        var color = spriteRenderer.color;
        color.a = 0f;
        spriteRenderer.material.DOColor(color, 0.9f);
        
//        gameObject.Unlink();
//        Object.Destroy(gameObject);
        gameObject.transform
            .DOScale(Vector3.one * 0.9f, 0.9f)
            .OnComplete(() => {
                
                    gameObject.Unlink();
                    Object.Destroy(gameObject);
                
                         
            });
    }

    public void TearDown()
    {
        
    }
}