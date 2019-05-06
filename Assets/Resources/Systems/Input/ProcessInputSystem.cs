using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ProcessInputSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext _context;
    public ProcessInputSystem(InputContext Input, GameContext Game) : base(Input)
    {
        _context = Game;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Input);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasInput;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var inputEntity = entities.SingleEntity();
        var input = inputEntity.input;
        Debug.Log("INPUT" + input + "INPUT ENTITY" + inputEntity);

        Debug.Log("position of input entity :" + input.x + "  " + input.y);
        foreach (var e in _context.GetEntitiesWithPosition(new Vector2(input.x,input.y)))
        {
            
            Debug.Log("list: " + e.ToString());
            Debug.Log("position of game entity :" + e.position.value.x + "  " + e.position.value.y);
            e.isTabbed = true;
        //    e.isDestroyed = true;

        }
    }

    
}