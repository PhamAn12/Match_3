using Entitas;
using System.Collections.Generic;

public class CreateBoardSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    public CreateBoardSystem(GameContext Game) : base(Game)
    {
        _context = Game;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        throw new System.NotImplementedException();
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BoadGameElement.Removed());
    }
}