
// Add all together



public class BoardSystems : Feature
{
    public BoardSystems ( GameContext Game)
    {       
        Add(new CreateBoardSystem(Game));
        
        Add(new FallSystem(Game));
        //Add(new FillSystem(Game));
        Add(new GameStateSystems(Game));
        Add(new ScoreSystem(Game));
        Add(new ViewSystem(Game));
//        Add(new AddViewSystem(Game));    
//        Add(new SetViewPositionSystem(Game));
//        Add(new CheckDeleteSystem(Game));
//        Add(new RemoveViewSystem(Game)); 
//        Add(new AnimatePositionSystem(Game));

    }
}