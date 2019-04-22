public class BoardSystems : Feature
{
    public BoardSystems (GameContext Game)
    {
        Add(new CreateBoardSystem(Game));
    }
}