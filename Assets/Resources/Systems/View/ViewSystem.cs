

public class ViewSystem : Feature
{
    public ViewSystem(GameContext gameContext)   
    {
        
        Add(new AddViewSystem(gameContext));
        Add(new SetViewPositionSystem(gameContext));
        Add(new CheckDeleteSystem(gameContext));
        Add(new MechanicsSystem(gameContext));
        
        Add(new AnimatePositionSystem(gameContext));
        
        //Add(new RocketSystem(gameContext));
        
        
        Add(new RemoveViewSystem(gameContext));
        Add(new CheckDieSystem(gameContext));        
        Add(new DestroyEntitySystem(gameContext));
        Add(new DestroyBoardGameSystem(gameContext));
    }
}
