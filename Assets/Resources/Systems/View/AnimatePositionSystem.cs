using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class AnimatePositionSystem : ReactiveSystem<GameEntity> {

    readonly GameContext _context;

    public AnimatePositionSystem(GameContext Game) : base(Game) {
        _context = Game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
        return context.CreateCollector(GameMatcher.Position);
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasView && entity.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities) {
        foreach (var e in entities)
        {
            Debug.Log("BCA" + e.position.value.x);
            var pos = e.position;
            var isTopRow = pos.value.y == _context.CreateGameBoard().boadGame.row - 1.5f;
            if (isTopRow) {
                e.view.gameObject.transform.localPosition = new Vector3(pos.value.x, pos.value.y + 1.5f);
            }
            e.view.gameObject.transform.DOMove(new Vector3(pos.value.x, pos.value.y, 0f), 0.3f);
        }
    }
}