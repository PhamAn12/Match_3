

public class ViewSystem : Feature
{
    public ViewSystem(GameContext gameContext)
    {
        Add(new AddViewSystem(gameContext));
        Add(new SetViewPositionSystem(gameContext));
        Add(new CheckDeleteSystem(gameContext));
        Add(new AnimatePositionSystem(gameContext));
        Add(new RemoveViewSystem(gameContext));        
        Add(new DestroyEntitySystem(gameContext));
        Add(new DestroyBoardGameSystem(gameContext));
        //Add(new CheckDeleteSystem(gameContext));
    }
}
