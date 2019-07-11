using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public class MechanicsSystem : ReactiveSystem<GameEntity>
{
    private GameContext gameContext;
    private IGroup<GameEntity> blockOnBoard;
    public MechanicsSystem(GameContext game) : base(game)
    {
        gameContext = game;
        blockOnBoard = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Position, GameMatcher.BoadGameElement)
        );
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.TypeTapOn);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        //entities[0].typeTapOn.typeTap.E
//        if (entities[0].typeTapOn.typeTap.Equals("Boom"))
//        {
//            var posY = entities[0].position.value.y;
//            var posX = entities[0].position.value.x;
//            var allBlock = blockOnBoard.GetEntities();
//            foreach (var block in allBlock)
//            {
//                if (block.position.value.y == posY && block.position.value.x == posX 
//                    || block.position.value.y == posY + 1.5f && block.position.value.x == posX + 1.5f 
//                    || block.position.value.y == posY + 1.5f && block.position.value.x == posX - 1.5f
//                    || block.position.value.y == posY - 1.5f && block.position.value.x == posX - 1.5f 
//                    || block.position.value.y == posY - 1.5f && block.position.value.x == posX + 1.5f 
//                    || block.position.value.y == posY + 1.5f && block.position.value.x == posX
//                    || block.position.value.y == posY - 1.5f && block.position.value.x == posX
//                    || block.position.value.y == posY && block.position.value.x == posX + 1.5f
//                    || block.position.value.y == posY && block.position.value.x == posX - 1.5f
//                )
//                {
//                    block.isDestroyed = true;
//                }
//            }
//        }

        foreach (var e in entities)
        {
            if (e.typeTapOn.typeTap.Equals("TapOnBoom"))
            {
                var posX = e.position.value.x;
                var posY = e.position.value.y;
                
                var allBlock = blockOnBoard.GetEntities();
                foreach (var block in allBlock)
                {
                    if (!block.hasTypeMechanicsDestroy &&
                         block.position.value.y == posY + 1.5f && block.position.value.x == posX + 1.5f 
                        || block.position.value.y == posY + 1.5f && block.position.value.x == posX - 1.5f
                        || block.position.value.y == posY - 1.5f && block.position.value.x == posX - 1.5f 
                        || block.position.value.y == posY - 1.5f && block.position.value.x == posX + 1.5f 
                        || block.position.value.y == posY + 1.5f && block.position.value.x == posX
                        || block.position.value.y == posY - 1.5f && block.position.value.x == posX
                        || block.position.value.y == posY && block.position.value.x == posX + 1.5f
                        || block.position.value.y == posY && block.position.value.x == posX - 1.5f
                    )
                    {
                        if (block.asset.name.Equals("Prefabs/Rocket"))
                        {
                            block.AddTypeTapOn("TapOnRocket");
                            //GameController.Instance.StartCoroutine(DelayBeforDeleteRocket(1f));
                            
                        }
                        else if (block.asset.name.Equals("Prefabs/Boom"))
                        {
                            block.AddTypeTapOn("TapOnBoom");
                            //GameController.Instance.StartCoroutine(DelayBeforDeleteRocket(1f));
                            
                        }
                        else 
                        block.AddTypeMechanicsDestroy("Boom");
                    }
                }
                
                e.AddTypeMechanicsDestroy("Boom");
                
            }
            else if (e.typeTapOn.typeTap.Equals("TapOnRocket"))
            {
                var posY = e.position.value.y;
                var posX = e.position.value.x;
                var widthBoard = gameContext.CreateGameBoard().boadGame.columns * 1.5f - 1.5f * posX;
                var allBlock = blockOnBoard.GetEntities();
                
                foreach (var block in allBlock)
                {
                    if (block.position.value.y == posY && block.position.value.x != posX && !block.hasTypeMechanicsDestroy)
                    {
                        block.AddTypeMechanicsDestroy("Rocket");
                    }
                }
                
                //e.view.gameObject.transform.DOMove(new Vector3(posX + widthBoard, posY, 0f), 0.5f);
                
                GameController.Instance.StartCoroutine(DelayBeforDeleteRocket(0));
                //e.AddTypeMechanicsDestroy("Rocket");
            }
            IEnumerator DelayBeforDeleteRocket(float time)
            {
                yield return  new WaitForSeconds(time);
                e.AddTypeMechanicsDestroy("Rocket");
            }
            
        }
        
    }

    
}