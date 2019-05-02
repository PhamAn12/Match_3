
// Add all together
public class BoardSystems : Feature
{
    public BoardSystems (GameContext Game)
    {
        Add(new CreateBoardSystem(Game));
        Add(new AddViewSystem(Game));
        Add(new SetViewPositionSystem(Game));
    //    Add(new InputSystem(Game));
    //    Add(new RenderSpriteSystems(Game));
        
    }
}